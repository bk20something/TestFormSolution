using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForms
{
    //An xml data class to make reading a writing xml data easier.
    public class Solider
    {
        private string _firstName;             //First Name of Solider. Max length set at 32 Charters
        private string _lastName;              //Last Name of Solider . Max length set at 32 Charters
        private string _battleRosterNumber;    //First letter of Last Name and Last 4 digits of SSN.
        private bool _heatCat;                 //A boolean value indicating if they are a heat casulity risk
        private double _height;                 //Height in ft. Must be a postive value
        private double _weight;                 //Weight in lbs. Must be a postive value
        private char _sex;                     //M if they are Male. F if they are Female
        //TODO Add age
        
        //Generic constructure 
        public Solider(string firstName, string lastName, string battleRosterNumber, bool heatCat, double height, double weight, char sex)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._battleRosterNumber = battleRosterNumber;
            this._heatCat = heatCat;
            this._height = height;
            this._weight = weight;
            this._sex = sex;
        }

        //Accessor Methods
        public string firstName { get { return _firstName; } } 
        public string lastName { get { return _lastName; } }  
        public string battleRosterNumber { get { return _battleRosterNumber; } }  
        public bool heatCat { get { return _heatCat; } }  
        public double height { get { return _height; } }  
        public double weight { get { return _weight; } }  
        public char sex { get { return _sex; } }

        //Display Method
        //Used to display roster number, last name and first name
        public string showNameInfo()
        {
            string output = "";
            output = output + _battleRosterNumber + " " + _lastName + ", " + _firstName + Environment.NewLine;
            return output;
        }

        public XElement getXML()
        {
            XElement root = new XElement("SoliderData");
            root.Add(new XElement("FirstName", firstName));
            root.Add(new XElement("LastName", lastName));
            root.Add(new XElement("BattleRosterNumber", battleRosterNumber));
            root.Add(new XElement("HeatCat", heatCat));
            root.Add(new XElement("Height", height));
            root.Add(new XElement("Weight", weight));
            root.Add(new XElement("Sex", sex));
            return root;
        }
        
        //Display Methods for Debug Purposes Only
        public string _show()
        {
            string output = "";
            output = output + "First Name: " + _firstName + Environment.NewLine;
            output = output + "Last Name: " + _lastName + Environment.NewLine;
            output = output + "Battle Roster Number: " + _battleRosterNumber + Environment.NewLine;
            output = output + "HeatCat: " + _heatCat + Environment.NewLine;
            output = output + "Height: " + _height + Environment.NewLine;
            output = output + "Weight: " + _weight + Environment.NewLine;
            output = output + "Sex: " + _sex + Environment.NewLine;

            return output;
        }
    }
}
