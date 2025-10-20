namespace IT59_Pharmacy.Views
{
    partial class FormReceiptNote
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtReceiptNoteNumber = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblReceiptNoteNumber = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelItems = new System.Windows.Forms.Panel();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.numUnitCost = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cboMedicineBatch = new System.Windows.Forms.ComboBox();
            this.lblUnitCost = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblMedicineBatch = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvReceiptNotes = new System.Windows.Forms.DataGridView();
            this.panelItemsTop = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblItemsTitle = new System.Windows.Forms.Label();
            this.dgvReceiptNoteItems = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNotes)).BeginInit();
            this.panelItemsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNoteItems)).BeginInit();
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
            this.lblTitle.Text = "QUẢN LÝ PHIẾU NHẬP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.cboStatus);
            this.panelForm.Controls.Add(this.cboSupplier);
            this.panelForm.Controls.Add(this.txtNotes);
            this.panelForm.Controls.Add(this.txtReceiptNoteNumber);
            this.panelForm.Controls.Add(this.lblStatus);
            this.panelForm.Controls.Add(this.lblNotes);
            this.panelForm.Controls.Add(this.lblSupplier);
            this.panelForm.Controls.Add(this.lblReceiptNoteNumber);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 60);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(20);
            this.panelForm.Size = new System.Drawing.Size(1400, 150);
            this.panelForm.TabIndex = 1;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(920, 30);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(250, 25);
            this.cboStatus.TabIndex = 4;
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(570, 30);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(250, 25);
            this.cboSupplier.TabIndex = 2;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(220, 80);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(950, 50);
            this.txtNotes.TabIndex = 3;
            // 
            // txtReceiptNoteNumber
            // 
            this.txtReceiptNoteNumber.Location = new System.Drawing.Point(220, 30);
            this.txtReceiptNoteNumber.Name = "txtReceiptNoteNumber";
            this.txtReceiptNoteNumber.Size = new System.Drawing.Size(250, 25);
            this.txtReceiptNoteNumber.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(830, 33);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 17);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(150, 83);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(57, 17);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(480, 33);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(95, 17);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Nhà cung cấp:";
            // 
            // lblReceiptNoteNumber
            // 
            this.lblReceiptNoteNumber.AutoSize = true;
            this.lblReceiptNoteNumber.Location = new System.Drawing.Point(150, 33);
            this.lblReceiptNoteNumber.Name = "lblReceiptNoteNumber";
            this.lblReceiptNoteNumber.Size = new System.Drawing.Size(62, 17);
            this.lblReceiptNoteNumber.TabIndex = 0;
            this.lblReceiptNoteNumber.Text = "Số phiếu:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 210);
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
            this.btnClear.Location = new System.Drawing.Point(460, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(350, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy phiếu";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // panelItems
            // 
            this.panelItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelItems.Controls.Add(this.btnRemoveItem);
            this.panelItems.Controls.Add(this.btnAddItem);
            this.panelItems.Controls.Add(this.numUnitCost);
            this.panelItems.Controls.Add(this.numQuantity);
            this.panelItems.Controls.Add(this.cboMedicineBatch);
            this.panelItems.Controls.Add(this.lblUnitCost);
            this.panelItems.Controls.Add(this.lblQuantity);
            this.panelItems.Controls.Add(this.lblMedicineBatch);
            this.panelItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItems.Location = new System.Drawing.Point(0, 270);
            this.panelItems.Name = "panelItems";
            this.panelItems.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelItems.Size = new System.Drawing.Size(1400, 70);
            this.panelItems.TabIndex = 3;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.Crimson;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(1160, 15);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(100, 40);
            this.btnRemoveItem.TabIndex = 7;
            this.btnRemoveItem.Text = "Xóa mục";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(1050, 15);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 40);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "Thêm mục";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // numUnitCost
            // 
            this.numUnitCost.DecimalPlaces = 2;
            this.numUnitCost.Location = new System.Drawing.Point(850, 25);
            this.numUnitCost.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numUnitCost.Name = "numUnitCost";
            this.numUnitCost.Size = new System.Drawing.Size(150, 25);
            this.numUnitCost.TabIndex = 5;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(620, 25);
            this.numQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 25);
            this.numQuantity.TabIndex = 4;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboMedicineBatch
            // 
            this.cboMedicineBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicineBatch.FormattingEnabled = true;
            this.cboMedicineBatch.Location = new System.Drawing.Point(150, 25);
            this.cboMedicineBatch.Name = "cboMedicineBatch";
            this.cboMedicineBatch.Size = new System.Drawing.Size(350, 25);
            this.cboMedicineBatch.TabIndex = 3;
            // 
            // lblUnitCost
            // 
            this.lblUnitCost.AutoSize = true;
            this.lblUnitCost.Location = new System.Drawing.Point(770, 28);
            this.lblUnitCost.Name = "lblUnitCost";
            this.lblUnitCost.Size = new System.Drawing.Size(57, 17);
            this.lblUnitCost.TabIndex = 0;
            this.lblUnitCost.Text = "Đơn giá:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(540, 28);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(68, 17);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // lblMedicineBatch
            // 
            this.lblMedicineBatch.AutoSize = true;
            this.lblMedicineBatch.Location = new System.Drawing.Point(30, 28);
            this.lblMedicineBatch.Name = "lblMedicineBatch";
            this.lblMedicineBatch.Size = new System.Drawing.Size(63, 17);
            this.lblMedicineBatch.TabIndex = 0;
            this.lblMedicineBatch.Text = "Lô thuốc:";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 340);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvReceiptNotes);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvReceiptNoteItems);
            this.splitContainer.Panel2.Controls.Add(this.panelItemsTop);
            this.splitContainer.Size = new System.Drawing.Size(1400, 530);
            this.splitContainer.SplitterDistance = 700;
            this.splitContainer.TabIndex = 3;
            // 
            // dgvReceiptNotes
            // 
            this.dgvReceiptNotes.AllowUserToAddRows = false;
            this.dgvReceiptNotes.AllowUserToDeleteRows = false;
            this.dgvReceiptNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceiptNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptNotes.Location = new System.Drawing.Point(0, 0);
            this.dgvReceiptNotes.Name = "dgvReceiptNotes";
            this.dgvReceiptNotes.ReadOnly = true;
            this.dgvReceiptNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptNotes.Size = new System.Drawing.Size(700, 530);
            this.dgvReceiptNotes.TabIndex = 0;
            this.dgvReceiptNotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptNotes_CellClick);
            // 
            // panelItemsTop
            // 
            this.panelItemsTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.panelItemsTop.Controls.Add(this.lblTotal);
            this.panelItemsTop.Controls.Add(this.lblItemsTitle);
            this.panelItemsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemsTop.Location = new System.Drawing.Point(0, 0);
            this.panelItemsTop.Name = "panelItemsTop";
            this.panelItemsTop.Size = new System.Drawing.Size(696, 50);
            this.panelItemsTop.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Yellow;
            this.lblTotal.Location = new System.Drawing.Point(496, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 50);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Tổng tiền: 0 ₫";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemsTitle
            // 
            this.lblItemsTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblItemsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblItemsTitle.ForeColor = System.Drawing.Color.White;
            this.lblItemsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblItemsTitle.Name = "lblItemsTitle";
            this.lblItemsTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblItemsTitle.Size = new System.Drawing.Size(300, 50);
            this.lblItemsTitle.TabIndex = 0;
            this.lblItemsTitle.Text = "CHI TIẾT PHIẾU NHẬP";
            this.lblItemsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvReceiptNoteItems
            // 
            this.dgvReceiptNoteItems.AllowUserToAddRows = false;
            this.dgvReceiptNoteItems.AllowUserToDeleteRows = false;
            this.dgvReceiptNoteItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceiptNoteItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptNoteItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptNoteItems.Location = new System.Drawing.Point(0, 50);
            this.dgvReceiptNoteItems.Name = "dgvReceiptNoteItems";
            this.dgvReceiptNoteItems.ReadOnly = true;
            this.dgvReceiptNoteItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceiptNoteItems.Size = new System.Drawing.Size(696, 480);
            this.dgvReceiptNoteItems.TabIndex = 0;
            this.dgvReceiptNoteItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptNoteItems_CellClick);
            // 
            // FormReceiptNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FormReceiptNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phiếu nhập - Pharmacy Management";
            this.Load += new System.EventHandler(this.FormReceiptNote_Load);
            this.panelTop.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelItems.ResumeLayout(false);
            this.panelItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNotes)).EndInit();
            this.panelItemsTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptNoteItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TextBox txtReceiptNoteNumber;
        private System.Windows.Forms.Label lblReceiptNoteNumber;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.Label lblMedicineBatch;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblUnitCost;
        private System.Windows.Forms.ComboBox cboMedicineBatch;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numUnitCost;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvReceiptNotes;
        private System.Windows.Forms.DataGridView dgvReceiptNoteItems;
        private System.Windows.Forms.Panel panelItemsTop;
        private System.Windows.Forms.Label lblItemsTitle;
        private System.Windows.Forms.Label lblTotal;
    }
}

