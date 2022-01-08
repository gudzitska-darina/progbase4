using static System.Console;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = 15000;

            FinancialSaving finance = new FinancialSaving();

            finance.SetAccumulationStrategy(new BuyingCurrency());
            finance.SaveFinancial(money);

            finance.SetAccumulationStrategy(new PutDeposit());
            finance.SaveFinancial(money);

            finance.SetAccumulationStrategy(new BuyShares());
            finance.SaveFinancial(money);

            ReadKey();
        }
    }
    abstract class AccumulationStrategy
    {
        public abstract void SaveMoney(int amound);
    }

    class BuyingCurrency : AccumulationStrategy
    {
        public override void SaveMoney(int amound)
        {
            WriteLine($"You have exchanged {amound} UAH for dollars)\nYour current balance: {amound / 27 }$");
        }
    }

    class PutDeposit : AccumulationStrategy
    {
        public override void SaveMoney(int amound)
        {
            WriteLine($"\nYou put {amound} UAH on a deposit at 10 % per annum.\n" +
                $"The bank will save your savings and in a year you will have {amound + amound * 0.1} UAH");

        }
    }

    class BuyShares : AccumulationStrategy
    {
        public override void SaveMoney(int amound)
        {
            WriteLine($"\nYou have successfully bought Apple shares for {amound} UAH. Congratulations))");
        }
    }

    class FinancialSaving
    {
        private AccumulationStrategy _accumulationStrategy;

        public void SetAccumulationStrategy(AccumulationStrategy accumulationStrategy)
        {
            this._accumulationStrategy = accumulationStrategy;
        }

        public void SaveFinancial(int num)
        {
            _accumulationStrategy.SaveMoney(num);
        }
    }
}
