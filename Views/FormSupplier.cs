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
            LoadSuppliers();
            SetFormMode(false);
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = _unitOfWork.Suppliers.GetAll();
                
                dgvSuppliers.DataSource = suppliers.Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Address,
                    s.PhoneNumber,
                    s.Email,
                    s.ContactPerson,
                    IsActive = s.IsActive ? "Hoạt động" : "Không hoạt động",
                    CreatedDate = s.CreatedDate.ToString("dd/MM/yyyy"),
                    CreatedBy = s.CreatedBy != null ? s.CreatedBy.Username : "",
                    UpdatedDate = s.UpdatedDate.HasValue ? s.UpdatedDate.Value.ToString("dd/MM/yyyy") : "",
                    UpdatedBy = s.UpdatedBy != null ? s.UpdatedBy.Username : ""
                }).ToList();
                
                if (dgvSuppliers.Columns["Name"] != null)
                    dgvSuppliers.Columns["Name"].HeaderText = "Nhà cung cấp";
                if (dgvSuppliers.Columns["Address"] != null)
                    dgvSuppliers.Columns["Address"].HeaderText = "Địa chỉ";
                if (dgvSuppliers.Columns["PhoneNumber"] != null)
                    dgvSuppliers.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
                if (dgvSuppliers.Columns["Email"] != null)
                    dgvSuppliers.Columns["Email"].HeaderText = "Email";
                if (dgvSuppliers.Columns["ContactPerson"] != null)
                    dgvSuppliers.Columns["ContactPerson"].HeaderText = "Người liên hệ";
                if (dgvSuppliers.Columns["IsActive"] != null)
                    dgvSuppliers.Columns["IsActive"].HeaderText = "Trạng thái";
                if (dgvSuppliers.Columns["CreatedDate"] != null)
                    dgvSuppliers.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                if (dgvSuppliers.Columns["CreatedBy"] != null)
                    dgvSuppliers.Columns["CreatedBy"].HeaderText = "Người tạo";
                if (dgvSuppliers.Columns["UpdatedDate"] != null)
                    dgvSuppliers.Columns["UpdatedDate"].HeaderText = "Ngày cập nhật";
                if (dgvSuppliers.Columns["UpdatedBy"] != null)
                    dgvSuppliers.Columns["UpdatedBy"].HeaderText = "Người cập nhật";

            }
            catch (Exception ex)
            {
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
