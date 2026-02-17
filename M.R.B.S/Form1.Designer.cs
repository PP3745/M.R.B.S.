using System;
using System.Drawing;
using System.Windows.Forms;

namespace M.R.B.S_
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelBookingID;
        private TextBox textBoxBookingID;
        private Label labelRoomName;
        private ComboBox comboBoxRoomName;
        private Label labelBookerName;
        private TextBox textBoxBookerName;
        private Label labelDate;
        private DateTimePicker dateTimePickerDate;
        private Label labelStartTime;
        private DateTimePicker dateTimePickerStartTime;
        private Label labelEndTime;
        private DateTimePicker dateTimePickerEndTime;
        private Label labelPurpose;
        private TextBox textBoxPurpose;
        private DataGridView dataGridViewBookings;
        private Button buttonSave;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Text = "โปรเเกรมบันทึกการจองห้องประชุม";

            // Title
            labelTitle = new Label();
            labelTitle.Name = "labelTitle";
            labelTitle.Text = "โปรเเกรมบันทึกการจองห้องประชุม";
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.AutoSize = false;
            labelTitle.Location = new Point(50, 10);
            labelTitle.Size = new Size(700, 40);
            Controls.Add(labelTitle);

            int leftLabelX = 20;
            int controlX = 180;
            int rowY = 70;
            int rowHeight = 36;
            int labelWidth = 150;

            // BookingID
            labelBookingID = new Label();
            labelBookingID.Name = "labelBookingID";
            labelBookingID.Text = "BookingID (รหัสการจอง)";
            labelBookingID.AutoSize = false;
            labelBookingID.TextAlign = ContentAlignment.MiddleLeft;
            labelBookingID.Location = new Point(leftLabelX, rowY);
            labelBookingID.Size = new Size(labelWidth, 24);
            Controls.Add(labelBookingID);

            textBoxBookingID = new TextBox();
            textBoxBookingID.Name = "textBoxBookingID";
            textBoxBookingID.Location = new Point(controlX, rowY - 4);
            textBoxBookingID.Size = new Size(220, 27);
            Controls.Add(textBoxBookingID);

            // RoomName
            rowY += rowHeight;
            labelRoomName = new Label();
            labelRoomName.Name = "labelRoomName";
            labelRoomName.Text = "RoomName (ชื่อห้องประชุม)";
            labelRoomName.AutoSize = false;
            labelRoomName.TextAlign = ContentAlignment.MiddleLeft;
            labelRoomName.Location = new Point(leftLabelX, rowY);
            labelRoomName.Size = new Size(labelWidth, 24);
            Controls.Add(labelRoomName);

            comboBoxRoomName = new ComboBox();
            comboBoxRoomName.Name = "comboBoxRoomName";
            comboBoxRoomName.Location = new Point(controlX, rowY - 4);
            comboBoxRoomName.Size = new Size(220, 27);
            comboBoxRoomName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRoomName.Items.AddRange(new object[] { "ห้องประชุม 1", "ห้องประชุม 2", "ห้องประชุม 3", "ห้องประชุม 4" });
            if (comboBoxRoomName.Items.Count > 0) comboBoxRoomName.SelectedIndex = 0;
            Controls.Add(comboBoxRoomName);

            // BookerName
            rowY += rowHeight;
            labelBookerName = new Label();
            labelBookerName.Name = "labelBookerName";
            labelBookerName.Text = "BookerName (ผู้จอง)";
            labelBookerName.AutoSize = false;
            labelBookerName.TextAlign = ContentAlignment.MiddleLeft;
            labelBookerName.Location = new Point(leftLabelX, rowY);
            labelBookerName.Size = new Size(labelWidth, 24);
            Controls.Add(labelBookerName);

            textBoxBookerName = new TextBox();
            textBoxBookerName.Name = "textBoxBookerName";
            textBoxBookerName.Location = new Point(controlX, rowY - 4);
            textBoxBookerName.Size = new Size(220, 27);
            Controls.Add(textBoxBookerName);

            // Date
            rowY += rowHeight;
            labelDate = new Label();
            labelDate.Name = "labelDate";
            labelDate.Text = "Date (วันที่จอง)";
            labelDate.AutoSize = false;
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            labelDate.Location = new Point(leftLabelX, rowY);
            labelDate.Size = new Size(labelWidth, 24);
            Controls.Add(labelDate);

            dateTimePickerDate = new DateTimePicker();
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(controlX, rowY - 4);
            dateTimePickerDate.Size = new Size(120, 27);
            Controls.Add(dateTimePickerDate);

            // StartTime
            rowY += rowHeight;
            labelStartTime = new Label();
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Text = "StartTime (เวลาเริ่ม)";
            labelStartTime.AutoSize = false;
            labelStartTime.TextAlign = ContentAlignment.MiddleLeft;
            labelStartTime.Location = new Point(leftLabelX, rowY);
            labelStartTime.Size = new Size(labelWidth, 24);
            Controls.Add(labelStartTime);

            dateTimePickerStartTime = new DateTimePicker();
            dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            dateTimePickerStartTime.Format = DateTimePickerFormat.Time;
            dateTimePickerStartTime.ShowUpDown = true;
            dateTimePickerStartTime.Location = new Point(controlX, rowY - 4);
            dateTimePickerStartTime.Size = new Size(120, 27);
            Controls.Add(dateTimePickerStartTime);

            // EndTime
            rowY += rowHeight;
            labelEndTime = new Label();
            labelEndTime.Name = "labelEndTime";
            labelEndTime.Text = "EndTime (เวลาสิ่นสุด)";
            labelEndTime.AutoSize = false;
            labelEndTime.TextAlign = ContentAlignment.MiddleLeft;
            labelEndTime.Location = new Point(leftLabelX, rowY);
            labelEndTime.Size = new Size(labelWidth, 24);
            Controls.Add(labelEndTime);

            dateTimePickerEndTime = new DateTimePicker();
            dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            dateTimePickerEndTime.Format = DateTimePickerFormat.Time;
            dateTimePickerEndTime.ShowUpDown = true;
            dateTimePickerEndTime.Location = new Point(controlX, rowY - 4);
            dateTimePickerEndTime.Size = new Size(120, 27);
            Controls.Add(dateTimePickerEndTime);

            // Purpose
            rowY += rowHeight;
            labelPurpose = new Label();
            labelPurpose.Name = "labelPurpose";
            labelPurpose.Text = "Purpose (วัตถุประสงค์การใช้ห้อง)";
            labelPurpose.AutoSize = false;
            labelPurpose.TextAlign = ContentAlignment.MiddleLeft;
            labelPurpose.Location = new Point(leftLabelX, rowY);
            labelPurpose.Size = new Size(labelWidth + 10, 24);
            Controls.Add(labelPurpose);

            textBoxPurpose = new TextBox();
            textBoxPurpose.Name = "textBoxPurpose";
            textBoxPurpose.Location = new Point(controlX, rowY - 4);
            textBoxPurpose.Size = new Size(360, 80);
            textBoxPurpose.Multiline = true;
            textBoxPurpose.ScrollBars = ScrollBars.Vertical;
            Controls.Add(textBoxPurpose);

            // Buttons
            buttonSave = new Button();
            buttonSave.Name = "buttonSave";
            buttonSave.Text = "Save";
            buttonSave.Location = new Point(controlX, rowY + 90);
            buttonSave.Size = new Size(80, 30);
            buttonSave.Click += ButtonSave_Click;
            Controls.Add(buttonSave);

            buttonUpdate = new Button();
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Text = "Update";
            buttonUpdate.Location = new Point(controlX + 90, rowY + 90);
            buttonUpdate.Size = new Size(80, 30);
            buttonUpdate.Click += ButtonUpdate_Click;
            Controls.Add(buttonUpdate);

            buttonDelete = new Button();
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Text = "Delete";
            buttonDelete.Location = new Point(controlX + 180, rowY + 90);
            buttonDelete.Size = new Size(80, 30);
            buttonDelete.Click += ButtonDelete_Click;
            Controls.Add(buttonDelete);

            buttonClear = new Button();
            buttonClear.Name = "buttonClear";
            buttonClear.Text = "Clear";
            buttonClear.Location = new Point(controlX + 270, rowY + 90);
            buttonClear.Size = new Size(80, 30);
            buttonClear.Click += ButtonClear_Click;
            Controls.Add(buttonClear);

            // DataGridView
            dataGridViewBookings = new DataGridView();
            dataGridViewBookings.Name = "dataGridViewBookings";
            dataGridViewBookings.Location = new Point(20, rowY + 140);
            dataGridViewBookings.Size = new Size(760, 320);
            dataGridViewBookings.ReadOnly = true;
            dataGridViewBookings.AllowUserToAddRows = false;
            dataGridViewBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBookings.MultiSelect = false;
            dataGridViewBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBookings.SelectionChanged += DataGridViewBookings_SelectionChanged;
            Controls.Add(dataGridViewBookings);

            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
