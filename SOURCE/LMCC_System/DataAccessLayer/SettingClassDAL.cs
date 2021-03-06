﻿using BusinessPropertyLayer;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
        private object ExecuteSqlString(string query, string tableName)
        {
            using(SqlConnection objSqlConn=new SqlConnection(conn))
            {
                objSqlConn.Open();
                using (DataSet ds = new DataSet())
                using (SqlCommand cmd= new SqlCommand(query,objSqlConn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(ds, "Table_Division");
                    da.Fill(ds, tableName);
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
            string query = "INSERT INTO Table_Division VALUES ('" + model.division + "', '"+ model.deportId +"')";
            InsertUpdateeleteSQL(query);
        }

        //UPDATE DIVISION
        public void UpdateDivisionDB(ISetting model)
        {
            string query = "UPDATE Table_Division SET division = '" + model.division + "', division_deport_id='"+ model.deportId +"' WHERE division = '" + model.oldDivision + "'";
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
            ds = (DataSet)ExecuteSqlString(query, "Table_Division");
            return ds;
        }





        //--------------------------------------------------------------//
        //                      SURVEYOR TYPE                           //
        //--------------------------------------------------------------//

        //ADD NEW SURVEYOR TYPE
        public void AddNewSurveyorTypeDB(ISetting model)
        {
            string query = "INSERT INTO Table_Surveyor_Type VALUES ('" + model.surveyorType + "')";
            InsertUpdateeleteSQL(query);
        }

        //UPDATE SURVEYOR TYPE
        public void UpdateSurveyorTypeDB(ISetting model)
        {
            string query = "UPDATE Table_Surveyor_Type SET surveyor_type ='" + model.surveyorType + "' WHERE surveyor_type='" + model.existSurveyorType + "'";
            InsertUpdateeleteSQL(query); ;
        }

        //CHECK EXIST SURVEYOR TYPE
        public bool SurveyorTypeExistDB(string surveyorType)
        {
            bool check = false;
            using (SqlConnection objConn = new SqlConnection(conn))
            {
                objConn.Open();
                string query = "SELECT * FROM Table_Surveyor_Type WHERE surveyor_type='" + surveyorType + "'";
                using (SqlCommand cmd=new SqlCommand (query, objConn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        check = true;
                    return check;
                }
            }
        }

        //LOAD SURVEYOR TYPE
        public object LoadSurveyorType()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Table_Surveyor_Type";
            ds = (DataSet)ExecuteSqlString(query, "Table_Surveyor_Type");
            return ds;
        }




        //--------------------------------------------------------------//
        //                       LAND MARK TYPE                         //
        //--------------------------------------------------------------//

        //ADD LAND MARK TYPE
        public void AddNewLandMarkTypeDB(ISetting model)
        {
            string query = "INSERT INTO Table_LM_Type VALUES ('" + model.landMarkType + "')";
            InsertUpdateeleteSQL(query);
        }

        //UPDATE LAND MARK TYPE
        public void UpdateLandMarkTypeDB(ISetting model)
        {
            string query = "UPDATE Table_LM_Type SET lm_type='" + model.landMarkType + "' WHERE lm_type='" + model.existLandMarkType + "'";
            InsertUpdateeleteSQL(query);
        }

        //CHECK EXIST LAND MARK TYPE
        public bool ExistLandMarkTypeDB(string landMarkType)
        {
            bool check = false;
            string query = "SELECT * FROM Table_LM_Type WHERE lm_type='" + landMarkType + "'";
            using (SqlConnection objConn = new SqlConnection(conn))
            {
                objConn.Open();
                using (SqlCommand cmd = new SqlCommand(query, objConn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        check = true;
                    return check;
                }
            }
        }

        //LOAD LAND MARK TYPE
        public object LoadLandMarkTypeDB()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Table_LM_Type";
            ds = (DataSet)ExecuteSqlString(query, "Table_LM_Type");
            return ds;
        }




        //--------------------------------------------------------------//
        //                       COMMON DETAILS                         //
        //--------------------------------------------------------------//

        //ADD COMMEN DETAILS
        //public void AddCommonDetails(ISetting model)
        //{
        //    string query = "INSERT INTO Table_Common_Details VALUES('" + model.common_division + "', '" + model.common_username + "', '" + model.common_district + "', '" + model.common_snrss + "')";
        //    InsertUpdateeleteSQL(query);
        //}

        //UPDATE COMMEN DETAILS
        public void UpdateCommonDetails(ISetting model)
        {
            string query = "UPDATE Table_Common_Details SET district='" + model.common_district + "', snrss='" + model.common_snrss + "' WHERE division='" + model.common_division + "' AND username='" + model.common_username + "'";
            InsertUpdateeleteSQL(query);
        }

        //LOAD COMMEN DETAILS
        public object LoadCommonDetails()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Table_Common_Details";
            ds = (DataSet)ExecuteSqlString(query, "Table_Common_Details");
            return ds;
        }



        //--------------------------------------------------------------//
        //                            STOCK                             //
        //--------------------------------------------------------------//

        //INSERT DEFAULT DATA TO STOCK
        public void StockDefaultDataAddDB(ISetting model)
        {
            string query = "INSERT INTO Table_Stock VALUES ('" + model.stock_lm_type + "', '" + model.stock_division + "', '" + model.stock_lm_total + "')";
            InsertUpdateeleteSQL(query);
        }

        //LAND MARK TYPES LIST
        public List<string> LandMarkTypeSet()
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

        //DIVISIONS LIST
        public List<string> DivisionSet()
        {
            using (SqlConnection objSqlCon = new SqlConnection(conn))
            {
                objSqlCon.Open();
                string query = "SELECT division FROM Table_Division   ";
                using (SqlCommand cmd = new SqlCommand(query, objSqlCon))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> DivisionList = new List<string>();
                    while (dr.Read())
                    {
                        DivisionList.Add(dr["division"].ToString());
                    }
                    return DivisionList;
                }
            }
        }
    }
}
