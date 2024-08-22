using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
  public  class CourseDetails
    {
        public long CourseDetailsID { get; set; }
        public string Name { get; set; }
        public string InstitutionName { get; set; }
        public long EnquiryNumber { get; set; }
        public int Duration { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Fees { get; set; }
    }
}
