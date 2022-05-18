using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasMotorcycle : GasVehicle
    {
        private const float k_MotorcycleFuelTank = 6.2f;

        private readonly Motorcycle r_Motorcycle;

        internal GasMotorcycle(Dictionary<string, object> i_DataFromUser) : base(i_DataFromUser)
        {
            NumberOfWheels = eNumberOfWheels.Motorcycle;
            MaxFuelTank = k_MotorcycleFuelTank;
            FuelType = eFuelType.Octan98;
            Wheels = InitWheels(i_DataFromUser, Wheel.eWheelMaxAirPressure.MotorCycle);
            r_Motorcycle = new Motorcycle(i_DataFromUser);
        }

        internal Motorcycle Motorcycle
        {
            get
            {
                return r_Motorcycle;
            }
        }

        internal static new Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in GasVehicle.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in Motorcycle.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            return data;
        }

        internal override void GetData(Dictionary<string, string> i_Data)
        {
            base.GetData(i_Data);
            Motorcycle.GetData(i_Data);
        }
    }
}
