using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Programming_Language
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application
            Application.EnableVisualStyles();

            // Set default text rendering compatibility
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of the random number generator
            IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

            // Run the application with the main form, passing the random number generator
            Application.Run(new Form1(randomNumberGenerator));
        }
    }
}
