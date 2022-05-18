using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public enum eUserChoice
        {
            AddVehicleToGarage = 1,
            PrintListOfVehicles,
            ChangeVehicleState,
            InflateAirPressure,
            Refuel,
            Recharge,
            ShowDetails,
            Exit
        }

        private readonly Garage r_Garage = new Garage();

        public Garage Garage
        {
            get
            {
                return r_Garage;
            }
        }

        private eUserChoice menu()
        {
            int value;
            string input, menu = string.Format(
@"This is a Garage!
Please choose the number of the action you want to do:
=========================================================
1. Add a vehicle to the garage.
2. Show list of the vehicles in the garage.
3. Change vehicle state.
4. Inflate air pressure of wheels to the maximum.
5. Refuel.
6. Recharge.
7. Show details of the vehicle.
8. Exit.
=========================================================");

            Console.Clear();
            Console.WriteLine(menu);
            input = Console.ReadLine();
            while(!int.TryParse(input, out value))
            {
                Console.WriteLine("Wrong input! Please choose a number.");
                input = Console.ReadLine();
            }

            return (eUserChoice)value;
        }

        public void RunGarage()
        {
            bool isValid = true;
            
            while (isValid)
            {
                Console.Clear();
                eUserChoice input = menu();

                try
                {
                    switch (input)
                    {
                        case eUserChoice.AddVehicleToGarage:
                            addVehicleToGarage();
                            break;
                        case eUserChoice.PrintListOfVehicles:
                            printListOfVehicles();
                            break;
                        case eUserChoice.ChangeVehicleState:
                            changeVehicleState();
                            break;
                        case eUserChoice.InflateAirPressure:
                            inflateAirPressure();
                            break;
                        case eUserChoice.Refuel:
                            refuel();
                            break;
                        case eUserChoice.Recharge:
                            recharge();
                            break;
                        case eUserChoice.ShowDetails:
                            showDetails();
                            break;
                        case eUserChoice.Exit:
                            isValid = false;
                            break;
                        default:
                            throw new ArgumentException("The number is not valid, please choose again.");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    exceptionMessage(ex.Message);
                }
                catch (FormatException ex)
                {
                    exceptionMessage(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    exceptionMessage(ex.Message);
                }
                catch (Exception ex)
                {
                    exceptionMessage(ex.Message);
                }
            }
        }

        private Dictionary<string, object> getDataFromUser(Dictionary<string, KeyValuePair<string, Type>> i_Data)
        {
            Dictionary<string, object> dataFromUser = new Dictionary<string, object>();
            string data;
            object value;
            bool isValid = false;

            foreach(KeyValuePair<string, KeyValuePair<string, Type>> pair in i_Data)
            {
                while (!isValid)
                {
                    try
                    {
                        Console.Clear();
                        Console.Write(pair.Key);
                        data = Console.ReadLine();
                        value = convertData(pair.Value.Value, data);
                        dataFromUser.Add(pair.Value.Key, value);
                        isValid = true;
                    }
                    catch(FormatException ex)
                    {
                        isValid = false;
                        exceptionMessage(ex.Message);
                    }
                }

                isValid = false;
            }

            return dataFromUser;
        }

        private void addVehicleToGarage()
        {
            Client newClient = createNewClient();
            VehicleCreator.eVehicleType vehicleType = getVehicleType();
            Dictionary<string, KeyValuePair<string, Type>> data = VehicleCreator.CreateData(vehicleType);
            Dictionary<string, object> dataFromUser = getDataFromUser(data);
            Vehicle newVehicle = VehicleCreator.CreateNewVehicle(vehicleType, dataFromUser);
            string message;

            Garage.AddVehicleToGarage(newVehicle, newClient);
            Console.Clear();
            message = string.Format("Vehicle number {0} has enter to the garage!", newVehicle.LicenseNumber);
            Console.WriteLine(message);
            pressAnyKeyToContinue();
        }

        private void printListOfVehicles()
        {
            Dictionary<string, Garage.eVehicleState> listOfVehicles = Garage.GetVehiclesLicenseNumber();
            string input, message;
            int state;

            message = string.Format("The license number of vehicles in the garage are: ");
            Console.Clear();
            Console.WriteLine("Want to filter by state? (1 for yes, 0 for no): ");
            input = Console.ReadLine();
            if(input == "1")
            {
                Console.Clear();
                Console.WriteLine("Choose state: ");
                Console.Write(Vehicle.GetEnumNames(typeof(Garage.eVehicleState)));
                input = Console.ReadLine();
                while (!int.TryParse(input, out state))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input! Choose state: ");
                    Console.Write(Vehicle.GetEnumNames(typeof(Garage.eVehicleState)));
                    input = Console.ReadLine();
                }

                message = string.Format("The license number of vehicles in the garage that their state is {0} are: ", (Garage.eVehicleState)state);
                listOfVehicles = Garage.GetVehiclesLicenseNumberByState(listOfVehicles, (Garage.eVehicleState)state);
            }

            Console.Clear();
            Console.WriteLine(message);
            foreach(KeyValuePair<string, Garage.eVehicleState> pair in listOfVehicles)
            {
                Console.WriteLine(pair.Key);
            }

            pressAnyKeyToContinue();
        }

        private void changeVehicleState()
        {
            string licenseNumber = getLicenseNumber();
            string message;
            Garage.eVehicleState newState = getNewState();

            Garage.ChangeState(licenseNumber, newState);
            Console.Clear();
            message = string.Format("State of vehicle number {0} has change to {1}", licenseNumber, newState);
            Console.WriteLine(message);
            pressAnyKeyToContinue();
        }

        private void inflateAirPressure()
        {
            string licenseNumber = getLicenseNumber();
            string message;

            Garage.InflateAirPresure(licenseNumber);
            Console.Clear();
            message = string.Format("Wheels of vehicle number {0} has inflate", licenseNumber);
            Console.WriteLine(message);
            pressAnyKeyToContinue();
        }

        private void refuel()
        {
            string licenseNumber = getLicenseNumber();
            GasVehicle.eFuelType fuelType = getFuelType();
            float amountToFill = getAmount();
            string message;

            Garage.Refuel(licenseNumber, fuelType, amountToFill);
            Console.Clear();
            message = string.Format("Vehicle number {0} has refuel of {1} litters", licenseNumber, amountToFill);
            Console.WriteLine(message);
            pressAnyKeyToContinue();
        }

        private void recharge()
        {
            string licenseNumber = getLicenseNumber();
            float amountToFill = getAmount();
            string message;

            Garage.Recharge(licenseNumber, amountToFill);
            Console.Clear();
            message = string.Format("Vehicle number {0} has rechage of {1} hours", licenseNumber, amountToFill);
            Console.WriteLine(message);
            pressAnyKeyToContinue();
        }

        private void showDetails()
        {
            string licenseNumber = getLicenseNumber();
            Dictionary<string, string> data = new Dictionary<string, string>();

            Console.Clear();
            Garage.GetData(data, licenseNumber);
            foreach(KeyValuePair<string, string> pair in data)
            {
                Console.Write(pair.Key);
                Console.Write(pair.Value);
                Console.WriteLine(Environment.NewLine);
            }

            pressAnyKeyToContinue();
        }

        private Client createNewClient()
        {
            Client newClient = new Client(getName(), getPhoneNumber());

            return newClient;
        }

        private string getLicenseNumber()
        {
            string licenseNumber;

            Console.Clear();
            Console.Write("Insert license number of the vehicle: ");
            licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        private Garage.eVehicleState getNewState()
        {
            int newState;
            string input;

            Console.Clear();
            Console.WriteLine("Insert new state: ");
            Console.Write(Vehicle.GetEnumNames(typeof(Garage.eVehicleState)));
            input = Console.ReadLine();
            while (!int.TryParse(input, out newState))
            {
                Console.Clear();
                Console.Write("Invalid input! Insert new state: ");
                Console.Write(Vehicle.GetEnumNames(typeof(Garage.eVehicleState)));
                input = Console.ReadLine();
            }

            Console.Clear();

            return (Garage.eVehicleState)newState;
        }

        private GasVehicle.eFuelType getFuelType()
        {
            int fuelType;
            string input;

            Console.Clear();
            Console.WriteLine("Insert fuel type: ");
            Console.Write(Vehicle.GetEnumNames(typeof(GasVehicle.eFuelType)));
            input = Console.ReadLine();
            while (!int.TryParse(input, out fuelType))
            {
                Console.Clear();
                Console.Write("Invalid input! Insert fuel type: ");
                Console.Write(Vehicle.GetEnumNames(typeof(GasVehicle.eFuelType)));
                input = Console.ReadLine();
            }

            Console.Clear();

            return (GasVehicle.eFuelType)fuelType;
        }

        private float getAmount()
        {
            float amount;

            Console.Clear();
            Console.Write("Insert amount: ");
            float.TryParse(Console.ReadLine(), out amount);

            return amount;
        }

        private string getName()
        {
            string name;

            Console.Clear();
            Console.Write("Insert your name: ");
            name = Console.ReadLine();

            return name;
        }

        private string getPhoneNumber()
        {
            string phoneNumber;

            Console.Clear();
            Console.Write("Insert your phone number: ");
            phoneNumber = Console.ReadLine();

            return phoneNumber;
        }

        private VehicleCreator.eVehicleType getVehicleType()
        {
            int vehicleType;
            string input;

            Console.Clear();
            Console.WriteLine("Insert vehicle type: ");
            Console.Write(Vehicle.GetEnumNames(typeof(VehicleCreator.eVehicleType)));
            input = Console.ReadLine();
            while(!int.TryParse(input, out vehicleType))
            {
                Console.Clear();
                Console.Write("Insert vehicle type: ");
                input = Console.ReadLine();
            }

            return (VehicleCreator.eVehicleType)vehicleType;
        }

        private void pressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private object convertData(Type i_Type, string i_Data)
        {
            object value;
            int valueInt;

            if (i_Type.IsEnum)
            {
                if(int.TryParse(i_Data, out valueInt))
                {
                    value = valueInt;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                value = Convert.ChangeType(i_Data, i_Type);
            }

            return value;
        }

        private void exceptionMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            pressAnyKeyToContinue();
        }
    }
}