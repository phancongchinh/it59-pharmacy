using System;
using System.Drawing;
using System.Windows.Forms;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using System.Linq;

namespace IT59_Pharmacy.Views
{
    public partial class FormInvoice : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedInvoiceId;

        public FormInvoice()
        {
            InitializeComponent();
            this.Load += FormInvoice_Load;
        }

        public FormInvoice(UnitOfWork unitOfWork) : this()
        {
            _unitOfWork = unitOfWork;
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadInvoices();
            LoadPaymentMethods();
        }

        private void ConfigureDataGridView()
        {
            // Configure main DataGridView for invoices
            dgvInvoices.AutoGenerateColumns = false;
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.ReadOnly = true;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.MultiSelect = false;

            dgvInvoices.Columns.Clear();
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Mã HĐ",
                Name = "colId",
                Width = 80
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeliveryDate",
                HeaderText = "Ngày bán",
                Name = "colDeliveryDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Khách hàng",
                Name = "colCustomerName",
                Width = 180
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerPhone",
                HeaderText = "SĐT",
                Name = "colCustomerPhone",
                Width = 110
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Tổng tiền",
                Name = "colTotalAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentMethod",
                HeaderText = "Thanh toán",
                Name = "colPaymentMethod",
                Width = 120
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Name = "colStatus",
                Width = 100
            });

            // Configure details DataGridView
            dgvInvoiceItems.AutoGenerateColumns = false;
            dgvInvoiceItems.AllowUserToAddRows = false;
            dgvInvoiceItems.AllowUserToDeleteRows = false;
            dgvInvoiceItems.ReadOnly = true;
            dgvInvoiceItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvInvoiceItems.Columns.Clear();
            dgvInvoiceItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicineName",
                HeaderText = "Tên thuốc",
                Name = "colMedicineName",
                Width = 200
            });
            dgvInvoiceItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "SL",
                Name = "colQuantity",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvInvoiceItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn giá",
                Name = "colUnitPrice",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvInvoiceItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Discount",
                HeaderText = "Giảm giá",
                Name = "colDiscount",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvInvoiceItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "Thành tiền",
                Name = "colTotalPrice",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void LoadInvoices()
        {
            try
            {
                if (_unitOfWork != null)
                {
                    var invoices = _unitOfWork.DeliveryNotes.GetAll()
                        .Where(x => x.DeliveryFor.Equals(DeliveryFor.Sales))
                        .OrderByDescending(x => x.CreatedDate)
                        .ToList();
                    dgvInvoices.DataSource = invoices;
                    UpdateStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadPaymentMethods()
        {
            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.Add("-- Chọn phương thức --");
            cboPaymentMethod.Items.Add("Tiền mặt");
            cboPaymentMethod.Items.Add("Chuyển khoản");
            cboPaymentMethod.Items.Add("Thẻ");
            cboPaymentMethod.Items.Add("Ví điện tử");
            cboPaymentMethod.SelectedIndex = 0;
        }

        private void UpdateStatistics()
        {
            // try
            // {
            //     if (_unitOfWork != null)
            //     {
            //         var today = DateTime.Today;
            //         var allInvoices = _unitOfWork.DeliveryNotes.GetAll()
            //             .Where(x => x.Status == "Completed" || x.Status == "Paid")
            //             .ToList();
            //
            //         var todayInvoices = allInvoices.Where(x => x.DeliveryDate?.Date == today).ToList();
            //         var todayRevenue = todayInvoices.Sum(x => x.TotalAmount);
            //
            //         lblTodayInvoices.Text = $"HĐ hôm nay: {todayInvoices.Count}";
            //         lblTodayRevenue.Text = $"Doanh thu: {todayRevenue:N0} VNĐ";
            //         lblTotalInvoices.Text = $"Tổng HĐ: {allInvoices.Count}";
            //     }
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show($"Lỗi khi cập nhật thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
            //         MessageBoxIcon.Error);
            // }
        }

        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count > 0)
            {
                var row = dgvInvoices.SelectedRows[0];
                _selectedInvoiceId = Convert.ToInt32(row.Cells["colId"].Value);
                LoadInvoiceDetails(_selectedInvoiceId.Value);
                LoadInvoiceInfo(_selectedInvoiceId.Value);
            }
        }

        private void LoadInvoiceDetails(int invoiceId)
        {
            try
            {
                if (_unitOfWork != null)
                {
                    var items = _unitOfWork.DeliveryNoteItems
                        .GetAll()
                        .Where(x => x.DeliveryNoteId == invoiceId)
                        .ToList();
                    dgvInvoiceItems.DataSource = items;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadInvoiceInfo(int invoiceId)
        {
            try
            {
                if (_unitOfWork != null)
                {
                    var invoice = _unitOfWork.DeliveryNotes.GetById(invoiceId);
                    if (invoice != null)
                    {
                        dtpInvoiceDate.Value = invoice.CreatedDate;
                        txtCustomerName.Text = invoice.DeliveryTo;
                        // txtSubTotal.Text = invoice.TotalAmount.ToString("N0");
                        // txtDiscount.Text = "0";
                        // txtTotal.Text = invoice.TotalAmount.ToString("N0");
                        txtNotes.Text = invoice.Notes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            ClearInputs();
            _selectedInvoiceId = null;
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (_unitOfWork == null) return;

                // Validation
                if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (cboPaymentMethod.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // if (_selectedInvoiceId.HasValue)
                // {
                //     // Update existing invoice
                //     var invoice = _unitOfWork.DeliveryNotes.GetById(_selectedInvoiceId.Value);
                //     if (invoice != null)
                //     {
                //         invoice.CreatedDate = dtpInvoiceDate.Value;
                //         invoice.PaymentMethod = cboPaymentMethod.SelectedItem;
                //         invoice.Notes = txtNotes.Text;
                //         invoice.Status = DeliveryNoteStatus.Completed;
                //         _unitOfWork.DeliveryNotes.Update(invoice);
                //     }
                // }
                // else
                // {
                //     // Create new invoice
                //     var invoice = new DeliveryNote
                //     {
                //         PaymentMethod = cboPaymentMethod.SelectedItem.ToString(),
                //         Notes = txtNotes.Text,
                //         TotalAmount = 0,
                //         Status = "Completed"
                //     };
                //     _unitOfWork.DeliveryNotes.Add(invoice);
                // }

                _unitOfWork.SaveChanges();
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadInvoices();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (!_selectedInvoiceId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Chức năng in hóa đơn đang được phát triển!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoices();
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (_unitOfWork == null) return;

                var searchText = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadInvoices();
                    return;
                }

                var filteredInvoices = _unitOfWork.DeliveryNotes.GetAll()
                    .Where(x => x.DeliveryNoteNumber.ToLower().Contains(searchText))
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();

                dgvInvoices.DataSource = filteredInvoices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterToday_Click(object sender, EventArgs e)
        {
            try
            {
                if (_unitOfWork == null) return;

                var today = DateTime.Today;
                var todayInvoices = _unitOfWork.DeliveryNotes.GetAll()
                    .Where(x => x.CreatedDate.Date == today)
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();

                dgvInvoices.DataSource = todayInvoices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            try
            {
                decimal subTotal = 0;
                decimal discount = 0;

                if (decimal.TryParse(txtSubTotal.Text.Replace(",", ""), out subTotal))
                {
                    decimal.TryParse(txtDiscount.Text.Replace(",", ""), out discount);
                    decimal total = subTotal - discount;
                    txtTotal.Text = total.ToString("N0");
                }
            }
            catch
            {
                txtTotal.Text = "0";
            }
        }

        private void ClearInputs()
        {
            _selectedInvoiceId = null;
            dtpInvoiceDate.Value = DateTime.Now;
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            txtCustomerAddress.Clear();
            cboPaymentMethod.SelectedIndex = 0;
            txtSubTotal.Text = "0";
            txtDiscount.Text = "0";
            txtTotal.Text = "0";
            txtNotes.Clear();
            dgvInvoiceItems.DataSource = null;
        }
    }
}