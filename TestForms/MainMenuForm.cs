using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForms
{
    public partial class MainMenuForm : Form
    {
        private bool menuButtonPressed = false;

        public MainMenuForm()
        {
            //Thread used to run start up splash screen 
            if (Program.SplashRan == false)
            {
                Program.SplashRan = true;
                Thread splashThread = new Thread(new ThreadStart(runSplash));
                splashThread.Start();
                Thread.Sleep(5000); //TODO Make Parameter for how long the splash screen is up for 
                splashThread.Abort();
            }
            //End SplashScreen Start Up
            InitializeComponent();
        }

        //Function used to run the Splash Screen 
        public void runSplash()
        {
            Application.Run(FormProvider.SplashScreen);
        }

        //Button click for opening the RosterDisplay Form
        private void button1_Click(object sender, EventArgs e)
        {
            menuButtonPressed = true;
            FormProvider.RosterDisplay.Show();
            FormProvider.MainMenu.Close();
        }

        //Button click for opening the RosterLoad Form
        private void button2_Click(object sender, EventArgs e)
        {
            menuButtonPressed = true;
            FormProvider.RosterLoad.Show();
            FormProvider.MainMenu.Close();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (menuButtonPressed)
            {
                menuButtonPressed = false;
                return;
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Do you really want to close this application", "Exit", MessageBoxButtons.YesNo);
                if(dialog == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else if(dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
