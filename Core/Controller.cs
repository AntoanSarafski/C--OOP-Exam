﻿using EDriveRent.Core.Contracts;
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
            if(vehicleType != "CargoVan" && vehicleType != "PassangerCar")
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
            throw new NotImplementedException();
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
