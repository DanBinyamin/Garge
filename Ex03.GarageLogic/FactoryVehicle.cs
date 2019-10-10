using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FactoryVehicle
    {
        private readonly List<string> r_AllVehicles;

        public FactoryVehicle()
        {
            r_AllVehicles = new List<string>();
            r_AllVehicles.Add("Fuel Bike");
            r_AllVehicles.Add("Electric Bike");
            r_AllVehicles.Add("Fuel Car");
            r_AllVehicles.Add("Electric Car");
            r_AllVehicles.Add("Truck");
        }

        public List<string> GetListOfVehicles()
        {
            return r_AllVehicles;
        }

        public Vehicle GetVehicle(string i_VehicleType, string i_LicenseId, string i_NameOfModel, float i_EnergyPrecent)
        {
            Vehicle vehicle = null;

            if (i_VehicleType.Equals("Fuel Bike"))
            {
                vehicle = new FuelBike(i_LicenseId, i_NameOfModel, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Electric Bike"))
            {
                vehicle = new ElectricBike(i_LicenseId, i_NameOfModel, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Fuel Car"))
            {
                vehicle = new FuelCar(i_LicenseId, i_NameOfModel, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Electric Car"))
            {
                vehicle = new ElectricCar(i_LicenseId, i_NameOfModel, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Truck"))
            {
                vehicle = new Truck(i_LicenseId, i_NameOfModel, i_EnergyPrecent);
            }
            else
            {
                throw new FormatException("The Vheicle type doen't exist");
            }

            return vehicle;
        }          
    }
}
