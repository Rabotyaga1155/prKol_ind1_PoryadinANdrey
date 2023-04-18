using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace indCollecForm
{
    public partial class Form1 : Form
    {
        Queue<string> male = new Queue<string>();
        Queue<string> female = new Queue<string>();
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Employee> employees = new List<Employee>();
            using (StreamReader reader = new StreamReader("rabfirm.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] employeeData = line.Split(',');
                    Employee employee = new Employee
                    {
                        LastName = employeeData[0].Trim(),
                        FirstName = employeeData[1].Trim(),
                        MiddleName = employeeData[2].Trim(),
                        Gender = employeeData[3].Trim(),
                        Age = int.Parse(employeeData[4].Trim()),
                        Salary = int.Parse(employeeData[5].Trim())
                    };
                    employees.Add(employee);
                }
            }

            Queue<Employee> maleEmployees = new Queue<Employee>();
            Queue<Employee> femaleEmployees = new Queue<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.Gender == "Мужской")
                {
                    maleEmployees.Enqueue(employee);
                }
                else if (employee.Gender == "Женский")
                {
                    femaleEmployees.Enqueue(employee);
                }
            }


            Queue<Employee> resultQueue = new Queue<Employee>();
            while (maleEmployees.Count > 0 || femaleEmployees.Count > 0)
            {
                if (maleEmployees.Count > 0)
                {
                    resultQueue.Enqueue(maleEmployees.Dequeue());
                }
                if (femaleEmployees.Count > 0)
                {
                    resultQueue.Enqueue(femaleEmployees.Dequeue());
                }
            }

            
            listBox1.Items.Clear();
            foreach (Employee employee in resultQueue)
            {
                listBox1.Items.Add(string.Format("{0} {1} {2} {3} {4} {5}", employee.LastName, employee.FirstName, employee.MiddleName, employee.Gender, employee.Age, employee.Salary));
            }
        }
    }

    internal class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
 
