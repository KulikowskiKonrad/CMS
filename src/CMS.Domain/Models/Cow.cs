using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Domain.Models
{
    public class Cow
    {
        public long Id { get; private set; }
        public string EarningNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public CowStatus Status { get; private set; }
        public double? Weight { get; private set; }
        public double? SoldPrice { get; private set; }
        public double? BoughtPrice { get; private set; }
        public DateTime? DateOfSold { get; private set; }
        public DateTime? DateOfDeath { get; private set; }

        public Cow(string earningNumber, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(earningNumber))
            {
                throw new ArgumentException();
            }
            EarningNumber = earningNumber;

            DateOfBirth = dateOfBirth;
            Status = CowStatus.FromMyFarm;
        }

        private Cow()
        {

        }

        public void Kill(DateTime dateOfDeath)
        {
            DateOfDeath = dateOfDeath;
            Status = CowStatus.Dead;
        }

        public static Cow FromBought(double price, double weight, DateTime dateOfBirth, string earningNumber)
        {
            var cow = new Cow();

            if (string.IsNullOrEmpty(earningNumber))
            {
                throw new ArgumentException();
            }

            cow.BoughtPrice = price;
            cow.DateOfBirth = dateOfBirth;
            cow.EarningNumber = earningNumber;
            cow.Status = CowStatus.Bought;
            cow.Weight = weight;

            return cow;
        }

        public void Sell(double price, double weight, DateTime dateOfSold)
        {
            if (Status != CowStatus.FromMyFarm)
            {
                throw new Exception();
            }

            Status = CowStatus.Sold;
            SoldPrice = price;
            Weight = weight;
            DateOfSold = dateOfSold;
        }
    }
}
