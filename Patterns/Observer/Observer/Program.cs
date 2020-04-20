using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Concrete;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);
           
            // имитация торгов
            stock.Market();
            
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            
            // имитация торгов
            stock.Market();

            Console.Read();
        }
    }
}
