using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricBike : Bike
    {
        internal ElectricBike(string i_LicenseId, string i_NameOfModel, float i_EnergyPrecent)
            : base(i_LicenseId, i_NameOfModel)
        {
            float currentCapcity = i_EnergyPrecent * 1.4f / 100f;
            m_EnergySystem = new ElectricEnergySystem(1.4f, currentCapcity);
            m_VehicleInfo = new VehicleInfo();
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Electric Energy System {0}", Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
