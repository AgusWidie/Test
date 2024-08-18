using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DataEmployee 
    {
        public static int employee_id = 0;
        public static int no = 1;
        public static string SaveDataEmployee(ModelEmployee data)
        {
            try
            {
                var data_employee = CollectionData.LstEmployee.OrderByDescending(x => x.employee_id).FirstOrDefault();
                if(data_employee == null)
                {
                    employee_id = 1000 + 1;
                    data.employee_id = employee_id.ToString();

                } else  {

                    employee_id = Convert.ToInt32(data_employee.employee_id) + 1;
                    data.employee_id = employee_id.ToString();
                }

                CollectionData.LstEmployee.Add(data);
                Console.WriteLine("");
                Console.WriteLine("Save Data Successfully.");

                Console.WriteLine("");
                Console.WriteLine("===========================================================================================");

                foreach(var employee in CollectionData.LstEmployee)
                {
                    Console.Write("Employee ID : " + employee.employee_id);
                    Console.Write("Employee Name : " + employee.employee_name);
                    Console.Write("Birthdate : " + employee.birth_date);
                    Console.Write("Description : " + employee.description);
                    Console.WriteLine("===========================================================================================");
                }

                return "Save Data Successfully.";
            }
            catch(Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("Error Save Data : " + ex.Message);
                return "Error Save Data : " + ex.Message;
            }
        }

        public static string DeleteDataEmployee(string employee_id)
        {
            try
            {
                var check_data = CollectionData.LstEmployee.Where(x => x.employee_id == employee_id).FirstOrDefault();
                if(check_data == null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Delete Data Employee ID : " + employee_id + " Not Found.");
                    return "Delete Data Employee ID : " + employee_id + " Not Found.";
                }

                CollectionData.LstEmployee.Remove(check_data);
                Console.WriteLine("");
                Console.WriteLine("Delete Data Successfully");

                Console.WriteLine("");
                Console.WriteLine("===========================================================================================");

                foreach (var employee in CollectionData.LstEmployee)
                {
                    Console.Write("Employee ID : " + employee.employee_id);
                    Console.Write("Employee Name : " + employee.employee_name);
                    Console.Write("Birthdate : " + employee.birth_date);
                    Console.Write("Description : " + employee.description);
                    Console.WriteLine("===========================================================================================");
                }

                return "Delete Data Employee ID : " + employee_id.ToString() + " Successfully.";
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("Error Delete Data : " + ex.Message);
                return "Error Delete Data : " + ex.Message;
            }
        }
    }
}
