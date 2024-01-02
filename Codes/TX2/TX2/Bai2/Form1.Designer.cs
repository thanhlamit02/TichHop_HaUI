namespace Bai2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGio = new System.Windows.Forms.TextBox();
            this.txtMakv = new System.Windows.Forms.TextBox();
            this.txtKieuthoitiet = new System.Windows.Forms.TextBox();
            this.txtNhietdo = new System.Windows.Forms.TextBox();
            this.txtDoam = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.datathoitiet = new System.Windows.Forms.DataGridView();
            this.gio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kieuthoitiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhietdo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datathoitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giờ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã khu vực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kiểu thời tiết";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhiệt độ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Độ ẩm";
            // 
            // txtGio
            // 
            this.txtGio.Location = new System.Drawing.Point(160, 38);
            this.txtGio.Name = "txtGio";
            this.txtGio.Size = new System.Drawing.Size(240, 22);
            this.txtGio.TabIndex = 5;
            // 
            // txtMakv
            // 
            this.txtMakv.Location = new System.Drawing.Point(160, 97);
            this.txtMakv.Name = "txtMakv";
            this.txtMakv.Size = new System.Drawing.Size(240, 22);
            this.txtMakv.TabIndex = 6;
            // 
            // txtKieuthoitiet
            // 
            this.txtKieuthoitiet.Location = new System.Drawing.Point(160, 158);
            this.txtKieuthoitiet.Name = "txtKieuthoitiet";
            this.txtKieuthoitiet.Size = new System.Drawing.Size(240, 22);
            this.txtKieuthoitiet.TabIndex = 7;
            // 
            // txtNhietdo
            // 
            this.txtNhietdo.Location = new System.Drawing.Point(160, 226);
            this.txtNhietdo.Name = "txtNhietdo";
            this.txtNhietdo.Size = new System.Drawing.Size(240, 22);
            this.txtNhietdo.TabIndex = 8;
            // 
            // txtDoam
            // 
            this.txtDoam.Location = new System.Drawing.Point(160, 287);
            this.txtDoam.Name = "txtDoam";
            this.txtDoam.Size = new System.Drawing.Size(240, 22);
            this.txtDoam.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(44, 358);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 48);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(289, 358);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 48);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(166, 358);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(111, 48);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
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
            this.datathoitiet.Location = new System.Drawing.Point(425, 38);
            this.datathoitiet.Name = "datathoitiet";
            this.datathoitiet.RowHeadersWidth = 51;
            this.datathoitiet.RowTemplate.Height = 24;
            this.datathoitiet.Size = new System.Drawing.Size(886, 368);
            this.datathoitiet.TabIndex = 13;
            // 
            // gio
            // 
            this.gio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gio.DataPropertyName = "gio";
            this.gio.HeaderText = "Thời gian";
            this.gio.MinimumWidth = 6;
            this.gio.Name = "gio";
            // 
            // ma
            // 
            this.ma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ma.DataPropertyName = "ma";
            this.ma.HeaderText = "Khu vực";
            this.ma.MinimumWidth = 6;
            this.ma.Name = "ma";
            // 
            // kieuthoitiet
            // 
            this.kieuthoitiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kieuthoitiet.DataPropertyName = "kieuthoitiet";
            this.kieuthoitiet.HeaderText = "Kiểu thời tiết";
            this.kieuthoitiet.MinimumWidth = 6;
            this.kieuthoitiet.Name = "kieuthoitiet";
            // 
            // nhietdo
            // 
            this.nhietdo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nhietdo.DataPropertyName = "nhietdo";
            this.nhietdo.HeaderText = "Nhiệt độ";
            this.nhietdo.MinimumWidth = 6;
            this.nhietdo.Name = "nhietdo";
            // 
            // doam
            // 
            this.doam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doam.DataPropertyName = "doam";
            this.doam.HeaderText = "Độ ẩm";
            this.doam.MinimumWidth = 6;
            this.doam.Name = "doam";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 495);
            this.Controls.Add(this.datathoitiet);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDoam);
            this.Controls.Add(this.txtNhietdo);
            this.Controls.Add(this.txtKieuthoitiet);
            this.Controls.Add(this.txtMakv);
            this.Controls.Add(this.txtGio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.datathoitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGio;
        private System.Windows.Forms.TextBox txtMakv;
        private System.Windows.Forms.TextBox txtKieuthoitiet;
        private System.Windows.Forms.TextBox txtNhietdo;
        private System.Windows.Forms.TextBox txtDoam;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView datathoitiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn gio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn kieuthoitiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhietdo;
        private System.Windows.Forms.DataGridViewTextBoxColumn doam;
    }
}

