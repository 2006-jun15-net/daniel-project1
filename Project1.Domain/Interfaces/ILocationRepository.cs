using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain
{
    public interface ILocationRepository
    {
        /// <summary>
        /// Get all Locations
        /// </summary>
        /// <returns>The collection of Locations</returns>
        IEnumerable<Location> GetAll();

        /// <summary>
        /// Get a Location by ID
        /// </summary>
        /// <param name="id">Location ID</param>
        /// <returns>The Location</returns>
        Location GetLocationByID(int id);
 
        void Create(Location location);

        void Update(Location location);
    }
}
