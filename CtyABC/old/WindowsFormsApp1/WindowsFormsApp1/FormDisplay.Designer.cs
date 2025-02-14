namespace WindowsFormsApp1
{
    partial class FormDisplay
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
            this.buttonHangHoa = new System.Windows.Forms.Button();
            this.buttonKhachHang = new System.Windows.Forms.Button();
            this.buttonPThuChi = new System.Windows.Forms.Button();
            this.buttonHoaDon = new System.Windows.Forms.Button();
            this.buttonCTHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonHangHoa
            // 
            this.buttonHangHoa.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHangHoa.Location = new System.Drawing.Point(788, 55);
            this.buttonHangHoa.Name = "buttonHangHoa";
            this.buttonHangHoa.Size = new System.Drawing.Size(182, 62);
            this.buttonHangHoa.TabIndex = 0;
            this.buttonHangHoa.Text = "Hàng Hóa";
            this.buttonHangHoa.UseVisualStyleBackColor = true;
            this.buttonHangHoa.Click += new System.EventHandler(this.buttonHangHoa_Click);
            // 
            // buttonKhachHang
            // 
            this.buttonKhachHang.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKhachHang.Location = new System.Drawing.Point(788, 123);
            this.buttonKhachHang.Name = "buttonKhachHang";
            this.buttonKhachHang.Size = new System.Drawing.Size(182, 62);
            this.buttonKhachHang.TabIndex = 1;
            this.buttonKhachHang.Text = "Khách Hàng";
            this.buttonKhachHang.UseVisualStyleBackColor = true;
            this.buttonKhachHang.Click += new System.EventHandler(this.buttonKhachHang_Click);
            // 
            // buttonPThuChi
            // 
            this.buttonPThuChi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPThuChi.Location = new System.Drawing.Point(788, 194);
            this.buttonPThuChi.Name = "buttonPThuChi";
            this.buttonPThuChi.Size = new System.Drawing.Size(182, 62);
            this.buttonPThuChi.TabIndex = 2;
            this.buttonPThuChi.Text = "Phiếu Thu Chi";
            this.buttonPThuChi.UseVisualStyleBackColor = true;
            this.buttonPThuChi.Click += new System.EventHandler(this.buttonPThuChi_Click);
            // 
            // buttonHoaDon
            // 
            this.buttonHoaDon.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHoaDon.Location = new System.Drawing.Point(788, 262);
            this.buttonHoaDon.Name = "buttonHoaDon";
            this.buttonHoaDon.Size = new System.Drawing.Size(182, 62);
            this.buttonHoaDon.TabIndex = 3;
            this.buttonHoaDon.Text = "Hóa Đơn";
            this.buttonHoaDon.UseVisualStyleBackColor = true;
            this.buttonHoaDon.Click += new System.EventHandler(this.buttonHoaDon_Click);
            // 
            // buttonCTHD
            // 
            this.buttonCTHD.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCTHD.Location = new System.Drawing.Point(788, 330);
            this.buttonCTHD.Name = "buttonCTHD";
            this.buttonCTHD.Size = new System.Drawing.Size(182, 62);
            this.buttonCTHD.TabIndex = 4;
            this.buttonCTHD.Text = "Chi Tiết Hóa Đơn";
            this.buttonCTHD.UseVisualStyleBackColor = true;
            this.buttonCTHD.Click += new System.EventHandler(this.buttonCTHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 47);
            this.label1.TabIndex = 5;
            this.label1.Text = "Công ty ABC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 60F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(573, 157);
            this.label2.TabIndex = 6;
            this.label2.Text = "Wellcome";
            // 
            // buttonThoat
            // 
            this.buttonThoat.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.Location = new System.Drawing.Point(788, 398);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(182, 62);
            this.buttonThoat.TabIndex = 7;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // FormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 521);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCTHD);
            this.Controls.Add(this.buttonHoaDon);
            this.Controls.Add(this.buttonPThuChi);
            this.Controls.Add(this.buttonKhachHang);
            this.Controls.Add(this.buttonHangHoa);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDisplay";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHangHoa;
        private System.Windows.Forms.Button buttonKhachHang;
        private System.Windows.Forms.Button buttonPThuChi;
        private System.Windows.Forms.Button buttonHoaDon;
        private System.Windows.Forms.Button buttonCTHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonThoat;
    }
}

