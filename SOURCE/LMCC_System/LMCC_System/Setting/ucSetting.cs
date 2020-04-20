using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace LMCC_System.Setting
{
    public partial class ucSetting : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucSetting Setting_Instance;
        public static ucSetting _Setting
        {
            get
            {
                Setting_Instance = null;
                if (Setting_Instance == null)
                    Setting_Instance = new ucSetting();
                return Setting_Instance;
            }
        }

        //CREATE SETTING CLASS
        SettingClassBLL objSetting;

        public ucSetting()
        {
            InitializeComponent();
        }

        //ADD NEW DIVISION
        private void AddDivision() 
        {
            try
            {
                if(String.IsNullOrWhiteSpace(txtDivisioin.Text))
                {
                    MessageBox.Show("Please enter ivision name!", "Division  Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objSetting = new SettingClassBLL();
                    if (objSetting.DivivisionExist(txtDivisioin.Text) == false)
                    {
                        objSetting = new SettingClassBLL()
                        {
                            division = txtDivisioin.Text
                        };

                        //ADD DIVISION
                        objSetting.AddNewDivision();
                        MessageBox.Show("Added Successfully!", "Division Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Division exist!", "Division Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDivisioin.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDivision_Click(object sender, EventArgs e)
        {
            if (btnAddDivision.Text == "Add")
                AddDivision();//ADD DIVISION
            if (btnAddDivision.Text == "Update")
                UpdateDivision();
        }

        private void UpdateDivision()
        {
            
        }
    }
}
