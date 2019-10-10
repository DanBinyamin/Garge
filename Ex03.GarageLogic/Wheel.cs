using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_NameOfManufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public void FillAirPressure(float i_AirToFill)
        {
            if (m_CurrentAirPressure + i_AirToFill <= m_MaxAirPressure && i_AirToFill >= 0)
            {
                m_CurrentAirPressure += i_AirToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure - m_CurrentAirPressure, 0);
            }
        }

        public string NameManufacuter
        {
            get
            {
                return m_NameOfManufacturer;
            }

            set
            {
                m_NameOfManufacturer = value;
            }
        }

        public float CurrentPsi
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxPsi
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public override string ToString()
        {
            return string.Format("Name manufacturer: {0}{2}Current air pressure: {1}", m_NameOfManufacturer, m_CurrentAirPressure, Environment.NewLine);
        }
    }
}
