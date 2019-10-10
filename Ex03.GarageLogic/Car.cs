using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eColorOfCar m_ColorOfCar;
        protected eNumberOfDoor m_NumOfDoors;

        internal Car(string i_LicenseId, string i_NameOfModel)
            : base(i_LicenseId, i_NameOfModel)
        {
            IntalizingWheels(4, 31);
            m_VehicleInfo = new VehicleInfo();
        }

        public eColorOfCar Color
        {
            get
            {
                return m_ColorOfCar;
            }
        }

        public eNumberOfDoor NumberOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
        }

        public override VehicleInfo GetInfoToInput()
        {
            m_VehicleInfo.Data.Add("Color Car (Red,Blue,Gray,Black):");
            m_VehicleInfo.Data.Add("Number Of Door (Two,Three,Four,Five) :");
            m_VehicleInfo.Data.Add("Wheel Manfactuer :");
            m_VehicleInfo.Data.Add("Wheel Curennt Psi :");

            return m_VehicleInfo;
        }

        public override void SetInfoToVehicle()
        {
            m_ColorOfCar = (eColorOfCar)Enum.Parse(typeof(eColorOfCar), m_VehicleInfo.Input[0]);
            m_NumOfDoors = (eNumberOfDoor)Enum.Parse(typeof(eNumberOfDoor), m_VehicleInfo.Input[1]);
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Color of the car : {0}{1}", m_ColorOfCar, Environment.NewLine));
            vehicleInfo.Append(string.Format("Number of doors in the car : {0}{1}", m_NumOfDoors, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
