using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasTruck : GasVehicle
    {
        private const float k_TruckFuelTank = 120f;

        private readonly Truck r_Truck;

        internal GasTruck(Dictionary<string, object> i_DataFromUser) : base(i_DataFromUser)
        {
            NumberOfWheels = eNumberOfWheels.Track;
            MaxFuelTank = k_TruckFuelTank;
            FuelType = eFuelType.Soler;
            Wheels = InitWheels(i_DataFromUser, Wheel.eWheelMaxAirPressure.Truck);
            r_Truck = new Truck(i_DataFromUser);
        }

        internal Truck Truck
        {
            get
            {
                return r_Truck;
            }
        }

        internal static new Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in GasVehicle.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in Truck.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            return data;
        }

        internal override void GetData(Dictionary<string, string> i_Data)
        {
            base.GetData(i_Data);
            Truck.GetData(i_Data);
        }
    }
}
