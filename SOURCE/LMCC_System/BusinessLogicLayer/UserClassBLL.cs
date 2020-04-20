using BusinessPropertyLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserClassBLL : IUser
    {
        //USER PROPERTIES
        public string username { get; set; }
        public string userType { get; set; }
        public string password { get; set; }
        public string secQue { get; set; }
        public string secAns { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string division { get; set; }

        //USER BUSINESS LAYER CLASS OBJECT
        UserClassDAL objUserClsBL;

        //ADD NEW USER
        public void AddNewUser()
        {
            objUserClsBL = new UserClassDAL();
            objUserClsBL.AddNewUserDB(this);
        }

        //LOAD DATA
        public object LoadUserData()
        {
            objUserClsBL = new UserClassDAL();
            return objUserClsBL.LoadUserData();
        }

        //UPDATE USER
        public void UpdateUser()
        {
            objUserClsBL = new UserClassDAL();
            objUserClsBL.UpdateUserDB(this);
        }

        //CURRENT USER LOGIN DETAILS
        public object CurrentUser(string usename)
        {
            objUserClsBL = new UserClassDAL();
            return objUserClsBL.CurrentUserData(usename);
        }

        //CHECK USER WITH USERNAME AND DIVISION
        public bool NewUserCheck(string username, string division)
        {
            objUserClsBL = new UserClassDAL();
            return objUserClsBL.NewUserDataCheck(username, division);
        }
    }
}
