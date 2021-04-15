namespace QLVT_DATHANG
{
    partial class uctNhanvien
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dGVDSNhanvien = new System.Windows.Forms.DataGridView();
            this.grQLNV = new System.Windows.Forms.GroupBox();
            this.button2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoLoc = new DevExpress.XtraEditors.SimpleButton();
            this.btnRedo = new DevExpress.XtraEditors.SimpleButton();
            this.btnUndo = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.dTPNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.cbbCompare2 = new System.Windows.Forms.ComboBox();
            this.cbbCompare1 = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.txtLocPhu = new System.Windows.Forms.TextBox();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.cbbLoc = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoc = new DevExpress.XtraEditors.SimpleButton();
            this.btnChuyenCN = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chuyểnChiNhánhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDSNhanvien)).BeginInit();
            this.grQLNV.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Marker", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(736, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "DANH SÁCH NHÂN VIÊN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Marker", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "THÔNG TIN NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dGVDSNhanvien);
            this.groupBox1.Location = new System.Drawing.Point(736, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 378);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dGVDSNhanvien
            // 
            this.dGVDSNhanvien.AllowUserToAddRows = false;
            this.dGVDSNhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVDSNhanvien.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dGVDSNhanvien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVDSNhanvien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVDSNhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDSNhanvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDSNhanvien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dGVDSNhanvien.Location = new System.Drawing.Point(3, 18);
            this.dGVDSNhanvien.Name = "dGVDSNhanvien";
            this.dGVDSNhanvien.ReadOnly = true;
            this.dGVDSNhanvien.RowHeadersWidth = 51;
            this.dGVDSNhanvien.RowTemplate.Height = 24;
            this.dGVDSNhanvien.Size = new System.Drawing.Size(673, 357);
            this.dGVDSNhanvien.TabIndex = 0;
            // 
            // grQLNV
            // 
            this.grQLNV.Controls.Add(this.button2);
            this.grQLNV.Controls.Add(this.btnBoLoc);
            this.grQLNV.Controls.Add(this.btnRedo);
            this.grQLNV.Controls.Add(this.btnUndo);
            this.grQLNV.Controls.Add(this.btnXoa);
            this.grQLNV.Controls.Add(this.btnHuy);
            this.grQLNV.Controls.Add(this.btnLuu);
            this.grQLNV.Controls.Add(this.btnReload);
            this.grQLNV.Controls.Add(this.btnThem);
            this.grQLNV.Controls.Add(this.dTPNgaySinh);
            this.grQLNV.Controls.Add(this.label9);
            this.grQLNV.Controls.Add(this.label6);
            this.grQLNV.Controls.Add(this.label8);
            this.grQLNV.Controls.Add(this.label7);
            this.grQLNV.Controls.Add(this.label4);
            this.grQLNV.Controls.Add(this.label5);
            this.grQLNV.Controls.Add(this.txtLuong);
            this.grQLNV.Controls.Add(this.txtHo);
            this.grQLNV.Controls.Add(this.txtDiaChi);
            this.grQLNV.Controls.Add(this.txtTen);
            this.grQLNV.Controls.Add(this.txtMaNV);
            this.grQLNV.Location = new System.Drawing.Point(3, 29);
            this.grQLNV.Name = "grQLNV";
            this.grQLNV.Size = new System.Drawing.Size(727, 234);
            this.grQLNV.TabIndex = 6;
            this.grQLNV.TabStop = false;
            // 
            // button2
            // 
            this.button2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.button2.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.button2.Appearance.Options.UseBackColor = true;
            this.button2.Appearance.Options.UseBorderColor = true;
            this.button2.Appearance.Options.UseFont = true;
            this.button2.Appearance.Options.UseForeColor = true;
            this.button2.ImageOptions.Image = global::QLVT_DATHANG.Properties.Resources.hide_32x32;
            this.button2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.button2.Location = new System.Drawing.Point(657, 5);
            this.button2.Name = "button2";
            this.button2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.button2.Size = new System.Drawing.Size(70, 32);
            this.button2.TabIndex = 92;
            this.button2.Text = "<<";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBoLoc.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnBoLoc.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoLoc.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnBoLoc.Appearance.Options.UseBackColor = true;
            this.btnBoLoc.Appearance.Options.UseBorderColor = true;
            this.btnBoLoc.Appearance.Options.UseFont = true;
            this.btnBoLoc.Appearance.Options.UseForeColor = true;
            this.btnBoLoc.ImageOptions.Image = global::QLVT_DATHANG.Properties.Resources.quickfilter_32x32;
            this.btnBoLoc.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnBoLoc.Location = new System.Drawing.Point(565, 5);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnBoLoc.Size = new System.Drawing.Size(93, 32);
            this.btnBoLoc.TabIndex = 93;
            this.btnBoLoc.Text = "Filter";
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRedo.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnRedo.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRedo.Appearance.Options.UseBackColor = true;
            this.btnRedo.Appearance.Options.UseBorderColor = true;
            this.btnRedo.Appearance.Options.UseFont = true;
            this.btnRedo.Appearance.Options.UseForeColor = true;
            this.btnRedo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRedo.ImageOptions.SvgImage = global::QLVT_DATHANG.Properties.Resources.actions_reload;
            this.btnRedo.Location = new System.Drawing.Point(473, 5);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnRedo.Size = new System.Drawing.Size(97, 32);
            this.btnRedo.TabIndex = 94;
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUndo.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnUndo.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnUndo.Appearance.Options.UseBackColor = true;
            this.btnUndo.Appearance.Options.UseBorderColor = true;
            this.btnUndo.Appearance.Options.UseFont = true;
            this.btnUndo.Appearance.Options.UseForeColor = true;
            this.btnUndo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUndo.ImageOptions.SvgImage = global::QLVT_DATHANG.Properties.Resources.actions_rollback;
            this.btnUndo.Location = new System.Drawing.Point(376, 5);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnUndo.Size = new System.Drawing.Size(97, 32);
            this.btnUndo.TabIndex = 94;
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoa.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Appearance.Options.UseBackColor = true;
            this.btnXoa.Appearance.Options.UseBorderColor = true;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Appearance.Options.UseForeColor = true;
            this.btnXoa.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnXoa.ImageOptions.SvgImage = global::QLVT_DATHANG.Properties.Resources.actions_deletecircled1;
            this.btnXoa.Location = new System.Drawing.Point(280, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnXoa.Size = new System.Drawing.Size(96, 32);
            this.btnXoa.TabIndex = 95;
            this.btnXoa.Text = "Delete";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHuy.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Appearance.Options.UseBackColor = true;
            this.btnHuy.Appearance.Options.UseBorderColor = true;
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Appearance.Options.UseForeColor = true;
            this.btnHuy.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnHuy.ImageOptions.SvgImage = global::QLVT_DATHANG.Properties.Resources.actions_forbid;
            this.btnHuy.Location = new System.Drawing.Point(183, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnHuy.Size = new System.Drawing.Size(97, 32);
            this.btnHuy.TabIndex = 94;
            this.btnHuy.Text = "Cancel";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLuu.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLuu.Appearance.Options.UseBackColor = true;
            this.btnLuu.Appearance.Options.UseBorderColor = true;
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Appearance.Options.UseForeColor = true;
            this.btnLuu.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLuu.ImageOptions.SvgImage = global::QLVT_DATHANG.Properties.Resources.actions_checkcircled;
            this.btnLuu.Location = new System.Drawing.Point(292, 194);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnLuu.Size = new System.Drawing.Size(104, 32);
            this.btnLuu.TabIndex = 95;
            this.btnLuu.Text = "Save";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnReload
            // 
            this.btnReload.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReload.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnReload.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnReload.Appearance.Options.UseBackColor = true;
            this.btnReload.Appearance.Options.UseBorderColor = true;
            this.btnReload.Appearance.Options.UseFont = true;
            this.btnReload.Appearance.Options.UseForeColor = true;
            this.btnReload.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnReload.ImageOptions.SvgImage = global::QLVT_DATHANG.Properties.Resources.actions_refresh;
            this.btnReload.Location = new System.Drawing.Point(82, 5);
            this.btnReload.Name = "btnReload";
            this.btnReload.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnReload.Size = new System.Drawing.Size(101, 32);
            this.btnReload.TabIndex = 96;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThem.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnThem.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Appearance.Options.UseBackColor = true;
            this.btnThem.Appearance.Options.UseBorderColor = true;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnThem.ImageOptions.SvgImage = global::QLVT_DATHANG.Properties.Resources.actions_addcircled;
            this.btnThem.Location = new System.Drawing.Point(0, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnThem.Size = new System.Drawing.Size(82, 32);
            this.btnThem.TabIndex = 97;
            this.btnThem.Text = "New";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dTPNgaySinh
            // 
            this.dTPNgaySinh.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPNgaySinh.Location = new System.Drawing.Point(446, 163);
            this.dTPNgaySinh.Name = "dTPNgaySinh";
            this.dTPNgaySinh.Size = new System.Drawing.Size(140, 30);
            this.dTPNgaySinh.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Marker", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(358, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 22);
            this.label9.TabIndex = 3;
            this.label9.Text = "Ngày Sinh :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Marker", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(400, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tên :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Marker", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(49, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 22);
            this.label8.TabIndex = 3;
            this.label8.Text = "Lương :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Marker", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 22);
            this.label7.TabIndex = 3;
            this.label7.Text = "Địa chỉ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Marker", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Marker", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Họ :";
            // 
            // txtLuong
            // 
            this.txtLuong.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuong.Location = new System.Drawing.Point(113, 163);
            this.txtLuong.MaxLength = 19;
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(130, 30);
            this.txtLuong.TabIndex = 2;
            this.txtLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLuong.TextChanged += new System.EventHandler(this.txtLuong_TextChanged);
            this.txtLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLuong_KeyPress);
            // 
            // txtHo
            // 
            this.txtHo.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHo.Location = new System.Drawing.Point(445, 67);
            this.txtHo.MaxLength = 40;
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(206, 30);
            this.txtHo.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(113, 114);
            this.txtDiaChi.MaxLength = 100;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(205, 30);
            this.txtDiaChi.TabIndex = 2;
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(445, 114);
            this.txtTen.MaxLength = 10;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(117, 30);
            this.txtTen.TabIndex = 2;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(113, 67);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(77, 30);
            this.txtMaNV.TabIndex = 2;
            this.txtMaNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbbCompare2
            // 
            this.cbbCompare2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCompare2.Font = new System.Drawing.Font("Segoe Marker", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCompare2.FormattingEnabled = true;
            this.cbbCompare2.Items.AddRange(new object[] {
            "=",
            "<",
            "<="});
            this.cbbCompare2.Location = new System.Drawing.Point(240, 68);
            this.cbbCompare2.Name = "cbbCompare2";
            this.cbbCompare2.Size = new System.Drawing.Size(64, 28);
            this.cbbCompare2.TabIndex = 89;
            this.cbbCompare2.Visible = false;
            // 
            // cbbCompare1
            // 
            this.cbbCompare1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCompare1.Font = new System.Drawing.Font("Segoe Marker", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCompare1.FormattingEnabled = true;
            this.cbbCompare1.Items.AddRange(new object[] {
            ">",
            "=",
            ">="});
            this.cbbCompare1.Location = new System.Drawing.Point(240, 19);
            this.cbbCompare1.Name = "cbbCompare1";
            this.cbbCompare1.Size = new System.Drawing.Size(64, 28);
            this.cbbCompare1.TabIndex = 90;
            this.cbbCompare1.Visible = false;
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(324, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(151, 22);
            this.dtpStart.TabIndex = 88;
            this.dtpStart.Value = new System.DateTime(2000, 11, 28, 20, 20, 0, 0);
            this.dtpStart.Visible = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(324, 67);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(151, 22);
            this.dtpEnd.TabIndex = 87;
            this.dtpEnd.Visible = false;
            // 
            // txtLocPhu
            // 
            this.txtLocPhu.Font = new System.Drawing.Font("Segoe Marker", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocPhu.Location = new System.Drawing.Point(324, 67);
            this.txtLocPhu.MaxLength = 19;
            this.txtLocPhu.Name = "txtLocPhu";
            this.txtLocPhu.Size = new System.Drawing.Size(151, 27);
            this.txtLocPhu.TabIndex = 86;
            this.txtLocPhu.Visible = false;
            this.txtLocPhu.TextChanged += new System.EventHandler(this.txtLocPhu_TextChanged);
            this.txtLocPhu.Enter += new System.EventHandler(this.txtLocPhu_Enter);
            this.txtLocPhu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isDigit_KeyPress);
            this.txtLocPhu.Leave += new System.EventHandler(this.txtLocPhu_Leave);
            // 
            // txtLoc
            // 
            this.txtLoc.Font = new System.Drawing.Font("Segoe Marker", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoc.Location = new System.Drawing.Point(324, 19);
            this.txtLoc.MaxLength = 19;
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(151, 27);
            this.txtLoc.TabIndex = 84;
            this.txtLoc.Visible = false;
            this.txtLoc.TextChanged += new System.EventHandler(this.txtLoc_TextChanged);
            this.txtLoc.Enter += new System.EventHandler(this.txtLoc_Enter);
            this.txtLoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isDigit_KeyPress);
            this.txtLoc.Leave += new System.EventHandler(this.txtLoc_Leave);
            // 
            // cbbLoc
            // 
            this.cbbLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoc.Font = new System.Drawing.Font("Segoe Marker", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoc.FormattingEnabled = true;
            this.cbbLoc.Location = new System.Drawing.Point(82, 18);
            this.cbbLoc.Name = "cbbLoc";
            this.cbbLoc.Size = new System.Drawing.Size(139, 28);
            this.cbbLoc.TabIndex = 83;
            this.cbbLoc.Visible = false;
            this.cbbLoc.TextChanged += new System.EventHandler(this.cbbLoc_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbLoc);
            this.groupBox2.Controls.Add(this.btnLoc);
            this.groupBox2.Controls.Add(this.btnChuyenCN);
            this.groupBox2.Controls.Add(this.cbbCompare2);
            this.groupBox2.Controls.Add(this.txtLoc);
            this.groupBox2.Controls.Add(this.cbbCompare1);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.txtLocPhu);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Location = new System.Drawing.Point(3, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 142);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            // 
            // btnLoc
            // 
            this.btnLoc.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoc.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnLoc.Appearance.Font = new System.Drawing.Font("Segoe Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLoc.Appearance.Options.UseBackColor = true;
            this.btnLoc.Appearance.Options.UseBorderColor = true;
            this.btnLoc.Appearance.Options.UseFont = true;
            this.btnLoc.Appearance.Options.UseForeColor = true;
            this.btnLoc.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLoc.Location = new System.Drawing.Point(507, 18);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
            this.btnLoc.Size = new System.Drawing.Size(96, 32);
            this.btnLoc.TabIndex = 93;
            this.btnLoc.Text = "Go";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnChuyenCN
            // 
            this.btnChuyenCN.Font = new System.Drawing.Font("Segoe Marker", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenCN.Location = new System.Drawing.Point(631, 18);
            this.btnChuyenCN.Name = "btnChuyenCN";
            this.btnChuyenCN.Size = new System.Drawing.Size(90, 32);
            this.btnChuyenCN.TabIndex = 9;
            this.btnChuyenCN.Text = "Chuyển CN";
            this.btnChuyenCN.UseVisualStyleBackColor = true;
            this.btnChuyenCN.Click += new System.EventHandler(this.btnChuyenCN_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chuyểnChiNhánhToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 28);
            // 
            // chuyểnChiNhánhToolStripMenuItem
            // 
            this.chuyểnChiNhánhToolStripMenuItem.Name = "chuyểnChiNhánhToolStripMenuItem";
            this.chuyểnChiNhánhToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.chuyểnChiNhánhToolStripMenuItem.Text = "Chuyển Chi Nhánh";
            this.chuyểnChiNhánhToolStripMenuItem.Click += new System.EventHandler(this.btnChuyenCN_Click);
            // 
            // uctNhanvien
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grQLNV);
            this.Name = "uctNhanvien";
            this.Size = new System.Drawing.Size(1419, 411);
            this.Load += new System.EventHandler(this.uctNhanvien_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDSNhanvien)).EndInit();
            this.grQLNV.ResumeLayout(false);
            this.grQLNV.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGVDSNhanvien;
        private System.Windows.Forms.GroupBox grQLNV;
        private System.Windows.Forms.DateTimePicker dTPNgaySinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.ComboBox cbbCompare2;
        private System.Windows.Forms.ComboBox cbbCompare1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.TextBox txtLocPhu;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.ComboBox cbbLoc;
        private DevExpress.XtraEditors.SimpleButton button2;
        private DevExpress.XtraEditors.SimpleButton btnBoLoc;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnUndo;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chuyểnChiNhánhToolStripMenuItem;
        private System.Windows.Forms.Button btnChuyenCN;
        private DevExpress.XtraEditors.SimpleButton btnLoc;
        private DevExpress.XtraEditors.SimpleButton btnRedo;
    }
}
