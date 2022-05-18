using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private readonly string r_Name;
        private readonly string r_PhoneNumber;

        public Client(string i_Name, string i_PhoneNumber)
        {
            r_Name = i_Name;
            r_PhoneNumber = i_PhoneNumber;
        }

        internal string Name
        {
            get
            {
                return r_Name;
            }
        }

        internal string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
        }

        internal void GetData(Dictionary<string, string> i_Data)
        {
            i_Data.Add("The name of the client is: ", Name);
            i_Data.Add("The phone number is: ", PhoneNumber);
        }
    }
}
