﻿using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public interface ILocationRepository
    {
        public void InsertLocation(Location loc);
        public Location GetLocationByName(string name);
        public List<Location> GetAllLocations();
        public void UpdateLocation(Location loc);
        public void DeleteLocation(long loc);
    }
}
