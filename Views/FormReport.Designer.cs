using System.Drawing;
using System.Windows.Forms;

namespace IT59_Pharmacy.Views
{
    partial class FormReport
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label lblTitle;
        private Panel panelButtons;
        private Button btnMedicineStock;
        private Button btnExpired;
        private Button btnExpirySoon;
        private TabControl tabControl;
        private TabPage tabMedicineStock;
        private TabPage tabExpired;
        private TabPage tabExpirySoon;
        private DataGridView dgvMedicineStock;
        private DataGridView dgvExpired;
        private DataGridView dgvExpirySoon;
        private Panel panelStockActions;
        private Button btnRefreshStock;
        private Button btnExportStock;
        private Label lblStockCount;
        private Panel panelExpiredActions;
        private Button btnRefreshExpired;
        private Button btnExportExpired;
        private Label lblExpiredCount;
        private Panel panelExpirySoonActions;
        private Button btnRefreshExpirySoon;
        private Button btnExportExpirySoon;
        private Label lblExpirySoonCount;
        private GroupBox grpExpirySoonFilter;
        private RadioButton rdo1Month;
        private RadioButton rdo3Months;

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
            this.panelButtons = new Panel();
            this.btnMedicineStock = new Button();
            this.btnExpired = new Button();
            this.btnExpirySoon = new Button();
            this.tabControl = new TabControl();
            this.tabMedicineStock = new TabPage();
            this.dgvMedicineStock = new DataGridView();
            this.panelStockActions = new Panel();
            this.lblStockCount = new Label();
            this.btnRefreshStock = new Button();
            this.btnExportStock = new Button();
            this.tabExpired = new TabPage();
            this.dgvExpired = new DataGridView();
            this.panelExpiredActions = new Panel();
            this.lblExpiredCount = new Label();
            this.btnRefreshExpired = new Button();
            this.btnExportExpired = new Button();
            this.tabExpirySoon = new TabPage();
            this.dgvExpirySoon = new DataGridView();
            this.panelExpirySoonActions = new Panel();
            this.grpExpirySoonFilter = new GroupBox();
            this.rdo1Month = new RadioButton();
            this.rdo3Months = new RadioButton();
            this.lblExpirySoonCount = new Label();
            this.btnRefreshExpirySoon = new Button();
            this.btnExportExpirySoon = new Button();

            this.tabControl.SuspendLayout();
            this.tabMedicineStock.SuspendLayout();
            this.tabExpired.SuspendLayout();
            this.tabExpirySoon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpirySoon)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelStockActions.SuspendLayout();
            this.panelExpiredActions.SuspendLayout();
            this.panelExpirySoonActions.SuspendLayout();
            this.grpExpirySoonFilter.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.BackColor = Color.FromArgb(142, 68, 173);
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
            this.lblTitle.Size = new Size(200, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ";

            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = Color.White;
            this.panelButtons.Controls.Add(this.btnMedicineStock);
            this.panelButtons.Controls.Add(this.btnExpired);
            this.panelButtons.Controls.Add(this.btnExpirySoon);
            this.panelButtons.Dock = DockStyle.Top;
            this.panelButtons.Location = new Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new Padding(20, 10, 20, 10);
            this.panelButtons.Size = new Size(1200, 70);
            this.panelButtons.TabIndex = 1;

            // 
            // btnMedicineStock
            // 
            this.btnMedicineStock.BackColor = Color.FromArgb(52, 152, 219);
            this.btnMedicineStock.FlatStyle = FlatStyle.Flat;
            this.btnMedicineStock.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnMedicineStock.ForeColor = Color.White;
            this.btnMedicineStock.Location = new Point(20, 15);
            this.btnMedicineStock.Name = "btnMedicineStock";
            this.btnMedicineStock.Size = new Size(180, 40);
            this.btnMedicineStock.TabIndex = 0;
            this.btnMedicineStock.Text = "Báo cáo tồn kho";
            this.btnMedicineStock.UseVisualStyleBackColor = false;
            this.btnMedicineStock.Click += new System.EventHandler(this.btnMedicineStock_Click);

            // 
            // btnExpired
            // 
            this.btnExpired.BackColor = Color.FromArgb(231, 76, 60);
            this.btnExpired.FlatStyle = FlatStyle.Flat;
            this.btnExpired.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnExpired.ForeColor = Color.White;
            this.btnExpired.Location = new Point(210, 15);
            this.btnExpired.Name = "btnExpired";
            this.btnExpired.Size = new Size(180, 40);
            this.btnExpired.TabIndex = 1;
            this.btnExpired.Text = "Thuốc hết hạn";
            this.btnExpired.UseVisualStyleBackColor = false;
            this.btnExpired.Click += new System.EventHandler(this.btnExpired_Click);

            // 
            // btnExpirySoon
            // 
            this.btnExpirySoon.BackColor = Color.FromArgb(230, 126, 34);
            this.btnExpirySoon.FlatStyle = FlatStyle.Flat;
            this.btnExpirySoon.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnExpirySoon.ForeColor = Color.White;
            this.btnExpirySoon.Location = new Point(400, 15);
            this.btnExpirySoon.Name = "btnExpirySoon";
            this.btnExpirySoon.Size = new Size(180, 40);
            this.btnExpirySoon.TabIndex = 2;
            this.btnExpirySoon.Text = "Sắp hết hạn";
            this.btnExpirySoon.UseVisualStyleBackColor = false;
            this.btnExpirySoon.Click += new System.EventHandler(this.btnExpirySoon_Click);

            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMedicineStock);
            this.tabControl.Controls.Add(this.tabExpired);
            this.tabControl.Controls.Add(this.tabExpirySoon);
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Segoe UI", 10F);
            this.tabControl.Location = new Point(0, 130);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(1200, 670);
            this.tabControl.TabIndex = 2;

            // 
            // tabMedicineStock
            // 
            this.tabMedicineStock.Controls.Add(this.dgvMedicineStock);
            this.tabMedicineStock.Controls.Add(this.panelStockActions);
            this.tabMedicineStock.Location = new Point(4, 26);
            this.tabMedicineStock.Name = "tabMedicineStock";
            this.tabMedicineStock.Padding = new Padding(3);
            this.tabMedicineStock.Size = new Size(1192, 640);
            this.tabMedicineStock.TabIndex = 0;
            this.tabMedicineStock.Text = "Tồn kho";
            this.tabMedicineStock.UseVisualStyleBackColor = true;

            // 
            // dgvMedicineStock
            // 
            this.dgvMedicineStock.BackgroundColor = Color.White;
            this.dgvMedicineStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicineStock.Dock = DockStyle.Fill;
            this.dgvMedicineStock.Location = new Point(3, 63);
            this.dgvMedicineStock.Name = "dgvMedicineStock";
            this.dgvMedicineStock.RowHeadersWidth = 51;
            this.dgvMedicineStock.Size = new Size(1186, 574);
            this.dgvMedicineStock.TabIndex = 0;
            this.dgvMedicineStock.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvMedicineStock_ColumnHeaderMouseClick);

            // 
            // panelStockActions
            // 
            this.panelStockActions.BackColor = Color.FromArgb(236, 240, 241);
            this.panelStockActions.Controls.Add(this.lblStockCount);
            this.panelStockActions.Controls.Add(this.btnRefreshStock);
            this.panelStockActions.Controls.Add(this.btnExportStock);
            this.panelStockActions.Dock = DockStyle.Top;
            this.panelStockActions.Location = new Point(3, 3);
            this.panelStockActions.Name = "panelStockActions";
            this.panelStockActions.Padding = new Padding(10);
            this.panelStockActions.Size = new Size(1186, 60);
            this.panelStockActions.TabIndex = 1;

            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblStockCount.Location = new Point(15, 20);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new Size(200, 20);
            this.lblStockCount.TabIndex = 0;
            this.lblStockCount.Text = "Tổng số loại thuốc: 0";

            // 
            // btnRefreshStock
            // 
            this.btnRefreshStock.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnRefreshStock.BackColor = Color.FromArgb(52, 152, 219);
            this.btnRefreshStock.FlatStyle = FlatStyle.Flat;
            this.btnRefreshStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRefreshStock.ForeColor = Color.White;
            this.btnRefreshStock.Location = new Point(936, 15);
            this.btnRefreshStock.Name = "btnRefreshStock";
            this.btnRefreshStock.Size = new Size(110, 30);
            this.btnRefreshStock.TabIndex = 1;
            this.btnRefreshStock.Text = "Làm mới";
            this.btnRefreshStock.UseVisualStyleBackColor = false;
            this.btnRefreshStock.Click += new System.EventHandler(this.btnRefreshStock_Click);

            // 
            // btnExportStock
            // 
            this.btnExportStock.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnExportStock.BackColor = Color.FromArgb(46, 204, 113);
            this.btnExportStock.FlatStyle = FlatStyle.Flat;
            this.btnExportStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExportStock.ForeColor = Color.White;
            this.btnExportStock.Location = new Point(1056, 15);
            this.btnExportStock.Name = "btnExportStock";
            this.btnExportStock.Size = new Size(110, 30);
            this.btnExportStock.TabIndex = 2;
            this.btnExportStock.Text = "Xuất Excel";
            this.btnExportStock.UseVisualStyleBackColor = false;
            this.btnExportStock.Click += new System.EventHandler(this.btnExportStock_Click);

            // 
            // tabExpired
            // 
            this.tabExpired.Controls.Add(this.dgvExpired);
            this.tabExpired.Controls.Add(this.panelExpiredActions);
            this.tabExpired.Location = new Point(4, 26);
            this.tabExpired.Name = "tabExpired";
            this.tabExpired.Padding = new Padding(3);
            this.tabExpired.Size = new Size(1192, 640);
            this.tabExpired.TabIndex = 1;
            this.tabExpired.Text = "Hết hạn";
            this.tabExpired.UseVisualStyleBackColor = true;

            // 
            // dgvExpired
            // 
            this.dgvExpired.BackgroundColor = Color.White;
            this.dgvExpired.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpired.Dock = DockStyle.Fill;
            this.dgvExpired.Location = new Point(3, 63);
            this.dgvExpired.Name = "dgvExpired";
            this.dgvExpired.RowHeadersWidth = 51;
            this.dgvExpired.Size = new Size(1186, 574);
            this.dgvExpired.TabIndex = 0;

            // 
            // panelExpiredActions
            // 
            this.panelExpiredActions.BackColor = Color.FromArgb(236, 240, 241);
            this.panelExpiredActions.Controls.Add(this.lblExpiredCount);
            this.panelExpiredActions.Controls.Add(this.btnRefreshExpired);
            this.panelExpiredActions.Controls.Add(this.btnExportExpired);
            this.panelExpiredActions.Dock = DockStyle.Top;
            this.panelExpiredActions.Location = new Point(3, 3);
            this.panelExpiredActions.Name = "panelExpiredActions";
            this.panelExpiredActions.Padding = new Padding(10);
            this.panelExpiredActions.Size = new Size(1186, 60);
            this.panelExpiredActions.TabIndex = 1;

            // 
            // lblExpiredCount
            // 
            this.lblExpiredCount.AutoSize = true;
            this.lblExpiredCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblExpiredCount.ForeColor = Color.FromArgb(192, 57, 43);
            this.lblExpiredCount.Location = new Point(15, 20);
            this.lblExpiredCount.Name = "lblExpiredCount";
            this.lblExpiredCount.Size = new Size(150, 20);
            this.lblExpiredCount.TabIndex = 0;
            this.lblExpiredCount.Text = "Số lô hết hạn: 0";

            // 
            // btnRefreshExpired
            // 
            this.btnRefreshExpired.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnRefreshExpired.BackColor = Color.FromArgb(52, 152, 219);
            this.btnRefreshExpired.FlatStyle = FlatStyle.Flat;
            this.btnRefreshExpired.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRefreshExpired.ForeColor = Color.White;
            this.btnRefreshExpired.Location = new Point(936, 15);
            this.btnRefreshExpired.Name = "btnRefreshExpired";
            this.btnRefreshExpired.Size = new Size(110, 30);
            this.btnRefreshExpired.TabIndex = 1;
            this.btnRefreshExpired.Text = "Làm mới";
            this.btnRefreshExpired.UseVisualStyleBackColor = false;
            this.btnRefreshExpired.Click += new System.EventHandler(this.btnRefreshExpired_Click);

            // 
            // btnExportExpired
            // 
            this.btnExportExpired.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnExportExpired.BackColor = Color.FromArgb(46, 204, 113);
            this.btnExportExpired.FlatStyle = FlatStyle.Flat;
            this.btnExportExpired.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExportExpired.ForeColor = Color.White;
            this.btnExportExpired.Location = new Point(1056, 15);
            this.btnExportExpired.Name = "btnExportExpired";
            this.btnExportExpired.Size = new Size(110, 30);
            this.btnExportExpired.TabIndex = 2;
            this.btnExportExpired.Text = "Xuất Excel";
            this.btnExportExpired.UseVisualStyleBackColor = false;
            this.btnExportExpired.Click += new System.EventHandler(this.btnExportExpired_Click);

            // 
            // tabExpirySoon
            // 
            this.tabExpirySoon.Controls.Add(this.dgvExpirySoon);
            this.tabExpirySoon.Controls.Add(this.panelExpirySoonActions);
            this.tabExpirySoon.Location = new Point(4, 26);
            this.tabExpirySoon.Name = "tabExpirySoon";
            this.tabExpirySoon.Padding = new Padding(3);
            this.tabExpirySoon.Size = new Size(1192, 640);
            this.tabExpirySoon.TabIndex = 2;
            this.tabExpirySoon.Text = "Sắp hết hạn";
            this.tabExpirySoon.UseVisualStyleBackColor = true;

            // 
            // dgvExpirySoon
            // 
            this.dgvExpirySoon.BackgroundColor = Color.White;
            this.dgvExpirySoon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpirySoon.Dock = DockStyle.Fill;
            this.dgvExpirySoon.Location = new Point(3, 63);
            this.dgvExpirySoon.Name = "dgvExpirySoon";
            this.dgvExpirySoon.RowHeadersWidth = 51;
            this.dgvExpirySoon.Size = new Size(1186, 574);
            this.dgvExpirySoon.TabIndex = 0;

            // 
            // panelExpirySoonActions
            // 
            this.panelExpirySoonActions.BackColor = Color.FromArgb(236, 240, 241);
            this.panelExpirySoonActions.Controls.Add(this.grpExpirySoonFilter);
            this.panelExpirySoonActions.Controls.Add(this.lblExpirySoonCount);
            this.panelExpirySoonActions.Controls.Add(this.btnRefreshExpirySoon);
            this.panelExpirySoonActions.Controls.Add(this.btnExportExpirySoon);
            this.panelExpirySoonActions.Dock = DockStyle.Top;
            this.panelExpirySoonActions.Location = new Point(3, 3);
            this.panelExpirySoonActions.Name = "panelExpirySoonActions";
            this.panelExpirySoonActions.Padding = new Padding(10);
            this.panelExpirySoonActions.Size = new Size(1186, 60);
            this.panelExpirySoonActions.TabIndex = 1;

            // 
            // grpExpirySoonFilter
            // 
            this.grpExpirySoonFilter.Controls.Add(this.rdo1Month);
            this.grpExpirySoonFilter.Controls.Add(this.rdo3Months);
            this.grpExpirySoonFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.grpExpirySoonFilter.Location = new Point(300, 10);
            this.grpExpirySoonFilter.Name = "grpExpirySoonFilter";
            this.grpExpirySoonFilter.Size = new Size(250, 45);
            this.grpExpirySoonFilter.TabIndex = 3;
            this.grpExpirySoonFilter.TabStop = false;
            this.grpExpirySoonFilter.Text = "Thời gian";

            // 
            // rdo1Month
            // 
            this.rdo1Month.AutoSize = true;
            this.rdo1Month.Font = new Font("Segoe UI", 9F);
            this.rdo1Month.Location = new Point(15, 18);
            this.rdo1Month.Name = "rdo1Month";
            this.rdo1Month.Size = new Size(75, 19);
            this.rdo1Month.TabIndex = 0;
            this.rdo1Month.Text = "1 tháng";
            this.rdo1Month.UseVisualStyleBackColor = true;
            this.rdo1Month.CheckedChanged += new System.EventHandler(this.rdo1Month_CheckedChanged);

            // 
            // rdo3Months
            // 
            this.rdo3Months.AutoSize = true;
            this.rdo3Months.Checked = true;
            this.rdo3Months.Font = new Font("Segoe UI", 9F);
            this.rdo3Months.Location = new Point(130, 18);
            this.rdo3Months.Name = "rdo3Months";
            this.rdo3Months.Size = new Size(75, 19);
            this.rdo3Months.TabIndex = 1;
            this.rdo3Months.TabStop = true;
            this.rdo3Months.Text = "3 tháng";
            this.rdo3Months.UseVisualStyleBackColor = true;
            this.rdo3Months.CheckedChanged += new System.EventHandler(this.rdo3Months_CheckedChanged);

            // 
            // lblExpirySoonCount
            // 
            this.lblExpirySoonCount.AutoSize = true;
            this.lblExpirySoonCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblExpirySoonCount.ForeColor = Color.FromArgb(211, 84, 0);
            this.lblExpirySoonCount.Location = new Point(15, 20);
            this.lblExpirySoonCount.Name = "lblExpirySoonCount";
            this.lblExpirySoonCount.Size = new Size(200, 20);
            this.lblExpirySoonCount.TabIndex = 0;
            this.lblExpirySoonCount.Text = "Số lô sắp hết hạn: 0";

            // 
            // btnRefreshExpirySoon
            // 
            this.btnRefreshExpirySoon.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnRefreshExpirySoon.BackColor = Color.FromArgb(52, 152, 219);
            this.btnRefreshExpirySoon.FlatStyle = FlatStyle.Flat;
            this.btnRefreshExpirySoon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRefreshExpirySoon.ForeColor = Color.White;
            this.btnRefreshExpirySoon.Location = new Point(936, 15);
            this.btnRefreshExpirySoon.Name = "btnRefreshExpirySoon";
            this.btnRefreshExpirySoon.Size = new Size(110, 30);
            this.btnRefreshExpirySoon.TabIndex = 1;
            this.btnRefreshExpirySoon.Text = "Làm mới";
            this.btnRefreshExpirySoon.UseVisualStyleBackColor = false;
            this.btnRefreshExpirySoon.Click += new System.EventHandler(this.btnRefreshExpirySoon_Click);

            // 
            // btnExportExpirySoon
            // 
            this.btnExportExpirySoon.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnExportExpirySoon.BackColor = Color.FromArgb(46, 204, 113);
            this.btnExportExpirySoon.FlatStyle = FlatStyle.Flat;
            this.btnExportExpirySoon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExportExpirySoon.ForeColor = Color.White;
            this.btnExportExpirySoon.Location = new Point(1056, 15);
            this.btnExportExpirySoon.Name = "btnExportExpirySoon";
            this.btnExportExpirySoon.Size = new Size(110, 30);
            this.btnExportExpirySoon.TabIndex = 2;
            this.btnExportExpirySoon.Text = "Xuất Excel";
            this.btnExportExpirySoon.UseVisualStyleBackColor = false;
            this.btnExportExpirySoon.Click += new System.EventHandler(this.btnExportExpirySoon_Click);

            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.ClientSize = new Size(1200, 800);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "FormReport";
            this.Text = "Báo cáo thống kê";

            this.tabControl.ResumeLayout(false);
            this.tabMedicineStock.ResumeLayout(false);
            this.tabExpired.ResumeLayout(false);
            this.tabExpirySoon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpirySoon)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelStockActions.ResumeLayout(false);
            this.panelStockActions.PerformLayout();
            this.panelExpiredActions.ResumeLayout(false);
            this.panelExpiredActions.PerformLayout();
            this.panelExpirySoonActions.ResumeLayout(false);
            this.panelExpirySoonActions.PerformLayout();
            this.grpExpirySoonFilter.ResumeLayout(false);
            this.grpExpirySoonFilter.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

