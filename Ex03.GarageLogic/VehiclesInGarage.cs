using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class VehiclesInGarage
    {
        private readonly Client r_Client;
        private readonly Vehicle r_Vehicle;
        Garage.eVehicleState m_State;

        internal VehiclesInGarage(Client i_Client, Vehicle i_Vehicle)
        {
            r_Client = i_Client;
            r_Vehicle = i_Vehicle;
            State = Garage.eVehicleState.InRepair;
        }

        internal Client Client
        {
            get
            {
                return r_Client;
            }
        }

        internal Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        internal Garage.eVehicleState State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }
        }

        internal void GetData(Dictionary<string, string> i_Data)
        {
            Client.GetData(i_Data);
            Vehicle.GetData(i_Data);
            i_Data.Add("The state of the vehicle in the garage is: ", State.ToString());
        }
    }
}
