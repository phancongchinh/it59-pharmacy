using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IT59_Pharmacy.Data.Repositories;

namespace IT59_Pharmacy.Views
{
    public partial class FormReport : Form
    {
        private readonly UnitOfWork _unitOfWork;

        public FormReport()
        {
            InitializeComponent();
            this.Load += FormReport_Load;
        }

        public FormReport(UnitOfWork unitOfWork) : this()
        {
            _unitOfWork = unitOfWork;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            ConfigureDataGridViews();
            // Load default report (Medicine Stock)
            LoadMedicineStockReport();
        }

        private void ConfigureDataGridViews()
        {
            // Configure Medicine Stock Report DataGridView
            dgvMedicineStock.AutoGenerateColumns = false;
            dgvMedicineStock.AllowUserToAddRows = false;
            dgvMedicineStock.AllowUserToDeleteRows = false;
            dgvMedicineStock.ReadOnly = true;
            dgvMedicineStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicineStock.MultiSelect = false;

            dgvMedicineStock.Columns.Clear();
            dgvMedicineStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicineId",
                HeaderText = "Mã thuốc",
                Name = "colMedicineId",
                Width = 80
            });
            dgvMedicineStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicineName",
                HeaderText = "Tên thuốc",
                Name = "colMedicineName",
                Width = 250
            });
            dgvMedicineStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Danh mục",
                Name = "colCategory",
                Width = 150
            });
            dgvMedicineStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unit",
                HeaderText = "Đơn vị",
                Name = "colUnit",
                Width = 100
            });
            dgvMedicineStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalQuantity",
                HeaderText = "Tồn kho",
                Name = "colTotalQuantity",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvMedicineStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalBatches",
                HeaderText = "Số lô",
                Name = "colTotalBatches",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Configure Expired Report DataGridView
            dgvExpired.AutoGenerateColumns = false;
            dgvExpired.AllowUserToAddRows = false;
            dgvExpired.AllowUserToDeleteRows = false;
            dgvExpired.ReadOnly = true;
            dgvExpired.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvExpired.Columns.Clear();
            dgvExpired.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BatchNumber",
                HeaderText = "Số lô",
                Name = "colBatchNumber",
                Width = 120
            });
            dgvExpired.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicineName",
                HeaderText = "Tên thuốc",
                Name = "colMedicineName2",
                Width = 250
            });
            dgvExpired.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExpiryDate",
                HeaderText = "Ngày hết hạn",
                Name = "colExpiryDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvExpired.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Name = "colQuantity",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvExpired.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DaysExpired",
                HeaderText = "Đã hết hạn (ngày)",
                Name = "colDaysExpired",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Configure Expiry Soon Report DataGridView
            dgvExpirySoon.AutoGenerateColumns = false;
            dgvExpirySoon.AllowUserToAddRows = false;
            dgvExpirySoon.AllowUserToDeleteRows = false;
            dgvExpirySoon.ReadOnly = true;
            dgvExpirySoon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvExpirySoon.Columns.Clear();
            dgvExpirySoon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BatchNumber",
                HeaderText = "Số lô",
                Name = "colBatchNumber2",
                Width = 120
            });
            dgvExpirySoon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicineName",
                HeaderText = "Tên thuốc",
                Name = "colMedicineName3",
                Width = 250
            });
            dgvExpirySoon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExpiryDate",
                HeaderText = "Ngày hết hạn",
                Name = "colExpiryDate2",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvExpirySoon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Name = "colQuantity2",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvExpirySoon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DaysUntilExpiry",
                HeaderText = "Còn lại (ngày)",
                Name = "colDaysUntilExpiry",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void LoadMedicineStockReport()
        {
            try
            {
                if (_unitOfWork == null) return;

                var medicineStock = _unitOfWork.MedicineBatches.GetAll()
                    .GroupBy(b => b.MedicineId)
                    .Select(g => new
                    {
                        MedicineId = g.Key,
                        MedicineName = g.First().Medicine?.Name ?? "N/A",
                        Unit = g.First().Medicine?.Unit.ToString() ?? "N/A",
                        TotalQuantity = g.Sum(b => b.Quantity),
                        TotalBatches = g.Count()
                    })
                    .OrderByDescending(m => m.TotalQuantity)
                    .ToList();

                dgvMedicineStock.DataSource = medicineStock;
                lblStockCount.Text = $"Tổng số loại thuốc: {medicineStock.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo tồn kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExpiredReport()
        {
            try
            {
                if (_unitOfWork == null) return;

                var today = DateTime.Today;
                var expiredBatches = _unitOfWork.MedicineBatches.GetAll()
                    .Where(b => b.ExpiryDate < today && b.Quantity > 0)
                    .Select(b => new
                    {
                        BatchNumber = b.BatchNumber,
                        MedicineName = b.Medicine?.Name ?? "N/A",
                        ExpiryDate = b.ExpiryDate,
                        Quantity = b.Quantity,
                        DaysExpired = (today - b.ExpiryDate).Days
                    })
                    .OrderBy(b => b.ExpiryDate)
                    .ToList();

                dgvExpired.DataSource = expiredBatches;
                lblExpiredCount.Text = $"Số lô hết hạn: {expiredBatches.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo hết hạn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExpirySoonReport(int months)
        {
            try
            {
                if (_unitOfWork == null) return;

                var today = DateTime.Today;
                var thresholdDate = today.AddMonths(months);
                
                var expiringSoonBatches = _unitOfWork.MedicineBatches.GetAll()
                    .Where(b => b.ExpiryDate >= today && b.ExpiryDate <= thresholdDate && b.Quantity > 0)
                    .Select(b => new
                    {
                        BatchNumber = b.BatchNumber,
                        MedicineName = b.Medicine?.Name ?? "N/A",
                        ExpiryDate = b.ExpiryDate,
                        Quantity = b.Quantity,
                        DaysUntilExpiry = (b.ExpiryDate - today).Days
                    })
                    .OrderBy(b => b.ExpiryDate)
                    .ToList();

                dgvExpirySoon.DataSource = expiringSoonBatches;
                lblExpirySoonCount.Text = $"Số lô sắp hết hạn: {expiringSoonBatches.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo sắp hết hạn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMedicineStock_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabMedicineStock;
            LoadMedicineStockReport();
        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabExpired;
            LoadExpiredReport();
        }

        private void btnExpirySoon_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabExpirySoon;
            // Default to 3 months
            rdo3Months.Checked = true;
            LoadExpirySoonReport(3);
        }

        private void rdo1Month_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1Month.Checked)
            {
                LoadExpirySoonReport(1);
            }
        }

        private void rdo3Months_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo3Months.Checked)
            {
                LoadExpirySoonReport(3);
            }
        }

        private void btnRefreshStock_Click(object sender, EventArgs e)
        {
            LoadMedicineStockReport();
        }

        private void btnRefreshExpired_Click(object sender, EventArgs e)
        {
            LoadExpiredReport();
        }

        private void btnRefreshExpirySoon_Click(object sender, EventArgs e)
        {
            int months = rdo1Month.Checked ? 1 : 3;
            LoadExpirySoonReport(months);
        }

        private void btnExportStock_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất báo cáo đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportExpired_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất báo cáo đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportExpirySoon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất báo cáo đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvMedicineStock_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (_unitOfWork == null) return;

                var columnName = dgvMedicineStock.Columns[e.ColumnIndex].Name;
                var medicineStock = _unitOfWork.MedicineBatches.GetAll()
                    .GroupBy(b => b.MedicineId)
                    .Select(g => new
                    {
                        MedicineId = g.Key,
                        MedicineName = g.First().Medicine?.Name ?? "N/A",
                        Unit = g.First().Medicine?.Unit.ToString() ?? "N/A",
                        TotalQuantity = g.Sum(b => b.Quantity),
                        TotalBatches = g.Count()
                    });

                // Sort based on clicked column
                switch (columnName)
                {
                    case "colMedicineId":
                        medicineStock = medicineStock.OrderBy(m => m.MedicineId);
                        break;
                    case "colMedicineName":
                        medicineStock = medicineStock.OrderBy(m => m.MedicineName);
                        break;
                    case "colTotalQuantity":
                        medicineStock = medicineStock.OrderByDescending(m => m.TotalQuantity);
                        break;
                    case "colTotalBatches":
                        medicineStock = medicineStock.OrderByDescending(m => m.TotalBatches);
                        break;
                }

                dgvMedicineStock.DataSource = medicineStock.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sắp xếp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

