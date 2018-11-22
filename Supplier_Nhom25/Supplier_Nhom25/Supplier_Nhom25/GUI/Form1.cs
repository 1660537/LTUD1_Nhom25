using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtSupplierID.ReadOnly = true;

        }
        public void TextRong()
        {
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtContactTitle.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtRegion.Clear();
            txtPostalCode.Clear();
            txtCountry.Clear();
            txtPhone.Clear();
            txtFax.Clear();
            txtHomePage.Clear();
        }
        void CreateColumn()
        {
            //xóa cột trước
            dtgXemDS.Columns.Clear();
            //cột SupplierID
            var dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "SupplierID";
            dtgXemDS.Columns.Add(dgvctb);
            //cot CompanyName
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "CompanyName";
            dtgXemDS.Columns.Add(dgvctb);
            //cot ContactName
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "ContactName";
            dtgXemDS.Columns.Add(dgvctb);
            //cot ContactTitle
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "ContactTitle";
            dtgXemDS.Columns.Add(dgvctb);
            //cot Address
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "Address";
            dtgXemDS.Columns.Add(dgvctb);
            //cot City
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "City";
            dtgXemDS.Columns.Add(dgvctb);
            //cot Region
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "Region";
            dtgXemDS.Columns.Add(dgvctb);
            //cot PostalCode
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "PostalCode";
            dtgXemDS.Columns.Add(dgvctb);
            //cot Country
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "Country";
            dtgXemDS.Columns.Add(dgvctb);
            //cot Phone
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "Phone";
            dtgXemDS.Columns.Add(dgvctb);
            //cot Fax
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "Fax";
            dtgXemDS.Columns.Add(dgvctb);
            //cot HomePage
            dgvctb = new DataGridViewTextBoxColumn();
            dgvctb.HeaderText = "HomePage";
            dtgXemDS.Columns.Add(dgvctb);
        }
        private void LoadDG()
        {
            dtgXemDS.Rows.Clear();
            DataGridViewRow row = null;
            DataGridViewCell cell = null;
            var ds = DAO.DataUlti.DSSupplier();
            foreach (var sv in ds)
            {
                row = new DataGridViewRow();
                //giu lai du lieu goc
                row.Tag = sv;
                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.SupplierID;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.CompanyName;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.ContactName;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.ContactTitle;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.Address;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.City;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.Region;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.PostalCode;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.Country;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.Phone;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.Fax;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = sv.HomePage;
                row.Cells.Add(cell);

                dtgXemDS.Rows.Add(row);
            }
            txtSupplierID.Text = DTO.Supplier.CreateSupplierID();
            TextRong();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumn();
            LoadDG();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DTO.Supplier slr = new DTO.Supplier();
            slr = DTO.Supplier.AddSupplier(Convert.ToInt32(txtSupplierID.Text),txtCompanyName.Text,txtContactTitle.Text, txtContactName.Text, txtAddress.Text,txtCity.Text,txtRegion.Text,txtPostalCode.Text,txtCountry.Text,txtPhone.Text,txtFax.Text,txtHomePage.Text);
            DAO.DataUlti.AddSupplier(slr);
            MessageBox.Show("Thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK);
            LoadDG();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int CurrentIndex =  dtgXemDS.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dtgXemDS.Rows[CurrentIndex].Cells[0].Value.ToString());
            DAO.DataUlti.DeleteSupplier(id);
            MessageBox.Show("Xóa thành công", "THÔNG BÁO", MessageBoxButtons.OK);
            LoadDG();
        }
    

     
        int demclick = 0;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (demclick == 0)
            {
                int CurrentIndex = dtgXemDS.CurrentCell.RowIndex;
                txtSupplierID.Text = dtgXemDS.Rows[CurrentIndex].Cells[0].Value.ToString();
                txtCompanyName.Text = dtgXemDS.Rows[CurrentIndex].Cells[1].Value.ToString();
                txtContactName.Text = dtgXemDS.Rows[CurrentIndex].Cells[2].Value.ToString();
                txtContactTitle.Text = dtgXemDS.Rows[CurrentIndex].Cells[3].Value.ToString();
                txtAddress.Text = dtgXemDS.Rows[CurrentIndex].Cells[4].Value.ToString();
                txtCity.Text = dtgXemDS.Rows[CurrentIndex].Cells[5].Value.ToString();
                txtRegion.Text = dtgXemDS.Rows[CurrentIndex].Cells[6].Value.ToString();
                txtPostalCode.Text = dtgXemDS.Rows[CurrentIndex].Cells[7].Value.ToString();
                txtCountry.Text = dtgXemDS.Rows[CurrentIndex].Cells[8].Value.ToString();
                txtPhone.Text = dtgXemDS.Rows[CurrentIndex].Cells[9].Value.ToString();
                txtFax.Text = dtgXemDS.Rows[CurrentIndex].Cells[10].Value.ToString();
                txtHomePage.Text = dtgXemDS.Rows[CurrentIndex].Cells[11].Value.ToString();
                btnUpdate.Text = "Lưu";
                demclick = 1;
            }
            else
            {
                DTO.Supplier slr = new DTO.Supplier();
                slr = DTO.Supplier.AddSupplier(Convert.ToInt32(txtSupplierID.Text), txtCompanyName.Text, txtContactTitle.Text, txtContactName.Text, txtAddress.Text, txtCity.Text, txtRegion.Text, txtPostalCode.Text, txtCountry.Text, txtPhone.Text, txtFax.Text, txtHomePage.Text);
                DAO.DataUlti.UpdateSupplier(slr);
                MessageBox.Show("Sửa thành công thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                LoadDG();
                btnUpdate.Text = "Sửa";
                demclick = 0;
            }
        }
    }
}
