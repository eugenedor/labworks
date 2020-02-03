using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LazySingleton.Instance.Log.Info("info message start");

                var text = Console.ReadLine();                
                LazySingleton.Instance.Log.Info($"{text}");
                Console.ReadKey();

                //Logger log = LogManager.GetCurrentClassLogger();
                //log.Info("info message");
            }
            catch (Exception ex)
            {
                LazySingleton.Instance.Log.Info($"{ex.Message}");
            }
            finally
            {
                LazySingleton.Instance.Log.Info("info message end");
            }
        }
    }
}
