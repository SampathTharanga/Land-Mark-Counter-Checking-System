using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPropertyLayer
{
    public interface IUser
    {
        //USER PROPERTIES
        string username { get; set; }
        string userType { get; set; }
        string password { get; set; }
        string secQue { get; set; }
        string secAns { get; set; }
        string mobile { get; set; }
        string email { get; set; }
        string division { get; set; }
    }
}
