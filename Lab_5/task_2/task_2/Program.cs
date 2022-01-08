using System;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler t1 = new Teacher();
            Handler t2 = new Teacher();
            Handler t3 = new Teacher();
            Handler s1 = new SeniorLecturer();

            t1.SetSuccessor(t2);
            t2.SetSuccessor(t3);

            int i = 0;
            while (true)
            {
                t1.CheckWork();
                i++;
                if (i == 3)
                {
                    t1.SetSuccessor(s1);
                    t1.CheckWork();
                    break;
                }
            }
            
            Console.ReadKey();
        }
    }

    abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void CheckWork();
    }

    class Teacher : Handler
    {
        public override void CheckWork()
        {
            if (new Random().Next(1, 10) % 3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your exam was checked)");
                Console.ResetColor();
                Environment.Exit(1);
            }
            else if (successor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("All teachers are busy, no one can check the work(");
                return;
            }
            else if (successor != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This teachers is busy(");
                successor.CheckWork();
            }
        }
    }

    class SeniorLecturer : Handler
    {
        public override void CheckWork()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Your exam was checked by a senior teacher");
            Console.ResetColor();
        }
    }

}
