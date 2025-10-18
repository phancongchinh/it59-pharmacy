using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormLogin : Form
    {
        private readonly AppDbContext _context;
        private readonly CurrentUserService _currentUserService;

        public FormLogin()
        {
            // Initialize services
            _context = new AppDbContext();
            _currentUserService = new CurrentUserService();

            // Cấu hình mặc định
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.Size = new Size(1920, 1080); // kích thước mặc định
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Set focus to username textbox when form loads
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                // Hash the password
                string hashedPassword = AuthenticationService.HashPassword(txtPassword.Text);

                // Find user by username and password
                var user = _context.Users.FirstOrDefault(u => 
                    u.Username == txtUsername.Text && 
                    u.PasswordHash == hashedPassword);

                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Check if user is active
                if (!user.IsActive)
                {
                    MessageBox.Show("Tài khoản của bạn đã bị vô hiệu hóa. Vui lòng liên hệ quản trị viên!", 
                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Set current user
                _currentUserService.setCurrentUserId(user.Id);

                // Show success message
                MessageBox.Show($"Đăng nhập thành công!\nXin chào, {user.FullName}!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open FormMain and close FormLogin
                FormMain formMain = new FormMain();
                formMain.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Confirm before closing
            var result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow login when pressing Enter key
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true; // Prevent the beep sound
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            // Dispose the context when form is closing
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
