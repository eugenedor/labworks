using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPult.Abstract;
using MultiPult.Concrete;

namespace MultiPult
{
    class Program
    {
        static void Main(string[] args)
        {
            TV tv = new TV();
            Volume volume = new Volume();
            MultiPult.Concrete.MultiPult mPult = new MultiPult.Concrete.MultiPult();
            mPult.SetCommand(0, new TVOnCommand(tv));
            mPult.SetCommand(1, new VolumeCommand(volume));
            
            // включаем телевизор
            mPult.PressButton(0);
            // увеличиваем громкость
            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressButton(1);

            // действия отмены
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();

            Console.Read();
        }
    }
}
