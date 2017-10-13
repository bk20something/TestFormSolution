using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestForms
{
    public partial class AddSoliderForm : Form
    {
        private bool menuButtonPressed = false;

        public AddSoliderForm()
        {
            InitializeComponent();
        }

        //Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            //First Name validiation and parsing 
            string firstName = firstNameTextBox.Text;
            if (firstName.Length < 1 || firstName.Length > 32)
            {
                MessageBox.Show("First Name must be between 1-32 characters long");
                return;
            }
            if(!Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("First Name can only contain alphabetic characters");
                return;
            }

            //Last Name validiation and parsing 
            string lastName = lastNameTextBox.Text;
            if (lastName.Length < 1 || lastName.Length > 32)
            {
                MessageBox.Show("Last Name must be between 1-32 characters long");
                return;
            }
            if (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Last Name can only contain alphabetic characters");
                return;
            }

            //BattleRosterNumber validation and parsing
            string battleRosterNumber = battleRosterNumberTextBox.Text;
            if (!Regex.IsMatch(battleRosterNumber, @"^[A-Z][A-Z][0-9][0-9][0-9][0-9]$"))
            {
                MessageBox.Show("Battle Roster Number must first 2 intials of last name in upercase and last 4 SSN numbers. (ie. AB1234)");
                return;
            }

            //Height validation and parsing
            float height;
            if(float.TryParse(HeightTextBox.Text, out height)){
                if (height < 1.0 || height > 12.0)
                {
                    MessageBox.Show("Enter a valid height");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter a valid height");
                return;
            }

            //Weight validation and parsing
            float weight;
            if (float.TryParse(WeightTextBox.Text, out weight))
            {
                if (weight < 1.0 || weight > 600.0)
                {
                    MessageBox.Show("Enter a valid weight");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter a valid weight");
                return;
            }

            //Age validation and parsing 
            int age;
            if (int.TryParse(AgeTextBox.Text, out age))
            {
                if (age < 17 || age > 110)
                {
                    MessageBox.Show("Enter a valid age");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter a valid age");
                return;
            }

            //Heat Casualty selection
            bool heatCat = true;
            if (HeatCatNoRadioButton.Checked) heatCat = false;
            if (HeatCatYesRadioButton.Checked) heatCat = true;

            //Male Female selection 
            char sex = 'M';
            if (SexMaleRadioButton.Checked) sex = 'M';
            if (SexFemaleRadioButton.Checked) sex = 'F';

            //Add data to the xmloader class
            Solider solider = new Solider(firstName, lastName,battleRosterNumber,heatCat, height, weight, sex);
            Program.xLoader.AddSoliderToRoster(solider);

            //Clear all data from textboxs and reset radio buttons
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            battleRosterNumberTextBox.Clear();
            HeightTextBox.Clear();
            WeightTextBox.Clear();
            AgeTextBox.Clear();
            HeatCatYesRadioButton.Checked = true;
            SexMaleRadioButton.Checked = true;

            //Hide Form and return to previous form
            menuButtonPressed = true;
            FormProvider.AddSolider.Close();
            FormProvider.RosterDisplay.Show();
        }


        private void AddSoliderForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            menuButtonPressed = true;
            FormProvider.AddSolider.Close();
            FormProvider.RosterDisplay.Show();
        }
    }
}
