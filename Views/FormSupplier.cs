using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormSupplier : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedSupplierId = null;
        private bool _isEditMode = false;

        public FormSupplier()
        {
            InitializeComponent();
            
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            // Set a default user ID for audit fields (you can set this from login)
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            // Optimize DataGridView
            OptimizeDataGridView(dgvSuppliers);
            
            LoadSuppliers();
            SetFormMode(false);
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

        private void LoadSuppliers()
        {
            try
            {
                // Suspend layout to prevent flickering
                dgvSuppliers.SuspendLayout();
                
                var suppliers = _unitOfWork.Suppliers.GetAll();
                
                dgvSuppliers.DataSource = suppliers.Select(s => new
                {
                    s.Id,
                    TênNhàCungCấp = s.Name,
                    ĐịaChỉ = s.Address,
                    ĐiệnThoại = s.PhoneNumber,
                    Email = s.Email,
                    NgườiLiênHệ = s.ContactPerson,
                    TrangThái = s.IsActive ? "Hoạt động" : "Không hoạt động",
                    NgàyTạo = s.CreatedDate.ToString("dd/MM/yyyy"),
                    NgườiTạo = s.CreatedBy != null ? s.CreatedBy.Username : "",
                    NgàyCậpNhật = s.UpdatedDate.HasValue ? s.UpdatedDate.Value.ToString("dd/MM/yyyy") : "",
                    NgườiCậpNhật = s.UpdatedBy != null ? s.UpdatedBy.Username : ""
                }).ToList();

                // Hide the Id column
                if (dgvSuppliers.Columns["Id"] != null)
                    dgvSuppliers.Columns["Id"].Visible = false;
                    
                // Resume layout
                dgvSuppliers.ResumeLayout();
            }
            catch (Exception ex)
            {
                dgvSuppliers.ResumeLayout();
                MessageBox.Show($"Lỗi khi tải danh sách nhà cung cấp: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
            ClearForm();
            _isEditMode = false;
            _selectedSupplierId = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierId == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa!", "Thông báo", 
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
                // Validate input
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Tên nhà cung cấp không được để trống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                if (_isEditMode && _selectedSupplierId.HasValue)
                {
                    // Update existing supplier
                    var supplier = _unitOfWork.Suppliers.GetById(_selectedSupplierId.Value);
                    if (supplier != null)
                    {
                        supplier.Name = txtName.Text.Trim();
                        supplier.Address = txtAddress.Text.Trim();
                        supplier.PhoneNumber = txtPhoneNumber.Text.Trim();
                        supplier.Email = txtEmail.Text.Trim();
                        supplier.ContactPerson = txtContactPerson.Text.Trim();
                        supplier.IsActive = chkIsActive.Checked;

                        _unitOfWork.Suppliers.Update(supplier);
                        _unitOfWork.SaveChanges();

                        MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Add new supplier
                    var newSupplier = new Supplier
                    {
                        Name = txtName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        PhoneNumber = txtPhoneNumber.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        ContactPerson = txtContactPerson.Text.Trim(),
                        IsActive = chkIsActive.Checked
                    };

                    _unitOfWork.Suppliers.Add(newSupplier);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadSuppliers();
                SetFormMode(false);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu nhà cung cấp: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(false);
            _selectedSupplierId = null;
            _isEditMode = false;
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvSuppliers.Rows[e.RowIndex];
                    _selectedSupplierId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var supplier = _unitOfWork.Suppliers.GetById(_selectedSupplierId.Value);
                    if (supplier != null)
                    {
                        txtName.Text = supplier.Name;
                        txtAddress.Text = supplier.Address;
                        txtPhoneNumber.Text = supplier.PhoneNumber;
                        txtEmail.Text = supplier.Email;
                        txtContactPerson.Text = supplier.ContactPerson;
                        chkIsActive.Checked = supplier.IsActive;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn nhà cung cấp: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetFormMode(bool isEditing)
        {
            txtName.Enabled = isEditing;
            txtAddress.Enabled = isEditing;
            txtPhoneNumber.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtContactPerson.Enabled = isEditing;
            chkIsActive.Enabled = isEditing;

            btnSave.Enabled = isEditing;
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtContactPerson.Clear();
            chkIsActive.Checked = true;
            _selectedSupplierId = null;
        }
    }
}
