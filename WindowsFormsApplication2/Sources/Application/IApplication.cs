using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2.Sources.Application
{
    interface IApplication
    {
        void start();
        void stop();

        string getAppState();

        string getAppName();
        string getCurrHost();
    }
}
