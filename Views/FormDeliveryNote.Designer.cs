using System.Drawing;
using System.Windows.Forms;

namespace IT59_Pharmacy.Views
{
    partial class FormDeliveryNote
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Panel panelMain;
        private SplitContainer splitContainer;
        private GroupBox grpDeliveryNotes;
        private DataGridView dgvDeliveryNotes;
        private Panel panelRight;
        private GroupBox grpDeliveryNoteInfo;
        private Label lblDeliveryDate;
        private DateTimePicker dtpDeliveryDate;
        private Label lblCustomer;
        private ComboBox cboCustomer;
        private Label lblNotes;
        private TextBox txtNotes;
        private Label lblTotalAmount;
        private TextBox txtTotalAmount;
        private Panel panelButtons;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private GroupBox grpDeliveryNoteItems;
        private DataGridView dgvDeliveryNoteItems;

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
            this.panelSearch = new Panel();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.btnRefresh = new Button();
            this.panelMain = new Panel();
            this.splitContainer = new SplitContainer();
            this.grpDeliveryNotes = new GroupBox();
            this.dgvDeliveryNotes = new DataGridView();
            this.panelRight = new Panel();
            this.grpDeliveryNoteInfo = new GroupBox();
            this.lblDeliveryDate = new Label();
            this.dtpDeliveryDate = new DateTimePicker();
            this.lblCustomer = new Label();
            this.cboCustomer = new ComboBox();
            this.lblNotes = new Label();
            this.txtNotes = new TextBox();
            this.lblTotalAmount = new Label();
            this.txtTotalAmount = new TextBox();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            this.grpDeliveryNoteItems = new GroupBox();
            this.dgvDeliveryNoteItems = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNoteItems)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.grpDeliveryNotes.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.grpDeliveryNoteInfo.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.grpDeliveryNoteItems.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.FromArgb(41, 128, 185);
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
            this.lblTitle.Size = new Size(300, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ PHIẾU XUẤT KHO";

            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = Color.White;
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnRefresh);
            this.panelSearch.Dock = DockStyle.Top;
            this.panelSearch.Location = new Point(0, 60);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new Padding(20, 10, 20, 10);
            this.panelSearch.Size = new Size(1200, 60);
            this.panelSearch.TabIndex = 1;

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
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 120);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(1200, 680);
            this.panelMain.TabIndex = 2;

            // 
            // splitContainer
            // 
            this.splitContainer.Dock = DockStyle.Fill;
            this.splitContainer.Location = new Point(20, 20);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new Size(1160, 640);
            this.splitContainer.SplitterDistance = 700;
            this.splitContainer.TabIndex = 0;

            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.grpDeliveryNotes);

            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelRight);

            // 
            // grpDeliveryNotes
            // 
            this.grpDeliveryNotes.Controls.Add(this.dgvDeliveryNotes);
            this.grpDeliveryNotes.Dock = DockStyle.Fill;
            this.grpDeliveryNotes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpDeliveryNotes.Location = new Point(0, 0);
            this.grpDeliveryNotes.Name = "grpDeliveryNotes";
            this.grpDeliveryNotes.Padding = new Padding(10);
            this.grpDeliveryNotes.Size = new Size(700, 640);
            this.grpDeliveryNotes.TabIndex = 0;
            this.grpDeliveryNotes.TabStop = false;
            this.grpDeliveryNotes.Text = "Danh sách phiếu xuất kho";

            // 
            // dgvDeliveryNotes
            // 
            this.dgvDeliveryNotes.BackgroundColor = Color.White;
            this.dgvDeliveryNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryNotes.Dock = DockStyle.Fill;
            this.dgvDeliveryNotes.Location = new Point(10, 29);
            this.dgvDeliveryNotes.Name = "dgvDeliveryNotes";
            this.dgvDeliveryNotes.RowHeadersWidth = 51;
            this.dgvDeliveryNotes.Size = new Size(680, 601);
            this.dgvDeliveryNotes.TabIndex = 0;
            this.dgvDeliveryNotes.SelectionChanged += new System.EventHandler(this.dgvDeliveryNotes_SelectionChanged);

            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.grpDeliveryNoteItems);
            this.panelRight.Controls.Add(this.grpDeliveryNoteInfo);
            this.panelRight.Dock = DockStyle.Fill;
            this.panelRight.Location = new Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new Size(456, 640);
            this.panelRight.TabIndex = 0;

            // 
            // grpDeliveryNoteInfo
            // 
            this.grpDeliveryNoteInfo.Controls.Add(this.lblDeliveryDate);
            this.grpDeliveryNoteInfo.Controls.Add(this.dtpDeliveryDate);
            this.grpDeliveryNoteInfo.Controls.Add(this.lblCustomer);
            this.grpDeliveryNoteInfo.Controls.Add(this.cboCustomer);
            this.grpDeliveryNoteInfo.Controls.Add(this.lblNotes);
            this.grpDeliveryNoteInfo.Controls.Add(this.txtNotes);
            this.grpDeliveryNoteInfo.Controls.Add(this.lblTotalAmount);
            this.grpDeliveryNoteInfo.Controls.Add(this.txtTotalAmount);
            this.grpDeliveryNoteInfo.Controls.Add(this.panelButtons);
            this.grpDeliveryNoteInfo.Dock = DockStyle.Top;
            this.grpDeliveryNoteInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpDeliveryNoteInfo.Location = new Point(0, 0);
            this.grpDeliveryNoteInfo.Name = "grpDeliveryNoteInfo";
            this.grpDeliveryNoteInfo.Padding = new Padding(10);
            this.grpDeliveryNoteInfo.Size = new Size(456, 340);
            this.grpDeliveryNoteInfo.TabIndex = 0;
            this.grpDeliveryNoteInfo.TabStop = false;
            this.grpDeliveryNoteInfo.Text = "Thông tin phiếu xuất";

            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new Font("Segoe UI", 10F);
            this.lblDeliveryDate.Location = new Point(15, 35);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new Size(80, 19);
            this.lblDeliveryDate.TabIndex = 0;
            this.lblDeliveryDate.Text = "Ngày xuất:";

            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Font = new Font("Segoe UI", 10F);
            this.dtpDeliveryDate.Format = DateTimePickerFormat.Short;
            this.dtpDeliveryDate.Location = new Point(15, 60);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new Size(420, 25);
            this.dtpDeliveryDate.TabIndex = 1;

            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new Font("Segoe UI", 10F);
            this.lblCustomer.Location = new Point(15, 95);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new Size(88, 19);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Khách hàng:";

            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCustomer.Font = new Font("Segoe UI", 10F);
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new Point(15, 120);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new Size(420, 25);
            this.cboCustomer.TabIndex = 3;

            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new Font("Segoe UI", 10F);
            this.lblNotes.Location = new Point(15, 155);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(60, 19);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Ghi chú:";

            // 
            // txtNotes
            // 
            this.txtNotes.Font = new Font("Segoe UI", 10F);
            this.txtNotes.Location = new Point(15, 180);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new Size(420, 60);
            this.txtNotes.TabIndex = 5;

            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new Font("Segoe UI", 10F);
            this.lblTotalAmount.Location = new Point(15, 250);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new Size(73, 19);
            this.lblTotalAmount.TabIndex = 6;
            this.lblTotalAmount.Text = "Tổng tiền:";

            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.txtTotalAmount.Location = new Point(15, 275);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new Size(200, 25);
            this.txtTotalAmount.TabIndex = 7;
            this.txtTotalAmount.TextAlign = HorizontalAlignment.Right;

            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Location = new Point(10, 280);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new Size(436, 50);
            this.panelButtons.TabIndex = 8;

            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(15, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(120, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnSave
            // 
            this.btnSave.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(145, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(120, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(275, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(120, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // grpDeliveryNoteItems
            // 
            this.grpDeliveryNoteItems.Controls.Add(this.dgvDeliveryNoteItems);
            this.grpDeliveryNoteItems.Dock = DockStyle.Fill;
            this.grpDeliveryNoteItems.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grpDeliveryNoteItems.Location = new Point(0, 340);
            this.grpDeliveryNoteItems.Name = "grpDeliveryNoteItems";
            this.grpDeliveryNoteItems.Padding = new Padding(10);
            this.grpDeliveryNoteItems.Size = new Size(456, 300);
            this.grpDeliveryNoteItems.TabIndex = 1;
            this.grpDeliveryNoteItems.TabStop = false;
            this.grpDeliveryNoteItems.Text = "Chi tiết phiếu xuất";

            // 
            // dgvDeliveryNoteItems
            // 
            this.dgvDeliveryNoteItems.BackgroundColor = Color.White;
            this.dgvDeliveryNoteItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryNoteItems.Dock = DockStyle.Fill;
            this.dgvDeliveryNoteItems.Location = new Point(10, 29);
            this.dgvDeliveryNoteItems.Name = "dgvDeliveryNoteItems";
            this.dgvDeliveryNoteItems.RowHeadersWidth = 51;
            this.dgvDeliveryNoteItems.Size = new Size(436, 261);
            this.dgvDeliveryNoteItems.TabIndex = 0;

            // 
            // FormDeliveryNote
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1200, 800);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelTop);
            this.Name = "FormDeliveryNote";
            this.Text = "Quản lý phiếu xuất kho";

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNoteItems)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.grpDeliveryNotes.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.grpDeliveryNoteInfo.ResumeLayout(false);
            this.grpDeliveryNoteInfo.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.grpDeliveryNoteItems.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
