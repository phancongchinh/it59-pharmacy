using System;
using System.Linq;
using System.Windows.Forms;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormReceiptNote : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedReceiptNoteId = null;
        private int? _selectedItemId = null;
        private bool _isEditMode = false;

        public FormReceiptNote()
        {
            InitializeComponent();
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormReceiptNote_Load(object sender, EventArgs e)
        {
            LoadReceiptNotes();
            LoadSuppliers();
            
            // Populate Status ComboBox with ReceiptNoteStatus enum values
            cboStatus.DataSource = Enum.GetValues(typeof(ReceiptNoteStatus));
            cboStatus.SelectedIndex = 0;
            
            SetFormMode(false);
        }

        private void LoadReceiptNotes()
        {
            try
            {
                var receiptNotes = _unitOfWork.ReceiptNotes.GetAll()
                    .OrderByDescending(r => r.CreatedDate)
                    .ToList();
                
                dgvReceiptNotes.DataSource = receiptNotes.Select(r => new
                {
                    r.Id,
                    SốPhiếu = r.ReceiptNoteNumber,
                    NhàCungCấp = r.Supplier != null ? r.Supplier.Name : "",
                    TổngSốMục = r.ReceiptNoteItems != null ? r.ReceiptNoteItems.Count : 0,
                    TrangThái = GetStatusText(r.Status),
                    GhiChú = r.Notes,
                    NgàyTạo = r.CreatedDate.ToString("dd/MM/yyyy HH:mm"),
                    NgườiTạo = r.CreatedBy != null ? r.CreatedBy.FullName : ""
                }).ToList();

                if (dgvReceiptNotes.Columns["Id"] != null)
                    dgvReceiptNotes.Columns["Id"].Visible = false;
                    
                dgvReceiptNoteItems.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phiếu nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReceiptNoteItems(int receiptNoteId)
        {
            try
            {
                var items = _unitOfWork.ReceiptNoteItems.GetAll()
                    .Where(i => i.ReceiptNoteId == receiptNoteId)
                    .ToList();
                
                dgvReceiptNoteItems.DataSource = items.Select(i => new
                {
                    i.Id,
                    TênThuốc = i.MedicineBatch != null && i.MedicineBatch.Medicine != null 
                        ? i.MedicineBatch.Medicine.Name : "",
                    SốLô = i.MedicineBatch != null ? i.MedicineBatch.BatchNumber : "",
                    HạnSửDụng = i.MedicineBatch != null 
                        ? i.MedicineBatch.ExpiryDate.ToString("dd/MM/yyyy") : "",
                    SốLượng = i.Quantity,
                    ĐơnGiá = i.UnitCost.ToString("N0") + " ₫",
                    ThànhTiền = (i.Quantity * i.UnitCost).ToString("N0") + " ₫",
                    NhàSảnXuất = i.MedicineBatch != null ? i.MedicineBatch.Manufacturer : ""
                }).ToList();

                if (dgvReceiptNoteItems.Columns["Id"] != null)
                    dgvReceiptNoteItems.Columns["Id"].Visible = false;
                    
                // Calculate and display total
                var total = items.Sum(i => i.Quantity * i.UnitCost);
                lblTotal.Text = $"Tổng tiền: {total:N0} ₫";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách mặt hàng: {ex.Message}", "Lỗi", 
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
                MessageBox.Show($"Lỗi khi tải nhà cung cấp: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
            ClearForm();
            _isEditMode = false;
            _selectedReceiptNoteId = null;
            
            // Generate receipt note number
            txtReceiptNoteNumber.Text = GenerateReceiptNoteNumber();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedReceiptNoteId == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var receiptNote = _unitOfWork.ReceiptNotes.GetById(_selectedReceiptNoteId.Value);
            if (receiptNote != null && receiptNote.Status == ReceiptNoteStatus.Cancelled)
            {
                MessageBox.Show("Không thể sửa phiếu nhập đã hủy!", "Thông báo", 
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
                if (string.IsNullOrWhiteSpace(txtReceiptNoteNumber.Text))
                {
                    MessageBox.Show("Số phiếu không được để trống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtReceiptNoteNumber.Focus();
                    return;
                }

                if (cboSupplier.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboSupplier.Focus();
                    return;
                }

                if (_isEditMode && _selectedReceiptNoteId.HasValue)
                {
                    var receiptNote = _unitOfWork.ReceiptNotes.GetById(_selectedReceiptNoteId.Value);
                    if (receiptNote != null)
                    {
                        receiptNote.ReceiptNoteNumber = txtReceiptNoteNumber.Text.Trim();
                        receiptNote.SupplierId = (int)cboSupplier.SelectedValue;
                        receiptNote.Notes = txtNotes.Text.Trim();
                        receiptNote.Status = (ReceiptNoteStatus)cboStatus.SelectedItem;

                        _unitOfWork.ReceiptNotes.Update(receiptNote);
                        _unitOfWork.SaveChanges();

                        MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var newReceiptNote = new ReceiptNote
                    {
                        ReceiptNoteNumber = txtReceiptNoteNumber.Text.Trim(),
                        SupplierId = (int)cboSupplier.SelectedValue,
                        Notes = txtNotes.Text.Trim(),
                        Status = ReceiptNoteStatus.Completed
                    };

                    _unitOfWork.ReceiptNotes.Add(newReceiptNote);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadReceiptNotes();
                SetFormMode(false);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedReceiptNoteId == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phiếu nhập này?\nLưu ý: Thao tác này sẽ xóa tất cả mặt hàng trong phiếu!", 
                "Xác nhận xóa", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete all items first
                    var items = _unitOfWork.ReceiptNoteItems.GetAll()
                        .Where(i => i.ReceiptNoteId == _selectedReceiptNoteId.Value)
                        .ToList();
                    
                    foreach (var item in items)
                    {
                        _unitOfWork.ReceiptNoteItems.Delete(item.Id);
                    }

                    // Then delete the receipt note
                    _unitOfWork.ReceiptNotes.Delete(_selectedReceiptNoteId.Value);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Xóa phiếu nhập thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadReceiptNotes();
                    ClearForm();
                    _selectedReceiptNoteId = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phiếu nhập: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(false);
            _selectedReceiptNoteId = null;
            _isEditMode = false;
        }

        private void dgvReceiptNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvReceiptNotes.Rows[e.RowIndex];
                    _selectedReceiptNoteId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var receiptNote = _unitOfWork.ReceiptNotes.GetById(_selectedReceiptNoteId.Value);
                    if (receiptNote != null)
                    {
                        txtReceiptNoteNumber.Text = receiptNote.ReceiptNoteNumber;
                        cboSupplier.SelectedValue = receiptNote.SupplierId;
                        txtNotes.Text = receiptNote.Notes;
                        cboStatus.SelectedItem = receiptNote.Status;
                        
                        // Load items for the selected receipt note
                        LoadReceiptNoteItems(_selectedReceiptNoteId.Value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn phiếu nhập: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvReceiptNoteItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvReceiptNoteItems.Rows[e.RowIndex];
                    _selectedItemId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn mặt hàng: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetFormMode(bool isEditing)
        {
            txtReceiptNoteNumber.Enabled = isEditing && !_isEditMode; // Only enable for new
            cboSupplier.Enabled = isEditing;
            txtNotes.Enabled = isEditing;
            cboStatus.Enabled = isEditing && _isEditMode; // Only enable status when editing

            btnSave.Enabled = isEditing;
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
            btnDelete.Enabled = !isEditing;
        }

        private void ClearForm()
        {
            txtReceiptNoteNumber.Clear();
            cboSupplier.SelectedIndex = -1;
            txtNotes.Clear();
            cboStatus.SelectedIndex = 0;
            _selectedReceiptNoteId = null;
            _selectedItemId = null;
            dgvReceiptNoteItems.DataSource = null;
            lblTotal.Text = "Tổng tiền: 0 ₫";
        }

        private string GenerateReceiptNoteNumber()
        {
            var date = DateTime.Now;
            var prefix = $"PN{date:yyyyMMdd}";
            
            var existingNotes = _unitOfWork.ReceiptNotes.GetAll()
                .Where(r => r.ReceiptNoteNumber.StartsWith(prefix))
                .ToList();
            
            var sequence = existingNotes.Count + 1;
            return $"{prefix}{sequence:D4}";
        }

        private string GetStatusText(ReceiptNoteStatus status)
        {
            switch (status)
            {
                case ReceiptNoteStatus.Completed: return "Hoàn thành";
                case ReceiptNoteStatus.Cancelled: return "Đã hủy";
                default: return "Không xác định";
            }
        }
    }
}
