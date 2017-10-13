using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForms
{
    public class PoolOut
    {
        private List<PoolData> _PoolData;  //List of all soliders in the pool

        //Add to pool 
        public void addToPool(List<PoolData> poolData)
        {
            if (poolData != null)
            {
                foreach (PoolData member in poolData)
                {
                    _PoolData.Add(member);
                }
            }
        }

        //Remove from pool
        public void removeFromPool(List<string> rosterNumbers)
        {
            //Store itemst to be removed
            List<PoolData> toBeRemoved = new List<PoolData>();
            //Select which items to remove
            foreach (string rosterNumber in rosterNumbers)
            {
                foreach(PoolData poolMember in _PoolData)
                {
                    if(poolMember.solider.battleRosterNumber == rosterNumber)
                    {
                        toBeRemoved.Add(poolMember);
                    }
                }
            }
            //Remove items
            foreach(PoolData entry in toBeRemoved)
            {
                _PoolData.Remove(entry);
            }
        }

        //Get Members
        public List<PoolData> getPoolMembers(List<String> rosterNumbers)
        {
            List<PoolData> returnList = new List<PoolData>();
            foreach (String rosterNumber in rosterNumbers)
            {
                foreach (PoolData poolMember in _PoolData)
                {
                    if (poolMember.solider.battleRosterNumber == rosterNumber)
                    {
                        returnList.Add(poolMember);
                    }
                }
            }

            return returnList;
        }

        //Class to XML
        public XElement getXML()
        {
            XElement root = new XElement("PoolOut");
            foreach (PoolData member in _PoolData)
            {
                root.Add(member.getXML());
            }
            return root;
        }
    }
}
