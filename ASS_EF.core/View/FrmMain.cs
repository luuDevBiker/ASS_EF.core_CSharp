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
        private Guid _ID;//biến theo dõi ID của đối tượng đang được chọn --> được gán khi click vào datagridview --> thao tác các chức năng sửa xóa
        private List<VwPeopleDanhba> _lstPeopleDanhbas;// list data được gộp từ từ hai bảng Người và danh bạ
        private int _indexRow;// biến theo dõi vị trí của row đang được click trên datagridview
        private bool _Flag = false;// biến cờ theo dõi sự thay đổi của data
        private int _flagDgv = 0;// biến cờ của datagridview theo dõi dữ liệu được đổ trên datagridview --> dựa bào data trên gridview là của bảng nào [ 0 : ]
        public FrmMain()
        {
            InitializeComponent();
            _IServices = new Services.Services();
            _lstPeopleDanhbas = new List<VwPeopleDanhba>();
            loadYear();
            btnLoadPerson_Click(null, null);
        }

        // bao gồm các hàm xử lý thông tin truyền vào , các hàm trả về " danh bạ , người dùng " , các hàm xử lý data trên datagridview
        #region Các hàm xự lý trên form
        //reset dẽ liệu trên groupbox Danh bạ gán lại giá trị mặc định
        void clearGrbDanhba()
        {
            txtTenDb.Text =
                txtSdt1.Text =
                    txtSdt2.Text =
                        txtMail.Text =
                            rtbGhiChu.Text =
                                default;
            var data = _IServices.sendPeopleDanhbas();
            ViewDanhba(data);// hiện thông tin của list danh bạ lên datagridview
            btnSuaPp.Enabled = btnXoaPp.Enabled = btnKiemTra.Enabled = false;
        }
        // reset dữ liệu trên groupbox người dùng
        void clearGrbPerson()
        {
            txtHo.Text =
                txtTenDem.Text =
                    txtTen.Text =
                        default;
            viewPerson();// hiện danh sách các người dùng lên datagridview
            btnSuaPp.Enabled = btnXoaPp.Enabled = btnKiemTra.Enabled = false;
        }
        // query dữ liệu từ list danh bạ và list người dùng rồi đổ lên datagridview
        void ViewDanhba(IEnumerable<VwPeopleDanhba> vwDanhBas)
        {
            if (dgvdata.Rows.Count > 0)// kiểm tra nếu trên datagridview đang có dữ liệu thì xóa data đi rồi đổ lại cột và data
                dgvdata.Rows.Clear();
            dgvdata.ColumnCount = 5;
            dgvdata.Columns[0].Name = "Người dùng";
            dgvdata.Columns[1].Name = "Só điện thoại 1";
            dgvdata.Columns[2].Name = "Số điện thoại 2";
            dgvdata.Columns[3].Name = "Email";
            dgvdata.Columns[4].Name = "Ghi chú";
            foreach (var x in vwDanhBas) // đổ data danh bạ được lọc ra từ list data được gộp của hai bảng người dùng và danh bạ
            {
                dgvdata.Rows.Add(x.Name, x.Phone1, x.Phone2, x.Mail, x.GhiChu);
            }
        }
        // đổ dữ liệu từ list người dùng bên services lên datagridview
        void viewPerson()
        {
            if (dgvdata.Rows.Count > 0)// kiểm tra nếu trên datagridview đang có dữ liệu thì xóa data đi rồi đổ lại cột và data
            dgvdata.Rows.Clear();
            dgvdata.ColumnCount = 3;
            dgvdata.Columns[0].Name = "Người dùng";
            dgvdata.Columns[1].Name = "Năm sinh";
            dgvdata.Columns[2].Name = "Giới Tính";

            foreach (var x in _IServices.senderListPerson())// đổ data lên datagridview --> data được lấy từ list người
            {
                dgvdata.Rows.Add(x.HoPp + "      " + x.TenDemPp + "      " + x.TenPp, x.NamSinhPp, x.GioiTinhPp == true ? "Nam" : "Nữ");
            }
            _flagDgv = 0;
        }
        // thao tác dữ liệu trên datagriview
        private void dgvdata_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int countRow = dgvdata.ColumnCount;// biến theo dõi số lượng cột trên datagridview
            int _indexRow = e.RowIndex;// lấy vị trí của dòng đang được select
            if (_indexRow < 0) return;// nếu click ra khỏi phạm vi của datagridview thì ngưng chương trình
            if (_flagDgv == 1) _ID = _lstPeopleDanhbas[_indexRow].Id;// _flagDgv = 1 --> dữ liệu đang được hiển thị là của _lstPeopleDanhbas thông qua vị trí của dòng đang được select trên gridview --. truy vấn ngược lại _lstPeopleDanhbas để lấy ra ID 
            if (_flagDgv == 0) // _flagDgv = 0 --> dữ liệu đang được hiển thị là của senderListPerson() hoặc sendPeopleDanhbas() truy vấn ngược lại để lấy ID
            {
                if (dgvdata.ColumnCount == 3)
                    _ID = _IServices.senderListPerson()[_indexRow].IdPp;
                if (dgvdata.ColumnCount == 5)
                    _ID = _IServices.sendPeopleDanhbas()[_indexRow].Id;
            }
            lblID.Text = _ID + "\n";
            // gán các thông tin của row lên form phù hợp
            if (countRow == 3)
            {
                getDataDgvPerson(_indexRow);
            }
            if (countRow == 5)
            {
                getDataDgvDanhba(_indexRow);
            }
            btnSuaPp.Enabled = btnXoaPp.Enabled = btnKiemTra.Enabled = true;
            btnThemPp.Enabled = false;
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
            var name = dgvdata.Rows[index].Cells[0].Value.ToString().Split("      ");// cắt tên thành họ , tên đệm và tên gán giá trị lên textbox
            txtHo.Text = name[0];
            txtTenDem.Text = name[1];
            txtTen.Text = name[2];
            cbNamSinh.Text = dgvdata.Rows[index].Cells[1].Value.ToString();
            cbGioiTinh.Text = dgvdata.Rows[index].Cells[2].Value == "Nam" ? "Nam" : "Nữ";
            btnKiemTra.Enabled = true;
        }
        // đổ dữ liệu vào combobox năm sinh -- gán giá trị cho combobox nhà mạng và giới tính
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
            cbNhaMang.Text = "lọc nhà mạng";
        }
        // validate thông tin nhập vào 
        bool validateForm()
        {
            if (dgvdata.ColumnCount == 3)
            {
                if (Regex.IsMatch(txtHo.Text, @"[0-9]") || Regex.IsMatch(txtTenDem.Text, @"[0-9]") || Regex.IsMatch(txtTen.Text, @"[0-9]"))
                {
                    MessageBox.Show("họ và tên không được có số.");
                    return false;
                }
                if (txtHo.Text.Length == 0 || txtTenDem.Text.Length == 0 || txtTen.Text.Length == 0)
                {
                    MessageBox.Show("không được để trống dữ liệu.");
                    return false;
                }
            }

            if (dgvdata.ColumnCount == 5)
            {
                if (Regex.IsMatch(txtSdt1.Text, @"[^0-9]") || Regex.IsMatch(txtSdt2.Text, @"[^0-9]") || Regex.IsMatch(txtSdt1.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    MessageBox.Show("Kiểm tra lại định dạng của số điện toại và mail.");
                    return false;
                }

                if (txtSdt1.Text.Length == 0 || txtSdt2.Text.Length == 0 || txtMail.Text.Length == 0 || rtbGhiChu.Text.Length == 0)
                {
                    MessageBox.Show("không được để trống thông tin .");
                    return false;
                }
            }
            return true;
        }
        // lấy thông tin nhập vào trên form trả về đối tượng người dùng
        Person resultPerson(Guid ID)// ID có thể là new ID hoặc là lấy ID từ dâtgridview khi click
        {
            Person people = new Person();
            people.IdPp = ID;
            lblID.Text = people.IdPp + "\n";
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
                IdDbPp = _ID,// ID được lấy khi datagridview click select 
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
        // dialogresult confilm CRUD
        DialogResult _Confilm;
        // button xóa click
        private void btnXoaPp_Click(object sender, EventArgs e)
        {
            _Confilm = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (_Confilm == DialogResult.Yes)
            {
                if (dgvdata.ColumnCount == 3)
                {
                    MessageBox.Show(_IServices.xoaPerson(resultPerson(_ID)));
                    clearGrbPerson();
                }
                if (dgvdata.ColumnCount == 5)
                {
                    _IServices.xoaDanhBa(resultDanhba());
                    clearGrbDanhba();
                } 
            }
            btnThemPp.Enabled = false;
            _Flag = true;
        }
        // button thêm click 
        private void btnThemPp_Click(object sender, EventArgs e)
        {
            if (!validateForm())
                return;
            _Confilm = MessageBox.Show("Bạn chắc chắn muốn thêm ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (_Confilm == DialogResult.Yes)
            {
                if (dgvdata.ColumnCount == 3)
                {
                    _IServices.addPerson(resultPerson(Guid.NewGuid()));
                    clearGrbPerson();
                } 
            }
            else
            {
                return;
            }
            _Flag = true;
        }
        // button Sửa click
        private void btnSuaPp_Click(object sender, EventArgs e)
        {
            if (!validateForm())
                return;
            _Confilm = MessageBox.Show("Bạn chắc chắc muốn cập nhật thông tin ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (_Confilm == DialogResult.Yes)
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
            }
            btnThemPp.Enabled = false;
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
            _flagDgv = 0;
            grbPeople.Hide();
            grbDanhBa.Show();
            ViewDanhba(_IServices.getListView());
        }
        // button load dữ liệu --> lấy dữ liệu list người dùng bên services đổ về form
        private void btnLoadPerson_Click(object sender, EventArgs e)
        {
            _flagDgv = 0;
            grbDanhBa.Hide();
            grbPeople.Show();
            viewPerson();
        }
        // button kiểm tra danh bạ --> kiểm tra xem người dùng đã có danh bạ hay chưa nếu chưa có thì hỏi xem có muốn thêm hay không --> chuyển qua form danh bạ
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            _lstPeopleDanhbas.Clear();
            var data = _IServices.sendPeopleDanhbas().Where(x => x.Id == _ID);
            _lstPeopleDanhbas = data.ToList();
            if (_lstPeopleDanhbas.Count == 0)
            {
                var xacNhapThemDuLieu =
                    MessageBox.Show("Hiện tại chưa có thông tin danh bạ . bạn có muốn thêm ?", "Thông Báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (xacNhapThemDuLieu == DialogResult.Yes)
                {
                    _IServices.addDanhBa(resultDanhba());
                    btnKiemTra_Click(null, null);
                }
            }
            else
            {
                btnLoadDanhba_Click(null, null);
                ViewDanhba(_lstPeopleDanhbas);
                var danhba = _lstPeopleDanhbas[0];
                txtTenDb.Text = danhba.Name;
                txtSdt1.Text = danhba.Phone1;
                txtSdt2.Text = danhba.Phone2;
                txtMail.Text = danhba.Mail;
                rtbGhiChu.Text = danhba.GhiChu;
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
            btnThemPp.Enabled = true;
        }
        // event khi đóng form mà chưa lưu dữ liệu
        private DialogResult xacNhanCloseForm;
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Flag == false) return;
            xacNhanCloseForm = MessageBox.Show("Có muốn lưu dữ liệu trước khi thoát ?", "Thông Báo",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (xacNhanCloseForm == DialogResult.Yes)
            {
                _IServices.saveChangeData();
                Environment.Exit(1);
            }

            if (xacNhanCloseForm == DialogResult.Cancel)
            {
                return;
            }

            if (xacNhanCloseForm == DialogResult.No)
            {
                Environment.Exit(1);
            }
        }
        // tìm kiếm textbox tìm kiếm
        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            var data =
                _IServices.sendPeopleDanhbas().Where(x =>
                x.Name.ToUpper().StartsWith(txtTimKiem.Text.ToUpper()) ||
                x.Phone1.StartsWith(txtTimKiem.Text) ||
                x.Phone2.StartsWith(txtTimKiem.Text) ||
                x.Mail.StartsWith(txtTimKiem.Text));
            _lstPeopleDanhbas = data.ToList();// đổ về list người danh bạ để theo dõi cho việc lấy mã ID
            if (dgvdata.ColumnCount == 5)
            {
                dgvdata.Rows.Clear();
                ViewDanhba(data);
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

            _flagDgv = 1;
        }
        // lọc nhà mạng
        private void cbNhaMang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dgvdata.ColumnCount == 3)clearGrbPerson();
            if(dgvdata.ColumnCount == 5)clearGrbDanhba();
            _flagDgv = 1;
            string[] viettel = { "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039" };
            string[] mobiphone = { "088", "091", "094", "081", "082", "083", "084", "085" };
            string[] vinaphone = { "089", "090", "093", "070", "079", "077", "076", "078" };
            string[] vietnamobile = { "092", "056", "058" };
            string[] gmobile = { "092", "056", "058" };

            if (cbNhaMang.Text == "Viettel")
            {
                selectData(viettel);
            }

            if (cbNhaMang.Text == "Mobiphone")
            {
                selectData(mobiphone);
            }
            if (cbNhaMang.Text == "Vinaphone")
            {
                selectData(vinaphone);
            }
            if (cbNhaMang.Text == "Vietnamobile")
            {
                selectData(vietnamobile);
            }
            if (cbNhaMang.Text == "Gmobile")
            {
                selectData(gmobile);
            }
        }

        void selectData(string[] nhaMang)// truyền vào 1 mảng các nhà mạng lọc số điện thoại có đầu số bắt đầu với các sô trong mảng 
        {
            _flagDgv = 1;// thay đổi biến cờ chuyển qua danh sách danh bạ người dùng
            if (dgvdata.Rows.Count > 0)
                dgvdata.Rows.Clear();
            foreach (var y in _IServices.getListView())
            {
                foreach (var x in nhaMang)
                {
                    if (y.Phone1.StartsWith(x) || y.Phone2.StartsWith(x))
                    {
                        _lstPeopleDanhbas.Add(y);
                        if (dgvdata.ColumnCount == 5)
                            dgvdata.Rows.Add(y.Name, y.Phone1, y.Phone2, y.Mail, y.GhiChu);
                        if (dgvdata.ColumnCount == 3)
                            dgvdata.Rows.Add(y.Name, y.YearOfBirth, y.Sex);
                        return;
                    }
                }
            }
        }
        #endregion
    }
}
