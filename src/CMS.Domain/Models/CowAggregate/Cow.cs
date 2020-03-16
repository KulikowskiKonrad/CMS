using CMS.Domain.Models.CowAggregate;
using CMS.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace CMS.Domain.Models
{
    public class Cow : Entity
    {
        public string EarningNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public CowStatus Status { get; private set; }
        public double? Weight { get; private set; }
        public double? SoldPrice { get; private set; }
        public double? BoughtPrice { get; private set; }
        public DateTime? DateOfSold { get; private set; }
        public DateTime? DateOfDeath { get; private set; }
        public CowType Type { get; private set; }
        public string PassportNumber { get; private set; }
        public Cow Mother { get; private set; }
        public Cow Father { get; private set; }
        public string PseudoName { get; private set; }
        public bool InPregnant { get; private set; }
        public List<Milking> Milkings { get; private set; }
        public List<Disease> Diseases { get; private set; }
        public List<Pregnancy> Pregnancies { get; private set; }
        public List<Insemination> Inseminations { get; private set; }
        public Contractor Contractor { get; private set; }
        public Cowshed Cowshed { get; private set; }
        public Gender Gender { get; private set; }

        private long CowshedId;
        private long ContractorId;
        private long? MotherId;
        private long? FatherId;

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
