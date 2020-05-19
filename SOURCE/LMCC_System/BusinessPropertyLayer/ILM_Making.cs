using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPropertyLayer
{
    public interface ILM_Making
    {
        //LM MAKING PROPERTIES
        int making_id { get; set; }
        DateTime date { get; set; }
        string lm_type { get; set; }
        string supplier_name { get; set; }
        int no_of_lm { get; set; }
        string username { get; set; }
        string division { get; set; }
    }
}
