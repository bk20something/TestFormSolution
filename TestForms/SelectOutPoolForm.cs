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
    public partial class SelectOutPoolForm : Form
    {
        private bool menuButtonPressed = false; //Check if close state is result of button on form

        public SelectOutPoolForm()
        {
            InitializeComponent();
        }

        private void SelectOutPoolForm_Load(object sender, EventArgs e)
        {
            foreach (Solider solider in Program.xLoader.roster.soliders)
            {
                checkedListBox1.Items.Add(solider.battleRosterNumber + " " + solider.lastName + ", " + solider.firstName);
            }
        }

        private void SelectOutPoolForm_FormClosing(object sender, FormClosingEventArgs e)
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
