using System;


namespace ConsoleApp1
{
    public interface ICondition
    {
        void ShowInfo();
    }
    public interface IMovement
    {
        void ShowInfo();
    }
    public class DevelopEventArgs : EventArgs
    {
        public int developmentLevel;
        public int humanCount;

        public DevelopEventArgs(int dL, int hC)
        {
            this.developmentLevel = dL;
            this.humanCount = hC;
        }

        public DevelopEventArgs() : this(0, 0) { }
    }
    public abstract class Planet
    {
        abstract public void Develop(Rocket r, DevelopEventArgs dEvent);
    }

    public class Sun : ICondition
    {
        private const int temperature = 5780;
        private const int mass = 2 * 10 ^ 30;

        public void ShowInfo()
        {
            Console.WriteLine($"[INFO] Temperature: {temperature}K\n\tWeight: {mass}kg");
        }
        static public void Illuminate()
        {
            Console.WriteLine("\tThe sun will shine for another 2 million years");
        }
        static public string Flash(string s)
        {
            return "\t!!A giant flash has been seen in the sun" + s;
        }
    }

    public class Mars : Planet, IMovement, ICondition
    {
        private const int temperature = 27;
        private const int mass = 6 * 10^23;
        private const int satellites = 2;
        public override void Develop(Rocket r, DevelopEventArgs dEvent)
        {
            Console.WriteLine($"{dEvent.humanCount} people flew to Mars on {r.name}");
            if (dEvent.developmentLevel <= 30)
                Console.WriteLine($"The rover is out, we start observing..");
            else
                Console.WriteLine("Development process started... ");
        }

        void IMovement.ShowInfo()
        {
            Console.WriteLine("[INFO]Rotation period: 24 hours 39 minutes 35.244 seconds");
        }

        void ICondition.ShowInfo()
        {
            Console.WriteLine($"[INFO] Temperature: {temperature}C\n\tWeight: {mass}kg\n\tNumber of satellites: {satellites}");
        }
    }
    public class Venus : Planet, IMovement, ICondition
    {
        private const int temperature = 127;
        private const int mass = 5 * 10 ^ 24;
        private const int satellites = 0;
        public override void Develop(Rocket r, DevelopEventArgs dEvent)
        {
            Console.WriteLine($"{dEvent.humanCount} people flew to Venus on {r.name}");
            if (dEvent.developmentLevel == 0)
                Console.WriteLine($"it's too hot here...");
            else
                Console.WriteLine("Оur technology allows you to stay clean regardless of the temperature...");
        }


        void IMovement.ShowInfo()
        {
            Console.WriteLine("[INFO]Rotation period: 243 Earth days ");
        }

        void ICondition.ShowInfo()
        {
            Console.WriteLine($"[INFO] Temperature: {temperature}C\n\tWeight: {mass}kg\n\tNumber of satellites: {satellites}");
        }
    }
    public delegate void DvelopingtingHandle(Rocket r, DevelopEventArgs dEvent);
    public class Rocket
    {
        public event DvelopingtingHandle RocketEvent;
        public string name;
        private int countHuman;
        public int CountHuman
        {
            get { return countHuman; }
            set
            {
                if (value <= 0)
                    throw new RocketException("People must participate in the expedition!", value);
                else if(value > 100)
                    throw new RocketException("It`s too many people for 1 expedition!", value);
                else
                    countHuman = value;
            }
        }

        public Rocket(string name)
        {
            this.name = name;
        }

        public void StartDeparture()
        {
            int dL, hC;
            DevelopEventArgs dargs;
            try
            {
                Console.Write("Enter level of development: ");
                dL = Int32.Parse(Console.ReadLine());

                Console.Write("Enter number of astronauts : ");
                hC = Int32.Parse(Console.ReadLine());
                dargs = new DevelopEventArgs(dL, hC);
            }
            catch
            {
                dargs = new DevelopEventArgs();
            }

            Console.WriteLine($"---Rocket {this.name} takes off, good luck---");
            if (RocketEvent != null)
                RocketEvent((Rocket)this, dargs);

        }
    }
    public static class RocketExtension
    {
        public static string StartExpedition(this Rocket r, string place)
        {
            return "The rocket goes on an expedition to " + place;
        }
    }
    class Space
    {
        Planet[] planets;

        public Space(Rocket rocket)
        {
            planets = new Planet[2];
            planets[0] = new Mars();
            planets[1] = new Venus();

            foreach (Planet p in planets)
                rocket.RocketEvent += new DvelopingtingHandle(p.Develop);
        }
    }

    class RocketException : ArgumentException
    {
        public int Value { get; }

        public RocketException()
            : base("Incorrect count of human.")
        {
        }
        public RocketException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }


    public delegate void IlluminateHendler(Sun sun);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t---------INTERFACES---------");
            Console.WriteLine("\t|SUN|");
            Sun sun = new Sun();
            sun.ShowInfo();
            Mars mars = new Mars();
            Console.WriteLine("\t|MARS|");
            ICondition cM = mars;
            IMovement mM = mars;
            cM.ShowInfo();
            mM.ShowInfo();
            Venus varus = new Venus();
            Console.WriteLine("\t|VARUS|");
            ICondition cV = varus;
            IMovement mV = varus;
            cV.ShowInfo();
            mV.ShowInfo();

            Console.WriteLine("\t\t\t--------DELEGATE EVENT--------");    
            Rocket rocket = new Rocket("Apolon");
            Space space = new Space(rocket);
            rocket.StartDeparture();

            Console.WriteLine("\tHow long will the sun live?");

            //анонимный метод
            IlluminateHendler handler1 = delegate
            {
                Console.WriteLine("\tThe sun will shine for another 4 million years") ;
            };
            handler1(sun);

            //lambda-выражение
            IlluminateHendler handler2 = (sun) =>
            Console.WriteLine("\tThe sun will shine for another 3 million years") ;
            handler2(sun);

            //Actoin
            Action actiondelegate = Sun.Illuminate;

            //Func
            Func<string, string> iluminate = Sun.Flash;
            string str = " lasting 15 minutes!!!";
            Console.WriteLine(iluminate(str));


            Console.Write("The rocket is sent on an expedition enter the location position: ");
            string place = Console.ReadLine();
            Console.WriteLine(rocket.StartExpedition(place));


            Console.WriteLine("\t\t\t--------EXEPTION--------");
            try
            {
                Rocket r = new Rocket("Apol") { CountHuman = -2 };
            }
            catch (RocketException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Invalid value: {ex.Value}");
            }

            try
            {
                Rocket r = new Rocket("Apol2") { CountHuman = 0 };
            }
            catch (RocketException ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }

            Console.ReadKey();
        }
    }
}
