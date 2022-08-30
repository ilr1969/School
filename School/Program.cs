using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class MainClass
{
    public class School
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public School(string s)
        {
            this.Name = s;
            Students = new List<Student>();
        }

        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("В школе " + Name + " нет учеников");
            }
            else
            {
                foreach (var i in Students)
                {
                    Console.WriteLine(i.FirstName + " " + i.LastName + " " + i.Age);
                }
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Student(string fn, string ln, int a)
        {
            FirstName = fn;
            LastName = ln;
            Age = a;
        }

    }
    public static void Main()
    {
        Console.WriteLine("Введите название школы");
        School s = new School(Console.ReadLine());
        Console.WriteLine("Школа " + s.Name + " успешно создана");
        while (true)
        {
            Console.WriteLine("Хотите посмотреть список всех учеников школы " + s.Name + " ? (Да/Нет)");
            if (Console.ReadLine().ToLower() == "да")
            {
                s.PrintStudents();
            }
            Console.WriteLine("Хотите добавить нового ученика? (Да/Нет)");
            if (Console.ReadLine().ToLower() == "да")
            {
                Console.WriteLine("Введите имя");
                string fn = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                string ln = Console.ReadLine();
                Console.WriteLine("Введите возраст");
                int a = Convert.ToInt32(Console.ReadLine());
                s.Students.Add(new Student(fn, ln, a));
                Console.WriteLine("Ученик " + fn + " " + ln + " " + a + " успешно добавлен");
            }
            Console.WriteLine("Хотите отчислить ученика? (Да/Нет)");
            if (Console.ReadLine().ToLower() == "да")
            {
                Console.WriteLine("Введите имя");
                string fn = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                string ln = Console.ReadLine();
                Console.WriteLine("Введите возраст");
                int a = Convert.ToInt32(Console.ReadLine());
                var ToDel = s.Students.Where(x => x.FirstName == fn && x.LastName == ln && x.Age == a);
                s.Students.Remove(ToDel.First());
                Console.WriteLine("Ученик " + fn + " " + ln + " " + a + " успешно отчислен");
            }
        }
    }
}