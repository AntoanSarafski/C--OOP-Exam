using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        private const double _maxMileage = 180;

        public CargoVan(string brand, string model, string licensePlateNumber) 
            : base(brand, model, _maxMileage, licensePlateNumber)
        {
        }

        public override void Drive(double mileage)
        {
            BatteryLevel = (int)Math.Round(BatteryLevel * ((mileage / MaxMileage) + 0.05));
        }
    }
}
