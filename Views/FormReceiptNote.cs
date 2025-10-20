using System;
using System.Collections.Generic;
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
        private List<ReceiptNoteItemViewModel> _tempItems = new List<ReceiptNoteItemViewModel>();

        public FormReceiptNote()
        {
            InitializeComponent();
            
            // Enable double buffering for both DataGridViews
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic,
                null, dgvReceiptNotes, new object[] { true });
            
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic,
                null, dgvReceiptNoteItems, new object[] { true });
            
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormReceiptNote_Load(object sender, EventArgs e)
        {
            // Optimize both DataGridViews
            OptimizeDataGridView(dgvReceiptNotes);
            OptimizeDataGridView(dgvReceiptNoteItems);
            
            LoadReceiptNotes();
            LoadSuppliers();
            LoadMedicineBatches();
            
            // Populate Status ComboBox with ReceiptNoteStatus enum values
            cboStatus.DataSource = Enum.GetValues(typeof(ReceiptNoteStatus));
            cboStatus.SelectedIndex = 0;
            
            SetFormMode(false);
            SetItemButtonsMode(false);
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

        private void LoadReceiptNotes()
        {
            try
            {
                // Suspend layout to prevent flickering
                dgvReceiptNotes.SuspendLayout();
                
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
                
                // Resume layout
                dgvReceiptNotes.ResumeLayout();
            }
            catch (Exception ex)
            {
                dgvReceiptNotes.ResumeLayout();
                MessageBox.Show($"Lỗi khi tải danh sách phiếu nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMedicineBatches()
        {
            try
            {
                var batches = _unitOfWork.MedicineBatches.GetAll()
                    .Where(b => b.Status == MedicineBatchStatus.Active)
                    .ToList();
                
                cboMedicineBatch.DataSource = batches;
                cboMedicineBatch.DisplayMember = "BatchNumber";
                cboMedicineBatch.ValueMember = "Id";
                cboMedicineBatch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lô thuốc: {ex.Message}", "Lỗi", 
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

        private void LoadReceiptNoteItems(int receiptNoteId)
        {
            try
            {
                var items = _unitOfWork.ReceiptNoteItems.GetAll()
                    .Where(i => i.ReceiptNoteId == receiptNoteId)
                    .ToList();
                
                _tempItems = items.Select(i => new ReceiptNoteItemViewModel
                {
                    Id = i.Id,
                    MedicineBatchId = i.MedicineBatchId,
                    MedicineName = i.MedicineBatch != null && i.MedicineBatch.Medicine != null 
                        ? i.MedicineBatch.Medicine.Name : "",
                    BatchNumber = i.MedicineBatch != null ? i.MedicineBatch.BatchNumber : "",
                    ExpiryDate = i.MedicineBatch != null ? i.MedicineBatch.ExpiryDate : DateTime.Now,
                    Quantity = i.Quantity,
                    UnitCost = i.UnitCost,
                    Manufacturer = i.MedicineBatch != null ? i.MedicineBatch.Manufacturer : ""
                }).ToList();
                
                RefreshItemsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách mặt hàng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshItemsGrid()
        {
            // Suspend layout to prevent flickering
            dgvReceiptNoteItems.SuspendLayout();
            
            dgvReceiptNoteItems.DataSource = null;
            dgvReceiptNoteItems.DataSource = _tempItems.Select(i => new
            {
                i.Id,
                TênThuốc = i.MedicineName,
                SốLô = i.BatchNumber,
                HạnSửDụng = i.ExpiryDate.ToString("dd/MM/yyyy"),
                SốLượng = i.Quantity,
                ĐơnGiá = i.UnitCost.ToString("N0") + " ₫",
                ThànhTiền = (i.Quantity * i.UnitCost).ToString("N0") + " ₫",
                NhàSảnXuất = i.Manufacturer
            }).ToList();

            if (dgvReceiptNoteItems.Columns["Id"] != null)
                dgvReceiptNoteItems.Columns["Id"].Visible = false;
                
            // Calculate and display total
            var total = _tempItems.Sum(i => i.Quantity * i.UnitCost);
            lblTotal.Text = $"Tổng tiền: {total:N0} ₫";
            
            // Resume layout
            dgvReceiptNoteItems.ResumeLayout();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
            ClearForm();
            _isEditMode = false;
            _selectedReceiptNoteId = null;
            _tempItems.Clear();
            RefreshItemsGrid();
            
            // Generate receipt note number
            txtReceiptNoteNumber.Text = GenerateReceiptNoteNumber();
            SetItemButtonsMode(true);
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
            SetItemButtonsMode(true);
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

                if (_tempItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một mặt hàng!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        // Delete old items
                        var oldItems = _unitOfWork.ReceiptNoteItems.GetAll()
                            .Where(i => i.ReceiptNoteId == receiptNote.Id)
                            .ToList();
                        foreach (var item in oldItems)
                        {
                            _unitOfWork.ReceiptNoteItems.Delete(item);
                        }

                        // Add new items
                        foreach (var tempItem in _tempItems)
                        {
                            _unitOfWork.ReceiptNoteItems.Add(new ReceiptNoteItem
                            {
                                ReceiptNoteId = receiptNote.Id,
                                MedicineBatchId = tempItem.MedicineBatchId,
                                Quantity = tempItem.Quantity,
                                UnitCost = tempItem.UnitCost
                            });
                        }

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

                    // Add items
                    foreach (var tempItem in _tempItems)
                    {
                        _unitOfWork.ReceiptNoteItems.Add(new ReceiptNoteItem
                        {
                            ReceiptNoteId = newReceiptNote.Id,
                            MedicineBatchId = tempItem.MedicineBatchId,
                            Quantity = tempItem.Quantity,
                            UnitCost = tempItem.UnitCost
                        });
                    }
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadReceiptNotes();
                SetFormMode(false);
                SetItemButtonsMode(false);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_selectedReceiptNoteId == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để hủy!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var receiptNote = _unitOfWork.ReceiptNotes.GetById(_selectedReceiptNoteId.Value);
            if (receiptNote != null && receiptNote.Status == ReceiptNoteStatus.Cancelled)
            {
                MessageBox.Show("Phiếu nhập này đã bị hủy!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy phiếu nhập này?", 
                "Xác nhận hủy", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    receiptNote.Status = ReceiptNoteStatus.Cancelled;
                    _unitOfWork.ReceiptNotes.Update(receiptNote);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Hủy phiếu nhập thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadReceiptNotes();
                    ClearForm();
                    _selectedReceiptNoteId = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hủy phiếu nhập: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMedicineBatch.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn lô thuốc!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (numQuantity.Value <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (numUnitCost.Value <= 0)
                {
                    MessageBox.Show("Đơn giá phải lớn hơn 0!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedBatch = (MedicineBatch)cboMedicineBatch.SelectedItem;
                
                // Check if batch already exists in temp items
                if (_tempItems.Any(i => i.MedicineBatchId == selectedBatch.Id))
                {
                    MessageBox.Show("Lô thuốc này đã có trong danh sách!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _tempItems.Add(new ReceiptNoteItemViewModel
                {
                    Id = 0, // New item
                    MedicineBatchId = selectedBatch.Id,
                    MedicineName = selectedBatch.Medicine != null ? selectedBatch.Medicine.Name : "",
                    BatchNumber = selectedBatch.BatchNumber,
                    ExpiryDate = selectedBatch.ExpiryDate,
                    Quantity = (int)numQuantity.Value,
                    UnitCost = numUnitCost.Value,
                    Manufacturer = selectedBatch.Manufacturer
                });

                RefreshItemsGrid();
                ClearItemFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm mặt hàng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (_selectedItemId == null && dgvReceiptNoteItems.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng để xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int itemId = 0;
                if (dgvReceiptNoteItems.CurrentRow != null)
                {
                    itemId = Convert.ToInt32(dgvReceiptNoteItems.CurrentRow.Cells["Id"].Value);
                }
                else if (_selectedItemId.HasValue)
                {
                    itemId = _selectedItemId.Value;
                }

                var itemToRemove = _tempItems.FirstOrDefault(i => i.Id == itemId || 
                    (i.Id == 0 && _tempItems.IndexOf(i) == dgvReceiptNoteItems.CurrentRow?.Index));
                
                if (itemToRemove != null)
                {
                    _tempItems.Remove(itemToRemove);
                    RefreshItemsGrid();
                    MessageBox.Show("Đã xóa mặt hàng!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa mặt hàng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(false);
            SetItemButtonsMode(false);
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
            txtReceiptNoteNumber.Enabled = isEditing && !_isEditMode;
            cboSupplier.Enabled = isEditing;
            txtNotes.Enabled = isEditing;
            cboStatus.Enabled = isEditing && _isEditMode;

            btnSave.Enabled = isEditing;
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
            btnCancel.Enabled = !isEditing;
        }

        private void SetItemButtonsMode(bool isEditing)
        {
            cboMedicineBatch.Enabled = isEditing;
            numQuantity.Enabled = isEditing;
            numUnitCost.Enabled = isEditing;
            btnAddItem.Enabled = isEditing;
            btnRemoveItem.Enabled = isEditing;
        }

        private void ClearForm()
        {
            txtReceiptNoteNumber.Clear();
            cboSupplier.SelectedIndex = -1;
            txtNotes.Clear();
            cboStatus.SelectedIndex = 0;
            _selectedReceiptNoteId = null;
            _selectedItemId = null;
            _tempItems.Clear();
            RefreshItemsGrid();
            ClearItemFields();
        }

        private void ClearItemFields()
        {
            cboMedicineBatch.SelectedIndex = -1;
            numQuantity.Value = 1;
            numUnitCost.Value = 0;
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

        private class ReceiptNoteItemViewModel
        {
            public int Id { get; set; }
            public int MedicineBatchId { get; set; }
            public string MedicineName { get; set; }
            public string BatchNumber { get; set; }
            public DateTime ExpiryDate { get; set; }
            public int Quantity { get; set; }
            public decimal UnitCost { get; set; }
            public string Manufacturer { get; set; }
        }
    }
}
