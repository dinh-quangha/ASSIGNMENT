using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tính_tiền_nước
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
               
                string choice = GetChoice();
                if (choice == "5")
                {
                    break;
                }
                Console.WriteLine("  ");// khoảng cách 
                Console.WriteLine("------ Informance customer -----");
                string name = GetName();

                int num1 = GetNumber("Enter water usage last month: ");
                Console.WriteLine("Water usage last month: " + num1 + "m³");
                int num2 = GetNumber("Enter water usage this month: ");
                Console.WriteLine("Water usage this month: " + num2 + "m³");

                if (num1 >= num2)
                {
                    Console.WriteLine("Invalid input. Last month's water usage should be less than this month's. Please try again.");
                    continue;
                }

                int waterConsumption;
                waterConsumption = num2 - num1;
                if (choice == "4")
                {
                    int numpeople = GetNumber("Enter numpeople: ");
                    double m3 = waterConsumption / numpeople;
                    Console.WriteLine("The average amount of water used by each person is: " + m3 + "m3");
                }
                Console.WriteLine("Water consumption is: " + waterConsumption + "m³");
                Console.WriteLine("        ");//khoảng cách 
                Console.WriteLine("----- Bill -----");
                double waterPrice = GetWaterPrice(choice, waterConsumption);
                Console.WriteLine("Total water bill: " + waterPrice.ToString("0.000") + " VND");
                double environmentFee = waterPrice * 0.1;
                Console.WriteLine("Environment Fee is: " + environmentFee.ToString("0.000") + "VND");

                double VAT = waterPrice * 0.1;
                Console.WriteLine("VAT is: " + VAT.ToString("0.000") + " VND");

                double totalBill;
                totalBill = waterPrice + VAT + environmentFee;
                Console.WriteLine("Total bill is: " + totalBill.ToString("0.000") + " VND");

                Console.WriteLine("Please press Enter key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void Menu() //in ra menu cho người dùng 
        {
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Business services");
            Console.WriteLine("2. Administrative agency, public services");
            Console.WriteLine("3. Production units");
            Console.WriteLine("4. Household");
            Console.WriteLine("5. Exit");
        }
        static string GetChoice() //người dùng nhập lựa chọn 
        {
            Console.WriteLine("Enter customer type: ");
            string choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Invalid choice. Please enter a valid option.");
                choice = Console.ReadLine();
            }

            return choice;
        }
        static string GetName() // người dùng nhập tên 
        {
            Console.WriteLine("Enter customer name: ");
            string name = Console.ReadLine();
            return name;
        }
        static int GetNumber(string message) // nhập số nước tháng trước, tháng này, số người trong hộ gia đình(nếu lựa chọn của người dùng là "4"
        {
            Console.Write(message);
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        static double GetWaterPrice(string choice, int waterConsumption) // tính toán tiền nước dựa theo lựa chọn người dùng  
        {
            double waterPrice = 0;
            switch (choice)
            {
                case "1":
                    waterPrice = waterConsumption * 22.068;
                    break;
                case "2":
                    waterPrice = waterConsumption * 9.955;
                    break;
                case "3":
                    waterPrice = waterConsumption * 11.615;
                    break;
                case "4":
                    if (waterConsumption <= 10)
                    {
                        waterPrice = 5.973 * waterConsumption;
                    }
                    else if (waterConsumption <= 20)
                    {
                        waterPrice = (10 * 5.973) + (waterConsumption - 10) * 7.052;
                    }
                    else if (waterConsumption <= 30)
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + (waterConsumption - 20) * 8.699;
                    }
                    else
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + (waterConsumption - 30) * 15.929;
                    }
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
            }
            return waterPrice;
        }

    }
}
