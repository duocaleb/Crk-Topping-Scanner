using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crk_Topping_Scanner
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        static void Main()
        {
            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Scanner());
        }
    }
}
