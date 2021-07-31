using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASS_EF.core.Context;
using ASS_EF.core.Models;

namespace ASS_EF.core
{
    public partial class FrmMain : Form
    {
        private IServices.IServices _IServices;
        private Guid _ID;
        public FrmMain()
        {
            InitializeComponent();
            _IServices = new Services.Services();
            loadYear();
            grbDanhBa.Hide();
        }

        private DatabaseContext _dbContext = new DatabaseContext();

        void ViewDanhba()
        {
            var dataAcc =
                from danhBa in _IServices.senderListDanhba()
                join person in _IServices.senderListPerson()
                    on danhBa.IdDbPp equals person.IdPp
                select new
                {
                    ID = person.IdPp,
                    Name = person.HoPp + " " + person.TenDemPp + " " + person.TenPp,
                    Sdt1 = danhBa.Sdt1,
                    Sdt2 = danhBa.Sdt2,
                    Mail = danhBa.Mail,
                    GhiChu = danhBa.GhiChu
                };
            dgvdata.Rows.Clear();
            dgvdata.ColumnCount = 6;
            dgvdata.Columns[0].Name = "ID";
            dgvdata.Columns[1].Name = "Người dùng";
            dgvdata.Columns[2].Name = "Só điện thoại 1";
            dgvdata.Columns[3].Name = "Số điện thoại 2";
            dgvdata.Columns[4].Name = "Email";
            dgvdata.Columns[5].Name = "Ghi chú";

            foreach (var x in dataAcc)
            {
                dgvdata.Rows.Add(x.ID,x.Name, x.Sdt1, x.Sdt2, x.Mail, x.GhiChu);
            }
        }
        void viewPerson()
        {

            dgvdata.Rows.Clear();
            dgvdata.ColumnCount = 4;
            dgvdata.Columns[0].Name = "ID";
            dgvdata.Columns[1].Name = "Người dùng";
            dgvdata.Columns[2].Name = "Năm sinh";
            dgvdata.Columns[3].Name = "Giới Tính";

            foreach (var x   in _IServices.senderListPerson())
            {
                dgvdata.Rows.Add(x.IdPp,x.HoPp + "  " + x.TenDemPp + "  " + x.TenPp, x.NamSinhPp, x.GioiTinhPp);
            }
        }
        private void btnLoadDanhba_Click(object sender, EventArgs e)
        {
            grbPeople.Hide();
            grbDanhBa.Show();
            ViewDanhba();
        }

        private void btnLoadPerson_Click(object sender, EventArgs e)
        {
            grbDanhBa.Hide();
            grbPeople.Show();
            viewPerson();
        }

        private void dgvdata_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int countRow = dgvdata.ColumnCount;
            int index = e.RowIndex;
            if (index<0)return;
            if (countRow == 4)
            {
                getDataDgvPerson(index);
            }

            if (countRow == 6)
            {
                getDataDgvDanhba(index);
            }
        }
        void getDataDgvDanhba(int index)
        {
            txtTenDb.Text = dgvdata.Rows[index].Cells[1].Value.ToString();
            txtSdt1.Text = dgvdata.Rows[index].Cells[2].Value.ToString();
            txtSdt2.Text = dgvdata.Rows[index].Cells[3].Value.ToString();
            txtMail.Text = dgvdata.Rows[index].Cells[4].Value.ToString();
            rtbGhiChu.Text = dgvdata.Rows[index].Cells[5].Value.ToString();
        }

        void getDataDgvPerson(int index)
        {
            var name = dgvdata.Rows[index].Cells[1].Value.ToString().Split(" ");
            txtHo.Text = name[0];
            txtTenDem.Text = name[1];
            txtTen.Text = name[2];
            cbNamSinh.Text = dgvdata.Rows[index].Cells[2].Value.ToString();
            cbGioiTinh.Text = (bool)dgvdata.Rows[index].Cells[3].Value == true ? "Nam":"Nữ";
        }
        
        void loadYear()
        {
            for (int i= 1900; i < DateTime.Now.Year; i++)
            {
                cbNamSinh.Items.Add(i);
            }
        }

        bool validateForm()
        {
            return true;
        }

        private void btnThemPp_Click(object sender, EventArgs e)
        {
            _IServices.addPerson(resultPerson());
            MessageBox.Show(_IServices.saveChangeData());
        }

        Person resultPerson()
        {
            var ID = Guid.NewGuid();
            Person people = new Person();
            people.IdPp = ID;
            people.HoPp = txtHo.Text;
            people.TenDemPp = txtTenDem.Text;
            people.TenPp = txtTen.Text;
            people.GioiTinhPp = cbGioiTinh.Text == "Nam" ? true : false;
            people.NamSinhPp = Convert.ToInt32(cbNamSinh.Text);
            return people;
        }
    }
}
