using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private int _indexRow;
        private bool _Flag = false;
        public FrmMain()
        {
            InitializeComponent();
            _IServices = new Services.Services();
            loadYear();
            btnLoadPerson_Click(null, null);
        }

        // bao gồm các hàm xử lý thông tin truyền vào , các hàm trả về " danh bạ , người dùng " , các hàm xử lý data trên datagridview
        #region Các hàm xự lý trên form
        //reset dẽ liệu trên groupbox Danh bạ
        void clearGrbDanhba()
        {
            txtTenDb.Text =
                txtSdt1.Text =
                    txtSdt2.Text =
                        txtMail.Text =
                            rtbGhiChu.Text =
                                default;
            ViewDanhba();
        }
        // reset dữ liệu trên groupbox người dùng
        void clearGrbPerson()
        {
            txtHo.Text =
                txtTenDem.Text =
                    txtTen.Text =
                        default;
            viewPerson();
        }
        // query dữ liệu từ list danh bạ và list người dùng rồi đổ lên datagridview
        void ViewDanhba()
        {
            var data =
                from danhBa in _IServices.senderListDanhba()
                join person in _IServices.senderListPerson()
                    on danhBa.IdDbPp equals person.IdPp
                select new
                {
                    ID = person.IdPp,
                    Name = person.HoPp + "      " + person.TenDemPp + "      " + person.TenPp,
                    NamSinh = person.NamSinhPp,
                    GioiTinh = person.GioiTinhPp,
                    Sdt1 = danhBa.Sdt1,
                    Sdt2 = danhBa.Sdt2,
                    Mail = danhBa.Mail,
                    GhiChu = danhBa.GhiChu
                };
            if (dgvdata.Rows.Count > 0)
                dgvdata.Rows.Clear();
            dgvdata.ColumnCount = 5;
            dgvdata.Columns[0].Name = "Người dùng";
            dgvdata.Columns[1].Name = "Só điện thoại 1";
            dgvdata.Columns[2].Name = "Số điện thoại 2";
            dgvdata.Columns[3].Name = "Email";
            dgvdata.Columns[4].Name = "Ghi chú";

            foreach (var x in data)
            {
                dgvdata.Rows.Add(x.Name, x.Sdt1, x.Sdt2, x.Mail, x.GhiChu);
            }
        }
        // đổ dữ liệu từ list người dùng bên services lên datagridview
        void viewPerson()
        {
            dgvdata.Rows.Clear();
            dgvdata.ColumnCount = 3;
            dgvdata.Columns[0].Name = "Người dùng";
            dgvdata.Columns[1].Name = "Năm sinh";
            dgvdata.Columns[2].Name = "Giới Tính";

            foreach (var x in _IServices.senderListPerson())
            {
                dgvdata.Rows.Add(x.HoPp + "      " + x.TenDemPp + "      " + x.TenPp, x.NamSinhPp, x.GioiTinhPp == true ? "Nam" : "Nữ");
            }
        }
        // thao tác dữ liệu trên datagriview
        private void dgvdata_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int countRow = dgvdata.ColumnCount;
            int _indexRow = e.RowIndex;
            if (_indexRow < 0) return;

            if (countRow == 3)
            {
                getDataDgvPerson(_indexRow);
            }

            if (countRow == 5)
            {
                getDataDgvDanhba(_indexRow);
            }
        }
        // đổ dữ liệu từ datagridview (data danh bạ) lên các textbox phù hợp
        void getDataDgvDanhba(int index)
        {
            txtTenDb.Text = dgvdata.Rows[index].Cells[0].Value.ToString();
            txtSdt1.Text = dgvdata.Rows[index].Cells[1].Value.ToString();
            txtSdt2.Text = dgvdata.Rows[index].Cells[2].Value.ToString();
            txtMail.Text = dgvdata.Rows[index].Cells[3].Value.ToString();
            rtbGhiChu.Text = dgvdata.Rows[index].Cells[4].Value.ToString();
        }
        // đổ dữ liệu từ datagridview (data người dùng) lên các textbox phù hợp
        void getDataDgvPerson(int index)
        {
            var name = dgvdata.Rows[index].Cells[0].Value.ToString().Split("      ");
            txtHo.Text = name[0];
            txtTenDem.Text = name[1];
            txtTen.Text = name[2];
            cbNamSinh.Text = dgvdata.Rows[index].Cells[1].Value.ToString();
            cbGioiTinh.Text = dgvdata.Rows[index].Cells[2].Value == "Nam" ? "Nam" : "Nữ";
            btnKiemTra.Enabled = true;
        }
        // đổ dữ liệu vào combobox năm sinh
        void loadYear()
        {
            for (int i = DateTime.Now.Year - 70; i < DateTime.Now.Year; i++)
            {
                cbNamSinh.Items.Add(i);
            }

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbNamSinh.SelectedIndex = (DateTime.Now.Year - (DateTime.Now.Year - 70)) / 2;
            cbGioiTinh.SelectedItem = "Nữ";
        }
        // validate thông tin nhập vào 
        bool validateForm()
        {




            return true;
        }
        // lấy thông tin nhập vào trên form trả về đối tượng người dùng
        Person resultPerson(Guid ID)
        {
            Person people = new Person();
            people.IdPp = ID;
            people.HoPp = txtHo.Text;
            people.TenDemPp = txtTenDem.Text;
            people.TenPp = txtTen.Text;
            people.GioiTinhPp = cbGioiTinh.Text == "Nam" ? true : false;
            people.NamSinhPp = Convert.ToInt32(cbNamSinh.Text);
            return people;
        }
        // lấy thông tin nhập vào trên form trả về đối tượng danh bạ
        DanhBa resultDanhba()
        {
            var danhba = new DanhBa
            {
                IdDbPp = _ID,
                Sdt1 = txtSdt1.Text,
                Sdt2 = txtSdt2.Text,
                GhiChu = rtbGhiChu.Text,
                Mail = txtMail.Text,
            };
            return danhba;
        }
        #endregion

        // các hàm sự kiện khi click nút trên form
        #region Sự kiện nhấn nút trên form
        // button xóa click
        private void btnXoaPp_Click(object sender, EventArgs e)
        {
            if (dgvdata.ColumnCount == 3)
            {
                _IServices.xoaPerson(resultPerson(_ID));
                clearGrbPerson();
            }

            if (dgvdata.ColumnCount == 5)
            {
                _IServices.xoaDanhBa(resultDanhba());
                clearGrbDanhba();
            }

            _Flag = true;
        }
        // button thêm click 
        private void btnThemPp_Click(object sender, EventArgs e)
        {
            if (!Validate())
                return;
            if (dgvdata.ColumnCount == 3)
            {
                _IServices.addPerson(resultPerson(Guid.NewGuid()));
                clearGrbPerson();
            }

            _Flag = true;
        }
        // button Sửa click
        private void btnSuaPp_Click(object sender, EventArgs e)
        {
            if (dgvdata.ColumnCount == 3)
            {
                _IServices.updatePerson(resultPerson(_ID));
                clearGrbPerson();
            }
            if (dgvdata.ColumnCount == 5)
            {
                _IServices.updateDanhBa(resultDanhba());
                clearGrbDanhba();
            }

            _Flag = true;
        }
        // button Lưu click
        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_IServices.saveChangeData());
            _Flag = false;
        }

        // button load dữ liệu danh bạ click --> lấy dữ liệu từ list danh bạ bên services đổ về form
        private void btnLoadDanhba_Click(object sender, EventArgs e)
        {
            grbPeople.Hide();
            grbDanhBa.Show();
            ViewDanhba();
        }
        // button load dữ liệu --> lấy dữ liệu list người dùng bên services đổ về form
        private void btnLoadPerson_Click(object sender, EventArgs e)
        {
            grbDanhBa.Hide();
            grbPeople.Show();
            viewPerson();
        }
        #endregion
        // button kiểm tra danh bạ --> kiểm tra xem 
        private DialogResult xacNhapThemDuLieu;
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            var infor = _IServices.getListView();
            xacNhapThemDuLieu =
                MessageBox.Show("Hiện tại chưa có thông tin danh bạ . bạn có muốn thêm ?", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (infor.ToList().Count == 0)
            {
                if (xacNhapThemDuLieu == DialogResult.Yes)
                {
                    _IServices.addDanhBa(resultDanhba());
                    btnKiemTra_Click(null, null);
                }
            }
            else
            {
                var data = infor.ToList()[0];
                btnLoadDanhba_Click(null, null);
                txtTenDb.Text = data.Name;
                txtSdt1.Text = data.Phone1;
                txtSdt2.Text = data.Phone2;
                txtMail.Text = data.Mail;
                rtbGhiChu.Text = data.GhiChu;
            }
        }

        private void btnClearPp_Click(object sender, EventArgs e)
        {
            if (dgvdata.ColumnCount == 3)
            {
                clearGrbPerson();
                btnKiemTra.Enabled = false;
            }

            if (dgvdata.ColumnCount == 5)
            {
                clearGrbDanhba();
            }
        }
        // event khi đóng form mà chưa lưu dữ liệu
        DialogResult xacNhanCloseForm = MessageBox.Show("Có muốn lưu dữ liệu trước khi thoát ?", "Thông Báo",
        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Flag == false) return;
            if (xacNhanCloseForm == DialogResult.Yes)
            {
                _IServices.saveChangeData();
                Application.Exit();
            }

            if (xacNhanCloseForm == DialogResult.Cancel)
            {
                return;
            }

            if (xacNhanCloseForm == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            var data =
                _IServices.getListView().Where(x =>
                x.Name.ToUpper().StartsWith(txtTimKiem.Text.ToUpper()) ||
                x.Phone1.StartsWith(txtTimKiem.Text) ||
                x.Phone2.StartsWith(txtTimKiem.Text) ||
                x.Mail.StartsWith(txtTimKiem.Text));
            if (dgvdata.ColumnCount == 5)
            {
                ViewDanhba();
                dgvdata.Rows.Clear();
                foreach (var x in data.ToList())
                {
                    dgvdata.Rows.Add(x.Name, x.Phone1, x.Phone2, x.Mail, x.GhiChu);
                }
            }

            if (dgvdata.ColumnCount == 3)
            {
                viewPerson();
                dgvdata.Rows.Clear();
                foreach (var x in data.ToList())
                {
                    dgvdata.Rows.Add(x.Name, x.YearOfBirth, x.Sex == true ? "Nam" : "Nữ");
                }
            }
        }

        private void cbNhaMang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] viettel = { "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039" };
            string[] mobiphone = { "088", "091", "094", "081", "082", "083", "084", "085" };
            string[] mobifone = { "089", "090", "093", "070", "079", "077", "076", "078" };
            string[] vietnamobile = { "092", "056", "058" };
            string[] gmobile = { "092", "056", "058" };
            if (cbNhaMang.Text == "viettel")
            {
                if (dgvdata.Rows.Count > 0)
                    dgvdata.Rows.Clear();
                List<VwPeopleDanhba> dataViettel = new List<VwPeopleDanhba>();
                foreach (var y in _IServices.getListView())
                {
                    foreach (var x in viettel)
                    {
                        if (y.Phone1.StartsWith(x) || y.Phone2.StartsWith(x))
                        {
                            if (dgvdata.ColumnCount == 5)
                                dgvdata.Rows.Add(y.Name, y.Phone1, y.Phone2, y.Mail, y.GhiChu);
                            if (dgvdata.ColumnCount == 3)
                                dgvdata.Rows.Add(y.Name, y.YearOfBirth, y.Sex);
                            return;
                        }
                    }
                }
            }
        }

        //
    }
}
