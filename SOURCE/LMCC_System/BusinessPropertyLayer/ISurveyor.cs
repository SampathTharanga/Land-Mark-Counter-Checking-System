using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPropertyLayer
{
    public interface ISurveyor
    {
        //SURVEYOR PROPERTIES
        DateTime date { get; set; }
        string emp_reg_no { get; set; }
        string initail_name { get; set; }
        string surveyor_type { get; set; }
        string mobile { get; set; }
        string email { get; set; }
        string division { get; set; }
        string username { get; set; }
    }
}
