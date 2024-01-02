namespace Tx2Ca2_deGiang
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
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGio = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtKieutt = new System.Windows.Forms.TextBox();
            this.txtNhietdo = new System.Windows.Forms.TextBox();
            this.txtDoam = new System.Windows.Forms.TextBox();
            this.datathoitiet = new System.Windows.Forms.DataGridView();
            this.gio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kieuthoitiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhietdo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datathoitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(622, 33);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(622, 100);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 1;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Tim
            // 
            this.btn_Tim.Location = new System.Drawing.Point(622, 164);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(75, 23);
            this.btn_Tim.TabIndex = 2;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Giờ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã khu vực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kiểu thời tiết";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhiệt độ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Độ ẩm";
            // 
            // txtGio
            // 
            this.txtGio.Location = new System.Drawing.Point(131, 33);
            this.txtGio.Name = "txtGio";
            this.txtGio.Size = new System.Drawing.Size(129, 20);
            this.txtGio.TabIndex = 8;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(131, 100);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(129, 20);
            this.txtMa.TabIndex = 9;
            // 
            // txtKieutt
            // 
            this.txtKieutt.Location = new System.Drawing.Point(131, 164);
            this.txtKieutt.Name = "txtKieutt";
            this.txtKieutt.Size = new System.Drawing.Size(129, 20);
            this.txtKieutt.TabIndex = 10;
            // 
            // txtNhietdo
            // 
            this.txtNhietdo.Location = new System.Drawing.Point(412, 25);
            this.txtNhietdo.Name = "txtNhietdo";
            this.txtNhietdo.Size = new System.Drawing.Size(100, 20);
            this.txtNhietdo.TabIndex = 11;
            // 
            // txtDoam
            // 
            this.txtDoam.Location = new System.Drawing.Point(412, 100);
            this.txtDoam.Name = "txtDoam";
            this.txtDoam.Size = new System.Drawing.Size(100, 20);
            this.txtDoam.TabIndex = 12;
            // 
            // datathoitiet
            // 
            this.datathoitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datathoitiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gio,
            this.ma,
            this.kieuthoitiet,
            this.nhietdo,
            this.doam});
            this.datathoitiet.Location = new System.Drawing.Point(38, 248);
            this.datathoitiet.Name = "datathoitiet";
            this.datathoitiet.Size = new System.Drawing.Size(712, 150);
            this.datathoitiet.TabIndex = 13;
            // 
            // gio
            // 
            this.gio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gio.HeaderText = "Thời gian";
            this.gio.Name = "gio";
            // 
            // ma
            // 
            this.ma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ma.HeaderText = "Khu vực";
            this.ma.Name = "ma";
            // 
            // kieuthoitiet
            // 
            this.kieuthoitiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kieuthoitiet.HeaderText = "Kiểu thời tiết";
            this.kieuthoitiet.Name = "kieuthoitiet";
            // 
            // nhietdo
            // 
            this.nhietdo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nhietdo.HeaderText = "Nhiệt độ";
            this.nhietdo.Name = "nhietdo";
            // 
            // doam
            // 
            this.doam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doam.HeaderText = "Độ ẩm";
            this.doam.Name = "doam";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.datathoitiet);
            this.Controls.Add(this.txtDoam);
            this.Controls.Add(this.txtNhietdo);
            this.Controls.Add(this.txtKieutt);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.txtGio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datathoitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGio;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtKieutt;
        private System.Windows.Forms.TextBox txtNhietdo;
        private System.Windows.Forms.TextBox txtDoam;
        private System.Windows.Forms.DataGridView datathoitiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn gio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn kieuthoitiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhietdo;
        private System.Windows.Forms.DataGridViewTextBoxColumn doam;
    }
}

