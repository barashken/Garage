using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car
    {
        internal enum eColors
        {
            Red = 1,
            White,
            Green,
            Blue
        }

        internal enum eDoorsNumber
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        private eColors m_Color;
        private eDoorsNumber m_DoorsNumber;

        public Car(Dictionary<string, object> i_DataFromUser)
        {
            m_Color = (eColors)i_DataFromUser["Color"];
            m_DoorsNumber = (eDoorsNumber)i_DataFromUser["numOfDoors"];
        }

        internal eColors Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        internal eDoorsNumber DoorsNumber
        {
            get
            {
                return m_DoorsNumber;
            }
            set
            {
                m_DoorsNumber = value;
            }
        }

        internal static Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();
            KeyValuePair<string, Type> pair1 = new KeyValuePair<string, Type>("Color", typeof(eColors));
            string eColors = Vehicle.GetEnumNames(typeof(eColors));
            string color = string.Format(
@"Choose color for the car: " + Environment.NewLine + eColors);
            KeyValuePair<string, Type> pair2 = new KeyValuePair<string, Type>("numOfDoors", typeof(eDoorsNumber));
            string eDoors = Vehicle.GetEnumNames(typeof(eDoorsNumber));
            string numOfDoors = string.Format(
@"Choose number for doors: " + Environment.NewLine + eDoors);

            data.Add(color, pair1);
            data.Add(numOfDoors, pair2);

            return data;
        }

        internal void GetData(Dictionary<string, string> i_Data)
        {
            i_Data.Add("The color is: ", Color.ToString());
            i_Data.Add("The number of doors is: ", DoorsNumber.ToString());
        }
    }
}
