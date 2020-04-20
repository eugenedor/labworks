using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Abstract;

namespace Observer.Concrete
{
    class Stock : IObservable
    {
        StockInfo sInfo; // информация о торгах
        List<IObserver> observers;

        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(69, 89);
            sInfo.Euro = rnd.Next(79, 99);
            NotifyObservers();
        }
    }
}
