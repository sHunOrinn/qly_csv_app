namespace qly_csv_app.UI.Admin
{
    partial class update_event
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
            this.groupBox_event_info = new System.Windows.Forms.GroupBox();
            this.label_event_id = new System.Windows.Forms.Label();
            this.txt_event_id = new System.Windows.Forms.TextBox();
            this.label_event_name = new System.Windows.Forms.Label();
            this.txt_event_name = new System.Windows.Forms.TextBox();
            this.label_event_date = new System.Windows.Forms.Label();
            this.dtp_event_date = new System.Windows.Forms.DateTimePicker();
            this.label_description = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.label_participants = new System.Windows.Forms.Label();
            this.txt_participants = new System.Windows.Forms.TextBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.groupBox_event_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_event_info
            // 
            this.groupBox_event_info.Controls.Add(this.txt_participants);
            this.groupBox_event_info.Controls.Add(this.label_participants);
            this.groupBox_event_info.Controls.Add(this.txt_description);
            this.groupBox_event_info.Controls.Add(this.label_description);
            this.groupBox_event_info.Controls.Add(this.dtp_event_date);
            this.groupBox_event_info.Controls.Add(this.label_event_date);
            this.groupBox_event_info.Controls.Add(this.txt_event_name);
            this.groupBox_event_info.Controls.Add(this.label_event_name);
            this.groupBox_event_info.Controls.Add(this.txt_event_id);
            this.groupBox_event_info.Controls.Add(this.label_event_id);
            this.groupBox_event_info.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_event_info.Location = new System.Drawing.Point(30, 70);
            this.groupBox_event_info.Name = "groupBox_event_info";
            this.groupBox_event_info.Size = new System.Drawing.Size(520, 320);
            this.groupBox_event_info.TabIndex = 0;
            this.groupBox_event_info.TabStop = false;
            this.groupBox_event_info.Text = "Thông tin sự kiện";
            // 
            // label_event_id
            // 
            this.label_event_id.AutoSize = true;
            this.label_event_id.Location = new System.Drawing.Point(20, 35);
            this.label_event_id.Name = "label_event_id";
            this.label_event_id.Size = new System.Drawing.Size(29, 23);
            this.label_event_id.TabIndex = 0;
            this.label_event_id.Text = "ID:";
            // 
            // txt_event_id
            // 
            this.txt_event_id.BackColor = System.Drawing.Color.LightGray;
            this.txt_event_id.Location = new System.Drawing.Point(150, 32);
            this.txt_event_id.Name = "txt_event_id";
            this.txt_event_id.ReadOnly = true;
            this.txt_event_id.Size = new System.Drawing.Size(100, 30);
            this.txt_event_id.TabIndex = 1;
            // 
            // label_event_name
            // 
            this.label_event_name.AutoSize = true;
            this.label_event_name.Location = new System.Drawing.Point(20, 75);
            this.label_event_name.Name = "label_event_name";
            this.label_event_name.Size = new System.Drawing.Size(110, 23);
            this.label_event_name.TabIndex = 2;
            this.label_event_name.Text = "Tên sự kiện:*";
            // 
            // txt_event_name
            // 
            this.txt_event_name.Location = new System.Drawing.Point(150, 72);
            this.txt_event_name.MaxLength = 255;
            this.txt_event_name.Name = "txt_event_name";
            this.txt_event_name.Size = new System.Drawing.Size(350, 30);
            this.txt_event_name.TabIndex = 3;
            // 
            // label_event_date
            // 
            this.label_event_date.AutoSize = true;
            this.label_event_date.Location = new System.Drawing.Point(20, 115);
            this.label_event_date.Name = "label_event_date";
            this.label_event_date.Size = new System.Drawing.Size(124, 23);
            this.label_event_date.TabIndex = 4;
            this.label_event_date.Text = "Ngày tổ chức:*";
            // 
            // dtp_event_date
            // 
            this.dtp_event_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_event_date.Location = new System.Drawing.Point(150, 112);
            this.dtp_event_date.Name = "dtp_event_date";
            this.dtp_event_date.Size = new System.Drawing.Size(200, 30);
            this.dtp_event_date.TabIndex = 5;
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(20, 155);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(62, 23);
            this.label_description.TabIndex = 6;
            this.label_description.Text = "Mô tả:";
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(150, 152);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_description.Size = new System.Drawing.Size(350, 100);
            this.txt_description.TabIndex = 7;
            // 
            // label_participants
            // 
            this.label_participants.AutoSize = true;
            this.label_participants.Location = new System.Drawing.Point(20, 270);
            this.label_participants.Name = "label_participants";
            this.label_participants.Size = new System.Drawing.Size(99, 23);
            this.label_participants.TabIndex = 8;
            this.label_participants.Text = "Số lượng TG:";
            // 
            // txt_participants
            // 
            this.txt_participants.BackColor = System.Drawing.Color.LightGray;
            this.txt_participants.Location = new System.Drawing.Point(150, 267);
            this.txt_participants.Name = "txt_participants";
            this.txt_participants.ReadOnly = true;
            this.txt_participants.Size = new System.Drawing.Size(100, 30);
            this.txt_participants.TabIndex = 9;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_update.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(300, 410);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(120, 40);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "Cập nhật";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_cancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(430, 410);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 40);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.label_title.Location = new System.Drawing.Point(200, 20);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(200, 38);
            this.label_title.TabIndex = 3;
            this.label_title.Text = "Cập nhật sự kiện";
            // 
            // update_event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 470);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.groupBox_event_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "update_event";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật sự kiện";
            this.groupBox_event_info.ResumeLayout(false);
            this.groupBox_event_info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_event_info;
        private System.Windows.Forms.Label label_event_id;
        private System.Windows.Forms.TextBox txt_event_id;
        private System.Windows.Forms.Label label_event_name;
        private System.Windows.Forms.TextBox txt_event_name;
        private System.Windows.Forms.Label label_event_date;
        private System.Windows.Forms.DateTimePicker dtp_event_date;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label label_participants;
        private System.Windows.Forms.TextBox txt_participants;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label_title;
    }
}