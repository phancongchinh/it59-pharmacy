using System;
using System.Drawing;
using System.Windows.Forms;

namespace IT59_Pharmacy.Views
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            // Cấu hình mặc định
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.Size = new Size(1920, 1080); // kích thước mặc định
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormUser());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSupplier());
        }

        private void btnMedicineCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMedicineCategory());
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMedicine());
        }

        private void btnReceiptNotes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormReceiptNote());
        }

        private void lblAppTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Handle logout logic
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        public void OpenChildForm(Form childForm)
        {
            // Clear existing controls in the content panel
            panelContent.Controls.Clear();

            // Configure child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add child form to panel
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
