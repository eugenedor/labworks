using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Abstract;

namespace Observer.Concrete
{
    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable stock;

        public Broker(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.USD > 79)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }
}
