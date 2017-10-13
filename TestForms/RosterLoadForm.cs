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
    public partial class RosterLoadForm : Form
    {
        private OpenFileDialog _ofd = new OpenFileDialog();
        private bool menuButtonPressed = false; //Check if close state is result of button on form

        public RosterLoadForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ofd.Filter = "XML|*.xml";
            if(_ofd.ShowDialog() == DialogResult.OK)
            {
                fileNameTextBox.Text = _ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_ofd.FileName != null)
            {
                //TODO check to see if loaded xml is valid
                Program.xLoader.loadXML(_ofd.FileName);

                //File was successfully loaded go to next screen
                menuButtonPressed = true;
                FormProvider.RosterLoad.Close();
                FormProvider.RosterDisplay.Show();

            }
            else
            {
                MessageBox.Show("Please Select a Roster File to Load");
            }
        }

        private void RosterLoadForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
