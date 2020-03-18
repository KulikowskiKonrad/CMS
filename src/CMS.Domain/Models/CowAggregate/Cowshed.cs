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
        public long UserId { get; private set; }
        public IReadOnlyCollection<Cow> Cows => _Cows.AsReadOnly();

        private List<Cow> _Cows;

        private Cowshed()
        {

        }
        public Cowshed(short numberOfPlaces, string name, DateTime dateOfBiuld)
        {
            NumberOfPlaces = numberOfPlaces;
            Name = name;
            DateOfBuild = dateOfBiuld;

        }

    }
}
