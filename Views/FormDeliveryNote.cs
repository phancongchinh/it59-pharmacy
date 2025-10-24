using System;
using System.Windows.Forms;
using IT59_Pharmacy.Data.Repositories;
using IT59_Pharmacy.Entities;
using System.Linq;
using IT59_Pharmacy.Data;
using IT59_Pharmacy.Services;

namespace IT59_Pharmacy.Views
{
    public partial class FormDeliveryNote : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private int? _selectedDeliveryNoteId;

        public FormDeliveryNote()
        {
            InitializeComponent();
            this.Load += FormDeliveryNote_Load;
            var context = new AppDbContext();
            var currentUserService = new CurrentUserService();
            currentUserService.setCurrentUserId(1);
            _unitOfWork = new UnitOfWork(context, currentUserService);
        }

        public FormDeliveryNote(UnitOfWork unitOfWork) : this()
        {
            _unitOfWork = unitOfWork;
        }

        private void FormDeliveryNote_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDeliveryNotes();
            LoadCustomers();
        }

        private void ConfigureDataGridView()
        {
            // Configure main DataGridView for delivery notes
            dgvDeliveryNotes.AutoGenerateColumns = false;
            dgvDeliveryNotes.AllowUserToAddRows = false;
            dgvDeliveryNotes.AllowUserToDeleteRows = false;
            dgvDeliveryNotes.ReadOnly = true;
            dgvDeliveryNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeliveryNotes.MultiSelect = false;

            dgvDeliveryNotes.Columns.Clear();
            dgvDeliveryNotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Mã phiếu",
                Name = "colId",
                Width = 80
            });
            dgvDeliveryNotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DeliveryDate",
                HeaderText = "Ngày xuất",
                Name = "colDeliveryDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvDeliveryNotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Khách hàng",
                Name = "colCustomerName",
                Width = 200
            });
            dgvDeliveryNotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Tổng tiền",
                Name = "colTotalAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvDeliveryNotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Name = "colStatus",
                Width = 120
            });
            dgvDeliveryNotes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Notes",
                HeaderText = "Ghi chú",
                Name = "colNotes",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Configure details DataGridView
            dgvDeliveryNoteItems.AutoGenerateColumns = false;
            dgvDeliveryNoteItems.AllowUserToAddRows = false;
            dgvDeliveryNoteItems.AllowUserToDeleteRows = false;
            dgvDeliveryNoteItems.ReadOnly = true;
            dgvDeliveryNoteItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDeliveryNoteItems.Columns.Clear();
            dgvDeliveryNoteItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedicineName",
                HeaderText = "Tên thuốc",
                Name = "colMedicineName",
                Width = 200
            });
            dgvDeliveryNoteItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BatchNumber",
                HeaderText = "Số lô",
                Name = "colBatchNumber",
                Width = 100
            });
            dgvDeliveryNoteItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Name = "colQuantity",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvDeliveryNoteItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn giá",
                Name = "colUnitPrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvDeliveryNoteItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "Thành tiền",
                Name = "colTotalPrice",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                    { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void LoadDeliveryNotes()
        {
            try
            {
                if (_unitOfWork != null)
                {
                    var deliveryNotes = _unitOfWork.DeliveryNotes.GetAll().ToList();
                    dgvDeliveryNotes.DataSource = deliveryNotes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                if (_unitOfWork != null)
                {
                    cboCustomer.Items.Clear();
                    cboCustomer.Items.Add("-- Chọn khách hàng --");
                    cboCustomer.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvDeliveryNotes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDeliveryNotes.SelectedRows.Count > 0)
            {
                var row = dgvDeliveryNotes.SelectedRows[0];
                _selectedDeliveryNoteId = Convert.ToInt32(row.Cells["colId"].Value);
                LoadDeliveryNoteDetails(_selectedDeliveryNoteId.Value);
                LoadDeliveryNoteInfo(_selectedDeliveryNoteId.Value);
            }
        }

        private void LoadDeliveryNoteDetails(int deliveryNoteId)
        {
            try
            {
                if (_unitOfWork != null)
                {
                    var items = _unitOfWork.DeliveryNoteItems
                        .GetAll()
                        .Where(x => x.DeliveryNoteId == deliveryNoteId)
                        .ToList();
                    dgvDeliveryNoteItems.DataSource = items;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDeliveryNoteInfo(int deliveryNoteId)
        {
            try
            {
                if (_unitOfWork != null)
                {
                    var deliveryNote = _unitOfWork.DeliveryNotes.GetById(deliveryNoteId);

                    var items = _unitOfWork.DeliveryNoteItems.GetAll()
                        .Where(i => i.DeliveryNoteId == deliveryNoteId)
                        .ToList();

                    var totalAmount = items.Sum(i => i.UnitPrice * i.Quantity);

                    if (deliveryNote != null)
                    {
                        dtpDeliveryDate.Value = deliveryNote.CreatedDate;
                        txtNotes.Text = deliveryNote.Notes;
                        txtTotalAmount.Text = totalAmount.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputs();
            _selectedDeliveryNoteId = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_unitOfWork == null) return;

                // Validation
                if (cboCustomer.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (_selectedDeliveryNoteId.HasValue)
                {
                    // Update existing delivery note
                    var deliveryNote = _unitOfWork.DeliveryNotes.GetById(_selectedDeliveryNoteId.Value);
                    if (deliveryNote != null)
                    {
                        deliveryNote.Notes = txtNotes.Text;
                        _unitOfWork.DeliveryNotes.Update(deliveryNote);
                    }
                }
                else
                {
                    // Create new delivery note
                    var deliveryNote = new DeliveryNote
                    {
                        Notes = txtNotes.Text,
                        Status = DeliveryNoteStatus.Pending
                    };
                    _unitOfWork.DeliveryNotes.Add(deliveryNote);
                }

                _unitOfWork.SaveChanges();

                MessageBox.Show("Lưu phiếu xuất kho thành công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadDeliveryNotes();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_unitOfWork == null || !_selectedDeliveryNoteId.HasValue) return;

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu xuất kho này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _unitOfWork.DeliveryNotes.Delete(_selectedDeliveryNoteId.Value);
                    _unitOfWork.SaveChanges();
                    MessageBox.Show("Xóa phiếu xuất kho thành công!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadDeliveryNotes();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDeliveryNotes();
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
                    LoadDeliveryNotes();
                    return;
                }

                var filteredNotes = _unitOfWork.DeliveryNotes.GetAll()
                    .Where(x => x.DeliveryTo.ToLower().Contains(searchText) ||
                                x.Notes.ToLower().Contains(searchText) ||
                                x.DeliveryNoteNumber.ToLower().Contains(searchText)
                    )
                    .ToList();

                dgvDeliveryNotes.DataSource = filteredNotes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            _selectedDeliveryNoteId = null;
            dtpDeliveryDate.Value = DateTime.Now;
            cboCustomer.SelectedIndex = 0;
            txtNotes.Clear();
            txtTotalAmount.Clear();
            dgvDeliveryNoteItems.DataSource = null;
        }
    }
}