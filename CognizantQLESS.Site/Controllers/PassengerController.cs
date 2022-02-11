using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CognizantQLESS.Core.Models;
using CognizantQLESS.DAL;
using CognizantQLESS.Core.Constants;
using CognizantQLESS.Core.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using CognizantQLESS.Site.Services;
using CognizantQLESS.Core.Interface;

namespace CognizantQLESS.Site.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly CacheSeeder _cacheSeeder;
        private readonly IFareCalculator _fareCalculator;

        private List<StationLineViewModel> stationLines;
        private List<StationViewModel> stations;
        private List<FareCacheViewModel> fares;

        public PassengerController(ApplicationDbContext context, IMemoryCache memoryCache, CacheSeeder cacheSeeder, IFareCalculator fareCalculator)
        {
            _context = context;
            _memoryCache = memoryCache;
            _cacheSeeder = cacheSeeder;
            _fareCalculator = fareCalculator;
        }

        public ActionResult DiscountRegistration()
        {
            if (TempData[Constants.UI_MESSAGE] != null)
            {
                ViewData[Constants.UI_MESSAGE] = JsonConvert.DeserializeObject<UIMessageViewModel>((string)TempData[Constants.UI_MESSAGE]);
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DiscountRegistration([Bind("SerialNumber,SeniorCitizenControlNumber,PWDIdNumber")] DiscountRegistrationViewModel discountRegistrationModel)
        {
            if (ModelState.IsValid)
            {
                var transportCard = await _context.TransportCards.FirstOrDefaultAsync(t => t.SerialNumber == discountRegistrationModel.SerialNumber);

                if (transportCard == null)
                {
                    ModelState.AddModelError("SerialNumber", Constants.ERR_INCORRECT_SERIALNUMBER);
                    return View(discountRegistrationModel);
                }
                else if (!transportCard.CanBeRegisteredAsDiscount)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_ALREADY_REGISTERED, transportCard.DiscountRegistrationDate?.ToString("MM/dd/yyyy"))
                    });

                    return RedirectToAction("DiscountRegistration");
                }
                else if (!transportCard.IsValid)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_CARD_EXPIRED, transportCard.ExpirationDate)
                    });
                    return RedirectToAction("DiscountRegistration");
                }

                transportCard.PWDIdNumber = discountRegistrationModel.PWDIdNumber;
                transportCard.SeniorCitizenControlNumber = discountRegistrationModel.SeniorCitizenControlNumber;
                transportCard.DiscountRegistrationDate = DateTime.Now;
                transportCard.LastUsedDate = DateTime.Now;

                try
                {
                    _context.Update(transportCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportCardExists(transportCard.TransportCardId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception e)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_GENERIC, e.Message)
                    });
                    return RedirectToAction("TopUp");
                }

                TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                {
                    IsSuccess = true,
                    Message = Constants.SUCCESS_DISCOUNTREGISTRATION
                });

                return RedirectToAction("DiscountRegistration");
            }
            return View(discountRegistrationModel);
        }

        public ActionResult TopUp()
        {
            if (TempData[Constants.UI_MESSAGE] != null)
            {
                ViewData[Constants.UI_MESSAGE] = JsonConvert.DeserializeObject<UIMessageViewModel>((string)TempData[Constants.UI_MESSAGE]);
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TopUp([Bind("SerialNumber,Amount,Cash")] LoadViewModel loadViewModel)
        {
            if (ModelState.IsValid)
            {
                TransportCard transportCard = await _context.TransportCards.FirstOrDefaultAsync(t => t.SerialNumber == loadViewModel.SerialNumber);

                if (!loadViewModel.IsValid)
                {
                    ModelState.AddModelError("Cash", Constants.ERR_INSUFFICIENT_CASH);
                    return View(loadViewModel);
                }
                else if (transportCard == null)
                {
                    ModelState.AddModelError("SerialNumber", Constants.ERR_INCORRECT_SERIALNUMBER);
                    return View(loadViewModel);
                }
                else if (!transportCard.IsValid)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_CARD_EXPIRED, transportCard.ExpirationDate)
                    });
                    return RedirectToAction("TopUp");
                }

                LoadHistory newHistory = new LoadHistory(loadViewModel, transportCard);
                transportCard.Load += loadViewModel.Amount;
                transportCard.LastUsedDate = DateTime.Now;

                try
                {
                    _context.LoadHistories.Add(newHistory);
                    _context.Update(transportCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportCardExists(transportCard.TransportCardId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception e)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_GENERIC, e.Message)
                    });
                    return RedirectToAction("TopUp");
                }

                TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel() {
                    IsSuccess = true,
                    Message = String.Format(Constants.SUCCESS_TOPUP, loadViewModel.Change, newHistory.RunningBalance)
                });

                return RedirectToAction("TopUp");
            }

            return View(loadViewModel);
        }

        public ActionResult Travel()
        {
            if (TempData[Constants.UI_MESSAGE] != null)
            {
                ViewData[Constants.UI_MESSAGE] = JsonConvert.DeserializeObject<UIMessageViewModel>((string)TempData[Constants.UI_MESSAGE]);
            }

            GetDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Travel([Bind("SerialNumber,OriginStationId,DestinationStationId")] TravelViewModel travelViewModel)
        {
            if (travelViewModel.OriginStationId == travelViewModel.DestinationStationId)
            {
                ModelState.AddModelError("OriginStationId", Constants.ERR_SAME_ORIGINDESTINATION);
                ModelState.AddModelError("DestinationStationId", Constants.ERR_SAME_ORIGINDESTINATION);
            }

            if (ModelState.IsValid)
            {
                GetFares();

                var fareModel = fares.FirstOrDefault(
                    f => f.OriginStationId == travelViewModel.OriginStationId &&
                    f.DestinationStationId == travelViewModel.DestinationStationId);

                if (fareModel == null)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_FAREMODEL_MISSING, travelViewModel.OriginStationId, travelViewModel.DestinationStationId)
                    });
                    return RedirectToAction("Travel");
                }

                TransportCard transportCard = await _context.TransportCards.FirstOrDefaultAsync(t => t.SerialNumber == travelViewModel.SerialNumber);

                if (transportCard == null)
                {
                    ModelState.AddModelError("SerialNumber", Constants.ERR_INCORRECT_SERIALNUMBER);
                    return View(travelViewModel);
                }
                else if (!transportCard.IsValid)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_CARD_EXPIRED, transportCard.ExpirationDate)
                    });
                    return RedirectToAction("Travel");
                }

                int travelsToday = _context.Travels.Where(t => 
                    t.TravelDate.Date == DateTime.Now.Date && 
                    t.TransportCardId == transportCard.TransportCardId).Count();

                float finalRate = _fareCalculator.GetRate(transportCard.IsDiscountType, travelsToday, fareModel.Rate);

                if (transportCard.Load <= finalRate)
                {
                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = false,
                        Message = String.Format(Constants.ERR_INSUFFICIENT_LOAD, transportCard.Load, finalRate)
                    });
                    return RedirectToAction("Travel");
                }
                else
                {
                    transportCard.Load = transportCard.Load - finalRate;

                    Travel newTravelHistory = new Travel() {
                        TransportCardId = transportCard.TransportCardId,
                        OriginStationId = travelViewModel.OriginStationId,
                        DestinationStationId = travelViewModel.DestinationStationId,
                        TravelDate = DateTime.Now
                    };

                    LoadHistory newLoadHistory = new LoadHistory()
                    {
                        TransportCardId = transportCard.TransportCardId,
                        Amount = finalRate,
                        Note = Constants.NOTE_TRAVEL,
                        Type = 0,
                        RunningBalance = transportCard.Load
                    };

                    try
                    {
                        _context.Travels.Add(newTravelHistory);
                        _context.LoadHistories.Add(newLoadHistory);
                        _context.Update(transportCard);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransportCardExists(transportCard.TransportCardId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    catch (Exception e)
                    {
                        TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                        {
                            IsSuccess = false,
                            Message = String.Format(Constants.ERR_GENERIC, e.Message)
                        });
                        return RedirectToAction("Travel");
                    }

                    TempData[Constants.UI_MESSAGE] = JsonConvert.SerializeObject(new UIMessageViewModel()
                    {
                        IsSuccess = true,
                        Message = String.Format(Constants.SUCCESS_TRAVEL, transportCard.Load)
                    });
                    return RedirectToAction("Travel");
                }
            }
            
            GetDropdowns();
            return View(travelViewModel);
        }

        private void GetFares()
        {
            if (!_memoryCache.TryGetValue(Constants.CACHE_FARES, out fares))
            {
                fares = _context.Fares.Select(f => new FareCacheViewModel
                {
                    OriginStationId = f.OriginStationId,
                    DestinationStationId = f.DestinationStationId,
                    Rate = f.Rate
                }).ToList();

                _cacheSeeder.Seed_Cache_Fares(fares);
            }
        }

        private void GetDropdowns()
        {
            if (!_memoryCache.TryGetValue(Constants.CACHE_STATIONLINES, out stationLines))
            {
                stationLines = _context.StationLines.Select(s => new StationLineViewModel
                {
                    StationLineId = s.StationLineId,
                    Name = s.Name
                }).ToList();

                _cacheSeeder.Seed_Cache_StationLines(stationLines);
            }

            if (!_memoryCache.TryGetValue(Constants.CACHE_STATIONS, out stations))
            {
                stations = _context.Stations.Select(s => new StationViewModel
                {
                    StationId = s.StationId,
                    StationLineId = s.StationLineId,
                    Name = s.Name,
                    Order = s.Order
                }).OrderBy(s=>s.Order).ToList();

                _cacheSeeder.Seed_Cache_Stations(stations);
            }

            ViewData[Constants.UI_DROPDOWN_STATIONLINES] = stationLines;
            ViewData[Constants.UI_DROPDOWN_STATIONS] = stations;
        }

        private bool TransportCardExists(int id)
        {
            return _context.TransportCards.Any(e => e.TransportCardId == id);
        }
    }
}
