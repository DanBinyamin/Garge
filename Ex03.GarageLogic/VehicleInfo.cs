using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        private List<string> m_DataNeedToGet = new List<string>();
        private List<string> m_InputFromUser = new List<string>();
        private string m_NameOfModel = string.Empty;
        private string m_LicenseID = string.Empty;
        private float m_EnergyPrecent;

        private bool checkEnergyPercentVaild()
        {
            if (m_EnergyPrecent >= 0 && m_EnergyPrecent <= 100)
            {
                return true;
            }
            else
            {
                throw new ValueOutOfRangeException(100, 0);
            }
        }

        private bool checkNameModelVaild()
        {
            if (!m_NameOfModel.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                throw new FormatException("Empty Field Name Please try again");
            }
        }

        private bool checkliecensIsVaild()
        {
            bool isVaild = true;

            if (m_LicenseID.Equals(string.Empty))
            {
                throw new FormatException("Empty Field License Please try again");
            }

            foreach (char charToCheck in m_LicenseID)
            {
                if (!char.IsLetterOrDigit(charToCheck))
                {
                    isVaild = false;
                }
            }

            return isVaild;
        }

        public string License
        {
            get
            {
                return m_LicenseID;
            }

            set
            {
                m_LicenseID = value;
                checkliecensIsVaild();
            }
        }

        public string NameModel
        {
            get
            {
                return m_NameOfModel;
            }

            set
            {
                m_NameOfModel = value;
                checkNameModelVaild();
            }
        }

        public float Energy
        {
            get
            {
                return m_EnergyPrecent;
            }
            
            set
            {
                m_EnergyPrecent = value;
                checkEnergyPercentVaild();
            }
        }

        public List<string> Data
        {
            get
            {
                return m_DataNeedToGet;
            }
        }

        public List<string> Input
        {
            get
            {
                return m_InputFromUser;
            }
        }
    }
}
