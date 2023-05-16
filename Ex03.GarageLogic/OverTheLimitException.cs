using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class OverTheLimitException: Exception
    {
        private float m_CurrentValue;
        private float m_MaxValue;
        private float m_AddedValue;

        public OverTheLimitException(float i_CurrentValue, float i_MaxValue, float i_AddedValue)
            : base(String.Format("The current value is {0}. your trying to add {1} which leads to exceed the limit value which is {2}", i_CurrentValue, i_AddedValue, i_MaxValue))
        {
            m_CurrentValue = i_CurrentValue;
            m_MaxValue = i_MaxValue;
            m_AddedValue = i_AddedValue;
        }

        public float GetCurrentValue()
        { 
            return m_CurrentValue;
        }

        public void SetCurrentValue(float i_CurrentValue)
        {
            m_CurrentValue = i_CurrentValue;
        }

        public float GetMaxValue()
        {
            return m_CurrentValue;
        }

        public void SetMaxValue(float i_MaxValue)
        {
            m_MaxValue = i_MaxValue;
        }

        public float GetAddedValue()
        {
            return m_AddedValue;
        }

        public void SetAddedValue(float i_AddedValue)
        {
            m_AddedValue = i_AddedValue;
        }

    }
}
