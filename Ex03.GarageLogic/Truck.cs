using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_DangerousCapcity = false;
        private float m_VolumeBaggage;

        internal Truck(string i_LicenseId, string i_NameOfModel, float i_EnergyPrecent)
            : base(i_LicenseId, i_NameOfModel)
        {
            float currentEnergy = i_EnergyPrecent * 110f / 100f;

            IntalizingWheels(12, 26);
            m_EnergySystem = new FuelEnergySystem(eTypeFuel.Soler, 110f, currentEnergy);
            m_VehicleInfo = new VehicleInfo();
        }

        public override VehicleInfo GetInfoToInput()
        {
            m_VehicleInfo.Data.Add("Dangerous Capcity (true | false)");
            m_VehicleInfo.Data.Add("Volume Baggage");
            m_VehicleInfo.Data.Add("Wheel Manfactuer :");
            m_VehicleInfo.Data.Add("Wheel Curennt Psi :");
            return m_VehicleInfo;
        }

        public override void SetInfoToVehicle()
        {
            m_DangerousCapcity = bool.Parse(m_VehicleInfo.Input[0]);
            m_VolumeBaggage = int.Parse(m_VehicleInfo.Input[1]);
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Fuel Energy System {0}", Environment.NewLine));
            vehicleInfo.Append(string.Format("Danderous capcity : {0}{1}", m_DangerousCapcity, Environment.NewLine));
            vehicleInfo.Append(string.Format("volume of Baggage : {0}{1}", m_VolumeBaggage, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
