using System;
using System.Collections.Generic;

namespace task_2
{
    public class Task
    {
        public string name;
        public int mark;
    }

    public class Modul
    {
        public List<Task> tasks;
    }

    public abstract class Abst_Performance
    {
        public abstract void Doing_Task(List<Modul> course);
    }

    public class Task_Performance : Abst_Performance
    {
        public override void Doing_Task(List<Modul> course)
        {
            foreach(Task t in course[course.Count-1].tasks)
                Console.WriteLine($"  Yes, I do {t.name} ))");
        }
    }

    public class Check_Previous_Task : Abst_Performance
    {
        Task_Performance perf = new Task_Performance();

        public override void Doing_Task(List<Modul> course)
        {
            if(CheckPrevModule(course))
              perf.Doing_Task(course);   
        }

        private bool CheckPrevModule(List<Modul> course)
        {
            for (int i = 0; i < course.Count - 1; i++)
            {
                if (course[i].tasks == null)
                {
                    Console.WriteLine("First do the tasks from the previous module!");
                    return false;
                }
                foreach (Task t in course[i].tasks)
                {
                    if (t.mark == 0 || t.mark <= 3)
                    {
                        Console.WriteLine($"First correct the grades for the module {i+1}({t.name} ~ mark:{t.mark})!");
                        return false;
                    }
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task() { name = "Task 1"});
            tasks.Add(new Task() { name = "Task 2" });
            tasks.Add(new Task() { name = "Task 3" });
            tasks.Add(new Task() { name = "Task 4" });
            tasks.Add(new Task() { name = "Task 5" });
            tasks.Add(new Task() { name = "Task 6" });
            tasks.Add(new Task() { name = "Task 7" });
            tasks.Add(new Task() { name = "Task 8" });
            tasks.Add(new Task() { name = "Task 9" });
            tasks.Add(new Task() { name = "Task 10"});

            Modul prev = new Modul();
            List<Task> prevTasks = new List<Task>();
            prev.tasks = prevTasks;
            for (int i = 0; i < 4; i++)
            {
                Random rand = new Random();
                int num = rand.Next(1, tasks.Count);
                prevTasks.Add(tasks[num]);
                prevTasks[i].mark = rand.Next(1, 6);
                //prevTasks[i].mark = 4;
            }

            Modul current = new Modul();
            List<Task> currTasks = new List<Task>();
            current.tasks = currTasks;
            for (int i = 0; i < 4; i++)
            {
                Random rand = new Random();
                int num = rand.Next(1, tasks.Count);
                currTasks.Add(tasks[num]);
            }

            List<Modul> course = new List<Modul>();
            course.Add(prev);
            course.Add(current);

            Check_Previous_Task doT = new Check_Previous_Task();
            doT.Doing_Task(course);

            Console.ReadKey();
        }
    }
}
