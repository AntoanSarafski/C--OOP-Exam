using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> vehicles;

        public void AddModel(IVehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public bool RemoveById(string identifier)
        {
            IVehicle vehicleForRemoving = vehicles.FirstOrDefault(u => u.LicensePlateNumber == identifier);

            if (vehicleForRemoving == null)
            {
                return false;
            }
            else
            {
                vehicles.Remove(vehicleForRemoving);
                return true;
            }
        }

        public IVehicle FindById(string identifier)
        {
            if (vehicles.FirstOrDefault(u => u.LicensePlateNumber == identifier) != null)
            {
                return vehicles.First(u => u.LicensePlateNumber == identifier);
            }
            else
            {
                return null;
            }
        }

        IReadOnlyCollection<IVehicle> IRepository<IVehicle>.GetAll() => vehicles.AsReadOnly();
    }
}
