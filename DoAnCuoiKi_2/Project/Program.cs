using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new dothi());
        }

        public class DoThi
        {
            int Value1, Value2;
            public DoThi(int value1, int value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            public DoThi(int X)
            {
                Value1 = X;
                Value2 = -1;
            }
        }
    }
}
