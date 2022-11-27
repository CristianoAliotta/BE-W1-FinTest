using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_W1_FinTest
{
    internal class Contributor
    {
        private string Name { get; set; }
        private string LastName { get; set; }
        private DateTime Birth { get; set; }
        private string TaxNumber { get; set; }
        private string Gender { get; set; }
        private string City { get; set; }
        private double Income { get; set; }
        public Contributor () { }
        public Contributor (string name, string lastName, DateTime birth, string taxNumber, string gender, string city, double income)
        {
            this.Name = name;           
            this.LastName = lastName;
            this.Birth = birth;
            this.TaxNumber = taxNumber;
            this.Gender = gender;
            this.City = city;
            this.Income = income;
                  
        }
        private double CalcTaxes(double income)
        {
            if (income >= 0.00 && income <= 15000.00)
            {
                return income * 0.23;
            }
            else if (income >= 15001.00 && income <= 28000.00)
            {
                return 3450.00 + ((income - 15000.00) * 0.27);
            }
            else if (income >= 28001.00 && income <= 55000.00)
            {
                return 6960.00 + ((income - 28000.00) * 0.38);
            }
            else if (income >= 55001.00 && income <= 75000.00)
            {
                return 17220.00 + ((income - 55000.00) * 0.41);
            }
            else if (income >= 75001.00)
            {
                return 25420.00 + ((income - 75000.00) * 0.43);
            }
            else
            {
                return 0.00;
            }
        }
        public void menu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("==========================================================");
            Console.WriteLine("-------------------------  MENU  -------------------------");
            Console.WriteLine("==========================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1) Create contributor");
            Console.WriteLine("2) Contributor detail");
            Console.WriteLine("3) Quit");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("==========================================================");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("==========================================================");

            string option = Console.ReadLine();
            if (option == "1") 
            {
               CreateContributor();
            }
            else if (option == "2")
            {
                ContributorDetail();

            }
            else if (option == "3")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choose a valid option");
                menu();

            }
        }
        private void CreateContributor()
        {
            try
            {
                Console.WriteLine("Insert contributor name");
                Name = Console.ReadLine();
                Console.WriteLine("Insert contributor lastname");
                LastName = Console.ReadLine();
                Console.WriteLine("Insert date of birth dd/mm/yyyy");
                Birth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Insert your tax number");
                TaxNumber = Console.ReadLine();
                Console.WriteLine("Press M if you are a boy");
                Console.WriteLine("Press F if you are a girl");
                Console.WriteLine("Press N if you prefer not to say it");
                string gender = Console.ReadLine();
                if (gender == "m")
                {
                    Gender = "Male";
                }
                else if (gender == "f")
                {
                    Gender = "Female";
                }
                else if (gender == "n")
                {
                    Gender = "Not specified";
                }
                else
                {
                    Console.WriteLine("Choose a valid option");
                    CreateContributor();
                }
                Console.WriteLine("Insert your city");
                City = Console.ReadLine();
                Console.WriteLine("Insert your annual income");
                Income = double.Parse(Console.ReadLine());
                menu();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {(ex.Message)} ");
                CreateContributor();
            }

        }
        private void ContributorDetail()
        {
            double tax = CalcTaxes(Income);
            Console.WriteLine("==========================================================");
            Console.WriteLine("-------------------  TAX CALCULATOR  ---------------------");
            Console.WriteLine("==========================================================");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Contributor: {Name} {LastName}");
            Console.WriteLine($"Date of birth: {Birth} Gender: {Gender}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine($"Tax number: {TaxNumber}");
            Console.WriteLine("");
            Console.WriteLine($"Annual income: {Income}");
            Console.WriteLine("");
            Console.WriteLine($"Taxes to pay: {tax}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("==========================================================");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("==========================================================");
            Console.ReadLine();
        }
    }
}
