using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Department> objDept1 = new List<Department>()
        {
        new Department{DepId=1,DepName="Software"},
        new Department{DepId=2,DepName="Finance"},
        new Department{DepId=3,DepName="Health"}
        };

            List<Employee> objEmp1 = new List<Employee>()
            {
            new Employee { EmpId=1,Name = "Akshay Tyagi", DeptId=1 },
            new Employee { EmpId=2,Name = "Vishi Tyagi", DeptId=1 },
            new Employee { EmpId=3,Name = "Arpita Rai", DeptId=2 },
            new Employee { EmpId=4,Name = "Mani", DeptId =2},
            new Employee { EmpId=5,Name = "Madhav Sai"}
            };

            //left join 
            Console.WriteLine("-------Left join--------");
            var result = from e in objEmp1
                         join d in objDept1
                         on e.DeptId equals d.DepId into empdept
                         from ed in empdept.DefaultIfEmpty()
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = ed == null ? "No Department" : ed.DepName

                         };

            foreach (var item in result)
            {
                Console.WriteLine("Employee :" + item.EmployeeName + "| Department" + item.DepartmentName);
            }


            //inner join 
            Console.WriteLine("-------Inner join--------");
            var result1 = from d in objDept1
                          join e in objEmp1
                          on d.DepId equals e.DeptId
                          select new
                          {
                              EmployeeName = e.Name,
                              DepartmentName = d.DepName
                          };
            foreach (var item in result1)
            {
                Console.WriteLine("Employee :" + item.EmployeeName + "| DepartmentName :" + item.DepartmentName);
            }


            Console.WriteLine("-------Cross join--------");
            var result2 = from d in objDept1
                          from e in objEmp1
                          select new
                          {
                              EmployeeName = e.Name,
                              DepartmentName = d.DepName

                          };

            foreach (var item in result2)
            {
                Console.WriteLine("Employee :" + item.EmployeeName + "| DepartmentName :" + item.DepartmentName);
            }

            Console.WriteLine("-------Group join--------");
            var result3 = from d in objDept1
                          join e in objEmp1
                          on d.DepId equals e.DeptId
                          into empdept
                          select new
                          {
                              DepartmentName = d.DepName,
                              EmployeeName = from emp2 in empdept
                                             orderby emp2.Name
                                             select emp2
                          };
            foreach (var item in result3)
            {
                Console.WriteLine("DepartmentName :" + item.DepartmentName);

                foreach (var emp in item.EmployeeName)
                {
                    Console.WriteLine("EmployeeName :" + emp.Name);
                }
            }

            string[] count1 = { "India", "USA", "UK", "Australia" };
            string[] count2 = { "India", "Canada", "UK", "China" };


            Console.WriteLine("-------Union--------");

            var result4 = count1.Union(count2);
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Intersection--------");

            var result5 = count1.Intersect(count2);
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Distinct--------");

            var result6 = count1.Distinct(StringComparer.OrdinalIgnoreCase);
            foreach (var item in result6)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Except--------");

            var result7 = count1.Except(count2);
            foreach (var item in result7)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Concat--------");

            var result8 = count1.Concat(count2);
            foreach (var item in result8)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Range--------");

            IEnumerable<int> obj1 = Enumerable.Range(100, 10);
            foreach (var item in obj1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Repeat--------");

            IEnumerable<int> obj2 = Enumerable.Repeat(100, 10);
            foreach (var item in obj2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------string array--------");

            IEnumerable<string> res = from a in count1
                                      where a.ToLowerInvariant().StartsWith("u")
                                      select a;
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------Order By--------");
            var res1 = objEmp1.OrderBy(e => e.Name);
            foreach (var item in res1)
            {
                Console.WriteLine("employee :" + item.Name);
            }

            Console.WriteLine("-------Order By Descending--------");
            var res2 = objEmp1.OrderByDescending(e => e.Name);
            foreach (var item in res1)
            {
                Console.WriteLine("employee :" + item.Name);
            }
            Console.WriteLine("-------Then By--------");
            var res3 = objEmp1.OrderBy(e => e.Name).ThenBy(e => e.DeptId);
            foreach (var item in res3)
            {
                Console.WriteLine("employee :" + item.Name);
            }

            Console.WriteLine("-------Find the number and its square of an array which is more than 20--------");
            var arr = new[] { 1, 3, 5, 4, 2, 6, 2 };
            var output = from a in arr
                         let SQrno = a * a
                         where SQrno > 20
                         select SQrno;
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------- display the number and frequency of number from giving array--------");
            var output1 = from a in arr
                          group a by a into y
                          select y;
            foreach (var item in output1)
            {
                Console.WriteLine("Number :" + item.Key + " Frequency :" + item.Count());
            }

            Console.WriteLine("------- display the Character and frequency of character in given string--------");
            string str = "Apple";
            var output2 = from a in str
                          group a by a into y
                          select y;
            foreach (var item in output2)
            {
                Console.WriteLine("Number :" + item.Key + " Frequency :" + item.Count());
            }

            Console.WriteLine("------- find the string which starts and ends with a specific character.--------");

            //Console.WriteLine("Enter Starting Character :");
            // char ch = (char)Console.Read();
            //string chst = ch.ToString();

            //Console.WriteLine("Enter Last Character :");
            // ch = (char)Console.Read();
            //string chen = ch.ToString();

            //var output3 = from x in count1
            //              where x.StartsWith(chst)
            //              where x.EndsWith(chen)
            //              select x;

            //foreach (var item in output3)
            //{
            //    Console.WriteLine(item);
            //}


            Console.WriteLine("------- Display top nth record--------");

            List<int> number = new List<int>() { 1, 3, 2, 5, 4, 6, 8, 6, 78, 8 };
            number.Sort();
            foreach (var item in number.Take(5))
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("-------find uppercase words--------");
            string name = "THIS is Linq Demo";
            var uppercase = name.Split(' ').Where(x => String.Equals(x, x.ToUpper(), StringComparison.Ordinal));

            foreach (var item in uppercase)
            {
                Console.WriteLine(item);

            }
            //When we create a delegate, Access modifier, return type, number of arguments,
            //and their data types of the delegate must and should be the same as Access modifier, 
            //return type, number of arguments and their data types of the function that we want to refer to.

            Console.WriteLine("-------Using Delegates--------");
            program obj = new program();
            Delegates objdel = new Delegates(obj.Add);
            objdel += obj.Substract;
            objdel += obj.Multiply;
            objdel += obj.Divide;

            objdel(5, 2);
            objdel -= obj.Substract;

            objdel(2, 3);

            Console.WriteLine("-------Array Sorting--------");
            var arr = { };


        }
        public delegate void Delegates(int a, int b);
        class Department
        {

            public int DepId { get; set; }
            public string DepName { get; set; }
        }
        class Employee
        {
            public int EmpId { get; set; }

            public string Name { get; set; }

            public int DeptId { get; set; }
        }


        class program
        {
            public void Add(int X,int Y)
            {
                Console.WriteLine("Addition is :" + (X + Y));
            }
            public void Substract(int X, int Y)
            {
                Console.WriteLine("Substraction is :" + (X - Y));
            }
            public void Multiply(int X, int Y)
            {
                Console.WriteLine("Multiplication is :" + (X * Y));
            }
            public void Divide(int X, int Y)
            {
                Console.WriteLine("Division is :" + (X / Y));
            }
        }
    }



}


