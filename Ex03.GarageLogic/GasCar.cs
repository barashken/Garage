using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasCar : GasVehicle
    {
        private const float k_CarFuelTank = 38f;

        private readonly Car r_Car;

        internal GasCar(Dictionary<string, object> i_DataFromUser) : base(i_DataFromUser)
        {
            NumberOfWheels = eNumberOfWheels.Car;
            MaxFuelTank = k_CarFuelTank;
            FuelType = eFuelType.Octan95;
            Wheels = InitWheels(i_DataFromUser, Wheel.eWheelMaxAirPressure.Car);
            r_Car = new Car(i_DataFromUser);
        }

        internal Car Car
        {
            get
            {
                return r_Car;
            }
        }

        internal static new Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();

            foreach(KeyValuePair<string, KeyValuePair<string, Type>> pair in GasVehicle.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in Car.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            return data;
        }

        internal override void GetData(Dictionary<string, string> i_Data)
        {
            base.GetData(i_Data);
            Car.GetData(i_Data);
        }
    }
}
