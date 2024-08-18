using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Test
{
    internal class Program
    {
        public static bool bolInput = false;
        static void Main(string[] args)
        {
            while(true)
            {
                if(bolInput == false)
                {
                    bolInput = true;
                    ModelEmployee mdlEmployee = new ModelEmployee();

                    Console.WriteLine("Input Data.......");
                    Console.WriteLine("======================================");
                    Console.WriteLine("Input Employee Name : ");
                    mdlEmployee.employee_name = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine("Employee Name : " + mdlEmployee.employee_name);
                    Console.WriteLine("Input BirthDate : (yyyy-MM-dd)");

                    string brith_date = Console.ReadLine();
                    DateTime dDate;

                    if (DateTime.TryParse(brith_date, out dDate))
                    {
                        mdlEmployee.birth_date = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Date"); // <-- Control flow goes here
                        Console.WriteLine("Input BirthDate : (yyyy-MM-dd)");
                    }

                    Console.WriteLine("BirhDate : " + mdlEmployee.birth_date);
                    Console.WriteLine("");
                    Console.WriteLine("Input Description : ");
                    mdlEmployee.description = Console.ReadLine();
                    Console.WriteLine("Description : " + mdlEmployee.description);
                    Console.WriteLine("");
                    Console.WriteLine("Are You Want Save Data...? Yes/No");
                    ConsoleKeyInfo ckiSaveData = Console.ReadKey();
                    if (ckiSaveData.Key.ToString().ToUpper() == "YES")
                    {
                        if ((mdlEmployee.employee_name == null || mdlEmployee.employee_name == "") || (mdlEmployee.birth_date == null && mdlEmployee.birth_date == ""))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Data Not Valid.");
                            bolInput = false;
                            continue;
                        }
                        else
                        {
                            string result = DataEmployee.SaveDataEmployee(mdlEmployee);
                        }


                    }
                    else
                    {
                        // presses something other then Y
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Are You Want Delete Data...? Yes/No");

                    ConsoleKeyInfo ckiDeleteData = Console.ReadKey();
                    if (ckiDeleteData.Key.ToString().ToUpper() == "YES")
                    {

                        Console.WriteLine("Input Employee ID For Delete .....");
                        mdlEmployee.employee_id = Console.ReadLine();
                        string result = DataEmployee.DeleteDataEmployee(mdlEmployee.employee_id);
                    }
                    else
                    {
                        // presses something other then Y
                    }
                    bolInput = false;
                }

                Thread.Sleep(1000);
            }

           
        }
    }
}
