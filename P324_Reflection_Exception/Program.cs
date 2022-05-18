using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P324_Reflection_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Homework
            //Product product = new Product("Milk",1,12.9d);
            //Product product1 = new Product("Milk",10,10.2d);
            //Product product2 = new Product("Milk",3,18.32d);
            //Product product3 = new Product("Milk",3,20.0d);

            //List<Product> products = new List<Product>
            //{
            //    product,
            //    product1,
            //    product2,
            //    product3
            //};

            //Order order = new Order(products);

            //order.MakeOrder();
            #endregion

            #region Reflection
            //Assembly assembly = Assembly.GetExecutingAssembly();

            //var classes = assembly.GetTypes();

            //foreach (var clas in classes)
            //{
            //Console.WriteLine("Class: "+ clas.Name);
            // Field
            //foreach (var field in clas.GetFields())
            //{
            //    Console.WriteLine(field);
            //}

            //Properties
            //foreach (var property in clas.GetProperties())
            //{
            //    Console.WriteLine(property);
            //}

            //Methods
            //foreach (var method in clas.GetMethods())
            //{
            //    Console.WriteLine(method);
            //}
            //}

            //var studentType = assembly.GetType("P324_Reflection_Exception.Student");
            //Console.WriteLine(studentType);
            //var fullnameField = studentType.GetField("StudentFullname");
            //Student student = new Student();
            //student.StudentFullname = "Jamal";
            //string fullname = fullnameField.GetValue(student).ToString();

            //Console.WriteLine(fullname);

            //fullnameField.SetValue(student,"Khalil");

            //Console.WriteLine(fullnameField.GetValue(student));

            //var pointField = studentType.GetField("Point", BindingFlags.NonPublic | BindingFlags.Instance);

            //Console.WriteLine(pointField.GetValue(student));

            //pointField.SetValue(student, "it can change");

            //Console.WriteLine(pointField.GetValue(student));

            //Human human = new Human
            //{
            //    Name = "Khalilbey",
            //    Surname = "Khalilbeyli"
            //};

            //Human human1 = new Human
            //{
            //    Name = "Jamal",
            //    Surname = null
            //};

            //Console.WriteLine(human.Surname);

            //human.Update(human1);
            //Console.WriteLine(human.Surname);
            #endregion

            #region Exception

            try
            {
                //Format exception
                //int num = int.Parse("5a");

                //Index out of range

                //int[] arr = new int[5];

                //Console.WriteLine(arr[5]);

                //Divide by zero
                //int five = 5;
                //int zero = 0;
                //int number = five / zero;

                //List<int> list = new List<int>();

                //list.Add(1);
                //list.Add(12);
                //list.Add(13);
                //list.Add(14);

                //list.First(x=>x==30);
                Student student = new Student();
                //student.Numbers.Add(5);
                student.Age = 17;
                student.CheckAge();
            }
            
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);



            }
            //catch(IndexOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(StudentAgeOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch(Exception e)
            //{
            //    throw new Exception("My problem");
            //}
            finally
            {
                Console.WriteLine("After throw");
            }
           
            Console.WriteLine("After exception");
            #endregion

        }
    }

    static class Extension
    {
        public static T Update<T>(this T oldModel, T newModel) where T : class, new()
        {
            oldModel.GetType().GetProperties().ToList().ForEach(op =>
            {
                newModel.GetType().GetProperties().ToList().ForEach(np =>
                {
                    if(op.Name == np.Name)
                    {
                        if(op.GetValue(newModel) != null)
                        {
                            op.SetValue(oldModel, np.GetValue(newModel));
                        }
                    }
                });
            });
            return oldModel;
        }
    }

    class Student
    {
        public List<int> Numbers;
        public string StudentFullname;
        public byte Age { get; set; }

        string Point = "This is private field";

        public void CheckAge()
        {
            if (Age < 18)
            {
                throw new StudentAgeOutOfRangeException();
            }
            else
            {
                Console.WriteLine("okaydir");
            }
        }
    }

    class Human
    {
        
        public int Test { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
