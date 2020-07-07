using Microsoft.EntityFrameworkCore;
using Project1.Data.Model;
using Project1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Project01Context _context;

        public LocationRepository(Project01Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Location location)
        {
            var Entity = new LocationEntity {Name = location.Name, Address = location.Address };

            _context.LocationEntity.Add(Entity);

            _context.SaveChanges();
        }

        public IEnumerable<Location> GetAll()
        {
            var entities = _context.LocationEntity.ToList();

            return entities.Select(e => new Location(e.LocationId, e.Name, e.Address));
        }

        public Location GetLocationByID(int id)
        {
            var location = _context.LocationEntity
                .FirstOrDefault(l => l.LocationId == id);

            return new Location(location.LocationId, location.Name, location.Address);
        }

        public void Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
