using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForms
{
    public class PoolData
    {
        //Enumrate the four types of pools the data can be in
        public enum Pool
        {
            Rest,
            HalfSuit,
            CRCM,
            OutRotation
        }

        //Data used by PoolData Object
        private Solider _solider;
        private DateTime _timeStartPool;
        private TimeSpan _maxTimeJob;
        private Jobs.Job _job;
        private bool _emergency;
        private Pool _currentPool;



        //Out and Rest Pool constructures 
        public PoolData(Solider solider, DateTime timeStartPool, Pool pool)
        {
            this._solider = solider;
            this._timeStartPool = timeStartPool;
            this._maxTimeJob = TimeSpan.MaxValue; //TODO Calulate this value based on the pool value
            this._job = Jobs.Job.NA;
            this._emergency = false;
            this._currentPool = pool;
        }

        //CRCM and HalfSuit Pool constructures 
        public PoolData(Solider solider, DateTime timeStartPool,Jobs.Job job, Pool pool)
        {
            //TODO use pool and job data to detemine max time job
        }

        //Accessor Methods
        public Solider solider { get { return _solider; } }
        public DateTime timeStartPool { get { return _timeStartPool; } }
        public TimeSpan maxTimeJob { get { return _maxTimeJob; } }
        public Jobs.Job job { get { return _job; } }
        public bool emergency { get { return _emergency; } }
        public Pool currentPool { get { return _currentPool; } }

        //Class to XML
        public XElement getXML()
        {
            XElement root = new XElement("PoolData");
            root.Add(new XElement(solider.getXML()));
            root.Add(new XElement("TimeStartPool", timeStartPool));
            root.Add(new XElement("MaxTimeJob", maxTimeJob));
            root.Add(new XElement("Job", job));
            root.Add(new XElement("Emergency", emergency));
            root.Add(new XElement("CurrentPool", currentPool));
            return root;
        }
    }
}
