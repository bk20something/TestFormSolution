using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForms
{
    public partial class RosterDisplayForm : Form
    {
        private bool menuButtonPressed = false; //Check if close state is result of button on form

        public RosterDisplayForm()
        {
            InitializeComponent();
        }

        //Back Button
        private void button1_Click(object sender, EventArgs e)
        {
            menuButtonPressed = true;
            FormProvider.RosterDisplay.Close();
            FormProvider.MainMenu.Show();
        }

        //Test roster button. This to be removed after debug
        private void button2_Click(object sender, EventArgs e)
        {
            //This button should be removed it only purpose is to test roster loading
            System.Diagnostics.Debug.WriteLine("Alert message");
            System.Diagnostics.Debug.WriteLine(Program.xLoader.roster._show());
        }

        //Add Solider Button
        private void button3_Click(object sender, EventArgs e)
        {
            menuButtonPressed = true;
            FormProvider.AddSolider.Show();
            FormProvider.RosterDisplay.Close();
        }

        //Begin Application Button
        private void button4_Click(object sender, EventArgs e)
        {
            menuButtonPressed = true;
            FormProvider.SelectOutPool.Show();
            FormProvider.RosterDisplay.Close();
        }

        //Form on Showing Logic
        //TODO check if this is better placed in on loading logic.
        private void RosterDisplayForm_Shown(object sender, EventArgs e)
        {
            if (Program.xLoader.roster != null)
            {
                foreach (Solider solider in Program.xLoader.roster.soliders)
                {
                    System.Diagnostics.Debug.WriteLine("Line Ran");
                    richTextBox1.Text += solider.showNameInfo();
                }
            }
        }

        //Form On Closing Logic
        private void RosterDisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (menuButtonPressed)
            {
                menuButtonPressed = false;
                return;
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Do you really want to close this application", "Exit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        //Form On Loading logic
        private void RosterDisplayForm_Load(object sender, EventArgs e)
        {

        }

    }
}
