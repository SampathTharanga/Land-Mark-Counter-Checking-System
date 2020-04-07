using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMCC_System
{
    public partial class ucSurveyor : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucSurveyor Surveyor_Instance;
        public static ucSurveyor _Surveyor
        {
            get
            {
                Surveyor_Instance = null;
                if (Surveyor_Instance == null)
                    Surveyor_Instance = new ucSurveyor();
                return Surveyor_Instance;
            }
        }
        public ucSurveyor()
        {
            InitializeComponent();
        }

        private void pbxSurveyorSetting_Click(object sender, EventArgs e)
        {
            //SURVEYOR SETTING FORM OPEN
            Surveyor.frmSurveyorType ftmSt = new Surveyor.frmSurveyorType();
            ftmSt.ShowDialog();
        }
    }
}
