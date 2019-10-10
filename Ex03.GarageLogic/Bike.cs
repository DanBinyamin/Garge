using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Bike : Vehicle
    {
        protected eTypeLicense m_LicenseType;
        protected int m_VolumeEngine;

        internal Bike(string i_LicenseId, string i_NameOfModel)
            : base(i_LicenseId, i_NameOfModel)
        {
            IntalizingWheels(2, 33);
            m_VehicleInfo = new VehicleInfo();
        }
        
        public eTypeLicense License
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public int VolumeEngine
        {
            get
            {
                return m_VolumeEngine;
            }

            set
            {
                m_VolumeEngine = value;
            }
        }

        public override VehicleInfo GetInfoToInput()
        {
            m_VehicleInfo.Data.Add("Volume Engine :");
            m_VehicleInfo.Data.Add("License Type (A1,A2,A,B) :");
            m_VehicleInfo.Data.Add("Wheel Manfactuer :");
            m_VehicleInfo.Data.Add("Wheel Curennt Psi :");

            return m_VehicleInfo;
        }

        public override void SetInfoToVehicle()
        {
            m_VolumeEngine = int.Parse(m_VehicleInfo.Input[0]);
            m_LicenseType = (eTypeLicense)Enum.Parse(typeof(eTypeLicense), m_VehicleInfo.Input[1]);
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("License Type : {0}{1}", m_LicenseType, Environment.NewLine));
            vehicleInfo.Append(string.Format("Volume Engine : {0}{1}", m_VolumeEngine, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
