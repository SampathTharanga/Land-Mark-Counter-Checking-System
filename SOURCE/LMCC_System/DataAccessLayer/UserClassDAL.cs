﻿using BusinessPropertyLayer;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
            using (SqlCommand objCmd = new SqlCommand(sqlstring, objSqlCon))
            {
                objSqlCon.Open();
                objCmd.ExecuteNonQuery();
            }

        }

        //EXECUTE STRING
        private object ExecuteSqlString(string sqlstring)
        {
            using (SqlConnection objsqlconn = new SqlConnection(conn))
            {
                objsqlconn.Open();
                using (DataSet ds = new DataSet())
                using (SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn))
                {
                    SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                    objAdp.Fill(ds, "Table_User");
                    return ds;
                }
            }
        }

        //INSERT NEW USER
        public void AddNewUserDB(IUser model)
        {
            string sql = "INSERT INTO Table_User VALUES ('" +model.username + "','" + model.userType + "','" + model.password + "','" + model.secQue + "','" + model.secAns + "','" + model.mobile + "','" + model.email + "','" + model.division + "')";
            InsertUpdateDeleteSQLString(sql);

            //INSERT COOMON DETAILS
            string district = "Please Update", snrss = "Please Update";
            string com_query = "INSERT INTO Table_Common_Details VALUES('" + model.division + "', '" + model.username + "', '" + district + "', '" + snrss + "')";
            InsertUpdateDeleteSQLString(com_query);
        }

        //LOAD USER DATA
        public object LoadUserData()
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM Table_User";
            ds = (DataSet)ExecuteSqlString(sql);
            return ds;
        }

        //UPDATE USER
        public void UpdateUserDB(IUser model)
        {
            string sql = "UPDATE Table_User SET user_type='" + model.userType + "', password='" + model.password + "', sec_question='" + model.secQue + "',sec_answer='" + model.secAns + "',mobile='" + model.mobile + "',email='" + model.email + "' WHERE username='" + model.username + "' AND division='" + model.division + "'";
            InsertUpdateDeleteSQLString(sql);
        }

        //SELECT CURRENT LOGIN USER
        public object CurrentUserData(string username)
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM Table_User WHERE username = '" + username + "'";
            ds = (DataSet)ExecuteSqlString(sql);
            return ds;
        }

        //CHECK NEW USER WITH CHECK USERNAME AND DIVISION
        public bool NewUserDataCheck(string username, string division)
        {
            bool check = false;
            using (SqlConnection objSqlConn = new SqlConnection(conn))
            {
                objSqlConn.Open();
                string sql = "SELECT * FROM Table_User WHERE username = '" + username + "' AND division='" + division + "'";
                using (SqlCommand cmd = new SqlCommand(sql, objSqlConn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        check = true;
                    return check;

                }
            }
        }

        //LOAD DIVISION TO COMBO BOX
        public List<string> LoadDivisionToCombo()
        {
            using (SqlConnection objSqlcon=new SqlConnection(conn))
            {
                objSqlcon.Open();
                string query = "SELECT division FROM Table_Division";
                using (SqlCommand cmd=new SqlCommand(query,objSqlcon))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> divisionList = new List<string>();
                    while (dr.Read())
                    {
                        divisionList.Add(dr["division"].ToString());
                    }
                    return divisionList;
                }
            }
        }

    }
}
