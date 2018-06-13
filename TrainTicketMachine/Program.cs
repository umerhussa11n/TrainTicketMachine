using System;
using System.Windows.Forms;


namespace TrainTicketMachine
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
            
            // Save in the Cache ..
            Application.Run(new Form1());
        }
    }
}
