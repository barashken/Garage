using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public enum eVehicleType
        {
            ElectricMotorcycle = 1,
            GasMotorcycle,
            ElectricCar,
            GasCar,
            GasTruck
        }

        public static Dictionary<string, KeyValuePair<string, Type>> CreateData(eVehicleType i_VehicleType)
        {
            Dictionary<string, KeyValuePair<string, Type>> data;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                    data = ElectricMotorcycle.CreateData();
                    break;
                case eVehicleType.GasMotorcycle:
                    data = GasMotorcycle.CreateData();
                    break;
                case eVehicleType.ElectricCar:
                    data = ElectricCar.CreateData();
                    break;
                case eVehicleType.GasCar:
                    data = GasCar.CreateData();
                    break;
                case eVehicleType.GasTruck:
                    data = GasTruck.CreateData();
                    break;
                default:
                    throw new ArgumentException("The vehicle type is not valid");
            }

            return data;
        }

        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, Dictionary<string, object> i_DataFromUser)
        {
            Vehicle newVehicle;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                        newVehicle = new ElectricMotorcycle(i_DataFromUser);
                        break;
                case eVehicleType.GasMotorcycle:
                        newVehicle = new GasMotorcycle(i_DataFromUser);
                        break;
                case eVehicleType.ElectricCar:
                        newVehicle = new ElectricCar(i_DataFromUser);
                        break;
                case eVehicleType.GasCar:
                        newVehicle = new GasCar(i_DataFromUser);
                        break;
                case eVehicleType.GasTruck:
                        newVehicle = new GasTruck(i_DataFromUser);
                        break;
                default:
                    throw new ArgumentException("The vehicle type is not valid");
            }

            return newVehicle;
        }
    }
}
