using System;
using System.Collections.Generic;
using static System.Console;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BookManager manager = new BookManager();

            Book b1 = new Book("Perfume: The Story of a Murderer", "AO12345", false, "Old Lion");
            b1.SetNumPage(500);
            manager["book without img"] = b1;

            Book b2 = new Book("Alice in Wonderland", "AM09876", true, "Old Lion");
            b2.SetNumPage(150);
            manager["book with img"] = b2;

            WriteLine($"Сirculation for {b1._title}:");
            for (int i = 0; i < 5; i++)
            {
                Book clone1 = manager["book without img"].Clone() as Book;
                clone1.SetSeria("AO1234"+i);
                clone1.ShowInfo();
            }
            WriteLine("");

            WriteLine($"Сirculation for {b2._title}:");
            for (int i = 0; i < 5; i++)
            {
                Book clone2 = manager["book with img"].Clone() as Book;
                clone2.SetSeria("AM0987" + i);
                clone2.ShowInfo();
            }
            
            ReadKey();
        }
    }

    abstract class BookProtoype
    {
        public abstract BookProtoype Clone();
    }

    class Book : BookProtoype
    {
        public string _title;
        private string _seria;
        private bool _availabilityImg;
        private string _publication;
        private int _numOfPage;

        public Book(string t, string s, bool img, string p)
        {
            this._title = t;
            this._seria = s;
            this._availabilityImg = img;
            this._publication = p;
        }

        public void SetNumPage(int n)
        {
            _numOfPage = n;
        }

        public void SetSeria(string n)
        {
            _seria = n;
        }
        public override BookProtoype Clone()
        {
            return this.MemberwiseClone() as BookProtoype;
        }

        public void ShowInfo()
        {
            WriteLine($"|{this._title}| — #{this._seria}\n\t" +
                $" Publishinghouse: {this._publication} | Pictures: {this._availabilityImg}\n\t Pages: {this._numOfPage}");
        }
    }

    class BookManager
    {
        private Dictionary<string, BookProtoype> _books =
      new Dictionary<string, BookProtoype>();

        
        public BookProtoype this[string key]
        {
            get { return _books[key]; }
            set { _books.Add(key, value); }
        }

    }
}
