using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Customer> r_Customers;

        public Garage()
        {
            r_Customers = new Dictionary<string, Customer>();
        }

        public void AddCustomer(Vehicle i_Vehicle, string i_Name, string i_PhoneNumber)
        {
            if(r_Customers.ContainsKey(i_Vehicle.LicenseID))
            {
                throw new ArgumentException("The Vehicle  already exists");
            }
            else
            {
                r_Customers.Add(i_Vehicle.LicenseID, new Customer(i_Name, i_PhoneNumber, i_Vehicle));
            }
        }

        public List<string> GetListVehiclsStatus()
        {
            return new List<string>(r_Customers.Keys);
        }

        public List<string> GetListVehiclsStatus(eStatusVehicle i_StatusVehicles)
        {
            List<string> listVehicles = new List<string>();

            foreach(Customer customer in r_Customers.Values)
            {
                if (customer.Status == i_StatusVehicles) 
                {
                    listVehicles.Add(customer.Vehicle.LicenseID);
                }
            }

            return listVehicles;
        }

        public void ChangeStatusVehicles(string i_LicenseID, eStatusVehicle i_StatusVehicle)
        {
             Customer customers = TryToGetCustomer(i_LicenseID);
             customers.Status = i_StatusVehicle;
        }

        public void FillAirToMaxPsi(string i_LicenseNum)
        {
            Customer customer = TryToGetCustomer(i_LicenseNum);

            foreach(Wheel wheel in customer.Vehicle.Wheels)
            {
                wheel.FillAirPressure(wheel.MaxPsi - wheel.CurrentPsi);
            }
        }

        public void FillRegularVehicle(string i_LicenseId, eTypeFuel i_FuelType, float i_AmountToFill)
        {
            Customer customer = TryToGetCustomer(i_LicenseId);
            FuelEnergySystem fuelEnergy = customer.Vehicle.EnergySystem as FuelEnergySystem;

            if(fuelEnergy != null)
            {
                fuelEnergy.FillFuel(i_AmountToFill, i_FuelType);
            }
            else
            {
                throw new FormatException("The Object doesn't have fuel system");
            }
        }

        public void ChargeElectricVehicle(string i_LicenseNum, int i_AmountMinToCharge)
        {
            float realNumberInHour = i_AmountMinToCharge / 60f;
            Customer customer = TryToGetCustomer(i_LicenseNum);
            ElectricEnergySystem electricEnergySystem = customer.Vehicle.EnergySystem as ElectricEnergySystem;

            if (electricEnergySystem != null)
            {
                electricEnergySystem.ChargeBattery(realNumberInHour);
            }
            else
            {
                throw new FormatException("The Object doesn't have Electric system");
            }
        }

        public Customer TryToGetCustomer(string i_LicenseID)
        {
            Customer o_Customer;
            bool isExists = r_Customers.TryGetValue(i_LicenseID, out o_Customer);
            if (isExists)
            {
                return o_Customer;
            }
            else
            {
                throw new ArgumentException("The license Number isn't exists");
            }
        }
    }
}
