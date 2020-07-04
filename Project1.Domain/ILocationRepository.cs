using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAll();

        void Create(Location location);

        void Update(Location location);
    }
}
