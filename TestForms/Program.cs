using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForms
{
    static class Program
    {
        //Global Variables and Classes
        public static XmlLoader xLoader = new XmlLoader();
        public static PoolManager poolManager = new PoolManager();
        public static bool SplashRan = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            //New
            FormProvider.MainMenu.Show();
            Application.Run();


            //Old creating a new MainMenu object to create the form
            //MainMenuForm main = new MainMenuForm();
            //main.Show();
            //Application.Run();

            //Old passing the main form as a parameter
            //This caused the application to close when the main form was closed
            //Application.Run(new main());
        }
    }
}
