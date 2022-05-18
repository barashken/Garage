using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck
    {
        private readonly bool r_IsRefrigratedCargo;
        private readonly float r_CargoVolume;

        internal Truck(Dictionary<string, object> i_DataFromUser)
        {
            r_IsRefrigratedCargo = (bool)i_DataFromUser["IsRefrigratedCargo"];
            r_CargoVolume = (float)i_DataFromUser["CargoVolume"];
        }

        internal bool IsRefrigratedCargo
        {
            get
            {
                return r_IsRefrigratedCargo;
            }
        }

        internal float CargoVolume
        {
            get
            {
                return r_CargoVolume;
            }
        }

        internal static Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();
            KeyValuePair<string, Type> pair1 = new KeyValuePair<string, Type>("IsRefrigratedCargo", typeof(bool));
            KeyValuePair<string, Type> pair2 = new KeyValuePair<string, Type>("CargoVolume", typeof(float));

            data.Add("Is refrigrated cargo? (true or false): ", pair1);
            data.Add("Insert cargo volume: ", pair2);

            return data;
        }

        internal void GetData(Dictionary<string, string> i_Data)
        {
            i_Data.Add("Is refrigrated cargo - ", IsRefrigratedCargo.ToString());
            i_Data.Add("The cargo volume is: ", CargoVolume.ToString());
        }
    }
}
