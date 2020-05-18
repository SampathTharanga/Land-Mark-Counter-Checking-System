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
    public class SurveyorClassDAL
    {
        //DATABASE CONNECTION
        private string conn = ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString();

        //INSERT UPDATE DELETE COMMON PART
        private void InsertDeleteUpdateCommon(string sqlstring)
        {
            using (SqlConnection objSqlCon = new SqlConnection(conn))
            using (SqlCommand objCmd= new SqlCommand(sqlstring, objSqlCon))
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
                using (SqlCommand objCmd=new SqlCommand(sqlstring, objSqlConn))
                {
                    SqlDataAdapter objAdap = new SqlDataAdapter(objCmd);
                    objAdap.Fill(ds, "Table_Surveyor");
                    return ds;
                }
            }
        }

        //INSERT NEW SURVEYOR
        public void AddNewSurveyorDB(ISurveyor model)
        {
            string sql = "INSERT INTO Table_Surveyor VALUES ('" + model.date + "','" + model.emp_reg_no + "','" + model.initail_name + "','" + model.surveyor_type + "','" + model.mobile + "','" + model.email + "','" + model.division + "','" + model.username + "')";
            InsertDeleteUpdateCommon(sql);
        }

        //UPDATE SURVEYOR
        public void UpdateSurveyorDB(ISurveyor model)
        {
            string sql = "UPDATE Table_Surveyor SET date='" + model.date + "', initial_name='" + model.initail_name + "', surveyor_type='" + model.surveyor_type + "', mobile='" + model.mobile + "', email='" + model.email + "', username='" + model.username + "' WHERE emp_reg_no='" + model.emp_reg_no + "' AND division='" + model.division + "'";
            InsertDeleteUpdateCommon(sql);
        }

        //LOAD SURVEYOR DATA
        public object LoadSurveyor()
        {
            //DataSet ds = new DataSet();
            //string sql = "SELECT * FROM Table_Surveyor";
            //ds = (DataSet)ExecuteSqlString(sql);
            //return ds;

            using (SqlConnection objSqlConn = new SqlConnection(conn))
            {
                string sql = "SELECT * FROM Table_Surveyor";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //CHECK EXIST SURVEYOR
        public bool ExistSurveyorCheck(string division, string emp_reg_no)
        {
            bool check = false;
            using (SqlConnection objSqlCon=new SqlConnection(conn))
            {
                objSqlCon.Open();
                string query= "SELECT * FROM Table_Surveyor WHERE division='"+division+"' AND emp_reg_no='" + emp_reg_no + "'";
                using (SqlCommand cmd=new SqlCommand(query, objSqlCon))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        check = true;
                    return check;
                }
            }
        }

        //LOAD SURVEYOR TYPE TO COMBOBOX
        public List<string> LoadSurveyorTypeToCombo()
        {
            using (SqlConnection objSqlCon=new SqlConnection(conn))
            {
                objSqlCon.Open();
                string query = "SELECT surveyor_type FROM Table_Surveyor_Type";
                using (SqlCommand cmd=new SqlCommand(query, objSqlCon))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> surveyorTypeList = new List<string>();
                    while (dr.Read())
                    {
                        surveyorTypeList.Add(dr["surveyor_type"].ToString());
                    }
                    return surveyorTypeList;
                }
            }
        }


        //DATA FILTER
        public object SearchDataDB()
        {
            //DataSet ds = new DataSet();
            //ds = (DataSet)objClassBLL.LoadSurveyor();
            //DataTable dt = ds.Tables["Table_Surveyor"];
            //DataView dv = new DataView(dt);
            //dv.RowFilter = string.Format("initial_name like '%" + txtSearchName.Text + "%'");
            //dgvSurveyor.Refresh();


            using (SqlConnection objSqlCon = new SqlConnection(conn))
            {
                objSqlCon.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_Surveyor", conn);
                DataTable dtbl = new DataTable();
                da.Fill(dtbl);

                return da;
                //BindingSource bnsue = new BindingSource();
                //bnsue.DataSource = dtbl;
                //dgvInvoiceView.DataSource = bnsue;
                //da.Update(dtbl);

                //DataView dv = new DataView(dtbl);
                //dv.RowFilter = "invoiceNo like '%" + txtInvoNo.Text + "%' ";
                //dgvInvoiceView.DataSource = dv;
            }
        }
    }
}
