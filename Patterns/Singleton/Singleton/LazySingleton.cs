using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Singleton
{
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());

        LazySingleton()
        {
            Log = LogManager.GetLogger(GetType().FullName);
        }

        public Logger Log { get; private set; }

        public static LazySingleton Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}
