using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        internal enum eWheelMaxAirPressure
        {
            MotorCycle = 31,
            Car = 29,
            Truck = 24
        }

        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        internal Wheel(Dictionary<string, object> i_DataFromUser, eWheelMaxAirPressure i_MaxAirPresure)
        {
            r_ManufacturerName = i_DataFromUser["Manufacturer"].ToString();
            CurrentAirPressure = (float)i_DataFromUser["CurrentAirPressure"];
            r_MaxAirPressure = (float)i_MaxAirPresure;
            if(CurrentAirPressure > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure);
            }
        }

        internal string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        internal float CurrentAirPressure
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

        internal float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        internal void AddAirPressure(float i_AirPresureAmount)
        {
            float canFilled = MaxAirPressure - CurrentAirPressure;

            if (i_AirPresureAmount > canFilled)
            {
                throw new ValueOutOfRangeException(MaxAirPressure, 0);
            }
            else
            {
                CurrentAirPressure += i_AirPresureAmount;
            }
        }

        internal static Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();
            KeyValuePair<string, Type> pair1 = new KeyValuePair<string, Type>("Manufacturer", typeof(string));
            KeyValuePair<string, Type> pair2 = new KeyValuePair<string, Type>("CurrentAirPressure", typeof(float));

            data.Add("Insert the manufacturer name of wheels: ", pair1);
            data.Add("Insert current air pressure of wheels: " , pair2);

            return data;
        }

        internal void GetData(Dictionary<string, string> i_Data, int numOfWheel)
        {
            string numOfWheelString = string.Format("Wheel number {0}: ", numOfWheel);
            string data = string.Format(
@"
The manufacturer name is: {0}
The current air pressure is: {1}", ManufacturerName, CurrentAirPressure.ToString());
            
            i_Data.Add(numOfWheelString, data);
        }
    }
}
