

namespace Mine_Sweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            Application app;
            do
            {
                app = new Application();
                app.Start();
            }
            while (!app.QuitApp);
        }
    }
}
