using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.Abstract;

namespace Strategy.Concrete
{
    class Car
    {
        protected int passengers; // кол-во пассажиров
        protected string model; // модель автомобиля

        public IMovable Movable { private get; set; }

        public Car(int num, string model, IMovable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }

        public void Print()
        {
            Console.WriteLine($"Модель {model}, кол-во пассажиров {passengers}");
        }

        public void Move()
        {
            Movable.Move();
        }
    }
}
