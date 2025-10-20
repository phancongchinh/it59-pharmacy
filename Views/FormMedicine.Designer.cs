namespace IT59_Pharmacy.Views
{
    partial class FormMedicine
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
            this.numLowStockThreshold = new System.Windows.Forms.NumericUpDown();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboForm = new System.Windows.Forms.ComboBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.chkPrescriptionRequired = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStrength = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblLowStockThreshold = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblForm = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.panelBatchesTop = new System.Windows.Forms.Panel();
            this.lblBatchesTitle = new System.Windows.Forms.Label();
            this.btnToggleBatchManagement = new System.Windows.Forms.Button();
            this.panelBatchButtons = new System.Windows.Forms.Panel();
            this.btnRefreshBatches = new System.Windows.Forms.Button();
            this.btnSaveBatch = new System.Windows.Forms.Button();
            this.btnUpdateBatch = new System.Windows.Forms.Button();
            this.btnAddBatch = new System.Windows.Forms.Button();
            this.dgvBatches = new System.Windows.Forms.DataGridView();
            this.panelBatchForm = new System.Windows.Forms.Panel();
            this.lblBatchStatus = new System.Windows.Forms.Label();
            this.lblBatchSupplier = new System.Windows.Forms.Label();
            this.lblBatchSellingPrice = new System.Windows.Forms.Label();
            this.lblBatchCostPrice = new System.Windows.Forms.Label();
            this.lblBatchQuantity = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblManufacturingDate = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.cboBatchStatus = new System.Windows.Forms.ComboBox();
            this.cboBatchSupplier = new System.Windows.Forms.ComboBox();
            this.numBatchSellingPrice = new System.Windows.Forms.NumericUpDown();
            this.numBatchCostPrice = new System.Windows.Forms.NumericUpDown();
            this.numBatchQuantity = new System.Windows.Forms.NumericUpDown();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpManufacturingDate = new System.Windows.Forms.DateTimePicker();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStockThreshold)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.panelBatchesTop.SuspendLayout();
            this.panelBatchButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).BeginInit();
            this.panelBatchForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchCostPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchQuantity)).BeginInit();
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
            this.lblTitle.Text = "QUẢN LÝ THUỐC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.numLowStockThreshold);
            this.panelForm.Controls.Add(this.cboCategory);
            this.panelForm.Controls.Add(this.cboUnit);
            this.panelForm.Controls.Add(this.cboForm);
            this.panelForm.Controls.Add(this.chkIsActive);
            this.panelForm.Controls.Add(this.chkPrescriptionRequired);
            this.panelForm.Controls.Add(this.txtDescription);
            this.panelForm.Controls.Add(this.txtStrength);
            this.panelForm.Controls.Add(this.txtName);
            this.panelForm.Controls.Add(this.lblLowStockThreshold);
            this.panelForm.Controls.Add(this.lblCategory);
            this.panelForm.Controls.Add(this.lblUnit);
            this.panelForm.Controls.Add(this.lblForm);
            this.panelForm.Controls.Add(this.lblDescription);
            this.panelForm.Controls.Add(this.lblStrength);
            this.panelForm.Controls.Add(this.lblName);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 60);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(20);
            this.panelForm.Size = new System.Drawing.Size(1400, 220);
            this.panelForm.TabIndex = 1;
            // 
            // numLowStockThreshold
            // 
            this.numLowStockThreshold.Location = new System.Drawing.Point(920, 130);
            this.numLowStockThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLowStockThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowStockThreshold.Name = "numLowStockThreshold";
            this.numLowStockThreshold.Size = new System.Drawing.Size(200, 25);
            this.numLowStockThreshold.TabIndex = 7;
            this.numLowStockThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(570, 130);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 25);
            this.cboCategory.TabIndex = 6;
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(220, 130);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(200, 25);
            this.cboUnit.TabIndex = 5;
            // 
            // cboForm
            // 
            this.cboForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForm.FormattingEnabled = true;
            this.cboForm.Location = new System.Drawing.Point(920, 70);
            this.cboForm.Name = "cboForm";
            this.cboForm.Size = new System.Drawing.Size(200, 25);
            this.cboForm.TabIndex = 4;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(220, 180);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(85, 21);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Text = "Hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // chkPrescriptionRequired
            // 
            this.chkPrescriptionRequired.AutoSize = true;
            this.chkPrescriptionRequired.Location = new System.Drawing.Point(920, 180);
            this.chkPrescriptionRequired.Name = "chkPrescriptionRequired";
            this.chkPrescriptionRequired.Size = new System.Drawing.Size(106, 21);
            this.chkPrescriptionRequired.TabIndex = 8;
            this.chkPrescriptionRequired.Text = "Cần kê đơn";
            this.chkPrescriptionRequired.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(570, 70);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 25);
            this.txtDescription.TabIndex = 3;
            // 
            // txtStrength
            // 
            this.txtStrength.Location = new System.Drawing.Point(220, 70);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(200, 25);
            this.txtStrength.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(220, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(900, 25);
            this.txtName.TabIndex = 1;
            // 
            // lblLowStockThreshold
            // 
            this.lblLowStockThreshold.AutoSize = true;
            this.lblLowStockThreshold.Location = new System.Drawing.Point(800, 133);
            this.lblLowStockThreshold.Name = "lblLowStockThreshold";
            this.lblLowStockThreshold.Size = new System.Drawing.Size(109, 17);
            this.lblLowStockThreshold.TabIndex = 0;
            this.lblLowStockThreshold.Text = "Ngưỡng tồn kho:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(450, 133);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(70, 17);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Danh mục:";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(150, 133);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(49, 17);
            this.lblUnit.TabIndex = 0;
            this.lblUnit.Text = "Đơn vị:";
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(800, 73);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(90, 17);
            this.lblForm.TabIndex = 0;
            this.lblForm.Text = "Dạng bào chế:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(450, 73);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(46, 17);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Mô tả:";
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(150, 73);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(64, 17);
            this.lblStrength.TabIndex = 0;
            this.lblStrength.Text = "Nồng độ:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(150, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên thuốc:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 280);
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
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 340);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvMedicines);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvBatches);
            this.splitContainer.Panel2.Controls.Add(this.panelBatchButtons);
            this.splitContainer.Panel2.Controls.Add(this.panelBatchesTop);
            this.splitContainer.Panel2.Controls.Add(this.panelBatchForm);
            this.splitContainer.Size = new System.Drawing.Size(1400, 460);
            this.splitContainer.SplitterDistance = 700;
            this.splitContainer.TabIndex = 3;
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicines.Location = new System.Drawing.Point(0, 0);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.Size = new System.Drawing.Size(700, 460);
            this.dgvMedicines.TabIndex = 0;
            this.dgvMedicines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicines_CellClick);
            // 
            // panelBatchesTop
            // 
            this.panelBatchesTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.panelBatchesTop.Controls.Add(this.lblBatchesTitle);
            this.panelBatchesTop.Controls.Add(this.btnToggleBatchManagement);
            this.panelBatchesTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBatchesTop.Location = new System.Drawing.Point(0, 0);
            this.panelBatchesTop.Name = "panelBatchesTop";
            this.panelBatchesTop.Size = new System.Drawing.Size(696, 40);
            this.panelBatchesTop.TabIndex = 1;
            // 
            // lblBatchesTitle
            // 
            this.lblBatchesTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBatchesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBatchesTitle.ForeColor = System.Drawing.Color.White;
            this.lblBatchesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblBatchesTitle.Name = "lblBatchesTitle";
            this.lblBatchesTitle.Size = new System.Drawing.Size(596, 40);
            this.lblBatchesTitle.TabIndex = 0;
            this.lblBatchesTitle.Text = "Danh Sách Lô Thuốc";
            this.lblBatchesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnToggleBatchManagement
            // 
            this.btnToggleBatchManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            this.btnToggleBatchManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleBatchManagement.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToggleBatchManagement.FlatAppearance.BorderSize = 0;
            this.btnToggleBatchManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleBatchManagement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnToggleBatchManagement.ForeColor = System.Drawing.Color.White;
            this.btnToggleBatchManagement.Location = new System.Drawing.Point(596, 0);
            this.btnToggleBatchManagement.Name = "btnToggleBatchManagement";
            this.btnToggleBatchManagement.Size = new System.Drawing.Size(100, 40);
            this.btnToggleBatchManagement.TabIndex = 1;
            this.btnToggleBatchManagement.Text = "Ẩn ▲";
            this.btnToggleBatchManagement.UseVisualStyleBackColor = false;
            this.btnToggleBatchManagement.Click += new System.EventHandler(this.btnToggleBatchManagement_Click);
            // 
            // panelBatchForm
            // 
            this.panelBatchForm.BackColor = System.Drawing.Color.White;
            this.panelBatchForm.Controls.Add(this.lblBatchStatus);
            this.panelBatchForm.Controls.Add(this.lblBatchSupplier);
            this.panelBatchForm.Controls.Add(this.lblBatchSellingPrice);
            this.panelBatchForm.Controls.Add(this.lblBatchCostPrice);
            this.panelBatchForm.Controls.Add(this.lblBatchQuantity);
            this.panelBatchForm.Controls.Add(this.lblExpiryDate);
            this.panelBatchForm.Controls.Add(this.lblManufacturingDate);
            this.panelBatchForm.Controls.Add(this.lblManufacturer);
            this.panelBatchForm.Controls.Add(this.lblBatchNumber);
            this.panelBatchForm.Controls.Add(this.cboBatchStatus);
            this.panelBatchForm.Controls.Add(this.cboBatchSupplier);
            this.panelBatchForm.Controls.Add(this.numBatchSellingPrice);
            this.panelBatchForm.Controls.Add(this.numBatchCostPrice);
            this.panelBatchForm.Controls.Add(this.numBatchQuantity);
            this.panelBatchForm.Controls.Add(this.dtpExpiryDate);
            this.panelBatchForm.Controls.Add(this.dtpManufacturingDate);
            this.panelBatchForm.Controls.Add(this.txtManufacturer);
            this.panelBatchForm.Controls.Add(this.txtBatchNumber);
            this.panelBatchForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBatchForm.Location = new System.Drawing.Point(0, 40);
            this.panelBatchForm.Name = "panelBatchForm";
            this.panelBatchForm.Padding = new System.Windows.Forms.Padding(10);
            this.panelBatchForm.Size = new System.Drawing.Size(696, 220);
            this.panelBatchForm.TabIndex = 3;
            // 
            // lblBatchStatus
            // 
            this.lblBatchStatus.AutoSize = true;
            this.lblBatchStatus.Location = new System.Drawing.Point(360, 180);
            this.lblBatchStatus.Name = "lblBatchStatus";
            this.lblBatchStatus.Size = new System.Drawing.Size(70, 17);
            this.lblBatchStatus.TabIndex = 0;
            this.lblBatchStatus.Text = "Trạng thái:";
            // 
            // lblBatchSupplier
            // 
            this.lblBatchSupplier.AutoSize = true;
            this.lblBatchSupplier.Location = new System.Drawing.Point(15, 180);
            this.lblBatchSupplier.Name = "lblBatchSupplier";
            this.lblBatchSupplier.Size = new System.Drawing.Size(103, 17);
            this.lblBatchSupplier.TabIndex = 0;
            this.lblBatchSupplier.Text = "Nhà cung cấp:";
            // 
            // lblBatchSellingPrice
            // 
            this.lblBatchSellingPrice.AutoSize = true;
            this.lblBatchSellingPrice.Location = new System.Drawing.Point(360, 140);
            this.lblBatchSellingPrice.Name = "lblBatchSellingPrice";
            this.lblBatchSellingPrice.Size = new System.Drawing.Size(60, 17);
            this.lblBatchSellingPrice.TabIndex = 0;
            this.lblBatchSellingPrice.Text = "Giá bán:";
            // 
            // lblBatchCostPrice
            // 
            this.lblBatchCostPrice.AutoSize = true;
            this.lblBatchCostPrice.Location = new System.Drawing.Point(15, 140);
            this.lblBatchCostPrice.Name = "lblBatchCostPrice";
            this.lblBatchCostPrice.Size = new System.Drawing.Size(68, 17);
            this.lblBatchCostPrice.TabIndex = 0;
            this.lblBatchCostPrice.Text = "Giá nhập:";
            // 
            // lblBatchQuantity
            // 
            this.lblBatchQuantity.AutoSize = true;
            this.lblBatchQuantity.Location = new System.Drawing.Point(360, 100);
            this.lblBatchQuantity.Name = "lblBatchQuantity";
            this.lblBatchQuantity.Size = new System.Drawing.Size(70, 17);
            this.lblBatchQuantity.TabIndex = 0;
            this.lblBatchQuantity.Text = "Số lượng:";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(15, 100);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(104, 17);
            this.lblExpiryDate.TabIndex = 0;
            this.lblExpiryDate.Text = "Hạn sử dụng:";
            // 
            // lblManufacturingDate
            // 
            this.lblManufacturingDate.AutoSize = true;
            this.lblManufacturingDate.Location = new System.Drawing.Point(360, 60);
            this.lblManufacturingDate.Name = "lblManufacturingDate";
            this.lblManufacturingDate.Size = new System.Drawing.Size(104, 17);
            this.lblManufacturingDate.TabIndex = 0;
            this.lblManufacturingDate.Text = "Ngày sản xuất:";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(15, 60);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(100, 17);
            this.lblManufacturer.TabIndex = 0;
            this.lblManufacturer.Text = "Nhà sản xuất:";
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(15, 20);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(45, 17);
            this.lblBatchNumber.TabIndex = 0;
            this.lblBatchNumber.Text = "Số lô:";
            // 
            // cboBatchStatus
            // 
            this.cboBatchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchStatus.FormattingEnabled = true;
            this.cboBatchStatus.Location = new System.Drawing.Point(470, 177);
            this.cboBatchStatus.Name = "cboBatchStatus";
            this.cboBatchStatus.Size = new System.Drawing.Size(200, 25);
            this.cboBatchStatus.TabIndex = 8;
            // 
            // cboBatchSupplier
            // 
            this.cboBatchSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchSupplier.FormattingEnabled = true;
            this.cboBatchSupplier.Location = new System.Drawing.Point(125, 177);
            this.cboBatchSupplier.Name = "cboBatchSupplier";
            this.cboBatchSupplier.Size = new System.Drawing.Size(220, 25);
            this.cboBatchSupplier.TabIndex = 7;
            // 
            // numBatchSellingPrice
            // 
            this.numBatchSellingPrice.DecimalPlaces = 0;
            this.numBatchSellingPrice.Location = new System.Drawing.Point(470, 137);
            this.numBatchSellingPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBatchSellingPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchSellingPrice.Name = "numBatchSellingPrice";
            this.numBatchSellingPrice.Size = new System.Drawing.Size(200, 25);
            this.numBatchSellingPrice.TabIndex = 6;
            this.numBatchSellingPrice.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBatchSellingPrice.ThousandsSeparator = true;
            // 
            // numBatchCostPrice
            // 
            this.numBatchCostPrice.DecimalPlaces = 0;
            this.numBatchCostPrice.Location = new System.Drawing.Point(125, 137);
            this.numBatchCostPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBatchCostPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchCostPrice.Name = "numBatchCostPrice";
            this.numBatchCostPrice.Size = new System.Drawing.Size(220, 25);
            this.numBatchCostPrice.TabIndex = 5;
            this.numBatchCostPrice.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBatchCostPrice.ThousandsSeparator = true;
            // 
            // numBatchQuantity
            // 
            this.numBatchQuantity.Location = new System.Drawing.Point(470, 97);
            this.numBatchQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBatchQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchQuantity.Name = "numBatchQuantity";
            this.numBatchQuantity.Size = new System.Drawing.Size(200, 25);
            this.numBatchQuantity.TabIndex = 4;
            this.numBatchQuantity.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(125, 97);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(220, 25);
            this.dtpExpiryDate.TabIndex = 3;
            // 
            // dtpManufacturingDate
            // 
            this.dtpManufacturingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpManufacturingDate.Location = new System.Drawing.Point(470, 57);
            this.dtpManufacturingDate.Name = "dtpManufacturingDate";
            this.dtpManufacturingDate.Size = new System.Drawing.Size(200, 25);
            this.dtpManufacturingDate.TabIndex = 2;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(125, 57);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(220, 25);
            this.txtManufacturer.TabIndex = 1;
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(125, 17);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(545, 25);
            this.txtBatchNumber.TabIndex = 0;
            // 
            // panelBatchButtons
            // 
            this.panelBatchButtons.Controls.Add(this.btnRefreshBatches);
            this.panelBatchButtons.Controls.Add(this.btnSaveBatch);
            this.panelBatchButtons.Controls.Add(this.btnUpdateBatch);
            this.panelBatchButtons.Controls.Add(this.btnAddBatch);
            this.panelBatchButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBatchButtons.Location = new System.Drawing.Point(0, 260);
            this.panelBatchButtons.Name = "panelBatchButtons";
            this.panelBatchButtons.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelBatchButtons.Size = new System.Drawing.Size(696, 50);
            this.panelBatchButtons.TabIndex = 2;
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnAddBatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBatch.ForeColor = System.Drawing.Color.White;
            this.btnAddBatch.Location = new System.Drawing.Point(10, 8);
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Size = new System.Drawing.Size(100, 35);
            this.btnAddBatch.TabIndex = 0;
            this.btnAddBatch.Text = "Thêm lô";
            this.btnAddBatch.UseVisualStyleBackColor = false;
            this.btnAddBatch.Click += new System.EventHandler(this.btnAddBatch_Click);
            // 
            // btnUpdateBatch
            // 
            this.btnUpdateBatch.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateBatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateBatch.ForeColor = System.Drawing.Color.White;
            this.btnUpdateBatch.Location = new System.Drawing.Point(120, 8);
            this.btnUpdateBatch.Name = "btnUpdateBatch";
            this.btnUpdateBatch.Size = new System.Drawing.Size(100, 35);
            this.btnUpdateBatch.TabIndex = 1;
            this.btnUpdateBatch.Text = "Cập nhật";
            this.btnUpdateBatch.UseVisualStyleBackColor = false;
            this.btnUpdateBatch.Click += new System.EventHandler(this.btnUpdateBatch_Click);
            // 
            // btnSaveBatch
            // 
            this.btnSaveBatch.BackColor = System.Drawing.Color.Green;
            this.btnSaveBatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveBatch.Enabled = false;
            this.btnSaveBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBatch.ForeColor = System.Drawing.Color.White;
            this.btnSaveBatch.Location = new System.Drawing.Point(230, 8);
            this.btnSaveBatch.Name = "btnSaveBatch";
            this.btnSaveBatch.Size = new System.Drawing.Size(100, 35);
            this.btnSaveBatch.TabIndex = 2;
            this.btnSaveBatch.Text = "Lưu";
            this.btnSaveBatch.UseVisualStyleBackColor = false;
            this.btnSaveBatch.Click += new System.EventHandler(this.btnSaveBatch_Click);
            // 
            // btnRefreshBatches
            // 
            this.btnRefreshBatches.BackColor = System.Drawing.Color.Gray;
            this.btnRefreshBatches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBatches.ForeColor = System.Drawing.Color.White;
            this.btnRefreshBatches.Location = new System.Drawing.Point(340, 8);
            this.btnRefreshBatches.Name = "btnRefreshBatches";
            this.btnRefreshBatches.Size = new System.Drawing.Size(100, 35);
            this.btnRefreshBatches.TabIndex = 3;
            this.btnRefreshBatches.Text = "Làm mới";
            this.btnRefreshBatches.UseVisualStyleBackColor = false;
            this.btnRefreshBatches.Click += new System.EventHandler(this.btnRefreshBatches_Click);
            // 
            // dgvBatches
            // 
            this.dgvBatches.AllowUserToAddRows = false;
            this.dgvBatches.AllowUserToDeleteRows = false;
            this.dgvBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatches.Location = new System.Drawing.Point(0, 90);
            this.dgvBatches.Name = "dgvBatches";
            this.dgvBatches.ReadOnly = true;
            this.dgvBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatches.Size = new System.Drawing.Size(696, 370);
            this.dgvBatches.TabIndex = 0;
            this.dgvBatches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBatches_CellClick);
            // 
            // panelBatchForm
            // 
            this.panelBatchForm.BackColor = System.Drawing.Color.White;
            this.panelBatchForm.Controls.Add(this.lblBatchStatus);
            this.panelBatchForm.Controls.Add(this.lblBatchSupplier);
            this.panelBatchForm.Controls.Add(this.lblBatchSellingPrice);
            this.panelBatchForm.Controls.Add(this.lblBatchCostPrice);
            this.panelBatchForm.Controls.Add(this.lblBatchQuantity);
            this.panelBatchForm.Controls.Add(this.lblExpiryDate);
            this.panelBatchForm.Controls.Add(this.lblManufacturingDate);
            this.panelBatchForm.Controls.Add(this.lblManufacturer);
            this.panelBatchForm.Controls.Add(this.lblBatchNumber);
            this.panelBatchForm.Controls.Add(this.cboBatchStatus);
            this.panelBatchForm.Controls.Add(this.cboBatchSupplier);
            this.panelBatchForm.Controls.Add(this.numBatchSellingPrice);
            this.panelBatchForm.Controls.Add(this.numBatchCostPrice);
            this.panelBatchForm.Controls.Add(this.numBatchQuantity);
            this.panelBatchForm.Controls.Add(this.dtpExpiryDate);
            this.panelBatchForm.Controls.Add(this.dtpManufacturingDate);
            this.panelBatchForm.Controls.Add(this.txtManufacturer);
            this.panelBatchForm.Controls.Add(this.txtBatchNumber);
            this.panelBatchForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBatchForm.Location = new System.Drawing.Point(0, 40);
            this.panelBatchForm.Name = "panelBatchForm";
            this.panelBatchForm.Padding = new System.Windows.Forms.Padding(10);
            this.panelBatchForm.Size = new System.Drawing.Size(696, 220);
            this.panelBatchForm.TabIndex = 3;
            // 
            // lblBatchStatus
            // 
            this.lblBatchStatus.AutoSize = true;
            this.lblBatchStatus.Location = new System.Drawing.Point(360, 180);
            this.lblBatchStatus.Name = "lblBatchStatus";
            this.lblBatchStatus.Size = new System.Drawing.Size(70, 17);
            this.lblBatchStatus.TabIndex = 0;
            this.lblBatchStatus.Text = "Trạng thái:";
            // 
            // lblBatchSupplier
            // 
            this.lblBatchSupplier.AutoSize = true;
            this.lblBatchSupplier.Location = new System.Drawing.Point(15, 180);
            this.lblBatchSupplier.Name = "lblBatchSupplier";
            this.lblBatchSupplier.Size = new System.Drawing.Size(103, 17);
            this.lblBatchSupplier.TabIndex = 0;
            this.lblBatchSupplier.Text = "Nhà cung cấp:";
            // 
            // lblBatchSellingPrice
            // 
            this.lblBatchSellingPrice.AutoSize = true;
            this.lblBatchSellingPrice.Location = new System.Drawing.Point(360, 140);
            this.lblBatchSellingPrice.Name = "lblBatchSellingPrice";
            this.lblBatchSellingPrice.Size = new System.Drawing.Size(60, 17);
            this.lblBatchSellingPrice.TabIndex = 0;
            this.lblBatchSellingPrice.Text = "Giá bán:";
            // 
            // lblBatchCostPrice
            // 
            this.lblBatchCostPrice.AutoSize = true;
            this.lblBatchCostPrice.Location = new System.Drawing.Point(15, 140);
            this.lblBatchCostPrice.Name = "lblBatchCostPrice";
            this.lblBatchCostPrice.Size = new System.Drawing.Size(68, 17);
            this.lblBatchCostPrice.TabIndex = 0;
            this.lblBatchCostPrice.Text = "Giá nhập:";
            // 
            // lblBatchQuantity
            // 
            this.lblBatchQuantity.AutoSize = true;
            this.lblBatchQuantity.Location = new System.Drawing.Point(360, 100);
            this.lblBatchQuantity.Name = "lblBatchQuantity";
            this.lblBatchQuantity.Size = new System.Drawing.Size(70, 17);
            this.lblBatchQuantity.TabIndex = 0;
            this.lblBatchQuantity.Text = "Số lượng:";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(15, 100);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(104, 17);
            this.lblExpiryDate.TabIndex = 0;
            this.lblExpiryDate.Text = "Hạn sử dụng:";
            // 
            // lblManufacturingDate
            // 
            this.lblManufacturingDate.AutoSize = true;
            this.lblManufacturingDate.Location = new System.Drawing.Point(360, 60);
            this.lblManufacturingDate.Name = "lblManufacturingDate";
            this.lblManufacturingDate.Size = new System.Drawing.Size(104, 17);
            this.lblManufacturingDate.TabIndex = 0;
            this.lblManufacturingDate.Text = "Ngày sản xuất:";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(15, 60);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(100, 17);
            this.lblManufacturer.TabIndex = 0;
            this.lblManufacturer.Text = "Nhà sản xuất:";
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(15, 20);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(45, 17);
            this.lblBatchNumber.TabIndex = 0;
            this.lblBatchNumber.Text = "Số lô:";
            // 
            // cboBatchStatus
            // 
            this.cboBatchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchStatus.FormattingEnabled = true;
            this.cboBatchStatus.Location = new System.Drawing.Point(470, 177);
            this.cboBatchStatus.Name = "cboBatchStatus";
            this.cboBatchStatus.Size = new System.Drawing.Size(200, 25);
            this.cboBatchStatus.TabIndex = 8;
            // 
            // cboBatchSupplier
            // 
            this.cboBatchSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchSupplier.FormattingEnabled = true;
            this.cboBatchSupplier.Location = new System.Drawing.Point(125, 177);
            this.cboBatchSupplier.Name = "cboBatchSupplier";
            this.cboBatchSupplier.Size = new System.Drawing.Size(220, 25);
            this.cboBatchSupplier.TabIndex = 7;
            // 
            // numBatchSellingPrice
            // 
            this.numBatchSellingPrice.DecimalPlaces = 0;
            this.numBatchSellingPrice.Location = new System.Drawing.Point(470, 137);
            this.numBatchSellingPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBatchSellingPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchSellingPrice.Name = "numBatchSellingPrice";
            this.numBatchSellingPrice.Size = new System.Drawing.Size(200, 25);
            this.numBatchSellingPrice.TabIndex = 6;
            this.numBatchSellingPrice.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBatchSellingPrice.ThousandsSeparator = true;
            // 
            // numBatchCostPrice
            // 
            this.numBatchCostPrice.DecimalPlaces = 0;
            this.numBatchCostPrice.Location = new System.Drawing.Point(125, 137);
            this.numBatchCostPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBatchCostPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchCostPrice.Name = "numBatchCostPrice";
            this.numBatchCostPrice.Size = new System.Drawing.Size(220, 25);
            this.numBatchCostPrice.TabIndex = 5;
            this.numBatchCostPrice.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numBatchCostPrice.ThousandsSeparator = true;
            // 
            // numBatchQuantity
            // 
            this.numBatchQuantity.Location = new System.Drawing.Point(470, 97);
            this.numBatchQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBatchQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchQuantity.Name = "numBatchQuantity";
            this.numBatchQuantity.Size = new System.Drawing.Size(200, 25);
            this.numBatchQuantity.TabIndex = 4;
            this.numBatchQuantity.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(125, 97);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(220, 25);
            this.dtpExpiryDate.TabIndex = 3;
            // 
            // dtpManufacturingDate
            // 
            this.dtpManufacturingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpManufacturingDate.Location = new System.Drawing.Point(470, 57);
            this.dtpManufacturingDate.Name = "dtpManufacturingDate";
            this.dtpManufacturingDate.Size = new System.Drawing.Size(200, 25);
            this.dtpManufacturingDate.TabIndex = 2;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(125, 57);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(220, 25);
            this.txtManufacturer.TabIndex = 1;
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(125, 17);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(545, 25);
            this.txtBatchNumber.TabIndex = 0;
            // 
            // FormMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FormMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thuốc - Pharmacy Management";
            this.Load += new System.EventHandler(this.FormMedicine_Load);
            this.panelTop.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowStockThreshold)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.panelBatchesTop.ResumeLayout(false);
            this.panelBatchButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).EndInit();
            this.panelBatchForm.ResumeLayout(false);
            this.panelBatchForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchCostPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblLowStockThreshold;
        private System.Windows.Forms.TextBox txtStrength;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkPrescriptionRequired;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ComboBox cboForm;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.NumericUpDown numLowStockThreshold;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.DataGridView dgvBatches;
        private System.Windows.Forms.Panel panelBatchesTop;
        private System.Windows.Forms.Label lblBatchesTitle;
        private System.Windows.Forms.Button btnToggleBatchManagement;
        private System.Windows.Forms.Panel panelBatchButtons;
        private System.Windows.Forms.Button btnRefreshBatches;
        private System.Windows.Forms.Button btnSaveBatch;
        private System.Windows.Forms.Button btnUpdateBatch;
        private System.Windows.Forms.Button btnAddBatch;
        private System.Windows.Forms.Panel panelBatchForm;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.DateTimePicker dtpManufacturingDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.NumericUpDown numBatchQuantity;
        private System.Windows.Forms.NumericUpDown numBatchCostPrice;
        private System.Windows.Forms.NumericUpDown numBatchSellingPrice;
        private System.Windows.Forms.ComboBox cboBatchSupplier;
        private System.Windows.Forms.ComboBox cboBatchStatus;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblManufacturingDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblBatchQuantity;
        private System.Windows.Forms.Label lblBatchCostPrice;
        private System.Windows.Forms.Label lblBatchSellingPrice;
        private System.Windows.Forms.Label lblBatchSupplier;
        private System.Windows.Forms.Label lblBatchStatus;
    }
}

