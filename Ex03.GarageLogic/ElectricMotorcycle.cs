using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private const float k_MotorcycleBattaryLife = 2.5f;

        private readonly Motorcycle r_Motorcycle;

        internal ElectricMotorcycle(Dictionary<string, object> i_DataFromUser) : base(i_DataFromUser)
        {
            NumberOfWheels = eNumberOfWheels.Motorcycle;
            MaxBattary = k_MotorcycleBattaryLife;
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

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in ElectricVehicle.CreateData())
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
