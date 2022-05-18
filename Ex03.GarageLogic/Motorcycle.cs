using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorcycle
    {
        internal enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            BB
        }

        private readonly eLicenseType r_Type;
        private readonly int r_EngineVolume;

        internal Motorcycle(Dictionary<string, object> i_DataFromUser)
        {
            r_Type = (eLicenseType)i_DataFromUser["LicenseType"];
            r_EngineVolume = (int)i_DataFromUser["EngineVolume"];
        }

        internal eLicenseType LicenseType
        {
            get
            {
                return r_Type;
            }
        }

        internal int EngineVolume
        {
            get
            {
                return r_EngineVolume;
            }
        }

        internal static Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();
            KeyValuePair<string, Type> pair1 = new KeyValuePair<string, Type>("LicenseType", typeof(eLicenseType));
            string eNames = Vehicle.GetEnumNames(typeof(eLicenseType));
            string licenseType = string.Format(
@"Choose license type: " + Environment.NewLine + eNames);
            KeyValuePair<string, Type> pair2 = new KeyValuePair<string, Type>("EngineVolume", typeof(int));

            data.Add(licenseType, pair1);
            data.Add("Insert engine volume: ", pair2);

            return data;
        }

        internal void GetData(Dictionary<string, string> i_Data)
        {
            i_Data.Add("The license type is: ", LicenseType.ToString());
            i_Data.Add("The engine volume is: ", EngineVolume.ToString());
        }
    }
}
