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
            this.btn_Them.Location = new System.Drawing.Point(13, 247);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(100, 47);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(125, 247);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(100, 47);
            this.btn_Xoa.TabIndex = 1;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Tim
            // 
            this.btn_Tim.Location = new System.Drawing.Point(235, 247);
            this.btn_Tim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(100, 47);
            this.btn_Tim.TabIndex = 2;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Giờ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã khu vực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kiểu thời tiết";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 159);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhiệt độ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Độ ẩm";
            // 
            // txtGio
            // 
            this.txtGio.Location = new System.Drawing.Point(140, 37);
            this.txtGio.Margin = new System.Windows.Forms.Padding(4);
            this.txtGio.Name = "txtGio";
            this.txtGio.Size = new System.Drawing.Size(195, 22);
            this.txtGio.TabIndex = 8;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(140, 71);
            this.txtMa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(195, 22);
            this.txtMa.TabIndex = 9;
            // 
            // txtKieutt
            // 
            this.txtKieutt.Location = new System.Drawing.Point(140, 113);
            this.txtKieutt.Margin = new System.Windows.Forms.Padding(4);
            this.txtKieutt.Name = "txtKieutt";
            this.txtKieutt.Size = new System.Drawing.Size(195, 22);
            this.txtKieutt.TabIndex = 10;
            // 
            // txtNhietdo
            // 
            this.txtNhietdo.Location = new System.Drawing.Point(140, 153);
            this.txtNhietdo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhietdo.Name = "txtNhietdo";
            this.txtNhietdo.Size = new System.Drawing.Size(195, 22);
            this.txtNhietdo.TabIndex = 11;
            // 
            // txtDoam
            // 
            this.txtDoam.Location = new System.Drawing.Point(140, 192);
            this.txtDoam.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoam.Name = "txtDoam";
            this.txtDoam.Size = new System.Drawing.Size(195, 22);
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
            this.datathoitiet.Location = new System.Drawing.Point(355, 37);
            this.datathoitiet.Margin = new System.Windows.Forms.Padding(4);
            this.datathoitiet.Name = "datathoitiet";
            this.datathoitiet.RowHeadersWidth = 51;
            this.datathoitiet.Size = new System.Drawing.Size(686, 396);
            this.datathoitiet.TabIndex = 13;
            // 
            // gio
            // 
            this.gio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gio.HeaderText = "Thời gian";
            this.gio.MinimumWidth = 6;
            this.gio.Name = "gio";
            // 
            // ma
            // 
            this.ma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ma.HeaderText = "Khu vực";
            this.ma.MinimumWidth = 6;
            this.ma.Name = "ma";
            // 
            // kieuthoitiet
            // 
            this.kieuthoitiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kieuthoitiet.HeaderText = "Kiểu thời tiết";
            this.kieuthoitiet.MinimumWidth = 6;
            this.kieuthoitiet.Name = "kieuthoitiet";
            // 
            // nhietdo
            // 
            this.nhietdo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nhietdo.HeaderText = "Nhiệt độ";
            this.nhietdo.MinimumWidth = 6;
            this.nhietdo.Name = "nhietdo";
            // 
            // doam
            // 
            this.doam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doam.HeaderText = "Độ ẩm";
            this.doam.MinimumWidth = 6;
            this.doam.Name = "doam";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 447);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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

