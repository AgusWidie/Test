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
                        Console.WriteLine("Invalid BirthDate"); // <-- Control flow goes here
                        Console.WriteLine("Input BirthDate : (yyyy-MM-dd)");
                    }

                    string resultData = "";
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
                            Console.Clear();
                            bolInput = false;
                            continue;
                        }
                        else
                        {
                            resultData = DataEmployee.SaveDataEmployee(mdlEmployee);
                        }


                    }
                    else
                    {
                        // presses something other then Y
                    }

                    if(resultData.Substring(0,5) == "Error")  {
                        Console.Clear();
                        bolInput = false;
                        continue;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Are You Want Delete Data...? Yes/No");

                    ConsoleKeyInfo ckiDeleteData = Console.ReadKey();
                    if (ckiDeleteData.Key.ToString().ToUpper() == "YES")
                    {

                        Console.WriteLine("Input Employee ID For Delete .....");
                        mdlEmployee.employee_id = Console.ReadLine();
                        resultData = DataEmployee.DeleteDataEmployee(mdlEmployee.employee_id);
                    }
                    else
                    {
                        // presses something other then Y
                    }
                    Console.Clear();
                    bolInput = false;
                }

                Thread.Sleep(1000);
            }

           
        }
    }
}
