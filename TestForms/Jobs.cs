using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForms
{
    public class Jobs
    {
        public enum Job
        {
            NonAmb,
            LitterCarry,
            CheckIn,
            Amb,
            EquipmentDecon,
            TechDecon,
            NA
        }

        TimeSpan CalculateMaxTimeJob(Job job, Solider solider)
        {
            //TODO ADD logic change return type to some kind of timespan
            return TimeSpan.FromHours(1);
        }
    }
}
