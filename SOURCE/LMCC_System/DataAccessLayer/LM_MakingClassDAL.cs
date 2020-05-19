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
    public class LM_MakingClassDAL
    {
        //DATABASE CONNECTION
        private string conn = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();

        //INSERT UPDATE DELETE COMMON PART
        private void InsertDeleteUpdateCommon(string sqlstring)
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
            using (SqlConnection objSqlConn = new SqlConnection(conn))
            {
                objSqlConn.Open();
                using (DataSet ds = new DataSet())
                using (SqlCommand objCmd = new SqlCommand(sqlstring, objSqlConn))
                {
                    SqlDataAdapter objAdap = new SqlDataAdapter(objCmd);
                    objAdap.Fill(ds, "Table_Surveyor");
                    return ds;
                }
            }
        }

        //INSERT NEW LM MAKING
        public void AddNewLmMakingDB(ILM_Making model)
        {

            using (SqlConnection objSqlConn = new SqlConnection(conn))
            {
                string sql = "SELECT * FROM Table_LM_Making";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int id = 0;
                if (dt.Rows.Count > 0) 
                {
                    DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                    id = int.Parse(lastRow["making_id"].ToString());
                }
                string query = "INSERT INTO Table_LM_Making VALUES ('" + id + "','" + model.date + "','" + model.lm_type + "','" + model.supplier_name + "','" + model.no_of_lm + "','" + model.username + "','" + model.division + "')";
                InsertDeleteUpdateCommon(query);
            }
        }

        //UPDATE LM MAKING
        public void UpdateLmMakingDB(ILM_Making model)
        {
            string sql = "UPDATE Table_LM_Making SET date='" + model.date + "', lm_type='" + model.lm_type + "', supplier_name='" + model.supplier_name + "', no_of_lm='" + model.no_of_lm + "', username='" + model.username + "' WHERE making_id='" + model.making_id + "' AND division='" + model.division + "'";
            InsertDeleteUpdateCommon(sql);
        }

        //LOAD LM MAKING DATA
        public object LoadLmMaking()
        {
            using (SqlConnection objSqlConn = new SqlConnection(conn))
            {
                string sql = "SELECT * FROM Table_LM_Making";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //LOAD LM TYPE TYPE TO COMBOBOX
        public List<string> LoadLmTypeToCombo()
        {
            using (SqlConnection objSqlCon = new SqlConnection(conn))
            {
                objSqlCon.Open();
                string query = "SELECT lm_type FROM Table_LM_Type   ";
                using (SqlCommand cmd = new SqlCommand(query, objSqlCon))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> lmTypeList = new List<string>();
                    while (dr.Read())
                    {
                        lmTypeList.Add(dr["lm_type"].ToString());
                    }
                    return lmTypeList;
                }
            }
        }

    }
}
