using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class GasVehicle : Vehicle
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private eFuelType m_Type;
        private float m_CurrentFuelTank;
        private float m_MaxFuelTank;

        internal GasVehicle(Dictionary<string, object> i_DataFromUser) : base(i_DataFromUser) { }

        internal eFuelType FuelType
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        internal float CurrentFuelTank
        {
            get
            {
                return m_CurrentFuelTank;
            }
            set
            {
                m_CurrentFuelTank = value;
                EnergyPrecentage = (m_CurrentFuelTank / m_MaxFuelTank) * 100;
            }
        }

        internal float MaxFuelTank
        {
            get
            {
                return m_MaxFuelTank;
            }
            set
            {
                m_MaxFuelTank = value;
            }
        }

        public void Refuel(float i_AmountToAdd, eFuelType i_Type)
        {
            float canFilled = MaxFuelTank - CurrentFuelTank;
            string message;

            if (i_AmountToAdd > canFilled)
            {
                throw new ValueOutOfRangeException(0, MaxFuelTank);
            }

            if(!isValidFuelType(i_Type))
            {
                message = string.Format(
@"The fuel type is not valid!
The correct type is: {0}", FuelType);
                throw new ArgumentException(message);
            }
            else
            {
                CurrentFuelTank += i_AmountToAdd;
            }
        }

        private bool isValidFuelType(eFuelType i_Type)
        {
            return FuelType == i_Type;
        }

        internal static new Dictionary<string, KeyValuePair<string, Type>> CreateData()
        {
            Dictionary<string, KeyValuePair<string, Type>> data = new Dictionary<string, KeyValuePair<string, Type>>();

            foreach (KeyValuePair<string, KeyValuePair<string, Type>> pair in Vehicle.CreateData())
            {
                data.Add(pair.Key, pair.Value);
            }

            return data;
        }

        internal override void GetData(Dictionary<string, string> i_Data)
        {
            base.GetData(i_Data);
            i_Data.Add("The current fuel tank is: ", CurrentFuelTank.ToString());
            i_Data.Add("The max fuel tank is: ", MaxFuelTank.ToString());
            i_Data.Add("The fuel type is: ", FuelType.ToString());
        }
    }
}
