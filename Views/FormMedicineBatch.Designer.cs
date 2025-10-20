namespace IT59_Pharmacy.Views
{
    partial class FormMedicineBatch
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelForm = new System.Windows.Forms.Panel();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.cboMedicine = new System.Windows.Forms.ComboBox();
            this.numSellingPrice = new System.Windows.Forms.NumericUpDown();
            this.numCostPrice = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpManufacturingDate = new System.Windows.Forms.DateTimePicker();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblManufacturingDate = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblMedicine = new System.Windows.Forms.Label();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvBatches = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1400, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ LÔ THUỐC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.cboStatus);
            this.panelForm.Controls.Add(this.cboSupplier);
            this.panelForm.Controls.Add(this.cboMedicine);
            this.panelForm.Controls.Add(this.numSellingPrice);
            this.panelForm.Controls.Add(this.numCostPrice);
            this.panelForm.Controls.Add(this.numQuantity);
            this.panelForm.Controls.Add(this.dtpExpiryDate);
            this.panelForm.Controls.Add(this.dtpManufacturingDate);
            this.panelForm.Controls.Add(this.txtManufacturer);
            this.panelForm.Controls.Add(this.txtBatchNumber);
            this.panelForm.Controls.Add(this.lblStatus);
            this.panelForm.Controls.Add(this.lblSupplier);
            this.panelForm.Controls.Add(this.lblSellingPrice);
            this.panelForm.Controls.Add(this.lblCostPrice);
            this.panelForm.Controls.Add(this.lblQuantity);
            this.panelForm.Controls.Add(this.lblExpiryDate);
            this.panelForm.Controls.Add(this.lblManufacturingDate);
            this.panelForm.Controls.Add(this.lblManufacturer);
            this.panelForm.Controls.Add(this.lblMedicine);
            this.panelForm.Controls.Add(this.lblBatchNumber);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 60);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(20);
            this.panelForm.Size = new System.Drawing.Size(1400, 240);
            this.panelForm.TabIndex = 1;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(920, 190);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(200, 25);
            this.cboStatus.TabIndex = 9;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(570, 190);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(200, 25);
            this.cboSupplier.TabIndex = 8;
            // 
            // cboMedicine
            // 
            this.cboMedicine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicine.FormattingEnabled = true;
            this.cboMedicine.Location = new System.Drawing.Point(220, 70);
            this.cboMedicine.Name = "cboMedicine";
            this.cboMedicine.Size = new System.Drawing.Size(550, 25);
            this.cboMedicine.TabIndex = 2;
            // 
            // numSellingPrice
            // 
            this.numSellingPrice.DecimalPlaces = 0;
            this.numSellingPrice.Location = new System.Drawing.Point(920, 150);
            this.numSellingPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numSellingPrice.Name = "numSellingPrice";
            this.numSellingPrice.Size = new System.Drawing.Size(200, 25);
            this.numSellingPrice.TabIndex = 7;
            this.numSellingPrice.ThousandsSeparator = true;
            // 
            // numCostPrice
            // 
            this.numCostPrice.DecimalPlaces = 0;
            this.numCostPrice.Location = new System.Drawing.Point(570, 150);
            this.numCostPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numCostPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCostPrice.Name = "numCostPrice";
            this.numCostPrice.Size = new System.Drawing.Size(200, 25);
            this.numCostPrice.TabIndex = 6;
            this.numCostPrice.ThousandsSeparator = true;
            this.numCostPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(220, 150);
            this.numQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(200, 25);
            this.numQuantity.TabIndex = 5;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(920, 110);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 25);
            this.dtpExpiryDate.TabIndex = 4;
            // 
            // dtpManufacturingDate
            // 
            this.dtpManufacturingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpManufacturingDate.Location = new System.Drawing.Point(570, 110);
            this.dtpManufacturingDate.Name = "dtpManufacturingDate";
            this.dtpManufacturingDate.Size = new System.Drawing.Size(200, 25);
            this.dtpManufacturingDate.TabIndex = 3;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(920, 70);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(200, 25);
            this.txtManufacturer.TabIndex = 2;
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(220, 30);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(900, 25);
            this.txtBatchNumber.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(800, 193);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 17);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(450, 193);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(103, 17);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Nhà cung cấp:";
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Location = new System.Drawing.Point(800, 153);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(60, 17);
            this.lblSellingPrice.TabIndex = 0;
            this.lblSellingPrice.Text = "Giá bán:";
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Location = new System.Drawing.Point(450, 153);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(68, 17);
            this.lblCostPrice.TabIndex = 0;
            this.lblCostPrice.Text = "Giá nhập:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(150, 153);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(70, 17);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(800, 113);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(104, 17);
            this.lblExpiryDate.TabIndex = 0;
            this.lblExpiryDate.Text = "Hạn sử dụng:";
            // 
            // lblManufacturingDate
            // 
            this.lblManufacturingDate.AutoSize = true;
            this.lblManufacturingDate.Location = new System.Drawing.Point(450, 113);
            this.lblManufacturingDate.Name = "lblManufacturingDate";
            this.lblManufacturingDate.Size = new System.Drawing.Size(104, 17);
            this.lblManufacturingDate.TabIndex = 0;
            this.lblManufacturingDate.Text = "Ngày sản xuất:";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(800, 73);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(100, 17);
            this.lblManufacturer.TabIndex = 0;
            this.lblManufacturer.Text = "Nhà sản xuất:";
            // 
            // lblMedicine
            // 
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.Location = new System.Drawing.Point(150, 73);
            this.lblMedicine.Name = "lblMedicine";
            this.lblMedicine.Size = new System.Drawing.Size(47, 17);
            this.lblMedicine.TabIndex = 0;
            this.lblMedicine.Text = "Thuốc:";
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(150, 33);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(45, 17);
            this.lblBatchNumber.TabIndex = 0;
            this.lblBatchNumber.Text = "Số lô:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 300);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelButtons.Size = new System.Drawing.Size(1400, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(350, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(240, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Orange;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(130, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvBatches
            // 
            this.dgvBatches.AllowUserToAddRows = false;
            this.dgvBatches.AllowUserToDeleteRows = false;
            this.dgvBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatches.Location = new System.Drawing.Point(0, 360);
            this.dgvBatches.Name = "dgvBatches";
            this.dgvBatches.ReadOnly = true;
            this.dgvBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatches.Size = new System.Drawing.Size(1400, 440);
            this.dgvBatches.TabIndex = 3;
            this.dgvBatches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBatches_CellClick);
            // 
            // FormMedicineBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.dgvBatches);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FormMedicineBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý lô thuốc - Pharmacy Management";
            this.Load += new System.EventHandler(this.FormMedicineBatch_Load);
            this.panelTop.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Label lblMedicine;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblManufacturingDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.DateTimePicker dtpManufacturingDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numCostPrice;
        private System.Windows.Forms.NumericUpDown numSellingPrice;
        private System.Windows.Forms.ComboBox cboMedicine;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvBatches;
    }
}
