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

        public FormMedicine()
        {
            InitializeComponent();
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormMedicine_Load(object sender, EventArgs e)
        {
            LoadMedicines();
            LoadCategories();
            
            // Populate Form ComboBox with MedicineForm enum values
            cboForm.DataSource = Enum.GetValues(typeof(MedicineForm));
            cboForm.SelectedIndex = -1;
            
            // Populate Unit ComboBox with MedicineUnit enum values
            cboUnit.DataSource = Enum.GetValues(typeof(MedicineUnit));
            cboUnit.SelectedIndex = -1;
            
            SetFormMode(false);
        }

        private void LoadMedicines()
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thuốc: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBatchesForMedicine(int medicineId)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
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
    }
}
