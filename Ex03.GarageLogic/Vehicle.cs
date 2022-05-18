using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        internal enum eNumberOfWheels
        {
            Motorcycle = 2,
            Car = 4,
            Track = 16
        }

        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private float m_EnergyPrecentage;
        private List<Wheel> m_Wheels;
        private eNumberOfWheels m_NumberOfWheels;

        internal Vehicle(Dictionary<string, object> i_DataFromUser)
        {
            r_Model = i_DataFromUser["Model"].ToString();
            r_LicenseNumber = i_DataFromUser["LicenseNumber"].ToString();
        }

        internal string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        internal float EnergyPrecentage
        {
            get
            {
                return m_EnergyPrecentage;
            }
            set
            {
                m_EnergyPrecentage = value;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }

        internal eNumberOfWheels NumberOfWheels
        {
            get
            {
                return m_NumberOfWheels;
            }
            set
            {
                m_NumberOfWheels = value;
            }
        }

        internal static Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();
            KeyValuePair<string, Type> pair1 = new KeyValuePair<string, Type>("Model", typeof(string));
            KeyValuePair<string, Type> pair2 = new KeyValuePair<string, Type>("LicenseNumber", typeof(string));

            data.Add("Insert the model of vehicle: ", pair1);
            data.Add("Insert license number: ", pair2);

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in Wheel.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            return data;
        }

        internal void Inflate(float i_AirPresureAmount)
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.AddAirPressure(i_AirPresureAmount);
            }
        }

        public static string GetEnumNames(Type i_EnumType)
        {
            string enumNames = "";
            string[] enumNamesArray = Enum.GetNames(i_EnumType);
            int index = 1;

            foreach(string eName in enumNamesArray)
            {
                enumNames += string.Format("{0}. {1}", index, eName);
                enumNames += Environment.NewLine;
                index++;
            }

            return enumNames;
        }

        internal List<Wheel> InitWheels(Dictionary<string, object> i_DataFromUser, Wheel.eWheelMaxAirPressure i_MaxAirPrussure)
        {
            List<Wheel> wheelsList = new List<Wheel>();

            for (int i = 0; i < (int)NumberOfWheels; i++)
            {
                wheelsList.Add(new Wheel(i_DataFromUser, i_MaxAirPrussure));
            }

            return wheelsList;
        }

        internal virtual void GetData(Dictionary<string, string> i_Data)
        {
            int index = 1;

            i_Data.Add("The model of the vehicle is: ", Model);
            i_Data.Add("The license number of the vehicle is: ", LicenseNumber);
            i_Data.Add("The energy percentage is: ", EnergyPrecentage.ToString());

            foreach(Wheel wheel in m_Wheels)
            {
                wheel.GetData(i_Data, index);
                index++;
            }
        }
    }
}
