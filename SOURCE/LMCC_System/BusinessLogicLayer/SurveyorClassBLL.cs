using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using BusinessPropertyLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SurveyorClassBLL : ISurveyor
    {
        //SURVEYOR PROPERTIES
        public DateTime date { get; set; }
        public string emp_reg_no { get; set; }
        public string initail_name { get; set; }
        public string surveyor_type { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string division { get; set; }
        public string username { get; set; }

        //SURVEYOR BUSINESS LAYER CALSS OBJECT
        SurveyorClassDAL objSurveyorDAL;

        //ADD NEW SURVEYOR
        public void AddNewSurveyor()
        {
            objSurveyorDAL = new SurveyorClassDAL();
            objSurveyorDAL.AddNewSurveyorDB(this);
        }

        //UPDATE SURVEYOR
        public void UpdateSurveyor()
        {
            objSurveyorDAL = new SurveyorClassDAL();
            objSurveyorDAL.UpdateSurveyorDB(this);
        }

        //LOAD SURVEYOR DATA
        public object LoadSurveyor()
        {
            objSurveyorDAL = new SurveyorClassDAL();
            return objSurveyorDAL.LoadSurveyor();
        }
        //CHECK EXIST SURVEYOR
        public bool ExistSurveyor(string division, string emp_reg_no)
        {
            objSurveyorDAL = new SurveyorClassDAL();
            return objSurveyorDAL.ExistSurveyorCheck(division, emp_reg_no);
        }

        //LOAD SURVEYOR TYPE TO COMBOBOX
        public List<string> LoadSurveyorType()
        {
            objSurveyorDAL = new SurveyorClassDAL();
            return objSurveyorDAL.LoadSurveyorTypeToCombo();
        }
    }
}
