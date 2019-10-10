using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEnergySystem : EnergySystem 
    {
        public ElectricEnergySystem(float i_EnergyCapacity, float i_CurrentEnergy) 
            : base(i_EnergyCapacity, i_CurrentEnergy)
        {
        }

        public void ChargeBattery(float i_HoursToAdd)
        {
            if (i_HoursToAdd + m_CurrentEnergy <= m_EnergyCapacity && i_HoursToAdd >= 0)
            {
                m_CurrentEnergy += i_HoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(m_EnergyCapacity - m_CurrentEnergy, 0);
            }
        }

        public override string ToString()
        {
            return string.Format("Energy system type: Electric , Current Battery: {0}h", m_CurrentEnergy);
        }
    }
}
