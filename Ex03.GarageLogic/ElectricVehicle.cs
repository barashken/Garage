using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private float m_CurrentBattary;
        private float m_MaxBattary;

        internal ElectricVehicle(Dictionary<string, object> i_DataFromUser) : base(i_DataFromUser) { }

        internal float CurrentBattary
        {
            get
            {
                return m_CurrentBattary;
            }
            set
            {
                m_CurrentBattary = value;
                EnergyPrecentage = (m_CurrentBattary / m_MaxBattary) * 100;
            }
        }

        internal float MaxBattary
        {
            get
            {
                return m_MaxBattary;
            }
            set
            {
                m_MaxBattary = value;
            }
        }

        internal void Recharge(float i_AmountToAdd)
        {
            float canFilled = MaxBattary - CurrentBattary;

            if (i_AmountToAdd > canFilled)
            {
                throw new ValueOutOfRangeException(0, MaxBattary);
            }
            else
            {
                CurrentBattary += i_AmountToAdd;
            }
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
            i_Data.Add("The current battary is: ", CurrentBattary.ToString());
            i_Data.Add("The max battary is: ", MaxBattary.ToString());
        }
    }
}
