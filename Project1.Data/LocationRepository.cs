using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Project01Context _context;

        public LocationRepository(Project01Context context)
        {
            _context = context;
        }

        public void Create(Location location)
        {
            var Entity = new LocationEntity { LocationId = location.LocationId, Name = location.Name, Address = location.Address };

            _context.LocationEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
