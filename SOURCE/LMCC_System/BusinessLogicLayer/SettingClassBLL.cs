using BusinessPropertyLayer;
using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class SettingClassBLL : ISetting
    {
        //DIVISION PROPERTIES
        public string division { get; set; }
        public string oldDivision { get; set; }

        //SURVEYOR TYPE PROPERTIES
        public string surveyorType { get; set; }
        public string existSurveyorType { get; set; }

        //LAND MARK PROPERTIES
        public string landMarkType { get; set; }
        public string existLandMarkType { get; set; }

        //COMMON DETAILS
        public string common_division { get; set; }
        public string common_username { get; set; }
        public string common_district { get; set; }
        public string common_snrss { get; set; }

        //STOCK PROPERTIES
        public string stock_lm_type { get; set; }
        public string stock_division { get; set; }
        public int stock_lm_total { get; set; }


        //SETTING BUSINESS LAYER CLASS OBJECT
        SettingClassDAL objSetDal;


        //--------------------------------------------------------------//
        //                            DIVISION                          //
        //--------------------------------------------------------------//

        //ADD NEW DIVISION
        public void AddNewDivision()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.AddNewDivisionDB(this);
        }

        //UPDATE DIVISION
        public void UpdateDivision()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.UpdateDivisionDB(this);
        }

        //CHECK DIVISION EXIST
        public bool DivivisionExist(string division)
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.DivisionExistDB(division);
        }

        //LOAD DIVISION DATA
        public object LoadDivision()
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.LoadDivisionData();
        }



        //--------------------------------------------------------------//
        //                      SURVEYOR TYPE                           //
        //--------------------------------------------------------------//

        //ADD NEW SURVEYOR TYPE
        public void AddNewSuerveyorType()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.AddNewSurveyorTypeDB(this);
        }

        //UPDATE SURVEYOR TYPE
        public void UpdateSurveyorType()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.UpdateSurveyorTypeDB(this);
        }

        //CHECK EXIST SURVEYOR TYPE
        public bool CheckSurveyorType(string surveyorType)
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.SurveyorTypeExistDB(surveyorType);
        }

        //LOAD SURVEYOR TYPES
        public object LoadSurveyorType()
        {
            objSetDal = new SettingClassDAL(); ;
            return objSetDal.LoadSurveyorType();
        }


        //--------------------------------------------------------------//
        //                       LAND MARK TYPE                         //
        //--------------------------------------------------------------//

        //ADD NEW LAND MARK TYPE
        public void AddNewLandMarkType()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.AddNewLandMarkTypeDB(this);
        }

        //UPDATE LAND MARK TYPE
        public void UpdateLandMarkType()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.UpdateLandMarkTypeDB(this);
        }

        //CHECK EXIST LAND MARK TYPE
        public bool CheckLandMarkType(string landMarkType)
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.ExistLandMarkTypeDB(landMarkType);
        }

        //LOAD LAND MARK TYPES
        public object LoadLandMarkType()
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.LoadLandMarkTypeDB();
        }



        //--------------------------------------------------------------//
        //                       COMMON DETAILS                         //
        //--------------------------------------------------------------//

        ////ADD COMMON DETAILS
        //public void AddCommonDetailsDB()
        //{
        //    objSetDal = new SettingClassDAL();
        //    objSetDal.AddCommonDetails(this);
        //}

        //UPDATE COMMON DETAILS
        public void UpdateCommonDetailsDB()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.UpdateCommonDetails(this);
        }

        //LOAD COMMON DETAILS
        public object LoadCommonDetails()
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.LoadCommonDetails();
        }

        //--------------------------------------------------------------//
        //                            STOCK                             //
        //--------------------------------------------------------------//

        //DEFAULT STOCK DATA INSERT
        public void DefaultStockData()
        {
            objSetDal = new SettingClassDAL();
            objSetDal.StockDefaultDataAddDB(this);
        }

        //LAN MARK TYPE COLLECTION
        public List<string> AllLandMarkTypes()
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.LandMarkTypeSet();
        }

        //LAN MARK TYPE COLLECTION
        public List<string> AllDivisios()
        {
            objSetDal = new SettingClassDAL();
            return objSetDal.DivisionSet();
        }
        
    }
}
