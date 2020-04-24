﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessPropertyLayer;
using DataAccessLayer;

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
    }
}