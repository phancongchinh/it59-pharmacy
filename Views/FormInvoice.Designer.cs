using System.Drawing;
using System.Windows.Forms;

namespace IT59_Pharmacy.Views
{
    partial class FormInvoice
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private Panel panelStatistics;
        private Label lblTodayInvoices;
        private Label lblTodayRevenue;
        private Label lblTotalInvoices;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Button btnFilterToday;
        private Panel panelMain;
        private SplitContainer splitContainer;
        private GroupBox grpInvoices;
        private DataGridView dgvInvoices;
        private Panel panelRight;
        private GroupBox grpInvoiceInfo;
        private Label lblInvoiceDate;
        private DateTimePicker dtpInvoiceDate;
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private Label lblCustomerPhone;
        private TextBox txtCustomerPhone;
        private Label lblCustomerAddress;
        private TextBox txtCustomerAddress;
        private Label lblPaymentMethod;
        private ComboBox cboPaymentMethod;
        private Label lblSubTotal;
        private TextBox txtSubTotal;
        private Label lblDiscount;
        private TextBox txtDiscount;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblNotes;
        private TextBox txtNotes;
        private Panel panelButtons;
        private Button btnNewInvoice;
        private Button btnSaveInvoice;
        private Button btnPrintInvoice;
        private GroupBox grpInvoiceItems;
        private DataGridView dgvInvoiceItems;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.panelStatistics = new Panel();
            this.lblTodayInvoices = new Label();
            this.lblTodayRevenue = new Label();
            this.lblTotalInvoices = new Label();
            this.panelSearch = new Panel();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.btnRefresh = new Button();
            this.btnFilterToday = new Button();
            this.panelMain = new Panel();
            this.splitContainer = new SplitContainer();
            this.grpInvoices = new GroupBox();
            this.dgvInvoices = new DataGridView();
            this.panelRight = new Panel();
            this.grpInvoiceInfo = new GroupBox();
            this.lblInvoiceDate = new Label();
            this.dtpInvoiceDate = new DateTimePicker();
            this.lblCustomerName = new Label();
            this.txtCustomerName = new TextBox();
            this.lblCustomerPhone = new Label();
            this.txtCustomerPhone = new TextBox();
            this.lblCustomerAddress = new Label();
            this.txtCustomerAddress = new TextBox();
            this.lblPaymentMethod = new Label();
            this.cboPaymentMethod = new ComboBox();
            this.lblSubTotal = new Label();
            this.txtSubTotal = new TextBox();
            this.lblDiscount = new Label();
            this.txtDiscount = new TextBox();
            this.lblTotal = new Label();
            this.txtTotal = new TextBox();
            this.lblNotes = new Label();
            this.txtNotes = new TextBox();
            this.panelButtons = new Panel();
            this.btnNewInvoice = new Button();
            this.btnSaveInvoice = new Button();
            this.btnPrintInvoice = new Button();
            this.grpInvoiceItems = new GroupBox();
            this.dgvInvoiceItems = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelStatistics.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.grpInvoices.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.grpInvoiceInfo.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.grpInvoiceItems.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.FromArgb(230, 126, 34);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(1200, 60);
            this.panelTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(250, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ HÓA ĐƠN";

            // 
            // panelStatistics
            // 
            this.panelStatistics.BackColor = Color.FromArgb(241, 196, 15);
            this.panelStatistics.Controls.Add(this.lblTodayInvoices);
            this.panelStatistics.Controls.Add(this.lblTodayRevenue);
            this.panelStatistics.Controls.Add(this.lblTotalInvoices);
            this.panelStatistics.Dock = DockStyle.Top;
            this.panelStatistics.Location = new Point(0, 60);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Padding = new Padding(20, 10, 20, 10);
            this.panelStatistics.Size = new Size(1200, 50);
            this.panelStatistics.TabIndex = 1;

            // 
            // lblTodayInvoices
            // 
            this.lblTodayInvoices.AutoSize = true;
            this.lblTodayInvoices.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTodayInvoices.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTodayInvoices.Location = new Point(20, 15);
            this.lblTodayInvoices.Name = "lblTodayInvoices";
            this.lblTodayInvoices.Size = new Size(150, 20);
            this.lblTodayInvoices.TabIndex = 0;
            this.lblTodayInvoices.Text = "HĐ hôm nay: 0";

            // 
            // lblTodayRevenue
            // 
            this.lblTodayRevenue.AutoSize = true;
            this.lblTodayRevenue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTodayRevenue.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTodayRevenue.Location = new Point(250, 15);
            this.lblTodayRevenue.Name = "lblTodayRevenue";
            this.lblTodayRevenue.Size = new Size(200, 20);
            this.lblTodayRevenue.TabIndex = 1;
            this.lblTodayRevenue.Text = "Doanh thu: 0 VNĐ";

            // 
            // lblTotalInvoices
            // 
            this.lblTotalInvoices.AutoSize = true;
            this.lblTotalInvoices.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalInvoices.ForeColor = Color.FromArgb(44, 62, 80);
            this.lblTotalInvoices.Location = new Point(550, 15);
            this.lblTotalInvoices.Name = "lblTotalInvoices";
            this.lblTotalInvoices.Size = new Size(100, 20);
            this.lblTotalInvoices.TabIndex = 2;
            this.lblTotalInvoices.Text = "Tổng HĐ: 0";

            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = Color.White;
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnRefresh);
            this.panelSearch.Controls.Add(this.btnFilterToday);
            this.panelSearch.Dock = DockStyle.Top;
            this.panelSearch.Location = new Point(0, 110);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new Padding(20, 10, 20, 10);
            this.panelSearch.Size = new Size(1200, 60);
            this.panelSearch.TabIndex = 2;

            // 
            // txtSearch
            // 
            this.txtSearch.Font = new Font("Segoe UI", 11F);
            this.txtSearch.Location = new Point(20, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(400, 27);
            this.txtSearch.TabIndex = 0;

            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new Point(430, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(100, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(540, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(100, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // btnFilterToday
            // 
            this.btnFilterToday.BackColor = Color.FromArgb(155, 89, 182);
            this.btnFilterToday.FlatStyle = FlatStyle.Flat;
            this.btnFilterToday.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnFilterToday.ForeColor = Color.White;
            this.btnFilterToday.Location = new Point(650, 12);
            this.btnFilterToday.Name = "btnFilterToday";
            this.btnFilterToday.Size = new Size(120, 35);
            this.btnFilterToday.TabIndex = 3;
            this.btnFilterToday.Text = "HĐ hôm nay";
            this.btnFilterToday.UseVisualStyleBackColor = false;
            this.btnFilterToday.Click += new System.EventHandler(this.btnFilterToday_Click);

            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 170);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(1200, 630);
            this.panelMain.TabIndex = 3;

            // 
            // splitContainer
            // 
            this.splitContainer.Dock = DockStyle.Fill;
            this.splitContainer.Location = new Point(20, 20);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new Size(1160, 590);
            this.splitContainer.SplitterDistance = 680;
            this.splitContainer.TabIndex = 0;

            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.grpInvoices);

            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelRight);

            // 
            // grpInvoices
            // 
            this.grpInvoices.Controls.Add(this.dgvInvoices);
            this.grpInvoices.Dock = DockStyle.Fill;
            this.grpInvoices.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpInvoices.Location = new Point(0, 0);
            this.grpInvoices.Name = "grpInvoices";
            this.grpInvoices.Padding = new Padding(10);
            this.grpInvoices.Size = new Size(680, 590);
            this.grpInvoices.TabIndex = 0;
            this.grpInvoices.TabStop = false;
            this.grpInvoices.Text = "Danh sách hóa đơn";

            // 
            // dgvInvoices
            // 
            this.dgvInvoices.BackgroundColor = Color.White;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Dock = DockStyle.Fill;
            this.dgvInvoices.Location = new Point(10, 29);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersWidth = 51;
            this.dgvInvoices.Size = new Size(660, 551);
            this.dgvInvoices.TabIndex = 0;
            this.dgvInvoices.SelectionChanged += new System.EventHandler(this.dgvInvoices_SelectionChanged);

            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.grpInvoiceItems);
            this.panelRight.Controls.Add(this.grpInvoiceInfo);
            this.panelRight.Dock = DockStyle.Fill;
            this.panelRight.Location = new Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new Size(476, 590);
            this.panelRight.TabIndex = 0;

            // 
            // grpInvoiceInfo
            // 
            this.grpInvoiceInfo.Controls.Add(this.lblInvoiceDate);
            this.grpInvoiceInfo.Controls.Add(this.dtpInvoiceDate);
            this.grpInvoiceInfo.Controls.Add(this.lblCustomerName);
            this.grpInvoiceInfo.Controls.Add(this.txtCustomerName);
            this.grpInvoiceInfo.Controls.Add(this.lblCustomerPhone);
            this.grpInvoiceInfo.Controls.Add(this.txtCustomerPhone);
            this.grpInvoiceInfo.Controls.Add(this.lblCustomerAddress);
            this.grpInvoiceInfo.Controls.Add(this.txtCustomerAddress);
            this.grpInvoiceInfo.Controls.Add(this.lblPaymentMethod);
            this.grpInvoiceInfo.Controls.Add(this.cboPaymentMethod);
            this.grpInvoiceInfo.Controls.Add(this.lblSubTotal);
            this.grpInvoiceInfo.Controls.Add(this.txtSubTotal);
            this.grpInvoiceInfo.Controls.Add(this.lblDiscount);
            this.grpInvoiceInfo.Controls.Add(this.txtDiscount);
            this.grpInvoiceInfo.Controls.Add(this.lblTotal);
            this.grpInvoiceInfo.Controls.Add(this.txtTotal);
            this.grpInvoiceInfo.Controls.Add(this.lblNotes);
            this.grpInvoiceInfo.Controls.Add(this.txtNotes);
            this.grpInvoiceInfo.Controls.Add(this.panelButtons);
            this.grpInvoiceInfo.Dock = DockStyle.Top;
            this.grpInvoiceInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpInvoiceInfo.Location = new Point(0, 0);
            this.grpInvoiceInfo.Name = "grpInvoiceInfo";
            this.grpInvoiceInfo.Padding = new Padding(10);
            this.grpInvoiceInfo.Size = new Size(476, 320);
            this.grpInvoiceInfo.TabIndex = 0;
            this.grpInvoiceInfo.TabStop = false;
            this.grpInvoiceInfo.Text = "Thông tin hóa đơn";

            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new Font("Segoe UI", 9F);
            this.lblInvoiceDate.Location = new Point(15, 30);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new Size(66, 15);
            this.lblInvoiceDate.TabIndex = 0;
            this.lblInvoiceDate.Text = "Ngày bán:";

            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Font = new Font("Segoe UI", 9F);
            this.dtpInvoiceDate.Format = DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new Point(15, 48);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new Size(200, 23);
            this.dtpInvoiceDate.TabIndex = 1;

            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new Font("Segoe UI", 9F);
            this.lblCustomerName.Location = new Point(15, 80);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new Size(92, 15);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Tên khách hàng:";

            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new Font("Segoe UI", 9F);
            this.txtCustomerName.Location = new Point(15, 98);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new Size(220, 23);
            this.txtCustomerName.TabIndex = 3;

            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new Font("Segoe UI", 9F);
            this.lblCustomerPhone.Location = new Point(245, 80);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new Size(79, 15);
            this.lblCustomerPhone.TabIndex = 4;
            this.lblCustomerPhone.Text = "Số điện thoại:";

            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Font = new Font("Segoe UI", 9F);
            this.txtCustomerPhone.Location = new Point(245, 98);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new Size(200, 23);
            this.txtCustomerPhone.TabIndex = 5;

            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Font = new Font("Segoe UI", 9F);
            this.lblCustomerAddress.Location = new Point(15, 130);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new Size(46, 15);
            this.lblCustomerAddress.TabIndex = 6;
            this.lblCustomerAddress.Text = "Địa chỉ:";

            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Font = new Font("Segoe UI", 9F);
            this.txtCustomerAddress.Location = new Point(15, 148);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new Size(430, 23);
            this.txtCustomerAddress.TabIndex = 7;

            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new Font("Segoe UI", 9F);
            this.lblPaymentMethod.Location = new Point(15, 180);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new Size(133, 15);
            this.lblPaymentMethod.TabIndex = 8;
            this.lblPaymentMethod.Text = "Phương thức thanh toán:";

            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new Font("Segoe UI", 9F);
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new Point(15, 198);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new Size(200, 23);
            this.cboPaymentMethod.TabIndex = 9;

            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new Font("Segoe UI", 9F);
            this.lblSubTotal.Location = new Point(245, 180);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new Size(63, 15);
            this.lblSubTotal.TabIndex = 10;
            this.lblSubTotal.Text = "Tạm tính:";

            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new Font("Segoe UI", 9F);
            this.txtSubTotal.Location = new Point(245, 198);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new Size(200, 23);
            this.txtSubTotal.TabIndex = 11;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = HorizontalAlignment.Right;

            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new Font("Segoe UI", 9F);
            this.lblDiscount.Location = new Point(15, 230);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new Size(60, 15);
            this.lblDiscount.TabIndex = 12;
            this.lblDiscount.Text = "Giảm giá:";

            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new Font("Segoe UI", 9F);
            this.txtDiscount.Location = new Point(15, 248);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new Size(150, 23);
            this.txtDiscount.TabIndex = 13;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);

            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(192, 57, 43);
            this.lblTotal.Location = new Point(245, 230);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(78, 19);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Tổng tiền:";

            // 
            // txtTotal
            // 
            this.txtTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.txtTotal.ForeColor = Color.FromArgb(192, 57, 43);
            this.txtTotal.Location = new Point(245, 248);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new Size(200, 27);
            this.txtTotal.TabIndex = 15;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = HorizontalAlignment.Right;

            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new Font("Segoe UI", 9F);
            this.lblNotes.Location = new Point(230, 30);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(51, 15);
            this.lblNotes.TabIndex = 16;
            this.lblNotes.Text = "Ghi chú:";

            // 
            // txtNotes
            // 
            this.txtNotes.Font = new Font("Segoe UI", 9F);
            this.txtNotes.Location = new Point(230, 48);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new Size(215, 73);
            this.txtNotes.TabIndex = 17;

            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnNewInvoice);
            this.panelButtons.Controls.Add(this.btnSaveInvoice);
            this.panelButtons.Controls.Add(this.btnPrintInvoice);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(10, 278);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(456, 32);
            this.panelButtons.TabIndex = 18;

            // 
            // btnNewInvoice
            // 
            this.btnNewInvoice.BackColor = Color.FromArgb(46, 204, 113);
            this.btnNewInvoice.FlatStyle = FlatStyle.Flat;
            this.btnNewInvoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNewInvoice.ForeColor = Color.White;
            this.btnNewInvoice.Location = new Point(15, 0);
            this.btnNewInvoice.Name = "btnNewInvoice";
            this.btnNewInvoice.Size = new Size(100, 30);
            this.btnNewInvoice.TabIndex = 0;
            this.btnNewInvoice.Text = "Tạo mới";
            this.btnNewInvoice.UseVisualStyleBackColor = false;
            this.btnNewInvoice.Click += new System.EventHandler(this.btnNewInvoice_Click);

            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSaveInvoice.FlatStyle = FlatStyle.Flat;
            this.btnSaveInvoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSaveInvoice.ForeColor = Color.White;
            this.btnSaveInvoice.Location = new Point(125, 0);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new Size(100, 30);
            this.btnSaveInvoice.TabIndex = 1;
            this.btnSaveInvoice.Text = "Lưu";
            this.btnSaveInvoice.UseVisualStyleBackColor = false;
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);

            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.BackColor = Color.FromArgb(155, 89, 182);
            this.btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            this.btnPrintInvoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnPrintInvoice.ForeColor = Color.White;
            this.btnPrintInvoice.Location = new Point(235, 0);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new Size(100, 30);
            this.btnPrintInvoice.TabIndex = 2;
            this.btnPrintInvoice.Text = "In hóa đơn";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);

            // 
            // grpInvoiceItems
            // 
            this.grpInvoiceItems.Controls.Add(this.dgvInvoiceItems);
            this.grpInvoiceItems.Dock = DockStyle.Fill;
            this.grpInvoiceItems.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpInvoiceItems.Location = new Point(0, 320);
            this.grpInvoiceItems.Name = "grpInvoiceItems";
            this.grpInvoiceItems.Padding = new Padding(10);
            this.grpInvoiceItems.Size = new Size(476, 270);
            this.grpInvoiceItems.TabIndex = 1;
            this.grpInvoiceItems.TabStop = false;
            this.grpInvoiceItems.Text = "Chi tiết hóa đơn";

            // 
            // dgvInvoiceItems
            // 
            this.dgvInvoiceItems.BackgroundColor = Color.White;
            this.dgvInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceItems.Dock = DockStyle.Fill;
            this.dgvInvoiceItems.Location = new Point(10, 29);
            this.dgvInvoiceItems.Name = "dgvInvoiceItems";
            this.dgvInvoiceItems.RowHeadersWidth = 51;
            this.dgvInvoiceItems.Size = new Size(456, 231);
            this.dgvInvoiceItems.TabIndex = 0;

            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1200, 800);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelStatistics);
            this.Controls.Add(this.panelTop);
            this.Name = "FormInvoice";
            this.Text = "Quản lý hóa đơn bán hàng";

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelStatistics.ResumeLayout(false);
            this.panelStatistics.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.grpInvoices.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.grpInvoiceInfo.ResumeLayout(false);
            this.grpInvoiceInfo.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.grpInvoiceItems.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

