using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Domain.Models.CowAggregate
{
    public class Cowshed
    {
        public long Id { get; private set; }
        public short NumberOfPlaces { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBuild { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Cow> CowsList { get; set; }
        private long UserId;
    }
}
