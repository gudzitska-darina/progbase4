using System;
using System.Collections.Generic;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentGroup course = new StudentGroup("course");
            course.Add(new Student("headman of course"));
            course.Add(new Student("deputy head of course"));

            StudentGroup group1 = new StudentGroup("KP-02");
            course.Add(group1);
            group1.Add(new Student("headman of group"));

            Student st1 = new Student("Sasha");
            group1.Add(st1);


            course.ViewInfo(0);
            Console.WriteLine("\n\r");
            st1.PassExam();

            Console.ReadKey();
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void ViewInfo(int step);
        public abstract void PassExam();
    }

    class StudentGroup : Component
    {
        private List<Component> _children = new List<Component>();

        // Constructor
        public StudentGroup(string name)
          : base(name)
        {
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void ViewInfo(int step)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String(' ', step) + $"#{name}");

            foreach (Component component in _children)
            {
                component.ViewInfo(step + 3);
            }
        }

        public override void PassExam()
        {
            Console.WriteLine("For the group to pass the exam, 70% of the students need to pass.");
        }
    }

    class Student : Component
    {
        // Constructor
        public Student(string name)
          : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Nothing can be added to the student");
        }

        public override void ViewInfo(int step)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new String(' ', step) + name);
        }

        public override void PassExam()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Random rand = new Random();
            if (rand.Next() % 2 == 0)
                Console.WriteLine($"Student {this.name} pass the exam))");
            else
                Console.WriteLine($"Sorry, {this.name}, you must retake((");
        }
    }
}

