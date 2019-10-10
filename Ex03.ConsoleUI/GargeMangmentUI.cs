using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GargeMangmentUI
    {
        private bool m_IsWantToExist = false;
        private FactoryVehicle m_Factory = new FactoryVehicle();
        private Garage m_Garge = new Garage();

        public void StartProgram()
        {
            while (!m_IsWantToExist)
            {
                showMenu();
                int userChoice = getUserChoice(1, 8);
                switch (userChoice)
                {
                    case 1:
                        {
                            addOptionOfNewCar();
                            break;
                        }

                    case 2:
                        {
                            getList();
                            break;
                        }

                    case 3:
                        {
                            changeVehicleStatus();
                            break;
                        }

                    case 4:
                        {
                            fillToMaxWheel();
                            break;
                        }

                    case 5:
                        {
                            fuelVehicle();
                            break;
                        }

                    case 6:
                        {
                            chargeVehicel();
                            break;
                        }

                    case 7:
                        {
                            printDetails();
                            break;
                        }

                    case 8:
                        {
                            wantToExist();
                            return;
                        }
                }

                Console.WriteLine("Please press any key to show Menu ...");
                Console.ReadLine();
            }
        }

        private void wantToExist()
        {
            m_IsWantToExist = true;
        }

        private void printDetails()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getLicenseNumber();
                Customer customer = m_Garge.TryToGetCustomer(licnsenumber);
                Console.Clear();
                Console.WriteLine(customer.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void chargeVehicel()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getLicenseNumber();
                int amountOfMin = getPositiveintInput("Enter how much Minutes you want to charge");
                m_Garge.ChargeElectricVehicle(licnsenumber, amountOfMin);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine("{0}", vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fuelVehicle()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getLicenseNumber();
                eTypeFuel typeFuel = reciveTypeFuel();
                float amountOfFuel = getPositiveFloatInput("Enter amount of fuel");
                m_Garge.FillRegularVehicle(licnsenumber, typeFuel, amountOfFuel);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fillToMaxWheel()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getLicenseNumber();
                m_Garge.FillAirToMaxPsi(licnsenumber);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void changeVehicleStatus()
        {
            try
            {
                Console.Clear();
                string licnsenumber = getLicenseNumber();
                eStatusVehicle eStatusVehicle = reciveStatusVehicle();

                m_Garge.ChangeStatusVehicles(licnsenumber, eStatusVehicle);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void getList()
        {
            Console.Clear();
            List<string> vehiclesString = null;
            Console.WriteLine(@"Hi please enter you choice:
1.All Vehicles, 
2.Some Vehicles,");
            int userChoice = getUserChoice(1, 2);
            switch (userChoice)
            {
                case 1:
                    {
                        vehiclesString = m_Garge.GetListVehiclsStatus();
                        showList(vehiclesString);
                        break;
                    }

                case 2:
                    {
                        eStatusVehicle eStatusVehicle = reciveStatusVehicle();
                        vehiclesString = m_Garge.GetListVehiclsStatus(eStatusVehicle);
                        showList(vehiclesString);
                        break;
                    }
            }
        }

        private void showList(List<string> i_ListOfStrig)
        {
            Console.Clear();
            Console.WriteLine("Hi this is the list of ID :");

            foreach(string msg in i_ListOfStrig)
            {
                Console.WriteLine("ID : {0}", msg);
            }
        }

        private void showMenu()
        {
            Console.Clear();
            Console.WriteLine(@"     Menu of Garge:

1. To enter a new vehicle into to the garge , please press 1
2. To view the list of the car in the garge , please press 2 
3. To change status of car in the garge , please press 3
4. To blow up to max the all wheels Psi , please press 4
5. To refueling a car that have Fuel system , please press 5
6. To charging a car that have elelctric system , please press 6
7. To get informarion about details on a spceifc car , please press 7
8. To Exits , please press 8
");
        }

        private void addOptionOfNewCar()
        {
            Console.Clear();
            int userChoice = 0;
            Console.WriteLine("Hi please enter you choice : ");
            List<string> listOfVehicles = m_Factory.GetListOfVehicles();
            for (int i = 0; i < listOfVehicles.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, listOfVehicles[i]);
            }

            userChoice = getUserChoice(1, listOfVehicles.Count);
            createCar(listOfVehicles[userChoice - 1]);
        }

        private void createCar(string i_Vehicle)
        {
            try
            {
                Vehicle vehicleToCreate;
                VehicleInfo vehicleInfo = getVehicleInfoToStart();

                vehicleToCreate = m_Factory.GetVehicle(i_Vehicle, vehicleInfo.License, vehicleInfo.NameModel, vehicleInfo.Energy);
                getVehicleInfoToProgress(vehicleToCreate);
                addToGarge(vehicleToCreate);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void addToGarge(Vehicle i_Vehicle)
        {
            string customerName = null;
            string phoneNumber = null;

            Console.WriteLine("Please Enter Name of Customer");
            customerName = Console.ReadLine();
            Console.WriteLine("Please Enter PhoneNumber of Customer");
            phoneNumber = Console.ReadLine();

            m_Garge.AddCustomer(i_Vehicle, customerName, phoneNumber);
        }

        private void getVehicleInfoToProgress(Vehicle i_Vehicle)
        {
            bool isVaildParmeters = false;
            VehicleInfo vehicleInfo = i_Vehicle.GetInfoToInput();
            while (!isVaildParmeters)
            {
                foreach (string dataNeedToInput in vehicleInfo.Data)
                {
                    if (dataNeedToInput.Equals("Wheel Manfactuer :"))
                    { 
                        foreach (Wheel wheel in i_Vehicle.Wheels)
                        {
                            Console.WriteLine(dataNeedToInput);
                            wheel.NameManufacuter = Console.ReadLine();
                        }

                        continue;
                    }
                    else if (dataNeedToInput.Equals("Wheel Curennt Psi :"))
                    {
                        foreach (Wheel wheel in i_Vehicle.Wheels)
                        {
                            wheel.CurrentPsi = getPositiveFloatInput(dataNeedToInput);
                        }

                        continue;
                    }

                    Console.WriteLine(dataNeedToInput);
                    vehicleInfo.Input.Add(Console.ReadLine());
                }

                i_Vehicle.SetInfoToVehicle();
                isVaildParmeters = true;
            }
        }

        private VehicleInfo getVehicleInfoToStart()
        {
            VehicleInfo infoOfVehicle = new VehicleInfo();
            Console.Clear();
            Console.WriteLine("Enter a name of model");
            infoOfVehicle.NameModel = Console.ReadLine();
            infoOfVehicle.License = getLicenseNumber();
            infoOfVehicle.Energy = getCurrentEnergy();

            return infoOfVehicle;
        }

        private string getLicenseNumber()
        {
            string msg = string.Empty;

            Console.WriteLine("Please Enter a license number");
            msg = Console.ReadLine();
            while (!liecensIsVaild(msg))
            {
                Console.WriteLine("Please try again");
                msg = Console.ReadLine();
            }

            return msg;
        }

        private bool liecensIsVaild(string i_LiescnseNumber)
        {
            bool isVaild = true;

            if(i_LiescnseNumber.Equals(string.Empty))
            {
                isVaild = false;
            }

            foreach(char charToCheck in i_LiescnseNumber)
            {
                if(!char.IsLetterOrDigit(charToCheck))
                {
                    isVaild = false;
                }
            }
        
            return isVaild;
        }

        private float getCurrentEnergy()
        {
            string msg = string.Empty;
            float numberToConvert = 0;
            bool isVaild = false;

            Console.WriteLine("Please Enter a Energy on precent");
            msg = Console.ReadLine();

            while (!isVaild)
            {
                if (float.TryParse(msg, out numberToConvert))
                {
                    isVaild = numberToConvert >= 0;
                }
                else
                {
                    Console.WriteLine("Wrong Please try again");
                    msg = Console.ReadLine();
                }
            }

            return numberToConvert;
        }

        private eTypeFuel reciveTypeFuel()
        {
            Console.WriteLine("Type of Fuel : ");
            return (eTypeFuel)receiveEnumChoice(typeof(eTypeFuel));
        }

        private eStatusVehicle reciveStatusVehicle()
        {
            Console.WriteLine("Status of Vehicle : ");
            return (eStatusVehicle)receiveEnumChoice(typeof(eStatusVehicle));
        }

        private Enum receiveEnumChoice(Type i_CurretnEnumType)
        {
            int userChoice;
            Array enumTypes = Enum.GetValues(i_CurretnEnumType);

            Console.Clear();
            foreach (Enum currentType in enumTypes)
            {
                Console.WriteLine("For {0}, press {1}", currentType, currentType.GetHashCode());
            }

            userChoice = getUserChoice(0, enumTypes.Length - 1);

            return (Enum)enumTypes.GetValue(userChoice);
        }

        private int getUserChoice(int i_MinValue, int i_MaxValue)
        {
            bool isVaild = false;
            string msg = string.Empty;
            int numberParsing = 0;

            while(!isVaild)
            {
                Console.WriteLine("please enter a number the range {0} - {1} ...", i_MinValue, i_MaxValue);
                msg = Console.ReadLine();
                if(int.TryParse(msg, out numberParsing))
                {
                    isVaild = numberParsing <= i_MaxValue && numberParsing >= i_MinValue;
                }

                if(!isVaild)
                {
                    Console.WriteLine("Wrong please try again ");
                }
            }

            return numberParsing;
        }

        private float getPositiveFloatInput(string i_Message)
        {
            float floatInput = 0;
            bool isValidInput = false;
            string input;

            while (!isValidInput)
            {
                Console.WriteLine(i_Message);
                input = Console.ReadLine();
                if (float.TryParse(input, out floatInput) && floatInput >= 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Wrong input... try again (only numbers)");
                }
            }

            return floatInput;
        }

        private int getPositiveintInput(string i_Message)
        {
            int intInput = 0;
            bool isValidInput = false;
            string input;

            while (!isValidInput)
            {
                Console.WriteLine(i_Message);
                input = Console.ReadLine();
                if (int.TryParse(input, out intInput) && intInput >= 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Wrong input... try again (only numbers)");
                }
            }

            return intInput;
        }
    }
}
