using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        internal FuelCar(string i_LicenseId, string i_NameOfModel, float i_EnergyPrecent)
            : base(i_LicenseId, i_NameOfModel)
        {
            float currentCapcity = i_EnergyPrecent * 55f / 100f;
            m_EnergySystem = new FuelEnergySystem(eTypeFuel.Octan96, 55f, currentCapcity);
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Fuel Energy System {0}", Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
