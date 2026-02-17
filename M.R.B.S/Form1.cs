using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace M.R.B.S_
{
    public partial class Form1 : Form
    {
        private List<Booking> _currentList = new();

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                DatabaseHelper.InitializeDatabase();
                LoadBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookings()
        {
            try
            {
                _currentList = DatabaseHelper.GetAllBookings();

                var ordered = _currentList
                    .OrderBy(b => b.Date)
                    .ThenBy(b => b.StartTime)
                    .ToList();

                dataGridViewBookings.DataSource = ordered;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewBookings_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridViewBookings.CurrentRow?.DataBoundItem is Booking b)
            {
                textBoxBookingID.Text = b.BookingID;

                // Safe ComboBox selection: check item exists, otherwise fallback to index 0
                if (!string.IsNullOrEmpty(b.RoomName) && comboBoxRoomName.Items.Contains(b.RoomName))
                {
                    comboBoxRoomName.SelectedItem = b.RoomName;
                }
                else if (comboBoxRoomName.Items.Count > 0)
                {
                    comboBoxRoomName.SelectedIndex = 0;
                }

                textBoxBookerName.Text = b.BookerName;
                dateTimePickerDate.Value = b.Date;
                dateTimePickerStartTime.Value = dateTimePickerDate.Value.Date + b.StartTime;
                dateTimePickerEndTime.Value = dateTimePickerDate.Value.Date + b.EndTime;
                textBoxPurpose.Text = b.Purpose;
            }
        }

        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput(out var booking)) return;

                // Ensure unique BookingID
                var exists = _currentList.Any(x => x.BookingID == booking.BookingID);
                if (exists)
                {
                    MessageBox.Show("BookingID already exists. Use Update to modify.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatabaseHelper.InsertBooking(booking);
                LoadBookings();
                MessageBox.Show("Booking saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput(out var booking)) return;

                var exists = _currentList.Any(x => x.BookingID == booking.BookingID);
                if (!exists)
                {
                    MessageBox.Show("BookingID does not exist. Use Save to create new.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatabaseHelper.UpdateBooking(booking);
                LoadBookings();
                MessageBox.Show("Booking updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                var id = textBoxBookingID.Text.Trim();
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Please select or enter BookingID to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show($"Delete booking '{id}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                DatabaseHelper.DeleteBooking(id);
                LoadBookings();
                MessageBox.Show("Booking deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private bool ValidateInput(out Booking booking)
        {
            booking = new Booking();
            try
            {
                var id = textBoxBookingID.Text.Trim();
                var room = comboBoxRoomName.SelectedItem?.ToString() ?? "";
                var booker = textBoxBookerName.Text.Trim();
                var date = dateTimePickerDate.Value.Date;
                var start = dateTimePickerStartTime.Value.TimeOfDay;
                var end = dateTimePickerEndTime.Value.TimeOfDay;
                var purpose = textBoxPurpose.Text.Trim();

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(room) || string.IsNullOrEmpty(booker))
                {
                    MessageBox.Show("Please fill BookingID, RoomName and BookerName.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (end <= start)
                {
                    MessageBox.Show("EndTime must be after StartTime.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                booking = new Booking
                {
                    BookingID = id,
                    RoomName = room,
                    BookerName = booker,
                    Date = date,
                    StartTime = start,
                    EndTime = end,
                    Purpose = purpose
                };

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Validation error: {ex.Message}", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void ClearInputs()
        {
            textBoxBookingID.Text = "";
            if (comboBoxRoomName.Items.Count > 0) comboBoxRoomName.SelectedIndex = 0;
            textBoxBookerName.Text = "";
            dateTimePickerDate.Value = DateTime.Now.Date;
            dateTimePickerStartTime.Value = DateTime.Now;
            dateTimePickerEndTime.Value = DateTime.Now;
            textBoxPurpose.Text = "";
        }
    }
}
