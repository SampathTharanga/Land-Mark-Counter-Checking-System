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

        //ALL DATAGRIDVIEW COMMONLY STYLE CHANGE
        //private void DgvCommonStyle()
        //{
        //    try
        //    {
        //        Action<Control.ControlCollection> func = null;
        //        func = (controls) =>
        //        {
        //            foreach (Control control in controls)
        //            {
        //                if (control is DataGridView)
        //                {
        //                    (control as DataGridView).AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
        //                    (control as DataGridView).DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
        //                    (control as DataGridView).DefaultCellStyle.SelectionForeColor = Color.Black;
        //                    (control as DataGridView).BackgroundColor = Color.White;
        //                    (control as DataGridView).EnableHeadersVisualStyles = false;
        //                    (control as DataGridView).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        //                    (control as DataGridView).ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 50, 64);
        //                    (control as DataGridView).ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //                    (control as DataGridView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //                    (control as DataGridView).MultiSelect = false;
        //                    (control as DataGridView).AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        //                    (control as DataGridView).AllowUserToResizeRows = false;
        //                    (control as DataGridView).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        //                    (control as DataGridView).AllowUserToResizeColumns = false;
        //                }
        //            }
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


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
            //DgvCommonStyle();//ALL DATAGRIDVIEW COMMONLY STYLE CHANGE

            //DgvDivisionStyle();//DIVISION DATAGRIDVIEW STYLE CHANGE
            //DgvSurveyorTypeStyle();//SURVEYOR TYPE DATAGRIDVIEW STYLE CHANGE

            LoadDivisionDatas();//LOAD DIVISION DATA
            LoadSurveyorTypeData();//LOAD SURVEYOR TYPE DATA
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

            dgvDivision.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvDivision.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dgvDivision.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDivision.BackgroundColor = Color.White;
            dgvDivision.EnableHeadersVisualStyles = false;
            dgvDivision.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDivision.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 50, 64);
            dgvDivision.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDivision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDivision.MultiSelect = false;
            dgvDivision.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDivision.AllowUserToResizeRows = false;
            dgvDivision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDivision.AllowUserToResizeColumns = false;
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
            if (btnAddDivision.Text == "Add")
                AddSurveyorType();//ADD NEW SURVEYOR TYPE
            if (btnAddDivision.Text == "Update")
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

            dgvSurveyorType.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvSurveyorType.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dgvSurveyorType.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSurveyorType.BackgroundColor = Color.White;
            dgvSurveyorType.EnableHeadersVisualStyles = false;
            dgvSurveyorType.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSurveyorType.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 50, 64);
            dgvSurveyorType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSurveyorType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSurveyorType.MultiSelect = false;
            dgvSurveyorType.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvSurveyorType.AllowUserToResizeRows = false;
            dgvSurveyorType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvSurveyorType.AllowUserToResizeColumns = false;
        }
        //ADD NEW SURVEYOR TYPE
        private void AddSurveyorType()
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

    //UPDATE SURVEYOR TYPE
    private void UpdateSurveyorType()
        {
            throw new NotImplementedException();
        }
    }
}
