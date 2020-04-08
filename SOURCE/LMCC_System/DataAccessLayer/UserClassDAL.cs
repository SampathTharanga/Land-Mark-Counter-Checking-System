using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using BusinessPropertyLayer;

namespace DataAccessLayer
{
    public class UserClassDAL
    {
        //DATABASE CONNECTION
        private string conn = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();

        //INSERT UPDATE DELETE SQL COMMON
        private void InsertUpdateDeleteSQLString(string sqlstring)
        {
            using (SqlConnection objSqlCon = new SqlConnection(conn))
            {
                using (SqlCommand objCmd = new SqlCommand(sqlstring, objSqlCon))
                {
                    objSqlCon.Open();
                    objCmd.ExecuteNonQuery();
                }
            }
        }
        //EXECUTE STRING
        private object ExecuteSqlString(string sqlstring)
        {
            SqlConnection objsqlconn = new SqlConnection(conn);
            objsqlconn.Open();
            DataSet ds = new DataSet();
            SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
            SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
            objAdp.Fill(ds, "Table_User");
            return ds;
        }
        //INSERT NEW USER
        public void AddNewUserDB(IUser model)
        {
            string sql = "INSERT INTO Table_User VALUES ('" +model.username + "','" + model.userType + "','" + model.password + "','" + model.secQue + "','" + model.secAns + "','" + model.mobile + "','" + model.email + "','" + model.division + "')";
            InsertUpdateDeleteSQLString(sql);
        }
        //LOAD USER DATA
        public object LoadUserData()
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM Table_User";
            ds = (DataSet)ExecuteSqlString(sql);
            return ds;
        }
    }
}
