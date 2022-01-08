using System;
using static System.Console;
using System.Collections.Generic;


namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArtificialPondBuilder builder;

            Area area = new Area();

            builder = new ConcretePondBuilder();
            area.Construct(builder);
            builder.ArtificialPond.Show();

            builder = new PlasticPondBuilder();
            area.Construct(builder);
            builder.ArtificialPond.Show();

            builder = new MembraneBuilder();
            area.Construct(builder);
            builder.ArtificialPond.Show();

            ReadKey();
        }
    }
    class Area
    {
        public void Construct(ArtificialPondBuilder artificialPondBuilder)
        {
            artificialPondBuilder.BuildPit();
            artificialPondBuilder.FillingWater();
            artificialPondBuilder.FishLaunch();
            artificialPondBuilder.Planting();
        }
    }

    class ArtificialPond
    {
        private string _pondType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        public ArtificialPond(string pondType)
        {
            this._pondType = pondType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"ArtificialPond: {_pondType}");
            ForegroundColor = ConsoleColor.Yellow; 
            WriteLine($"\tType of pit: {_parts["pit"]}");
            WriteLine($"\tWater volume: {_parts["water volume"]}");
            WriteLine($"\tFloating fish: {_parts["fish"]}");
            WriteLine($"\tPlanted algae: {_parts["plants"]}\r\n");
        }
    }
    abstract class ArtificialPondBuilder
    {
        protected ArtificialPond artificialPond;

        public ArtificialPond ArtificialPond
        {
            get { return artificialPond; }
        }

        public abstract void BuildPit();
        public abstract void FillingWater();
        public abstract void Planting();
        public abstract void FishLaunch();
    }

    class ConcretePondBuilder : ArtificialPondBuilder
    {
        public ConcretePondBuilder() 
        {
            artificialPond = new ArtificialPond("ArtificialPond # 1");
        }

        public override void BuildPit()
        {
            artificialPond["pit"] = "concrete pit";
        }

        public override void FillingWater()
        {
            artificialPond["water volume"] = "2 000 liters";
        }

        public override void FishLaunch()
        {
            artificialPond["fish"] = "shark";
        }

        public override void Planting()
        {
            artificialPond["plants"] = "coral";
        }
    }

    class PlasticPondBuilder : ArtificialPondBuilder
    {
        public PlasticPondBuilder()
        {
            artificialPond = new ArtificialPond("ArtificialPond # 2");
        }

        public override void BuildPit()
        {
            artificialPond["pit"] = "plastic pit";
        }

        public override void FillingWater()
        {
            artificialPond["water volume"] = "750 liters";
        }

        public override void FishLaunch()
        {
            artificialPond["fish"] = "japanese carp";
        }

        public override void Planting()
        {
            artificialPond["plants"] = "red algae";
        }
    }

    class MembraneBuilder : ArtificialPondBuilder
    {
        public MembraneBuilder()
        {
            artificialPond = new ArtificialPond("ArtificialPond # 3");
        }

        public override void BuildPit()
        {
            artificialPond["pit"] = "pit covered with membrane";
        }

        public override void FillingWater()
        {
            artificialPond["water volume"] = "200 liters";
        }

        public override void FishLaunch()
        {
            artificialPond["fish"] = "crucian carp";
        }

        public override void Planting()
        {
            artificialPond["plants"] = "none";
        }
    }
}
