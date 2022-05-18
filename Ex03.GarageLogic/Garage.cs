using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleState
        {
            InRepair = 1,
            Fixed,
            Paid
        }

        private readonly Dictionary<string, VehiclesInGarage> r_CurrentVehicles = new Dictionary<string, VehiclesInGarage>();

        internal Dictionary<string, VehiclesInGarage> CurrentVehicles
        {
            get
            {
                return r_CurrentVehicles;
            }
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle, Client i_Client)
        {
            if (CurrentVehicles.ContainsKey(i_Vehicle.LicenseNumber))
            {
                throw new ArgumentException("There is vehicle with this license number in the garage");
            }

            CurrentVehicles.Add(i_Vehicle.LicenseNumber, new VehiclesInGarage(i_Client, i_Vehicle));
        }

        public Dictionary<string, eVehicleState> GetVehiclesLicenseNumber()
        {
            Dictionary<string, eVehicleState> licenseNumberDic = new Dictionary<string, eVehicleState>();

            foreach (KeyValuePair<string, VehiclesInGarage> pair in r_CurrentVehicles)
            {
                licenseNumberDic.Add(pair.Key, pair.Value.State);
            }

            return licenseNumberDic;
        }

        public Dictionary<string, eVehicleState> GetVehiclesLicenseNumberByState(Dictionary<string, eVehicleState> i_LicenseNumberDic, eVehicleState i_CurrentState)
        {
            Dictionary<string, eVehicleState> newLicenseNumberDic = new Dictionary<string, eVehicleState>();

            foreach (KeyValuePair<string, eVehicleState> pair in i_LicenseNumberDic)
            {
                if (pair.Value == i_CurrentState)
                {
                    newLicenseNumberDic.Add(pair.Key, pair.Value);
                }
            }

            return newLicenseNumberDic;
        }

        private bool isVehicleInGarage(string i_LicenseNumber)
        {
            return CurrentVehicles.ContainsKey(i_LicenseNumber);
        }

        public void ChangeState(string i_LicenseNumber, eVehicleState i_NewState)
        {
            if (isVehicleInGarage(i_LicenseNumber))
            {
                CurrentVehicles[i_LicenseNumber].State = i_NewState;
            }
            else
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage");
            }
        }

        public void InflateAirPresure(string i_LicenseNumber)
        {
            if (isVehicleInGarage(i_LicenseNumber))
            {
                foreach(Wheel currentWheel in CurrentVehicles[i_LicenseNumber].Vehicle.Wheels)
                {
                    currentWheel.AddAirPressure(currentWheel.MaxAirPressure - currentWheel.CurrentAirPressure);
                }
            }
            else
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage");
            }
        }

        public void Refuel(string i_LicenseNumber, GasVehicle.eFuelType i_FuelType, float i_AmountToFill)
        {
            if (!isVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage");
            }

            if(CurrentVehicles[i_LicenseNumber].Vehicle is GasVehicle)
            {
                (CurrentVehicles[i_LicenseNumber].Vehicle as GasVehicle).Refuel(i_AmountToFill, i_FuelType);
            }
            else
            {
                throw new FormatException("This is not a gas vehicle");
            }
        }

        public void Recharge(string i_LicenseNumber, float i_AmountToFill)
        {
            if (!isVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle with this license number in the garage");
            }

            if (CurrentVehicles[i_LicenseNumber].Vehicle is ElectricVehicle)
            {
                (CurrentVehicles[i_LicenseNumber].Vehicle as ElectricVehicle).Recharge(i_AmountToFill);
            }
            else
            {
                throw new FormatException("This is not a electric vehicle");
            }
        }

        public void Inflate(string i_LicenseNumber, float i_AmountToFill)
        {
            if (!isVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle  with this license number in the garage");
            }

            CurrentVehicles[i_LicenseNumber].Vehicle.Inflate(i_AmountToFill);
        }

        public void GetData(Dictionary<string, string> i_Data, string i_LicenseNumber)
        {
            if (!isVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("There is no vehicle  with this license number in the garage");
            }

            CurrentVehicles[i_LicenseNumber].GetData(i_Data);
        }
    }
}
