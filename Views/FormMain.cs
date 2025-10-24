using System;
using System.Drawing;
using System.Windows.Forms;

namespace IT59_Pharmacy.Views
{
    public partial class FormMain : Form
    {
        private Form _currentChildForm;

        public FormMain()
        {
            // Cấu hình mặc định
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.Size = new Size(1920, 1080);
            
            // Enable double buffering for smooth rendering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                         ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();
            
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
        
        private void btnMedicineBatches_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMedicineBatch());
        }

        private void btnReceiptNotes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormReceiptNote());
        }

        private void btnDeliveryNotes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDeliveryNote());
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormInvoice());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormReport());
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
            // Dispose previous form to free resources
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
                _currentChildForm.Dispose();
                _currentChildForm = null;
            }

            // Suspend layout to prevent flickering
            panelContent.SuspendLayout();
            
            // Clear existing controls
            panelContent.Controls.Clear();

            // Configure child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Enable double buffering for child form
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic,
                null, childForm, new object[] { true });

            // Add child form to panel
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            _currentChildForm = childForm;
            childForm.BringToFront();
            childForm.Show();
            
            // Resume layout
            panelContent.ResumeLayout(true);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            // Clean up resources
            if (_currentChildForm != null)
            {
                _currentChildForm.Dispose();
            }
        }
    }
}
