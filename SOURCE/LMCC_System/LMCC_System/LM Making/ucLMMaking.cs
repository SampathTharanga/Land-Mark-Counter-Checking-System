using BusinessLogicLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LMCC_System
{
    public partial class ucLMMaking : UserControl
    {
        //USER CONTROL LOAD IN TO MAIN PANEL
        private static ucLMMaking LMMaking_Instance;
        public static ucLMMaking _LMMaking
        {
            get
            {
                LMMaking_Instance = null;
                if (LMMaking_Instance == null)
                    LMMaking_Instance = new ucLMMaking();
                return LMMaking_Instance;
            }
        }
        public ucLMMaking()
        {
            InitializeComponent();
        }


        LM_MakingClassBLL objClassBLL;

        //SET CURRENT USER USERNAME AND DIVISION
        static string _username = "", _division = "";
        public static void PassValue(string username, string division)
        {
            _division = division;
            _username = username;
        }


        //VARIABLE DECLAIR
        int id = 0;

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
                MessageBox.Show(ex.Message, "SURVEYOR ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SAVE DATA
        private void DataSave()
        {
            try
            {
                if (//CHECK TEXBOXES NOT NULL OR EMPTY
                    String.IsNullOrWhiteSpace(txtSupplierName.Text) ||
                    String.IsNullOrWhiteSpace(cbxLmType.Text.ToString()) ||
                    String.IsNullOrWhiteSpace(txtNoOfLM.Text)
                    )
                {
                    MessageBox.Show("You must be filling all field!.", "LM Making Added Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                        //PROPERTIES FOR DATA ADD
                        objClassBLL = new LM_MakingClassBLL()
                        {
                            //making_id = txtEmpRegNo.Text,
                            date = DateTime.Today,
                            lm_type = cbxLmType.Text.ToString(),
                            supplier_name = txtSupplierName.Text,
                            no_of_lm = int.Parse(txtNoOfLM.Text),
                            username = _username,
                            division = _division
                        };
                        //INSERT DATA TO DATABASE
                        objClassBLL.AddNew();
                        MessageBox.Show("Lm making added successfully!", "LM MAKING", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //CLEAR ALL TEXBOX AND COMBOBOX
                        ClearTextBoxces();

                        //LOAD USER DATA
                        LoadDataDgv();

                        //SET TO BUTTON TEXT Add
                        btnAdd.Text = "Add";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LM MAKING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //UPDATE DATA
        private void DataUpadate()
        {
            try
            {
                if (//CHECK TEXBOXES NOT NULL OR EMPTY
                    String.IsNullOrWhiteSpace(txtSupplierName.Text) ||
                    String.IsNullOrWhiteSpace(cbxLmType.Text.ToString()) ||
                    String.IsNullOrWhiteSpace(txtNoOfLM.Text)
                    )
                {
                    MessageBox.Show("You must be filling all field!.", "LM MAKING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    objClassBLL = new LM_MakingClassBLL()
                    {
                        making_id = id,
                        date = DateTime.Today,
                        lm_type = cbxLmType.Text.ToString(),
                        supplier_name = txtSupplierName.Text,
                        no_of_lm = int.Parse(txtNoOfLM.Text),
                        username = _username,
                        division = _division
                    };
                    objClassBLL.Update();//UPDATE USER DATA



                    MessageBox.Show("LM making Update successfully!", "LM MAKING", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //CLEAR ALL TEXBOX AND COMBOBOX
                    ClearTextBoxces();

                    //LOAD USER DATA
                    LoadDataDgv();

                    //SET TO BUTTON TEXT Add
                    btnAdd.Text = "Add";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LM MAKING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD DATA
        private void LoadDataDgv()
        {
            objClassBLL = new LM_MakingClassBLL();
            dgvLmMaking.DataSource = objClassBLL.Load();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL TEXBOX AND COMBOBOX
            btnAdd.Text = "Add";
        }

        private void ucLMMaking_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            btnAdd.Text = "Add";//TEXTBOX DEFAULT TEXT SET AFTER DATAGRIDVIEW ROW DOUBLE CLICK   

            LoadDataDgv();//LOAD USER DATA
            DataGrdViewDesign();//DATAGRIDVIEW DESIGN

            //LOAD DIVISION DATA TO COMBO BOX
            objClassBLL = new LM_MakingClassBLL();
            cbxLmType.DataSource = objClassBLL.LoadType();
            cbxSearchLmType.DataSource = objClassBLL.LoadType();

            //CLEAR ALL COMBOBOX DEFAULT SELECT VALUE
            ClearTextBoxces();
        }

        private void dgvLmMaking_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                btnAdd.Text = "Update";//ADD BUTTON TEXT CHANGE TO Update
                id = int.Parse(dgvLmMaking.CurrentRow.Cells[0].Value.ToString());
                cbxLmType.Text = dgvLmMaking.CurrentRow.Cells[2].Value.ToString();
                txtSupplierName.Text = dgvLmMaking.CurrentRow.Cells[3].Value.ToString();
                txtNoOfLM.Text = dgvLmMaking.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SURVEYOR ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")//ADD BUTTON USE
                DataSave();//DATA SAVE

            if (btnAdd.Text == "Update")//UPDATE BUTTON USE
                DataUpadate();//DATA UPDATE
        }

        private void txtSearchSupName_TextChanged(object sender, EventArgs e)
        {
            //FILTER DATA
            (dgvLmMaking.DataSource as DataTable).DefaultView.RowFilter = string.Format("supplier_name  LIKE '%" + txtSearchSupName.Text + "%'");
        }

        private void cbxSearchLmType_TextChanged(object sender, EventArgs e)
        {
            //FILTER DATA
            (dgvLmMaking.DataSource as DataTable).DefaultView.RowFilter = string.Format("lm_type  LIKE '%" + cbxSearchLmType.Text + "%'");
        }

        private void txtSearchSupName_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL COMBOBOX DEFAULT SELECT VALUE
        }

        private void cbxSearchLmType_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxces();//CLEAR ALL COMBOBOX DEFAULT SELECT VALUE
        }

        //DATAGRIDVIEW DESIGN SECTION
        private void DataGrdViewDesign()
        {
            try
            {
                dgvLmMaking.Columns[0].HeaderText = "ID";
                dgvLmMaking.Columns[1].HeaderText = "Date";
                dgvLmMaking.Columns[2].HeaderText = "LM Type";
                dgvLmMaking.Columns[3].HeaderText = "Suplier Name";
                dgvLmMaking.Columns[4].HeaderText = "No Of Item";
                dgvLmMaking.Columns[5].HeaderText = "Username";
                dgvLmMaking.Columns[6].HeaderText = "Division";

                dgvLmMaking.Columns[0].Width = 50;
                dgvLmMaking.Columns[1].Width = 100;
                dgvLmMaking.Columns[2].Width = 100;
                dgvLmMaking.Columns[3].Width = 200;
                dgvLmMaking.Columns[4].Width = 100;
                dgvLmMaking.Columns[5].Width = 100;
                dgvLmMaking.Columns[6].Width = 100;

                //dgvUser.BorderStyle = BorderStyle.None;
                dgvLmMaking.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dgvLmMaking.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvLmMaking.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
                dgvLmMaking.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvLmMaking.BackgroundColor = Color.White;

                dgvLmMaking.EnableHeadersVisualStyles = false;
                dgvLmMaking.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgvLmMaking.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 50, 64);
                dgvLmMaking.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dgvLmMaking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvLmMaking.MultiSelect = false;

                dgvLmMaking.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvLmMaking.AllowUserToResizeRows = false;

                dgvLmMaking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LM MAKING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
