using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        internal ElectricCar(string i_LicenseId, string i_NameOfModel, float i_EnergyPrecent)
            : base(i_LicenseId, i_NameOfModel)
        {
            float currentCapcaity = i_EnergyPrecent * 1.8f / 100f;
            m_EnergySystem = new ElectricEnergySystem(1.8f, currentCapcaity);
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
