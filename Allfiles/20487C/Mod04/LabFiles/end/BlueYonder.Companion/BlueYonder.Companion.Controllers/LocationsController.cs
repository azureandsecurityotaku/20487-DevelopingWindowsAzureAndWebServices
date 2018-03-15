﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BlueYonder.DataAccess.Interfaces;
using BlueYonder.Entities;
using System.Linq;
using BlueYonder.Companion.Controllers.DataTransferObjects;
using BlueYonder.Companion.Entities.Mappers;
using BlueYonder.Companion.Entities;
using BlueYonder.DataAccess.Repositories;
using System.Web.Http;

namespace BlueYonder.Companion.Controllers
{
    public class LocationsController : ApiController
    {
        public ILocationRepository Locations { get; set; }

        public LocationsController(ILocationRepository locations)
        {
            Locations = locations;
        }

        public IEnumerable<LocationDTO> Get()
        {
            return Locations.GetAll().ToList().Select(x => x.ToLocationDTO()).ToList();
        }

        public IEnumerable<LocationDTO> Get(string source)
        {
            return Locations.GetAll().Where(x => x.City == source).ToList().Select(x => x.ToLocationDTO()).ToList();
        }

        public LocationDTO Get(int id)
        {
            var location = Locations.GetSingle(id);

            return location.ToLocationDTO();
        }

        protected override void Dispose(bool disposing)
        {
            Locations.Dispose();
            base.Dispose(disposing);
        }
    }
}