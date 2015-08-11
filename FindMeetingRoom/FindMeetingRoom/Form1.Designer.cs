namespace FindMeetingRoom
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindRoom = new System.Windows.Forms.Button();
            this.btnBookRoom = new System.Windows.Forms.Button();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radBtnLater = new System.Windows.Forms.RadioButton();
            this.radBtnNow = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopyEmail = new System.Windows.Forms.Button();
            this.dgvMeetingRoomStatus = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbFloorSelection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorkerLocator = new System.ComponentModel.BackgroundWorker();
            this.lblInformation = new System.Windows.Forms.Label();
            this.pictureBoxWait = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingRoomStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWait)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(90, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.OnDateTimeSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "End Time";
            // 
            // btnFindRoom
            // 
            this.btnFindRoom.Location = new System.Drawing.Point(254, 634);
            this.btnFindRoom.Name = "btnFindRoom";
            this.btnFindRoom.Size = new System.Drawing.Size(94, 49);
            this.btnFindRoom.TabIndex = 5;
            this.btnFindRoom.Text = "Find Rooms";
            this.btnFindRoom.UseVisualStyleBackColor = true;
            this.btnFindRoom.Click += new System.EventHandler(this.btnFindRoom_Click);
            // 
            // btnBookRoom
            // 
            this.btnBookRoom.Location = new System.Drawing.Point(681, 637);
            this.btnBookRoom.Name = "btnBookRoom";
            this.btnBookRoom.Size = new System.Drawing.Size(94, 46);
            this.btnBookRoom.TabIndex = 8;
            this.btnBookRoom.Text = "Book";
            this.btnBookRoom.UseVisualStyleBackColor = true;
            this.btnBookRoom.Visible = false;
            this.btnBookRoom.Click += new System.EventHandler(this.btnBookRoom_Click);
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(90, 62);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(77, 21);
            this.cmbStartTime.TabIndex = 9;
            this.cmbStartTime.SelectedIndexChanged += new System.EventHandler(this.OnStartTimeSelected);
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndTime.FormattingEnabled = true;
            this.cmbEndTime.Location = new System.Drawing.Point(90, 96);
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(77, 21);
            this.cmbEndTime.TabIndex = 9;
            this.cmbEndTime.SelectedIndexChanged += new System.EventHandler(this.OnEndTimeSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radBtnLater);
            this.groupBox1.Controls.Add(this.radBtnNow);
            this.groupBox1.Location = new System.Drawing.Point(26, 497);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 131);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meeting Preference";
            // 
            // radBtnLater
            // 
            this.radBtnLater.AutoSize = true;
            this.radBtnLater.Location = new System.Drawing.Point(21, 86);
            this.radBtnLater.Name = "radBtnLater";
            this.radBtnLater.Size = new System.Drawing.Size(49, 17);
            this.radBtnLater.TabIndex = 1;
            this.radBtnLater.TabStop = true;
            this.radBtnLater.Text = "Later";
            this.radBtnLater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnLater.UseVisualStyleBackColor = true;
            // 
            // radBtnNow
            // 
            this.radBtnNow.AutoSize = true;
            this.radBtnNow.Checked = true;
            this.radBtnNow.Location = new System.Drawing.Point(21, 47);
            this.radBtnNow.Name = "radBtnNow";
            this.radBtnNow.Size = new System.Drawing.Size(47, 17);
            this.radBtnNow.TabIndex = 0;
            this.radBtnNow.TabStop = true;
            this.radBtnNow.Text = "Now";
            this.radBtnNow.UseVisualStyleBackColor = true;
            this.radBtnNow.CheckedChanged += new System.EventHandler(this.radBtnNow_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.cmbEndTime);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbStartTime);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(418, 497);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 131);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Custom";
            // 
            // chkBoxSelectAll
            // 
            this.chkBoxSelectAll.AutoSize = true;
            this.chkBoxSelectAll.Location = new System.Drawing.Point(24, 143);
            this.chkBoxSelectAll.Name = "chkBoxSelectAll";
            this.chkBoxSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chkBoxSelectAll.TabIndex = 11;
            this.chkBoxSelectAll.Text = "Select All";
            this.chkBoxSelectAll.UseVisualStyleBackColor = true;
            this.chkBoxSelectAll.CheckedChanged += new System.EventHandler(this.chkBoxSelectAll_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lao UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(171, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 45);
            this.label4.TabIndex = 12;
            this.label4.Text = "Orion Meeting Room Locator";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCopyEmail
            // 
            this.btnCopyEmail.Location = new System.Drawing.Point(26, 634);
            this.btnCopyEmail.Name = "btnCopyEmail";
            this.btnCopyEmail.Size = new System.Drawing.Size(94, 49);
            this.btnCopyEmail.TabIndex = 5;
            this.btnCopyEmail.Text = "Copy";
            this.btnCopyEmail.UseVisualStyleBackColor = true;
            this.btnCopyEmail.Click += new System.EventHandler(this.btnCopyMail);
            // 
            // dgvMeetingRoomStatus
            // 
            this.dgvMeetingRoomStatus.AllowUserToAddRows = false;
            this.dgvMeetingRoomStatus.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeetingRoomStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMeetingRoomStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeetingRoomStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colRoomName,
            this.colEmail,
            this.colStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMeetingRoomStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMeetingRoomStatus.Location = new System.Drawing.Point(26, 166);
            this.dgvMeetingRoomStatus.Name = "dgvMeetingRoomStatus";
            this.dgvMeetingRoomStatus.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeetingRoomStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMeetingRoomStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetingRoomStatus.Size = new System.Drawing.Size(749, 325);
            this.dgvMeetingRoomStatus.TabIndex = 13;
            this.dgvMeetingRoomStatus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnDGVCellClick);
            this.dgvMeetingRoomStatus.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnDGVCellFormatting);
            // 
            // colSelect
            // 
            this.colSelect.FalseValue = "false";
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.ReadOnly = true;
            this.colSelect.TrueValue = "true";
            // 
            // colRoomName
            // 
            this.colRoomName.HeaderText = "Room";
            this.colRoomName.Name = "colRoomName";
            this.colRoomName.ReadOnly = true;
            this.colRoomName.Width = 250;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Visible = false;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(418, 634);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 49);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbFloorSelection
            // 
            this.cmbFloorSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloorSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFloorSelection.Font = new System.Drawing.Font("Lao UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFloorSelection.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbFloorSelection.FormattingEnabled = true;
            this.cmbFloorSelection.Items.AddRange(new object[] {
            "GF",
            "1st   Floor",
            "2nd Floor",
            "3rd  Floor",
            "4th  Floor",
            "5th  Floor",
            "6th  Floor",
            "7th  Floor"});
            this.cmbFloorSelection.Location = new System.Drawing.Point(224, 78);
            this.cmbFloorSelection.Name = "cmbFloorSelection";
            this.cmbFloorSelection.Size = new System.Drawing.Size(175, 53);
            this.cmbFloorSelection.TabIndex = 14;
            this.cmbFloorSelection.SelectedIndexChanged += new System.EventHandler(this.OnSelectedFloorChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lao UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(19, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 37);
            this.label5.TabIndex = 12;
            this.label5.Text = "Select Floor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // backgroundWorkerLocator
            // 
            this.backgroundWorkerLocator.WorkerReportsProgress = true;
            this.backgroundWorkerLocator.WorkerSupportsCancellation = true;
            this.backgroundWorkerLocator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWorkFindRoom);
            this.backgroundWorkerLocator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnFindRoomCompleted);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Lao UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblInformation.Location = new System.Drawing.Point(475, 88);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(126, 30);
            this.lblInformation.TabIndex = 12;
            this.lblInformation.Text = "Information";
            this.lblInformation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxWait
            // 
            this.pictureBoxWait.Location = new System.Drawing.Point(411, 83);
            this.pictureBoxWait.Name = "pictureBoxWait";
            this.pictureBoxWait.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxWait.TabIndex = 15;
            this.pictureBoxWait.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 695);
            this.Controls.Add(this.pictureBoxWait);
            this.Controls.Add(this.cmbFloorSelection);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvMeetingRoomStatus);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkBoxSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBookRoom);
            this.Controls.Add(this.btnCopyEmail);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFindRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Meeting Room";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetingRoomStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFindRoom;
        private System.Windows.Forms.Button btnBookRoom;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.ComboBox cmbEndTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radBtnLater;
        private System.Windows.Forms.RadioButton radBtnNow;
        private System.Windows.Forms.CheckBox chkBoxSelectAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopyEmail;
        private System.Windows.Forms.DataGridView dgvMeetingRoomStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbFloorSelection;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLocator;
        private System.Windows.Forms.PictureBox pictureBoxWait;
        private System.Windows.Forms.Label lblInformation;
    }
}

