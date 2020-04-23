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

        //ADD NEW DIVISION
        private void AddDivision() 
        {
            try
            {
                if(String.IsNullOrWhiteSpace(txtDivisioin.Text))
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

            DgvCommonStyle();//ALL DATAGRIDVIEW COMMONLY STYLE CHANGE
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

        //ALL DATAGRIDVIEW COMMONLY STYLE CHANGE
        private void DgvCommonStyle()
        {
            try
            {
                Action<Control.ControlCollection> func = null;
                func = (controls) =>
                {
                    foreach (Control control in controls)
                    {
                        if (control is DataGridView)
                        {
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
                    }
                };
                DgvDivisionStyle();//DIVISION DATAGRIDVIEW STYLE CHANGE
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Division Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDivisionClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
        }
    }
}
