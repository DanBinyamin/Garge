﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base(string.Format("Out of the range Exception min {0} max {1}", i_MinValue, i_MaxValue))
        { 
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }        
    }
}
