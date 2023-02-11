using System;
using System.Collections.Generic;

namespace Observer.RealWorld
{
 

    public class Program
    {
        public static void Main(string[] args)
        {
    

            IBM ibm = new IBM("Banco BHD", 120.00);
            ibm.Attach(new Investor("Jose"));
            ibm.Attach(new Investor("Juan"));

           

            ibm.Price = 120.10;
            ibm.Price = 120.50;
            ibm.Price = 120.75;


            Console.ReadKey();
        }
    }

  
    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();

     
        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }


        public string Symbol
        {
            get { return symbol; }
        }
    }

  
    public class IBM : Stock
    {

        public IBM(string symbol, double price)
            : base(symbol, price)
        {
        }
    }


    public interface IInvestor
    {
        void Update(Stock stock);
    }


    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;

     

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notificar a {0} que {1} " +
                "cambio a {2:C}", name, stock.Symbol, stock.Price);
        }

        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
