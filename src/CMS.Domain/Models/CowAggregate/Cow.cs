using CMS.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace CMS.Domain.Models.CowAggregate
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
        public IReadOnlyCollection<Milking> Milkings => _Milkings.AsReadOnly();
        public IReadOnlyCollection<Disease> Diseases => _Diseases.AsReadOnly();
        public IReadOnlyCollection<Pregnancy> Pregnancies => _Pregnancies.AsReadOnly();
        public IReadOnlyCollection<Insemination> InseminationsAsMother => _InseminationsAsMother.AsReadOnly();
        public IReadOnlyCollection<Insemination> InseminationsAsFather => _InseminationsAsFather.AsReadOnly();
        public Cowshed Cowshed { get; private set; }
        public Gender Gender { get; private set; }
        public long CowshedId { get; private set; }
        public long? MotherId { get; private set; }
        public long? FatherId { get; private set; }

        private List<Milking> _Milkings;
        private List<Disease> _Diseases;
        private List<Pregnancy> _Pregnancies;
        private List<Insemination> _InseminationsAsMother;
        private List<Insemination> _InseminationsAsFather;

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

        public void AddMilking(DateTime milkingDate, short volume)
        {
            if (_Milkings == null)
            {
                throw new Exception($"Property {nameof(_Milkings)} is not initialized.");
            }
            _Milkings.Add(new Milking(milkingDate, volume));
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
