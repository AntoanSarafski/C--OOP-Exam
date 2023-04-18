using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }


        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.FindById(drivingLicenseNumber) == null)
            {
                IUser user = new User(firstName, lastName, drivingLicenseNumber);
                users.AddModel(user);
                return String.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
            }
            else
            {
                return String.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
        }


        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if(vehicleType != "CargoVan" && vehicleType != "PassengerCar")
            {
                return String.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            if(vehicles.FindById(licensePlateNumber) != null)
            {
                return String.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            else
            {
                if(vehicleType == "CargoVan")
                {
                    IVehicle vehicle = new CargoVan(brand,model,licensePlateNumber);
                    vehicles.AddModel(vehicle);
                    return String.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
                }
                else
                {
                    IVehicle vehicle = new PassengerCar(brand, model, licensePlateNumber);
                    vehicles.AddModel(vehicle);
                    return String.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
                    
                }
            }

        }



        public string AllowRoute(string startPoint, string endPoint, double length)
        {

            if (routes.GetAll()
                .Contains(routes.GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length)))
            {
                return String.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }    

            if(routes.GetAll()
                .Contains(routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length)))
            {
                return String.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }
            IRoute route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            routes.AddModel(route);

            if (routes.GetAll().Contains(routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length)))
            {
                routes.GetAll().First(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length).LockRoute();
            }
            return String.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);

        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            throw new NotImplementedException();
        }


        public string RepairVehicles(int count)
        {
            throw new NotImplementedException();
        }


        public string UsersReport()
        {
            throw new NotImplementedException();
        }
    }
}
