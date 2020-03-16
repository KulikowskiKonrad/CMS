using CMS.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace CMS.Domain.Models.CowAggregate
{
    public class Cowshed : Entity
    {
        public short NumberOfPlaces { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBuild { get; private set; }
        public List<Cow> CowsList { get; set; }
        private long UserId;
    }
}
