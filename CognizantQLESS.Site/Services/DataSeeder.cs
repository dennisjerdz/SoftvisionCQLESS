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
                    new Station { Name = "Baclaran", Order = 1, StationLineId = mrtLine1.StationLineId },
                    new Station { Name = "Edsa", Order = 2, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Libertad", Order = 3, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Gil Puyat", Order = 4, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Vito Cruz", Order = 5, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Quirino", Order = 6, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Pedro Gil", Order = 7, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "U.N. Avenue", Order = 8, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Central Terminal", Order = 9, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Carriedo", Order = 10, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Doroteo Jose", Order = 11, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Bambang", Order = 12, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Tayuman", Order = 13, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Blumentritt", Order = 14, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Abad Santos", Order = 15, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "R. Papa", Order = 16, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "5th Avenue", Order = 17, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Monumento", Order = 18, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Balintawak", Order = 19, StationLineId = mrtLine1.StationLineId  },
                    new Station { Name = "Roosevelt", Order = 20, StationLineId = mrtLine1.StationLineId  }
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
                    new Station { Name = "Recto", Order = 1, StationLineId = mrtLine2.StationLineId },
                    new Station { Name = "Legarda", Order = 2, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "Pureza", Order = 3, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "V. Mapa", Order = 4, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "J. RUIZ", Order = 5, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "Gilmore", Order = 6, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "Betty-Go", Order = 7, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "Cubao", Order = 8, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "Anonas", Order = 9, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "Katipunan", Order = 10, StationLineId = mrtLine2.StationLineId  },
                    new Station { Name = "Santolan", Order = 11, StationLineId = mrtLine2.StationLineId  }
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

                List<Fare> fares = new List<Fare>() { 
                    // baclaran
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },
                
                    // edsa
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },

                    // Libertad
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 28
                    },

                    // Gil Puyat
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },

                    // Vito Cruz
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },

                    // Quirino
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },

                    // Pedro Gil
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },

                    // U.N. Avenue
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },

                    // Central Terminal
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },

                    // Carriedo
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },

                    // Doroteo Jose
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },

                    // Bambang
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },

                    // Tayuman
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },

                    // Blumentritt
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },

                    // Abad Santos
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },

                    // R. Papa
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },

                    // 5th Avenue
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },

                    // Monumento
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 14
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 12
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },

                    // Balintawak
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    },

                    // Roosevelt
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Baclaran").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Edsa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 29
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Libertad").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 28
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Gil Puyat").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 27
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Vito Cruz").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 26
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Quirino").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 25
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Pedro Gil").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 24
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "U.N. Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 23
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Central Terminal").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Carriedo").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 22
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Doroteo Jose").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 21
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Bambang").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Tayuman").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 20
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Blumentritt").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 19
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Abad Santos").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 18
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "R. Papa").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 17
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "5th Avenue").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 16
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Monumento").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 15
                    },
                    new Fare
                    {
                        OriginStationId = stations.FirstOrDefault(s=>s.Name == "Roosevelt").StationId,
                        DestinationStationId = stations.FirstOrDefault(s=>s.Name == "Balintawak").StationId,
                        EffectiveDate = effectiveDate,
                        Rate = 13
                    }
                };

                _context.Fares.AddRange(fares);
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
                    LastUsedDate = DateTime.Now.AddYears(-1),
                    PurchaseDate = DateTime.Now.AddYears(-2),
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
                    PurchaseDate = DateTime.Now.AddYears(-2),
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
