using CognizantQLESS.Core.Constants;
using CognizantQLESS.Core.Models.ViewModels;
using CognizantQLESS.DAL;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CognizantQLESS.Site.Services
{
    public class CacheSeeder
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _context;

        public CacheSeeder(IMemoryCache memoryCache, ApplicationDbContext applicationDbContext)
        {
            _memoryCache = memoryCache;
            _context = applicationDbContext;
        }
        
        public void Initialize()
        {
            Seed_Cache_Fares(null);
            Seed_Cache_StationLines(null);
            Seed_Cache_Stations(null);
        }

        public void Seed_Cache_StationLines(List<StationLineViewModel> stationLines)
        {
            if (stationLines == null)
            {
                stationLines = _context.StationLines.Select(s => new StationLineViewModel
                {
                    StationLineId = s.StationLineId,
                    Name = s.Name
                }).ToList();
            }

            _memoryCache.Set(Constants.CACHE_STATIONLINES, stationLines);
        }

        public void Seed_Cache_Stations(List<StationViewModel> stations)
        {
            if (stations == null)
            {
                stations = _context.Stations.Select(s => new StationViewModel
                {
                    StationId = s.StationId,
                    StationLineId = s.StationLineId,
                    Name = s.Name,
                    Order = s.Order
                }).OrderBy(s => s.Order).ToList();
            }
            
            _memoryCache.Set(Constants.CACHE_STATIONS, stations);
        }

        public void Seed_Cache_Fares(List<FareCacheViewModel> fares)
        {
            if (fares == null)
            {
                fares = _context.Fares.Select(f => new FareCacheViewModel
                {
                    OriginStationId = f.OriginStationId,
                    DestinationStationId = f.DestinationStationId,
                    Rate = f.Rate
                }).ToList();
            }
            
            _memoryCache.Set(Constants.CACHE_FARES, fares);
        }
    }
}
