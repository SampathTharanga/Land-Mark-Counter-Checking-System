using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPropertyLayer
{
    public interface ISetting
    {
        //DIVISION PROPERTIES
        string division { get; set; }
        string oldDivision { get; set; }
    }
}
