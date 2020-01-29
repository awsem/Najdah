using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najdah.Models
{
    public class Report
    {
        public ReportType ReportType { get; set; }

        public string Location { get; set; }

    }

    public enum ReportType
    {
        Policeman,   
        Firefighter,
        Hospital,
        Municipality
    }
}
