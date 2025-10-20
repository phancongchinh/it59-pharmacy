using System;
using System.Linq;
using System.Windows.Forms;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormMedicineBatch : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedBatchId;
        private bool _isEditMode;

        public FormMedicineBatch()
        {
            InitializeComponent();
            
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormMedicineBatch_Load(object sender, EventArgs e)
        {
            OptimizeDataGridView(dgvBatches);
            LoadBatches();
            LoadMedicines();
            LoadSuppliers();
            LoadBatchStatuses();
            SetFormMode(false);
        }

        private void OptimizeDataGridView(DataGridView dgv)
        {
            dgv.SuspendLayout();
            dgv.AutoGenerateColumns = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.ResumeLayout();
        }

        private void LoadBatches()
        {
            try
            {
                dgvBatches.SuspendLayout();

                var batches = _unitOfWork.MedicineBatches.GetAll();

                dgvBatches.DataSource = batches.Select(b => new
                {
                    b.Id,
                    SốLô = b.BatchNumber,
                    Thuốc = b.Medicine != null ? b.Medicine.Name : "",
                    NhàSảnXuất = b.Manufacturer,
                    NgàySảnXuất = b.ManufacturingDate.ToString("dd/MM/yyyy"),
                    HạnSửDụng = b.ExpiryDate.ToString("dd/MM/yyyy"),
                    SốLượng = b.Quantity,
                    GiáNhập = b.CostPrice.ToString("N0"),
                    GiáBán = b.SellingPrice.HasValue ? b.SellingPrice.Value.ToString("N0") : "",
                    NhàCungCấp = b.Supplier != null ? b.Supplier.Name : "",
                    TrạngThái = GetBatchStatusText(b.Status),
                    NgàyTạo = b.CreatedDate.ToString("dd/MM/yyyy"),
                    NgườiTạo = b.CreatedBy != null ? b.CreatedBy.Username : ""
                }).ToList();

                if (dgvBatches.Columns["Id"] != null)
                    dgvBatches.Columns["Id"].Visible = false;

                dgvBatches.ResumeLayout();
            }
            catch (Exception ex)
            {
                dgvBatches.ResumeLayout();
                MessageBox.Show($"Lỗi khi tải danh sách lô thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMedicines()
        {
            try
            {
                var medicines = _unitOfWork.Medicines.GetAll()
                    .Where(m => m.isActive)
                    .ToList();

                cboMedicine.DataSource = medicines;
                cboMedicine.DisplayMember = "Name";
                cboMedicine.ValueMember = "Id";
                cboMedicine.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = _unitOfWork.Suppliers.GetAll()
                    .Where(s => s.IsActive)
                    .ToList();

                cboSupplier.DataSource = suppliers;
                cboSupplier.DisplayMember = "Name";
                cboSupplier.ValueMember = "Id";
                cboSupplier.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhà cung cấp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBatchStatuses()
        {
            cboStatus.DataSource = Enum.GetValues(typeof(MedicineBatchStatus));
            cboStatus.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
            ClearForm();
            _isEditMode = false;
            _selectedBatchId = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedBatchId == null)
            {
                MessageBox.Show("Vui lòng chọn lô thuốc để sửa!", "Thông báo",
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
                if (string.IsNullOrWhiteSpace(txtBatchNumber.Text))
                {
                    MessageBox.Show("Số lô không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBatchNumber.Focus();
                    return;
                }

                if (cboMedicine.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn thuốc!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboMedicine.Focus();
                    return;
                }

                if (cboSupplier.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboSupplier.Focus();
                    return;
                }

                if (dtpExpiryDate.Value <= dtpManufacturingDate.Value)
                {
                    MessageBox.Show("Hạn sử dụng phải sau ngày sản xuất!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpExpiryDate.Focus();
                    return;
                }

                if (_isEditMode && _selectedBatchId.HasValue)
                {
                    var batch = _unitOfWork.MedicineBatches.GetById(_selectedBatchId.Value);
                    if (batch != null)
                    {
                        batch.BatchNumber = txtBatchNumber.Text.Trim();
                        batch.MedicineId = (int)cboMedicine.SelectedValue;
                        batch.SupplierId = (int)cboSupplier.SelectedValue;
                        batch.Manufacturer = txtManufacturer.Text.Trim();
                        batch.ManufacturingDate = dtpManufacturingDate.Value;
                        batch.ExpiryDate = dtpExpiryDate.Value;
                        batch.Quantity = (int)numQuantity.Value;
                        batch.CostPrice = numCostPrice.Value;
                        batch.SellingPrice = numSellingPrice.Value > 0 ? numSellingPrice.Value : (decimal?)null;
                        batch.Status = (MedicineBatchStatus)cboStatus.SelectedItem;

                        _unitOfWork.MedicineBatches.Update(batch);
                        _unitOfWork.SaveChanges();

                        MessageBox.Show("Cập nhật lô thuốc thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var newBatch = new MedicineBatch
                    {
                        BatchNumber = txtBatchNumber.Text.Trim(),
                        MedicineId = (int)cboMedicine.SelectedValue,
                        SupplierId = (int)cboSupplier.SelectedValue,
                        Manufacturer = txtManufacturer.Text.Trim(),
                        ManufacturingDate = dtpManufacturingDate.Value,
                        ExpiryDate = dtpExpiryDate.Value,
                        Quantity = (int)numQuantity.Value,
                        CostPrice = numCostPrice.Value,
                        SellingPrice = numSellingPrice.Value > 0 ? numSellingPrice.Value : (decimal?)null,
                        Status = (MedicineBatchStatus)cboStatus.SelectedItem
                    };

                    _unitOfWork.MedicineBatches.Add(newBatch);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm lô thuốc thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadBatches();
                SetFormMode(false);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu lô thuốc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(false);
            _selectedBatchId = null;
            _isEditMode = false;
        }

        private void dgvBatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvBatches.Rows[e.RowIndex];
                    _selectedBatchId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var batch = _unitOfWork.MedicineBatches.GetById(_selectedBatchId.Value);
                    if (batch != null)
                    {
                        txtBatchNumber.Text = batch.BatchNumber;
                        cboMedicine.SelectedValue = batch.MedicineId;
                        cboSupplier.SelectedValue = batch.SupplierId;
                        txtManufacturer.Text = batch.Manufacturer;
                        dtpManufacturingDate.Value = batch.ManufacturingDate;
                        dtpExpiryDate.Value = batch.ExpiryDate;
                        numQuantity.Value = batch.Quantity;
                        numCostPrice.Value = batch.CostPrice;
                        numSellingPrice.Value = batch.SellingPrice ?? 0;
                        cboStatus.SelectedItem = batch.Status;
                    }
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
            txtBatchNumber.Enabled = isEditing;
            cboMedicine.Enabled = isEditing;
            cboSupplier.Enabled = isEditing;
            txtManufacturer.Enabled = isEditing;
            dtpManufacturingDate.Enabled = isEditing;
            dtpExpiryDate.Enabled = isEditing;
            numQuantity.Enabled = isEditing;
            numCostPrice.Enabled = isEditing;
            numSellingPrice.Enabled = isEditing;
            cboStatus.Enabled = isEditing;

            btnSave.Enabled = isEditing;
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
        }

        private void ClearForm()
        {
            txtBatchNumber.Clear();
            cboMedicine.SelectedIndex = -1;
            cboSupplier.SelectedIndex = -1;
            txtManufacturer.Clear();
            dtpManufacturingDate.Value = DateTime.Now;
            dtpExpiryDate.Value = DateTime.Now.AddYears(2);
            numQuantity.Value = 1;
            numCostPrice.Value = 0;
            numSellingPrice.Value = 0;
            cboStatus.SelectedIndex = 0;
            _selectedBatchId = null;
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
    }
}
