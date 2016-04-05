using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpiresOOP.Interfaces
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Name { get; set; }

        IList<string> Parameters { get; set; }

    }
}
