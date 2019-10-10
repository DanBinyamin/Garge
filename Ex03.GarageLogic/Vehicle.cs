using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_NameOfModel = string.Empty;
        private readonly string r_LicenseId = string.Empty;
        protected EnergySystem m_EnergySystem = null;
        protected List<Wheel> m_Wheels = null;
        protected VehicleInfo m_VehicleInfo;

        internal Vehicle(string i_LicenseId, string i_NameOfModel)
        {
            r_LicenseId = i_LicenseId;
            r_NameOfModel = i_NameOfModel;
            m_Wheels = new List<Wheel>();
        }

        public override bool Equals(object obj)
        {
            bool toCompare = false;
            Vehicle vehicleToCompare = obj as Vehicle;

            if (vehicleToCompare != null) 
            {
                toCompare = vehicleToCompare.r_LicenseId == this.r_LicenseId;
            }

            return toCompare;
        }

        public EnergySystem EnergySystem
        {
            get
            {
                return m_EnergySystem;
            }
        }

        protected void IntalizingWheels(int i_CountOfWheels, int i_MaxPressuer)
        {
            for (int i = 0; i < i_CountOfWheels; i++) 
            {
                m_Wheels.Add(new Wheel(i_MaxPressuer));
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public bool CheckLicense(string i_LicenseToCheck)
        {
            return r_LicenseId == i_LicenseToCheck;
        }

        public override int GetHashCode()
        {
            return r_LicenseId.GetHashCode();
        }

        public string LicenseID
        {
            get
            {
                return r_LicenseId;
            }
        }

        public abstract VehicleInfo GetInfoToInput();

        public abstract void SetInfoToVehicle();

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            int currentIndex = 1;

            vehicleInfo.Append(string.Format("License number: {0}{1}", r_LicenseId, Environment.NewLine));
            vehicleInfo.Append(string.Format("Model name: {0}{1}", r_NameOfModel, Environment.NewLine));
            vehicleInfo.Append(string.Format("{0}{1}", m_EnergySystem.ToString(), Environment.NewLine));
            vehicleInfo.Append(string.Format("Wheels: {0}", Environment.NewLine));
            foreach (Wheel currentWheel in m_Wheels)
            {
                vehicleInfo.Append(string.Format("wheel {0}: {1}{2}", currentIndex, currentWheel.ToString(), Environment.NewLine));
                currentIndex++;
            }

            return vehicleInfo.ToString();
        }
    }
}
