using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestForms
{
    //Used to load and save roster data.
    //Roster data will be passed to main application for processing
    public class XmlLoader
    {
        private static Roster _roster;
        private static string _outputDirectory;
        private static string _outputFileName;

        //Load XML into a roster class
        public void loadXML(string xmlPath)
        {
            //TODO: check if xml path is good

            //Load xml
            XDocument xDoc = XDocument.Load(xmlPath);

            //TODO: Validate xml passed in

            //Load all roster data from the xml
            List<Solider> soliders = new List<Solider>();
            foreach(var solider in xDoc.Descendants("Solider"))
            {
                string firstName = solider.Element("FirstName").Value;//---------------------Parse out FirstName
                string lastName = solider.Element("LastName").Value;//-----------------------Parse out LastName 
                string battleRosterNumber = solider.Element("BattleRosterNumber").Value;//---Parse out BattleRosterNumber
                bool heatCat = bool.Parse(solider.Element("HeatCat").Value);//---------------Parse out HeatCat
                float height = float.Parse(solider.Element("Height").Value);//---------------Parse out Height
                float weight = float.Parse(solider.Element("Weight").Value);//---------------Parse out Weight
                char sex = char.Parse(solider.Element("Sex").Value);//-----------------------Parse out Sex
                soliders.Add(new Solider(firstName, lastName, battleRosterNumber, heatCat, height, weight, sex));
            }
            _roster = new Roster(soliders);


            //TODO: Parse out outputDirectory and outputFileName from xml path
        }

        //This method is used to add a solider the roster variable
        //If the roster variable has not been instanced yet it will do that here
        public void AddSoliderToRoster(Solider solider)
        {
            if (_roster == null)
            {
                _roster = new Roster();
            }
            _roster.addSolider(solider);
        }

        //Accessor Methods
        public Roster roster { get { return _roster; } }

        //TODO: Finish these methods 
        //RemoveSolider --this should be done via battle roster number
        //SaveRoster
        //SetOutputDirectory
        //SetOutputFileName
    }
}
