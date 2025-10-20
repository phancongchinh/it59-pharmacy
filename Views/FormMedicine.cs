using System;
using System.Linq;
using System.Windows.Forms;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormMedicine : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedMedicineId = null;
        private int? _selectedBatchId = null;
        private bool _isEditMode = false;
        private bool _isBatchEditMode = false;
        private bool _isBatchManagementVisible = true;

        public FormMedicine()
        {
            InitializeComponent();

            // Enable double buffering for both DataGridViews
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, dgvMedicines, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, dgvBatches, new object[] { true });

            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormMedicine_Load(object sender, EventArgs e)
        {
            // Optimize both DataGridViews
            OptimizeDataGridView(dgvMedicines);
            OptimizeDataGridView(dgvBatches);

            LoadMedicines();
            LoadCategories();
            LoadSuppliersForBatch();

            // Populate Form ComboBox with MedicineForm enum values
            cboForm.DataSource = Enum.GetValues(typeof(MedicineForm));
            cboForm.SelectedIndex = -1;

            // Populate Unit ComboBox with MedicineUnit enum values
            cboUnit.DataSource = Enum.GetValues(typeof(MedicineUnit));
            cboUnit.SelectedIndex = -1;

            // Populate Batch Status ComboBox
            cboBatchStatus.DataSource = Enum.GetValues(typeof(MedicineBatchStatus));
            cboBatchStatus.SelectedIndex = 0;

            SetFormMode(false);
            SetBatchFormMode(false);
            // Always show batch form by default - removed HideBatchForm()
        }

        private void OptimizeDataGridView(DataGridView dgv)
        {
            // Suspend layout during configuration
            dgv.SuspendLayout();

            // Performance optimizations
            dgv.AutoGenerateColumns = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Resume layout
            dgv.ResumeLayout();
        }

        private void LoadMedicines()
        {
            try
            {
                // Suspend layout to prevent flickering
                dgvMedicines.SuspendLayout();

                var medicines = _unitOfWork.Medicines.GetAll();

                dgvMedicines.DataSource = medicines.Select(m => new
                {
                    m.Id,
                    TênThuốc = m.Name,
                    NồngĐộ = m.Strength,
                    DạngBàoChế = GetMedicineFormText(m.MedicineForm),
                    ĐơnVị = GetMedicineUnitText(m.Unit),
                    CầnĐơn = m.IsPrescriptionRequired ? "Có" : "Không",
                    NgưỡngTồnKho = m.LowStockThreshold,
                    MôTả = m.Description,
                    TrangThái = m.isActive ? "Hoạt động" : "Không hoạt động",
                    NgàyTạo = m.CreatedDate.ToString("dd/MM/yyyy"),
                    NgườiTạo = m.CreatedBy != null ? m.CreatedBy.Username : ""
                }).ToList();

                if (dgvMedicines.Columns["Id"] != null)
                    dgvMedicines.Columns["Id"].Visible = false;

                // Clear batches when medicines reload
                dgvBatches.DataSource = null;

                // Resume layout
                dgvMedicines.ResumeLayout();
            }
            catch (Exception ex)
            {
                dgvMedicines.ResumeLayout();
                MessageBox.Show($"Lỗi khi tải danh sách thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBatchesForMedicine(int medicineId)
        {
            try
            {
                // Suspend layout to prevent flickering
                dgvBatches.SuspendLayout();

                var batches = _unitOfWork.MedicineBatches.GetAll()
                    .Where(b => b.MedicineId == medicineId)
                    .OrderByDescending(b => b.CreatedDate)
                    .ToList();

                dgvBatches.DataSource = batches.Select(b => new
                {
                    b.Id,
                    SốLô = b.BatchNumber,
                    NhàSảnXuất = b.Manufacturer,
                    NgàySảnXuất = b.ManufacturingDate.ToString("dd/MM/yyyy"),
                    HạnSửDụng = b.ExpiryDate.ToString("dd/MM/yyyy"),
                    SốLượng = b.Quantity,
                    GiáNhập = b.CostPrice.ToString("N0") + " ₫",
                    GiáBán = b.SellingPrice.HasValue ? b.SellingPrice.Value.ToString("N0") + " ₫" : "",
                    TrangThái = GetBatchStatusText(b.Status),
                    NhàCungCấp = b.Supplier != null ? b.Supplier.Name : "",
                    NgàyTạo = b.CreatedDate.ToString("dd/MM/yyyy")
                }).ToList();

                if (dgvBatches.Columns["Id"] != null)
                    dgvBatches.Columns["Id"].Visible = false;

                // Resume layout
                dgvBatches.ResumeLayout();
            }
            catch (Exception ex)
            {
                dgvBatches.ResumeLayout();
                MessageBox.Show($"Lỗi khi tải danh sách lô thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _unitOfWork.MedicineCategories.GetAll()
                    .Where(c => c.IsActive)
                    .ToList();

                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Id";
                cboCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSuppliersForBatch()
        {
            try
            {
                var suppliers = _unitOfWork.Suppliers.GetAll()
                    .Where(s => s.IsActive)
                    .OrderBy(s => s.Name)
                    .ToList();

                cboBatchSupplier.DataSource = suppliers;
                cboBatchSupplier.DisplayMember = "Name";
                cboBatchSupplier.ValueMember = "Id";
                cboBatchSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhà cung cấp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
            ClearForm();
            _isEditMode = false;
            _selectedMedicineId = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedMedicineId == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetFormMode(true);
            _isEditMode = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Tên thuốc không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                if (cboForm.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn dạng bào chế!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboForm.Focus();
                    return;
                }

                if (cboUnit.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đơn vị!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboUnit.Focus();
                    return;
                }

                if (_isEditMode && _selectedMedicineId.HasValue)
                {
                    var medicine = _unitOfWork.Medicines.GetById(_selectedMedicineId.Value);
                    if (medicine != null)
                    {
                        medicine.Name = txtName.Text.Trim();
                        medicine.Strength = txtStrength.Text.Trim();
                        medicine.Description = txtDescription.Text.Trim();
                        medicine.MedicineForm = (MedicineForm)cboForm.SelectedItem;
                        medicine.Unit = (MedicineUnit)cboUnit.SelectedItem;
                        medicine.IsPrescriptionRequired = chkPrescriptionRequired.Checked;
                        medicine.LowStockThreshold = (int)numLowStockThreshold.Value;
                        medicine.isActive = chkIsActive.Checked;

                        _unitOfWork.Medicines.Update(medicine);
                        _unitOfWork.SaveChanges();

                        MessageBox.Show("Cập nhật thuốc thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var newMedicine = new Medicine
                    {
                        Name = txtName.Text.Trim(),
                        Strength = txtStrength.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        MedicineForm = (MedicineForm)cboForm.SelectedItem,
                        Unit = (MedicineUnit)cboUnit.SelectedItem,
                        IsPrescriptionRequired = chkPrescriptionRequired.Checked,
                        LowStockThreshold = (int)numLowStockThreshold.Value,
                        isActive = chkIsActive.Checked
                    };

                    _unitOfWork.Medicines.Add(newMedicine);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm thuốc thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadMedicines();
                SetFormMode(false);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(false);
            _selectedMedicineId = null;
            _isEditMode = false;
        }

        private void dgvMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvMedicines.Rows[e.RowIndex];
                    _selectedMedicineId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var medicine = _unitOfWork.Medicines.GetById(_selectedMedicineId.Value);
                    if (medicine != null)
                    {
                        txtName.Text = medicine.Name;
                        txtStrength.Text = medicine.Strength;
                        txtDescription.Text = medicine.Description;
                        cboForm.SelectedItem = medicine.MedicineForm;
                        cboUnit.SelectedItem = medicine.Unit;
                        chkPrescriptionRequired.Checked = medicine.IsPrescriptionRequired;
                        numLowStockThreshold.Value = medicine.LowStockThreshold;
                        chkIsActive.Checked = medicine.isActive;

                        // Load batches for the selected medicine
                        LoadBatchesForMedicine(_selectedMedicineId.Value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn thuốc: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvBatches.Rows[e.RowIndex];
                    _selectedBatchId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn lô thuốc: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetFormMode(bool isEditing)
        {
            txtName.Enabled = isEditing;
            txtStrength.Enabled = isEditing;
            txtDescription.Enabled = isEditing;
            cboForm.Enabled = isEditing;
            cboUnit.Enabled = isEditing;
            chkPrescriptionRequired.Enabled = isEditing;
            numLowStockThreshold.Enabled = isEditing;
            chkIsActive.Enabled = isEditing;

            btnSave.Enabled = isEditing;
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
        }

        private void SetBatchFormMode(bool isEditing)
        {
            // Enable or disable batch form controls
            txtBatchNumber.Enabled = isEditing;
            txtManufacturer.Enabled = isEditing;
            dtpManufacturingDate.Enabled = isEditing;
            dtpExpiryDate.Enabled = isEditing;
            numBatchQuantity.Enabled = isEditing;
            numBatchCostPrice.Enabled = isEditing;
            numBatchSellingPrice.Enabled = isEditing;
            cboBatchSupplier.Enabled = isEditing;
            cboBatchStatus.Enabled = isEditing;

            btnSaveBatch.Enabled = isEditing;
            btnAddBatch.Enabled = !isEditing;
            btnUpdateBatch.Enabled = !isEditing;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtStrength.Clear();
            txtDescription.Clear();
            cboForm.SelectedIndex = -1;
            cboUnit.SelectedIndex = -1;
            cboCategory.SelectedIndex = -1;
            chkPrescriptionRequired.Checked = false;
            numLowStockThreshold.Value = 10;
            chkIsActive.Checked = true;
            _selectedMedicineId = null;
            _selectedBatchId = null;
            dgvBatches.DataSource = null;
        }

        private void HideBatchForm()
        {
            panelBatchForm.Visible = false;
            panelBatchForm.Height = 0;
        }

        private void ShowBatchForm()
        {
            panelBatchForm.Visible = true;
            panelBatchForm.Height = 250;
        }

        private void ClearBatchForm()
        {
            txtBatchNumber.Clear();
            txtManufacturer.Clear();
            dtpManufacturingDate.Value = DateTime.Now.AddMonths(-6);
            dtpExpiryDate.Value = DateTime.Now.AddYears(2);
            numBatchQuantity.Value = 1;
            numBatchCostPrice.Value = 1;
            numBatchSellingPrice.Value = 1;
            cboBatchSupplier.SelectedIndex = -1;
            cboBatchStatus.SelectedItem = MedicineBatchStatus.Active;
            _selectedBatchId = null;
        }

        private void LoadBatchData(int batchId)
        {
            try
            {
                var batch = _unitOfWork.MedicineBatches.GetById(batchId);
                if (batch != null)
                {
                    txtBatchNumber.Text = batch.BatchNumber;
                    txtManufacturer.Text = batch.Manufacturer;
                    dtpManufacturingDate.Value = batch.ManufacturingDate;
                    dtpExpiryDate.Value = batch.ExpiryDate;
                    numBatchQuantity.Value = batch.Quantity;
                    numBatchCostPrice.Value = batch.CostPrice;
                    numBatchSellingPrice.Value = batch.SellingPrice ?? 0;
                    cboBatchSupplier.SelectedValue = batch.SupplierId;
                    cboBatchStatus.SelectedItem = batch.Status;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin lô thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBatchInput()
        {
            if (string.IsNullOrWhiteSpace(txtBatchNumber.Text))
            {
                MessageBox.Show("Số lô không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBatchNumber.Focus();
                return false;
            }

            if (cboBatchSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBatchSupplier.Focus();
                return false;
            }

            if (dtpExpiryDate.Value <= dtpManufacturingDate.Value)
            {
                MessageBox.Show("Hạn sử dụng phải sau ngày sản xuất!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpExpiryDate.Focus();
                return false;
            }

            if (numBatchQuantity.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numBatchQuantity.Focus();
                return false;
            }

            if (numBatchCostPrice.Value <= 0)
            {
                MessageBox.Show("Giá nhập phải lớn hơn 0!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numBatchCostPrice.Focus();
                return false;
            }

            return true;
        }

        private void btnAddBatch_Click(object sender, EventArgs e)
        {
            if (_selectedMedicineId == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc trước khi thêm lô!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowBatchForm();
            ClearBatchForm();
            SetBatchFormMode(true);
            _isBatchEditMode = false;
            _selectedBatchId = null;
        }

        private void btnUpdateBatch_Click(object sender, EventArgs e)
        {
            if (_selectedBatchId == null)
            {
                MessageBox.Show("Vui lòng chọn lô thuốc để cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedMedicineId == null)
            {
                MessageBox.Show("Vui lòng chọn thuốc trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowBatchForm();
            LoadBatchData(_selectedBatchId.Value);
            SetBatchFormMode(true);
            _isBatchEditMode = true;
        }

        private void btnSaveBatch_Click(object sender, EventArgs e)
        {
            if (!ValidateBatchInput())
                return;

            try
            {
                if (_isBatchEditMode && _selectedBatchId.HasValue)
                {
                    var batch = _unitOfWork.MedicineBatches.GetById(_selectedBatchId.Value);
                    if (batch != null)
                    {
                        batch.BatchNumber = txtBatchNumber.Text.Trim();
                        batch.Manufacturer = txtManufacturer.Text.Trim();
                        batch.ManufacturingDate = dtpManufacturingDate.Value;
                        batch.ExpiryDate = dtpExpiryDate.Value;
                        batch.Quantity = (int)numBatchQuantity.Value;
                        batch.CostPrice = numBatchCostPrice.Value;
                        batch.SellingPrice =
                            numBatchSellingPrice.Value > 0 ? numBatchSellingPrice.Value : (decimal?)null;
                        batch.SupplierId = (int)cboBatchSupplier.SelectedValue;
                        batch.Status = (MedicineBatchStatus)cboBatchStatus.SelectedItem;

                        _unitOfWork.MedicineBatches.Update(batch);
                        _unitOfWork.SaveChanges();

                        MessageBox.Show("Cập nhật lô thuốc thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadBatchesForMedicine(_selectedMedicineId.Value);
                        HideBatchForm();
                        SetBatchFormMode(false);
                        _selectedBatchId = null;
                    }
                }
                else
                {
                    var newBatch = new MedicineBatch
                    {
                        MedicineId = _selectedMedicineId.Value,
                        BatchNumber = txtBatchNumber.Text.Trim(),
                        Manufacturer = txtManufacturer.Text.Trim(),
                        ManufacturingDate = dtpManufacturingDate.Value,
                        ExpiryDate = dtpExpiryDate.Value,
                        Quantity = (int)numBatchQuantity.Value,
                        CostPrice = numBatchCostPrice.Value,
                        SellingPrice = numBatchSellingPrice.Value > 0 ? numBatchSellingPrice.Value : (decimal?)null,
                        SupplierId = (int)cboBatchSupplier.SelectedValue,
                        Status = (MedicineBatchStatus)cboBatchStatus.SelectedItem
                    };

                    _unitOfWork.MedicineBatches.Add(newBatch);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm lô thuốc thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBatchesForMedicine(_selectedMedicineId.Value);
                    HideBatchForm();
                    SetBatchFormMode(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu lô thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshBatches_Click(object sender, EventArgs e)
        {
            if (_selectedMedicineId.HasValue)
            {
                LoadBatchesForMedicine(_selectedMedicineId.Value);
                HideBatchForm();
                SetBatchFormMode(false);
                MessageBox.Show("Đã làm mới danh sách lô thuốc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvBatches.DataSource = null;
                MessageBox.Show("Vui lòng chọn thuốc để xem danh sách lô!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetMedicineFormText(MedicineForm form)
        {
            switch (form)
            {
                case MedicineForm.Tablet: return "Viên nén";
                case MedicineForm.Capsule: return "Viên nang";
                case MedicineForm.Syrup: return "Siro";
                case MedicineForm.Injection: return "Tiêm";
                case MedicineForm.Ointment: return "Thuốc mỡ";
                case MedicineForm.Drops: return "Thuốc nhỏ";
                case MedicineForm.Inhaler: return "Thuốc xịt";
                case MedicineForm.Patch: return "Miếng dán";
                case MedicineForm.Powder: return "Bột";
                default: return "Khác";
            }
        }

        private string GetMedicineUnitText(MedicineUnit unit)
        {
            switch (unit)
            {
                case MedicineUnit.Tablet: return "Viên";
                case MedicineUnit.Bottle: return "Chai";
                case MedicineUnit.Box: return "Hộp";
                case MedicineUnit.Strip: return "Vỉ";
                case MedicineUnit.Vial: return "Lọ";
                case MedicineUnit.Ampoule: return "Ống";
                case MedicineUnit.Tube: return "Tuýp";
                case MedicineUnit.Sachet: return "Gói";
                case MedicineUnit.Pack: return "Túi";
                default: return "Khác";
            }
        }

        private string GetBatchStatusText(MedicineBatchStatus status)
        {
            switch (status)
            {
                case MedicineBatchStatus.Active: return "Hoạt động";
                case MedicineBatchStatus.Inactive: return "Không hoạt động";
                case MedicineBatchStatus.Expired: return "Hết hạn";
                default: return "Không xác định";
            }
        }

        private void btnToggleBatchManagement_Click(object sender, EventArgs e)
        {
            _isBatchManagementVisible = !_isBatchManagementVisible;

            if (_isBatchManagementVisible)
            {
                // Show batch management
                panelBatchForm.Visible = true;
                panelBatchButtons.Visible = true;
                btnToggleBatchManagement.Text = "Ẩn ▲";
            }
            else
            {
                // Hide batch management
                panelBatchForm.Visible = false;
                panelBatchButtons.Visible = false;
                btnToggleBatchManagement.Text = "Hiện ▼";
            }

        }
    }
}
