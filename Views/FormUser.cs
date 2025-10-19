using System;
using System.Linq;
using System.Windows.Forms;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormUser : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedUserId;
        private bool _isEditMode;

        public FormUser()
        {
            InitializeComponent();
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            // Set a default user ID for audit fields (you can set this from login)
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            LoadUserRoles();
            LoadUsers();
            SetFormMode(false);
        }

        private void LoadUserRoles()
        {
            cmbRole.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void LoadUsers()
        {
            try
            {
                var users = _unitOfWork.Users.GetAll();
                
                dgvUsers.DataSource = users.Select(u => new
                {
                    u.Id,
                    TênĐăngNhập = u.Username,
                    HọTên = u.FullName,
                    u.Email,
                    ĐiệnThoại = u.PhoneNumber,
                    VaiTrò = u.Role.ToString(),
                    TrangThái = u.IsActive ? "Hoạt động" : "Không hoạt động",
                    NgàyTạo = u.CreatedDate.ToString("dd/MM/yyyy"),
                    NgườiTạo = u.CreatedBy != null ? u.CreatedBy.Username : "",
                    NgàyCậpNhật = u.UpdatedDate.HasValue ? u.UpdatedDate.Value.ToString("dd/MM/yyyy") : "",
                    NgườiCậpNhật = u.UpdatedBy != null ? u.UpdatedBy.Username : ""
                }).ToList();

                // Hide the Id column
                if (dgvUsers.Columns["Id"] != null)
                    dgvUsers.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetFormMode(true);
            ClearForm();
            _isEditMode = false;
            _selectedUserId = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng để sửa!", "Thông báo", 
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
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Họ tên không được để trống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFullName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Email không được để trống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                if (!_isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return;
                }

                if (_isEditMode && _selectedUserId.HasValue)
                {
                    // Update existing user
                    var user = _unitOfWork.Users.GetById(_selectedUserId.Value);
                    if (user != null)
                    {
                        user.Username = txtUsername.Text.Trim();
                        user.FullName = txtFullName.Text.Trim();
                        user.Email = txtEmail.Text.Trim();
                        user.PhoneNumber = txtPhoneNumber.Text.Trim();
                        user.Role = (UserRole)cmbRole.SelectedItem;
                        user.IsActive = chkIsActive.Checked;

                        // Only update password if provided
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            user.PasswordHash = PasswordHelper.HashPassword(txtPassword.Text);
                        }

                        _unitOfWork.Users.Update(user);
                        _unitOfWork.SaveChanges();

                        MessageBox.Show("Cập nhật người dùng thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Add new user
                    var newUser = new User
                    {
                        Username = txtUsername.Text.Trim(),
                        FullName = txtFullName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PhoneNumber = txtPhoneNumber.Text.Trim(),
                        PasswordHash = PasswordHelper.HashPassword(txtPassword.Text),
                        Role = (UserRole)cmbRole.SelectedItem,
                        IsActive = chkIsActive.Checked
                    };

                    _unitOfWork.Users.Add(newUser);
                    _unitOfWork.SaveChanges();

                    MessageBox.Show("Thêm người dùng thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadUsers();
                SetFormMode(false);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu người dùng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(false);
            _selectedUserId = null;
            _isEditMode = false;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var selectedRow = dgvUsers.Rows[e.RowIndex];
                    _selectedUserId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    var user = _unitOfWork.Users.GetById(_selectedUserId.Value);
                    if (user != null)
                    {
                        txtUsername.Text = user.Username;
                        txtFullName.Text = user.FullName;
                        txtEmail.Text = user.Email;
                        txtPhoneNumber.Text = user.PhoneNumber;
                        cmbRole.SelectedItem = user.Role;
                        chkIsActive.Checked = user.IsActive;
                        txtPassword.Text = ""; // Don't show password
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chọn người dùng: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetFormMode(bool isEditing)
        {
            txtUsername.Enabled = isEditing;
            txtFullName.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtPhoneNumber.Enabled = isEditing;
            txtPassword.Enabled = isEditing;
            cmbRole.Enabled = isEditing;
            chkIsActive.Enabled = isEditing;

            btnSave.Enabled = isEditing;
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
            chkIsActive.Checked = true;
            _selectedUserId = null;
        }
    }
}
