using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System.LM_Manage
{
    public partial class ucLMManage : UserControl
    {
        /*
         * DEPORT NUMBERS
         * 
         * 01. Anuradhapura division office - LM/ANP/2020/001
         * 02. Thambuththegam division office - LM/TMB/2020/001
         * 03. Thirappane division office - LM/TRP/2020/001
         * 04. Kekirawa division office - LM/KKR/2020/001
         * 05. Padawiya division office - LM/PDW/2020/001
         * 06. Medawachchiya division office - LM/MDW/2020/001
         */


        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucLMManage LMManage_Instance;
        public static ucLMManage _LMManage
        {
            get
            {
                LMManage_Instance = null;
                if (LMManage_Instance == null)
                    LMManage_Instance = new ucLMManage();
                return LMManage_Instance;
            }
        }
        public ucLMManage()
        {
            InitializeComponent();
        }
    }
}
