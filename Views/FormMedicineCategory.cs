using System;
using System.Linq;
using System.Windows.Forms;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormMedicineCategory : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedCategoryId;
        private bool _isEditMode;

        public FormMedicineCategory()
        {
            InitializeComponent();
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormMedicineCategory_Load(object sender, EventArgs e)
        {
            LoadCategories();
            SetFormMode(false);
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _unitOfWork.MedicineCategories.GetAll();
                
                dgvMedicineCategories.DataSource = categories.Select(c => new
                {
                    c.Id,
                    TênDanhMục = c.Name,
                    MôTả = c.Description,
                    TrangThái = c.IsActive ? "Hoạt động" : "Không hoạt động",
                    NgàyTạo = c.CreatedDate.ToString("dd/MM/yyyy"),
                    NgườiTạo = c.CreatedBy != null ? c.CreatedBy.Username : "",
                    NgàyCậpNhật = c.UpdatedDate.HasValue ? c.UpdatedDate.Value.ToString("dd/MM/yyyy") : "",
                    NgườiCậpNhật = c.UpdatedBy != null ? c.UpdatedBy.Username : ""
                }).ToList();

                if (dgvMedicineCategories.Columns["Id"] != null)
                    dgvMedicineCategories.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách danh mục: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
            ClearForm();
            _isEditMode = false;
            _selectedCategoryId = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục để sửa!", "Thông báo", 
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
                    MessageBox.Show("Tên danh mục không được để trống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }

                if (_isEditMode && _selectedCategoryId.HasValue)
                {
                    var category = _unitOfWork.MedicineCategories.GetById(_selectedCategoryId.Value);
                    if (category != null)
                    {
                        category.Name = txtName.Text.Trim();
                        category.Description = txtDescription.Text.Trim();
                        category.IsActive = chkIsActive.Checked;

                        _unitOfWork.MedicineCategories.Update(category);
                        _unitOfWork.SaveChanges();

                        MessageBox.Show("Cập nhật danh mục thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var newCategory = new MedicineCategory
                    {
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        IsActive = chkIsActive.Checked
                    };

                    _unitOfWork.MedicineCategories.Add(newCategory);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm danh mục thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadCategories();
                SetFormMode(false);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu danh mục: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(false);
            _selectedCategoryId = null;
            _isEditMode = false;
        }

        private void dgvMedicineCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvMedicineCategories.Rows[e.RowIndex];
                    _selectedCategoryId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var category = _unitOfWork.MedicineCategories.GetById(_selectedCategoryId.Value);
                    if (category != null)
                    {
                        txtName.Text = category.Name;
                        txtDescription.Text = category.Description;
                        chkIsActive.Checked = category.IsActive;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn danh mục: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetFormMode(bool isEditing)
        {
            txtName.Enabled = isEditing;
            txtDescription.Enabled = isEditing;
            chkIsActive.Enabled = isEditing;

            btnSave.Enabled = isEditing;
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            chkIsActive.Checked = true;
            _selectedCategoryId = null;
        }
    }
}
