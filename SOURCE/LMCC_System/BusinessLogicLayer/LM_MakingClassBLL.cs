using BusinessPropertyLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class LM_MakingClassBLL : ILM_Making
    {
        //LM MAKING PROPERTIES
        public int making_id { get; set; }
        public DateTime date { get; set; }
        public string lm_type { get; set; }
        public string supplier_name { get; set; }
        public int no_of_lm { get; set; }
        public string username { get; set; }
        public string division { get; set; }


        //BUSINESS LAYER CALSS OBJECT
        LM_MakingClassDAL objLmMakingDAL;

        //ADD NEW 
        public void AddNew()
        {
            objLmMakingDAL = new LM_MakingClassDAL();
            objLmMakingDAL.AddNewLmMakingDB(this);
        }

        //UPDATE
        public void Update()
        {
            objLmMakingDAL = new LM_MakingClassDAL();
            objLmMakingDAL.UpdateLmMakingDB(this);
        }

        //LOAD DATA
        public object Load()
        {
            objLmMakingDAL = new LM_MakingClassDAL();
            return objLmMakingDAL.LoadLmMaking();
        }

        //LOAD LM TYPE TO COMBOBOX
        public List<string> LoadType()
        {
            objLmMakingDAL = new LM_MakingClassDAL();
            return objLmMakingDAL.LoadLmTypeToCombo();
        }
    }
}
