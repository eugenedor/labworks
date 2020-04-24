using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSysComposite.Abstract;

namespace FileSysComposite.Concrete
{
    class File : Component
    {
        public File(string name) 
            : base(name)
        { }
    }
}
