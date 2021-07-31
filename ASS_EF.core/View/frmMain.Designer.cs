
namespace ASS_EF.core
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnEvent = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoadDanhba = new System.Windows.Forms.Button();
            this.btnLoadPerson = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbDanhBa = new System.Windows.Forms.GroupBox();
            this.btnClearDB = new System.Windows.Forms.Button();
            this.btnXoaDB = new System.Windows.Forms.Button();
            this.btnSuaDB = new System.Windows.Forms.Button();
            this.btnThemDB = new System.Windows.Forms.Button();
            this.rtbGhiChu = new System.Windows.Forms.RichTextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblSDT2 = new System.Windows.Forms.Label();
            this.lblSDT1 = new System.Windows.Forms.Label();
            this.lblTenDb = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtSdt2 = new System.Windows.Forms.TextBox();
            this.txtSdt1 = new System.Windows.Forms.TextBox();
            this.txtTenDb = new System.Windows.Forms.TextBox();
            this.grbPeople = new System.Windows.Forms.GroupBox();
            this.btnClearPp = new System.Windows.Forms.Button();
            this.btnXoaPp = new System.Windows.Forms.Button();
            this.btnSuaPp = new System.Windows.Forms.Button();
            this.btnThemPp = new System.Windows.Forms.Button();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblNamSinh = new System.Windows.Forms.Label();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.cbNamSinh = new System.Windows.Forms.ComboBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtTenDem = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblTenDem = new System.Windows.Forms.Label();
            this.lblHo = new System.Windows.Forms.Label();
            this.pnData = new System.Windows.Forms.Panel();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.pnEvent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbDanhBa.SuspendLayout();
            this.grbPeople.SuspendLayout();
            this.pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // pnEvent
            // 
            this.pnEvent.BackColor = System.Drawing.Color.Linen;
            this.pnEvent.Controls.Add(this.groupBox1);
            this.pnEvent.Controls.Add(this.grbDanhBa);
            this.pnEvent.Controls.Add(this.grbPeople);
            this.pnEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEvent.Location = new System.Drawing.Point(0, 0);
            this.pnEvent.Name = "pnEvent";
            this.pnEvent.Size = new System.Drawing.Size(1082, 397);
            this.pnEvent.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadDanhba);
            this.groupBox1.Controls.Add(this.btnLoadPerson);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(710, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 397);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnLoadDanhba
            // 
            this.btnLoadDanhba.Location = new System.Drawing.Point(18, 310);
            this.btnLoadDanhba.Name = "btnLoadDanhba";
            this.btnLoadDanhba.Size = new System.Drawing.Size(171, 34);
            this.btnLoadDanhba.TabIndex = 2;
            this.btnLoadDanhba.Text = "Load Danh bạ";
            this.btnLoadDanhba.UseVisualStyleBackColor = true;
            this.btnLoadDanhba.Click += new System.EventHandler(this.btnLoadDanhba_Click);
            // 
            // btnLoadPerson
            // 
            this.btnLoadPerson.Location = new System.Drawing.Point(18, 350);
            this.btnLoadPerson.Name = "btnLoadPerson";
            this.btnLoadPerson.Size = new System.Drawing.Size(171, 34);
            this.btnLoadPerson.TabIndex = 2;
            this.btnLoadPerson.Text = "Load Person";
            this.btnLoadPerson.UseVisualStyleBackColor = true;
            this.btnLoadPerson.Click += new System.EventHandler(this.btnLoadPerson_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(103, 39);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(263, 31);
            this.textBox8.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // grbDanhBa
            // 
            this.grbDanhBa.AutoSize = true;
            this.grbDanhBa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grbDanhBa.Controls.Add(this.btnClearDB);
            this.grbDanhBa.Controls.Add(this.btnXoaDB);
            this.grbDanhBa.Controls.Add(this.btnSuaDB);
            this.grbDanhBa.Controls.Add(this.btnThemDB);
            this.grbDanhBa.Controls.Add(this.rtbGhiChu);
            this.grbDanhBa.Controls.Add(this.lblGhiChu);
            this.grbDanhBa.Controls.Add(this.lblMail);
            this.grbDanhBa.Controls.Add(this.lblSDT2);
            this.grbDanhBa.Controls.Add(this.lblSDT1);
            this.grbDanhBa.Controls.Add(this.lblTenDb);
            this.grbDanhBa.Controls.Add(this.txtMail);
            this.grbDanhBa.Controls.Add(this.txtSdt2);
            this.grbDanhBa.Controls.Add(this.txtSdt1);
            this.grbDanhBa.Controls.Add(this.txtTenDb);
            this.grbDanhBa.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbDanhBa.Location = new System.Drawing.Point(353, 0);
            this.grbDanhBa.Name = "grbDanhBa";
            this.grbDanhBa.Size = new System.Drawing.Size(357, 397);
            this.grbDanhBa.TabIndex = 1;
            this.grbDanhBa.TabStop = false;
            this.grbDanhBa.Text = "Danh Bạ";
            // 
            // btnClearDB
            // 
            this.btnClearDB.Location = new System.Drawing.Point(277, 350);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(74, 34);
            this.btnClearDB.TabIndex = 5;
            this.btnClearDB.Text = "Clear";
            this.btnClearDB.UseVisualStyleBackColor = true;
            // 
            // btnXoaDB
            // 
            this.btnXoaDB.Location = new System.Drawing.Point(186, 350);
            this.btnXoaDB.Name = "btnXoaDB";
            this.btnXoaDB.Size = new System.Drawing.Size(74, 34);
            this.btnXoaDB.TabIndex = 6;
            this.btnXoaDB.Text = "Xóa";
            this.btnXoaDB.UseVisualStyleBackColor = true;
            // 
            // btnSuaDB
            // 
            this.btnSuaDB.Location = new System.Drawing.Point(97, 350);
            this.btnSuaDB.Name = "btnSuaDB";
            this.btnSuaDB.Size = new System.Drawing.Size(74, 34);
            this.btnSuaDB.TabIndex = 7;
            this.btnSuaDB.Text = "Sửa";
            this.btnSuaDB.UseVisualStyleBackColor = true;
            // 
            // btnThemDB
            // 
            this.btnThemDB.Location = new System.Drawing.Point(9, 350);
            this.btnThemDB.Name = "btnThemDB";
            this.btnThemDB.Size = new System.Drawing.Size(74, 34);
            this.btnThemDB.TabIndex = 8;
            this.btnThemDB.Text = "Thêm";
            this.btnThemDB.UseVisualStyleBackColor = true;
            // 
            // rtbGhiChu
            // 
            this.rtbGhiChu.Location = new System.Drawing.Point(113, 222);
            this.rtbGhiChu.MaxLength = 150;
            this.rtbGhiChu.Name = "rtbGhiChu";
            this.rtbGhiChu.Size = new System.Drawing.Size(221, 103);
            this.rtbGhiChu.TabIndex = 1;
            this.rtbGhiChu.Text = "";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(6, 225);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(83, 25);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "Ghi Chú :";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(6, 178);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(54, 25);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "Mail :";
            // 
            // lblSDT2
            // 
            this.lblSDT2.AutoSize = true;
            this.lblSDT2.Location = new System.Drawing.Point(6, 131);
            this.lblSDT2.Name = "lblSDT2";
            this.lblSDT2.Size = new System.Drawing.Size(67, 25);
            this.lblSDT2.TabIndex = 0;
            this.lblSDT2.Text = "SDT 2 :";
            // 
            // lblSDT1
            // 
            this.lblSDT1.AutoSize = true;
            this.lblSDT1.Location = new System.Drawing.Point(6, 86);
            this.lblSDT1.Name = "lblSDT1";
            this.lblSDT1.Size = new System.Drawing.Size(67, 25);
            this.lblSDT1.TabIndex = 0;
            this.lblSDT1.Text = "SDT 1 :";
            // 
            // lblTenDb
            // 
            this.lblTenDb.AutoSize = true;
            this.lblTenDb.Location = new System.Drawing.Point(6, 42);
            this.lblTenDb.Name = "lblTenDb";
            this.lblTenDb.Size = new System.Drawing.Size(47, 25);
            this.lblTenDb.TabIndex = 0;
            this.lblTenDb.Text = "Tên :";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(113, 178);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(221, 31);
            this.txtMail.TabIndex = 1;
            // 
            // txtSdt2
            // 
            this.txtSdt2.Location = new System.Drawing.Point(113, 128);
            this.txtSdt2.Name = "txtSdt2";
            this.txtSdt2.Size = new System.Drawing.Size(221, 31);
            this.txtSdt2.TabIndex = 1;
            // 
            // txtSdt1
            // 
            this.txtSdt1.Location = new System.Drawing.Point(113, 83);
            this.txtSdt1.Name = "txtSdt1";
            this.txtSdt1.Size = new System.Drawing.Size(221, 31);
            this.txtSdt1.TabIndex = 1;
            // 
            // txtTenDb
            // 
            this.txtTenDb.Location = new System.Drawing.Point(113, 39);
            this.txtTenDb.Name = "txtTenDb";
            this.txtTenDb.ReadOnly = true;
            this.txtTenDb.Size = new System.Drawing.Size(221, 31);
            this.txtTenDb.TabIndex = 1;
            // 
            // grbPeople
            // 
            this.grbPeople.AutoSize = true;
            this.grbPeople.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grbPeople.Controls.Add(this.btnClearPp);
            this.grbPeople.Controls.Add(this.btnXoaPp);
            this.grbPeople.Controls.Add(this.btnSuaPp);
            this.grbPeople.Controls.Add(this.btnThemPp);
            this.grbPeople.Controls.Add(this.lblGioiTinh);
            this.grbPeople.Controls.Add(this.lblNamSinh);
            this.grbPeople.Controls.Add(this.cbGioiTinh);
            this.grbPeople.Controls.Add(this.cbNamSinh);
            this.grbPeople.Controls.Add(this.txtTen);
            this.grbPeople.Controls.Add(this.txtTenDem);
            this.grbPeople.Controls.Add(this.txtHo);
            this.grbPeople.Controls.Add(this.lblTen);
            this.grbPeople.Controls.Add(this.lblTenDem);
            this.grbPeople.Controls.Add(this.lblHo);
            this.grbPeople.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbPeople.Location = new System.Drawing.Point(0, 0);
            this.grbPeople.Name = "grbPeople";
            this.grbPeople.Size = new System.Drawing.Size(353, 397);
            this.grbPeople.TabIndex = 0;
            this.grbPeople.TabStop = false;
            this.grbPeople.Text = "Peoples";
            // 
            // btnClearPp
            // 
            this.btnClearPp.Location = new System.Drawing.Point(273, 350);
            this.btnClearPp.Name = "btnClearPp";
            this.btnClearPp.Size = new System.Drawing.Size(74, 34);
            this.btnClearPp.TabIndex = 4;
            this.btnClearPp.Text = "Clear";
            this.btnClearPp.UseVisualStyleBackColor = true;
            // 
            // btnXoaPp
            // 
            this.btnXoaPp.Location = new System.Drawing.Point(182, 350);
            this.btnXoaPp.Name = "btnXoaPp";
            this.btnXoaPp.Size = new System.Drawing.Size(74, 34);
            this.btnXoaPp.TabIndex = 4;
            this.btnXoaPp.Text = "Xóa";
            this.btnXoaPp.UseVisualStyleBackColor = true;
            // 
            // btnSuaPp
            // 
            this.btnSuaPp.Location = new System.Drawing.Point(93, 350);
            this.btnSuaPp.Name = "btnSuaPp";
            this.btnSuaPp.Size = new System.Drawing.Size(74, 34);
            this.btnSuaPp.TabIndex = 4;
            this.btnSuaPp.Text = "Sửa";
            this.btnSuaPp.UseVisualStyleBackColor = true;
            // 
            // btnThemPp
            // 
            this.btnThemPp.Location = new System.Drawing.Point(5, 350);
            this.btnThemPp.Name = "btnThemPp";
            this.btnThemPp.Size = new System.Drawing.Size(74, 34);
            this.btnThemPp.TabIndex = 4;
            this.btnThemPp.Text = "Thêm";
            this.btnThemPp.UseVisualStyleBackColor = true;
            this.btnThemPp.Click += new System.EventHandler(this.btnThemPp_Click);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(6, 225);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(90, 25);
            this.lblGioiTinh.TabIndex = 3;
            this.lblGioiTinh.Text = "Giới Tính :";
            // 
            // lblNamSinh
            // 
            this.lblNamSinh.AutoSize = true;
            this.lblNamSinh.Location = new System.Drawing.Point(6, 178);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(98, 25);
            this.lblNamSinh.TabIndex = 3;
            this.lblNamSinh.Text = "Năm Sinh :";
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbGioiTinh.Location = new System.Drawing.Point(104, 222);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(115, 33);
            this.cbGioiTinh.TabIndex = 2;
            // 
            // cbNamSinh
            // 
            this.cbNamSinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNamSinh.FormattingEnabled = true;
            this.cbNamSinh.Location = new System.Drawing.Point(104, 175);
            this.cbNamSinh.Name = "cbNamSinh";
            this.cbNamSinh.Size = new System.Drawing.Size(115, 33);
            this.cbNamSinh.TabIndex = 2;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(104, 128);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(221, 31);
            this.txtTen.TabIndex = 1;
            // 
            // txtTenDem
            // 
            this.txtTenDem.Location = new System.Drawing.Point(104, 83);
            this.txtTenDem.Name = "txtTenDem";
            this.txtTenDem.Size = new System.Drawing.Size(221, 31);
            this.txtTenDem.TabIndex = 1;
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(104, 39);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(221, 31);
            this.txtHo.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(6, 131);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(47, 25);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên :";
            // 
            // lblTenDem
            // 
            this.lblTenDem.AutoSize = true;
            this.lblTenDem.Location = new System.Drawing.Point(6, 86);
            this.lblTenDem.Name = "lblTenDem";
            this.lblTenDem.Size = new System.Drawing.Size(88, 25);
            this.lblTenDem.TabIndex = 0;
            this.lblTenDem.Text = "Tên đệm :";
            // 
            // lblHo
            // 
            this.lblHo.AutoSize = true;
            this.lblHo.Location = new System.Drawing.Point(6, 42);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(45, 25);
            this.lblHo.TabIndex = 0;
            this.lblHo.Text = "Họ :";
            // 
            // pnData
            // 
            this.pnData.Controls.Add(this.dgvdata);
            this.pnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnData.Location = new System.Drawing.Point(0, 397);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(1082, 319);
            this.pnData.TabIndex = 0;
            // 
            // dgvdata
            // 
            this.dgvdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdata.Location = new System.Drawing.Point(0, 0);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowHeadersWidth = 62;
            this.dgvdata.RowTemplate.Height = 33;
            this.dgvdata.Size = new System.Drawing.Size(1082, 319);
            this.dgvdata.TabIndex = 2;
            this.dgvdata.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvdata_CellMouseClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 716);
            this.Controls.Add(this.pnData);
            this.Controls.Add(this.pnEvent);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.pnEvent.ResumeLayout(false);
            this.pnEvent.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDanhBa.ResumeLayout(false);
            this.grbDanhBa.PerformLayout();
            this.grbPeople.ResumeLayout(false);
            this.grbPeople.PerformLayout();
            this.pnData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnEvent;
        private System.Windows.Forms.Panel pnData;
        private System.Windows.Forms.GroupBox grbDanhBa;
        private System.Windows.Forms.GroupBox grbPeople;
        private System.Windows.Forms.Button btnClearPp;
        private System.Windows.Forms.Button btnXoaPp;
        private System.Windows.Forms.Button btnSuaPp;
        private System.Windows.Forms.Button btnThemPp;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.ComboBox cbNamSinh;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtTenDem;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblTenDem;
        private System.Windows.Forms.Label lblHo;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.RichTextBox rtbGhiChu;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblSDT2;
        private System.Windows.Forms.Label lblSDT1;
        private System.Windows.Forms.Label lblTenDb;
        private System.Windows.Forms.Button btnClearDB;
        private System.Windows.Forms.Button btnXoaDB;
        private System.Windows.Forms.Button btnSuaDB;
        private System.Windows.Forms.Button btnThemDB;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtSdt2;
        private System.Windows.Forms.TextBox txtSdt1;
        private System.Windows.Forms.TextBox txtTenDb;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadDanhba;
        private System.Windows.Forms.Button btnLoadPerson;
    }
}

