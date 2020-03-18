using System;

namespace CMS.Application.Commands.Cowshed
{
    public class NewCowshedCommand
    {
        public string Name { get; set; }
        public short NumberOfPlaces { get; set; }
        public DateTime DateOfBuild { get; set; }
    }
}
