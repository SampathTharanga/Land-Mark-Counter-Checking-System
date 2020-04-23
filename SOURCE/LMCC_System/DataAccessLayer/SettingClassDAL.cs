using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessPropertyLayer;

namespace DataAccessLayer
{
    public class SettingClassDAL
    {
        //--------------------------------------------------------------//
        //                            COMMON                            //
        //--------------------------------------------------------------//

        //DATABASE CONNECTION
        private string conn = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();

        //INSERT UPDATE DELETE SQL
        private void InsertUpdateeleteSQL(string query)
        {
            using (SqlConnection objSqlConn = new SqlConnection(conn))
            using (SqlCommand objCmd=new SqlCommand(query, objSqlConn))
            {
                objSqlConn.Open();
                objCmd.ExecuteNonQuery();
            }
        }

        //EXECUTE STRING AND RETURN DATASET
        private object ExecuteSqlString(string query)
        {
            using(SqlConnection objSqlConn=new SqlConnection(conn))
            {
                objSqlConn.Open();
                using (DataSet ds = new DataSet())
                using (SqlCommand cmd= new SqlCommand(query,objSqlConn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Table_Division");
                    return ds;
                }
            }
        }


        //--------------------------------------------------------------//
        //                            DIVISION                          //
        //--------------------------------------------------------------//

        //INSERT NEW DIVISION
        public void AddNewDivisionDB(ISetting model)
        {
            string query = "INSERT INTO Table_Division VALUES ('" + model.division + "')";
            InsertUpdateeleteSQL(query);
        }

        //UPDATE DIVISION
        public void UpdateDivisionDB(ISetting model)
        {
            string query = "UPDATE Table_Division SET division = '" + model.division + "' WHERE division = '" + model.oldDivision + "'";
            InsertUpdateeleteSQL(query);
        }
        
        //CHECK DIVISION EXIST
        public bool DivisionExistDB(string division)
        {
            bool check = false;
            using (SqlConnection objSqlConn=new SqlConnection(conn))
            {
                objSqlConn.Open();
                string query = "SELECT * FROM Table_Division WHERE division = '" + division + "'";
                using (SqlCommand  cmd=new SqlCommand(query,objSqlConn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        check = true;
                    return check;
                }
            }
        }

        //LOAD DIVISION DATA
        public object LoadDivisionData()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Table_Division";
            ds = (DataSet)ExecuteSqlString(query);
            return ds;
        }

    }
}
