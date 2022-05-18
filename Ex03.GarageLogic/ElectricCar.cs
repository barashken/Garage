using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        const float k_CarBattaryLife = 3.3f;

        private readonly Car r_Car;

        internal ElectricCar(Dictionary<string, object> i_DataFromUser) : base(i_DataFromUser)
        {
            NumberOfWheels = eNumberOfWheels.Car;
            MaxBattary = k_CarBattaryLife;
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

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in ElectricVehicle.CreateData())
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
