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




        //--------------------------------------------------------------//
        //                            COMMON                            //
        //--------------------------------------------------------------//

        //CLEAR ALL TEXBOX AND COMBOBOX
        private void ClearTextBoxces()
        {
            try
            {
                Action<Control.ControlCollection> func = null;
                func = (cotrols) =>
                {
                    foreach (Control control in cotrols)
                    {
                        if (control is TextBox)
                            (control as TextBox).Clear();//TEXTBOX CLEAR
                        else if (control is ComboBox)
                            (control as ComboBox).SelectedIndex = -1;//COMBOBOX CLEAR
                        else
                            func(control.Controls);
                    }
                };
                func(Controls);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //--------------------------------------------------------------//
        //                            DIVISION                          //
        //--------------------------------------------------------------//


        //ADD NEW DIVISION
        private void AddDivision()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtDivisioin.Text))
                {
                    MessageBox.Show("Please enter division name!", "Division  Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        LoadDivisionDatas();
                        ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
                    }
                    else
                    {
                        MessageBox.Show("Division exist!", "Division Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
                    }
                }
                btnAddDivision.Text = "Add";
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
                UpdateDivision();//UPDATE DIVISION
        }

        //LOAD DIVISION DATA
        private void LoadDivisionDatas()
        {
            objSetting = new SettingClassBLL();
            dgvDivision.DataSource = objSetting.LoadDivision();
            dgvDivision.DataMember = "Table_Division";

            DgvDivisionStyle();
        }

        //DIVISION DATA UPDATE
        private void UpdateDivision()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtDivisioin.Text))
                {
                    MessageBox.Show("Please enter division name!", "Division  Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objSetting = new SettingClassBLL();
                    if (objSetting.DivivisionExist(txtDivisioin.Text) == false)
                    {
                        //UPDATE DIVISION
                        objSetting = new SettingClassBLL()
                        {
                            division = txtDivisioin.Text,
                            oldDivision = dgvDivision.CurrentRow.Cells[0].Value.ToString()
                        };
                        objSetting.UpdateDivision();
                        MessageBox.Show("Division Update successfully!", "Division Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDivisionDatas();
                        ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
                    }
                    else
                    {
                        MessageBox.Show("Division exist!", "Division Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
                    }
                    ClearTextBoxces();
                    btnAddDivision.Text = "Add";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {
            LoadDivisionDatas();//LOAD DIVISION DATA
            LoadSurveyorTypeData();//LOAD SURVEYOR TYPE DATA
            LoadLandMarTypekData();//LOAD LAND MARK TYPE DATA
        }

        private void dgvDivision_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAddDivision.Text = "Update";
            txtDivisioin.Text = dgvDivision.CurrentRow.Cells[0].Value.ToString();
        }

        //DIVISION DATAGRIDVIEW STYLE CHANGE
        private void DgvDivisionStyle()
        {
            dgvDivision.Columns[0].HeaderText = "Division";
            dgvDivision.Columns[0].Width = 300;
        }

        private void btnDivisionClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
        }

        private void txtDivisioin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }





        //--------------------------------------------------------------//
        //                      SURVEYOR TYPE                           //
        //--------------------------------------------------------------//

        private void btnSurveyorTypeAdd_Click(object sender, EventArgs e)
        {
            if (btnSurveyorTypeAdd.Text == "Add")
                AddSurveyorType();//ADD NEW SURVEYOR TYPE
            if (btnSurveyorTypeAdd.Text == "Update")
                UpdateSurveyorType();//UPDATE SURVEYOR TYPE
        }

        //LOAD SURVEYOR TYPES
        private void LoadSurveyorTypeData()
        {
            objSetting = new SettingClassBLL();
            dgvSurveyorType.DataSource = objSetting.LoadSurveyorType();
            dgvSurveyorType.DataMember = "Table_Surveyor_Type";

            DgvSurveyorTypeStyle();
        }

        //SURVEYOR TYPE DATA GRIDVIEW STYLE
        private void DgvSurveyorTypeStyle()
        {
            dgvSurveyorType.Columns[0].Width = 300;
            dgvSurveyorType.Columns[0].HeaderText = "Surveyor Type";
        }
        //ADD NEW SURVEYOR TYPE
        private void AddSurveyorType()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtSurveyorType.Text))
                {
                    MessageBox.Show("Please enter Surveyor Type!", "Add New Surveyor Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objSetting = new SettingClassBLL();
                    if (objSetting.CheckSurveyorType(txtSurveyorType.Text) == false)
                    {
                        objSetting = new SettingClassBLL()
                        {
                            surveyorType = txtSurveyorType.Text
                        };
                        objSetting.AddNewSuerveyorType();
                        MessageBox.Show("Surveyor New Type added successful!", "Add New Surveyor Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSurveyorTypeData();
                        ClearTextBoxces();
                    }
                    else
                    {
                        MessageBox.Show("Surveyor Type is exist!", "Add New Surveyor Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxces();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //UPDATE SURVEYOR TYPE
        private void UpdateSurveyorType()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtSurveyorType.Text))
                {
                    MessageBox.Show("Please enter Surveyor Type!", "Surveyor Type Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objSetting = new SettingClassBLL();
                    if (objSetting.CheckSurveyorType(txtSurveyorType.Text) == false)
                    {
                        objSetting = new SettingClassBLL()
                        {
                            surveyorType = txtSurveyorType.Text,
                            existSurveyorType = dgvSurveyorType.CurrentRow.Cells[0].Value.ToString()
                        };
                        objSetting.UpdateSurveyorType();
                        MessageBox.Show("Surveyor Type update successful!", "Surveyor Type Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSurveyorTypeData();
                        ClearTextBoxces();
                    }

                    else
                    {
                        MessageBox.Show("Surveyor Type exist!", "Surveyor Type Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxces();
                    }
                }
                btnSurveyorTypeAdd.Text = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSurveyorTypeClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();
            btnSurveyorTypeAdd.Text = "Add";
        }

        private void dgvSurveyorType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                btnSurveyorTypeAdd.Text = "Update";
                txtSurveyorType.Text = dgvSurveyorType.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSurveyorType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }


        //--------------------------------------------------------------//
        //                       LAND MARK TYPE                         //
        //--------------------------------------------------------------//

        //LOAD LAND MARK DATA
        private void LoadLandMarTypekData()
        {
            objSetting = new SettingClassBLL();
            dgvLandMarkType.DataSource = objSetting.LoadLandMarkType();
            dgvLandMarkType.DataMember = "Table_LM_Type";

            DgvLandMarkTypeStyle();
        }

        //ADD NEW LAND MARK DATA
        private void AddLandMark()
        {
            if(String.IsNullOrWhiteSpace(txtLMType.Text))
            {
                MessageBox.Show("Please enter Land Mark Type!", "Land Mark Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                objSetting = new SettingClassBLL();
                if(objSetting.CheckLandMarkType(txtLMType.Text) == false)
                {
                    objSetting = new SettingClassBLL()
                    {
                        landMarkType=txtLMType.Text
                    };

                    objSetting.AddNewLandMarkType();
                    MessageBox.Show("Land Mark Type added successful!", "Add New Land Mark Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLandMarTypekData();
                    ClearTextBoxces();
                }
                else
                {
                    MessageBox.Show("Land Mark Type is exist!", "Land Mark Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxces();
                }
            }
        }

        //UPDATE LANDA MARK DATA
        private void UpdateLandMark()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtLMType.Text))
                {
                    MessageBox.Show("Please enter Land Mark Type!", "Land Mark Type Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objSetting = new SettingClassBLL();
                    if (objSetting.CheckLandMarkType(txtLMType.Text) == false)
                    {
                        objSetting = new SettingClassBLL()
                        {
                            landMarkType = txtLMType.Text,
                            existLandMarkType = dgvLandMarkType.CurrentRow.Cells[0].Value.ToString()
                        };
                        objSetting.UpdateLandMarkType();
                        MessageBox.Show("Land Mark Type update successful!", "Land Mark Type Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLandMarTypekData();
                        ClearTextBoxces();
                    }

                    else
                    {
                        MessageBox.Show("Surveyor Type exist!", "Surveyor Type Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxces();
                    }
                }
                btnLMTypeAdd.Text = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //DATAGRIDVIEW STYLE LANDA MARK TYPE
        private void DgvLandMarkTypeStyle()
        {
            dgvLandMarkType.Columns[0].Width = 300;
            dgvLandMarkType.Columns[0].HeaderText = "Land Mark Type";
        }

        private void btnLMTypeClear_Click(object sender, EventArgs e)
        {
            btnLMTypeAdd.Text = "Add";
            ClearTextBoxces();
        }

        private void dgvLandMarkType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                btnLMTypeAdd.Text = "Update";
                txtLMType.Text = dgvLandMarkType.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Land Mark Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLMType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }

        private void btnLMTypeAdd_Click(object sender, EventArgs e)
        {
            if (btnLMTypeAdd.Text == "Add")
                AddLandMark();//ADD NEW LAND MARK TYPE
            if (btnLMTypeAdd.Text == "Update")
                UpdateLandMark();//UPDATE LAND MARK TYPE
        }

        private void btnCommonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();
        }
    }
}
