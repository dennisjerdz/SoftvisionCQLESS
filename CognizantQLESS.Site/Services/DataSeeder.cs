using CognizantQLESS.Core;
using CognizantQLESS.Core.Constants;
using CognizantQLESS.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CognizantQLESS.DAL;
using CognizantQLESS.Core.Models.ViewModels;

namespace CognizantQLESS.Site.Services
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Initialize()
        {
            Seed_Roles();
            Seed_Users();
            Seed_StationLines();
            Seed_Stations();
            Seed_Fares();
            Seed_TransportCards();
            Seed_Travels();
        }

        private void Seed_Roles()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == Constants.ROLE_ADMIN))
            {
                _context.Roles.Add(new IdentityRole { Name = Constants.ROLE_ADMIN, NormalizedName = Constants.ROLE_ADMIN });
            }

            if (!_context.Roles.Any(r => r.Name == Constants.ROLE_MEMBER))
            {
                _context.Roles.Add(new IdentityRole { Name = Constants.ROLE_MEMBER, NormalizedName = Constants.ROLE_MEMBER });
            }

            _context.SaveChanges();
        }

        private void Seed_Users()
        {
            var findAdmin = _userManager.FindByEmailAsync("admin@mail.com").Result;

            if (_userManager.FindByEmailAsync("admin@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@mail.com",
                    Email = "admin@mail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    EmailConfirmed = true
                };

                IdentityResult result = _userManager.CreateAsync(user, "Test@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, Constants.ROLE_ADMIN).Wait();
                }
            }

            _context.SaveChanges();
        }

        private void Seed_StationLines()
        {
            List<StationLine> stationLines = new List<StationLine>()
            {
                new StationLine { Name = "MRT Line 1" },
                new StationLine { Name = "MRT Line 2" }
            };

            foreach(var item in stationLines)
            {
                if (!_context.StationLines.Any(s=>s.Name == item.Name))
                {
                    _context.StationLines.Add(item);
                }
            }

            _context.SaveChanges();
        }

        private void Seed_Stations()
        {
            var allStations = _context.Stations.Select(s=>s.Name).ToList();

            var mrtLine1 = _context.StationLines.FirstOrDefault(m => m.Name == "MRT Line 1");

            if (mrtLine1 != null)
            {
                List<Station> stations1 = new List<Station>()
                {
                    new Station { Name = Constants.STATION_BACLARAN, Order = 1, StationLineId = mrtLine1.StationLineId },
                    new Station { Name = Constants.STATION_EDSA, Order = 2, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_LIBERTAD, Order = 3, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_GILPUYAT, Order = 4, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_VITOCRUZ, Order = 5, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_QUIRINO, Order = 6, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_PEDROGIL, Order = 7, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_UNAVENUE, Order = 8, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_CENTRAL, Order = 9, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_CARRIEDO, Order = 10, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_DOROTEOJ, Order = 11, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_BAMBANG, Order = 12, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_TAYUMAN, Order = 13, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_BLUMENTRITT, Order = 14, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_ABADSANTOS, Order = 15, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_RPAPA, Order = 16, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_5THAVENUE, Order = 17, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_MONUMENTO, Order = 18, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_BALINTAWAK, Order = 19, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = Constants.STATION_ROOSEVELT, Order = 20, StationLineId = mrtLine1.StationLineId  }
                };

                foreach (var item in stations1)
                {
                    if (!allStations.Any(s => s == item.Name))
                    {
                        _context.Stations.Add(item);
                    }
                }
            }

            //

            var mrtLine2 = _context.StationLines.FirstOrDefault(m => m.Name == "MRT Line 2");

            if (mrtLine2 != null)
            {
                List<Station> stations2 = new List<Station>()
                {
                    new Station { Name = Constants.STATION_RECTO, Order = 1, StationLineId = mrtLine2.StationLineId },
                    new Station { Name = Constants.STATION_LEGARDA, Order = 2, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_PUREZA, Order = 3, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_VMAPA, Order = 4, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_JRUIZ, Order = 5, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_GILMORE, Order = 6, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_BETTYGO, Order = 7, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_CUBAO, Order = 8, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_ANONAS, Order = 9, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_KATIPUNAN, Order = 10, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = Constants.STATION_SANTOLAN, Order = 11, StationLineId = mrtLine2.StationLineId  }
                };

                foreach (var item in stations2)
                {
                    if (!allStations.Any(s => s == item.Name))
                    {
                        _context.Stations.Add(item);
                    }
                }
            }

            _context.SaveChanges();
        }

        private void Seed_Fares()
        {
            if (_context.Fares.Count() == 0)
            {
                var effectiveDate = DateTime.Now.AddYears(-5);
                List<StationSeedViewModel> stations = _context.Stations.Select(s => new StationSeedViewModel { Name = s.Name, StationId = s.StationId }).ToList();

                List<Fare> faresL1 = new List<Fare>() { 
                    // baclaran
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },
                
                    // edsa
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },

                    // Libertad
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 28
                    },

                    // Gil Puyat
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },

                    // Vito Cruz
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },

                    // Quirino
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },

                    // Pedro Gil
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },

                    // U.N. Avenue
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },

                    // Central Terminal
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },

                    // Carriedo
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },

                    // Doroteo Jose
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },

                    // Bambang
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },

                    // Tayuman
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },

                    // Blumentritt
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },

                    // Abad Santos
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },

                    // R. Papa
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },

                    // 5th Avenue
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },

                    // Monumento
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },

                    // Balintawak
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },

                    // Roosevelt
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BACLARAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_EDSA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LIBERTAD).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 28
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILPUYAT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VITOCRUZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_QUIRINO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PEDROGIL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_UNAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CENTRAL).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CARRIEDO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_DOROTEOJ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BAMBANG).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_TAYUMAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BLUMENTRITT).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ABADSANTOS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RPAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_5THAVENUE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_MONUMENTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ROOSEVELT).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BALINTAWAK).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    }
                };

                List<Fare> faresL2 = new List<Fare>()
                {
                    // Recto
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },

                    // Legarda
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },

                    // Pureza
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },

                    // V. Mapa
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },

                    // J. RUIZ
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },

                    // Gilmore
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },

                    // Betty-Go
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },

                    // Cubao
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },

                    // Anonas
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },

                    // Katipunan
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },

                    // Santolan
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_RECTO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_LEGARDA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_PUREZA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_VMAPA).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_JRUIZ).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_GILMORE).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_BETTYGO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_CUBAO).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_ANONAS).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_SANTOLAN).StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == Constants.STATION_KATIPUNAN).StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    }
                };

                _context.Fares.AddRange(faresL1);
                _context.Fares.AddRange(faresL2);
                _context.SaveChanges();
            }
        }

        private void Seed_TransportCards()
        {
            if (_context.TransportCards.Count() == 0)
            {
                List<TransportCard> transportCards = new List<TransportCard>() {
                // expired unregistered
                new TransportCard {
                    SerialNumber = "T001",
                    LastUsedDate = DateTime.Now.AddYears(-6),
                    PurchaseDate = DateTime.Now.AddYears(-5),
                    Load = 100
                },

                // purchased 5 months ago, unregistered
                new TransportCard {
                    SerialNumber = "T002",
                    LastUsedDate = null,
                    PurchaseDate = DateTime.Now.AddMonths(-5),
                    Load = 100
                },

                // registered, no travels today
                new TransportCard {
                    SerialNumber = "T003",
                    LastUsedDate = null,
                    SeniorCitizenControlNumber = "1234567890",
                    DiscountRegistrationDate = DateTime.Now,
                    PurchaseDate = DateTime.Now,
                    Load = 100
                },

                // registered, 2 travels today
                new TransportCard {
                    SerialNumber = "T004",
                    LastUsedDate = null,
                    SeniorCitizenControlNumber = "1234567890",
                    DiscountRegistrationDate = DateTime.Now,
                    PurchaseDate = DateTime.Now,
                    Load = 100
                },

                // registered, 4 travels today
                new TransportCard {
                    SerialNumber = "T005",
                    LastUsedDate = null,
                    SeniorCitizenControlNumber = "1234567891",
                    DiscountRegistrationDate = DateTime.Now,
                    PurchaseDate = DateTime.Now,
                    Load = 100
                },

                // completely new
                new TransportCard {
                    SerialNumber = "T006",
                    LastUsedDate = null,
                    PurchaseDate = DateTime.Now,
                    Load = 100
                },
            };

                _context.TransportCards.AddRange(transportCards);
                _context.SaveChanges();
            }

        }

        private void Seed_Travels()
        {
            var station = _context.Stations.FirstOrDefault();
            var travelsCount = _context.Travels.Count();
            var travelsToday2 = _context.TransportCards.FirstOrDefault(t => t.SerialNumber == "T004");
            var travelsToday4 = _context.TransportCards.FirstOrDefault(t => t.SerialNumber == "T005");

            if (station != null && travelsCount == 0)
            {
                if (travelsToday2 != null)
                {
                    _context.Travels.AddRange(
                        new Travel
                        {
                            TransportCardId = travelsToday2.TransportCardId,
                            TravelDate = DateTime.Now,
                            OriginStationId = station.StationId,
                            DestinationStationId = station.StationId
                        },
                        new Travel
                        {
                            TransportCardId = travelsToday2.TransportCardId,
                            TravelDate = DateTime.Now,
                            OriginStationId = station.StationId,
                            DestinationStationId = station.StationId
                        }
                    );
                }

                if (travelsToday4 != null)
                {
                    _context.Travels.AddRange(
                        new Travel
                        {
                            TransportCardId = travelsToday4.TransportCardId,
                            TravelDate = DateTime.Now,
                            OriginStationId = station.StationId,
                            DestinationStationId = station.StationId
                        },
                        new Travel
                        {
                            TransportCardId = travelsToday4.TransportCardId,
                            TravelDate = DateTime.Now,
                            OriginStationId = station.StationId,
                            DestinationStationId = station.StationId
                        },
                        new Travel
                        {
                            TransportCardId = travelsToday4.TransportCardId,
                            TravelDate = DateTime.Now,
                            OriginStationId = station.StationId,
                            DestinationStationId = station.StationId
                        },
                        new Travel
                        {
                            TransportCardId = travelsToday4.TransportCardId,
                            TravelDate = DateTime.Now,
                            OriginStationId = station.StationId,
                            DestinationStationId = station.StationId
                        }
                    );
                }

                _context.SaveChanges();
            }
        }
    }
}
