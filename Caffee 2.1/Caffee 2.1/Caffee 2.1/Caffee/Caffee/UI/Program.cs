using Caffee;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Platform.DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "database.db");
            Application.Run(new Form1());
        }
    }
}
