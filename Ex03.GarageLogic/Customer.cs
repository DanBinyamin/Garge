using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Customer
    {
        private string m_CustomerName = string.Empty;
        private string m_CustomerPhoneNumber = string.Empty;
        private eStatusVehicle m_StatusVehicle;
        private Vehicle m_Vehicle;

        public Customer(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            this.m_CustomerName = i_Name;
            this.m_CustomerPhoneNumber = i_PhoneNumber;
            this.m_StatusVehicle = eStatusVehicle.InProgress;
            this.m_Vehicle = i_Vehicle;
        }

        public string Name
        {
            get
            {
                return m_CustomerName;
            }

            set
            {
                m_CustomerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_CustomerPhoneNumber;
            }

            set
            {
                m_CustomerPhoneNumber = value;
            }
        }

        public eStatusVehicle Status
        {
            get
            {
                return m_StatusVehicle;
            }

            set
            {
                m_StatusVehicle = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public override int GetHashCode()
        {
            return m_CustomerPhoneNumber.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", m_Vehicle.ToString()));
            vehicleInfo.Append(string.Format("Name : {0}{1}", m_CustomerName, Environment.NewLine));
            vehicleInfo.Append(string.Format("Phone Number : {0}{1}", m_CustomerPhoneNumber, Environment.NewLine));
            vehicleInfo.Append(string.Format("Status Of the car : {0}{1}", m_StatusVehicle, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
