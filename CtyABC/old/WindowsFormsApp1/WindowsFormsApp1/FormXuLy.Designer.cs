namespace WindowsFormsApp1
{
    partial class FormXuLy
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
            this.buttonKhachHang = new System.Windows.Forms.Button();
            this.buttonHangHoa = new System.Windows.Forms.Button();
            this.buttonHoaDon = new System.Windows.Forms.Button();
            this.buttonPThuChi = new System.Windows.Forms.Button();
            this.labelKH = new System.Windows.Forms.Label();
            this.labelHang = new System.Windows.Forms.Label();
            this.labelHD = new System.Windows.Forms.Label();
            this.labelPThuCHi = new System.Windows.Forms.Label();
            this.labelCTHD = new System.Windows.Forms.Label();
            this.buttonCTHD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Trùng Lặp";
            // 
            // buttonKhachHang
            // 
            this.buttonKhachHang.Location = new System.Drawing.Point(18, 55);
            this.buttonKhachHang.Name = "buttonKhachHang";
            this.buttonKhachHang.Size = new System.Drawing.Size(123, 50);
            this.buttonKhachHang.TabIndex = 1;
            this.buttonKhachHang.Text = "KH";
            this.buttonKhachHang.UseVisualStyleBackColor = true;
            this.buttonKhachHang.Click += new System.EventHandler(this.buttonKhachHang_Click);
            // 
            // buttonHangHoa
            // 
            this.buttonHangHoa.Location = new System.Drawing.Point(241, 55);
            this.buttonHangHoa.Name = "buttonHangHoa";
            this.buttonHangHoa.Size = new System.Drawing.Size(123, 50);
            this.buttonHangHoa.TabIndex = 2;
            this.buttonHangHoa.Text = "Hàng";
            this.buttonHangHoa.UseVisualStyleBackColor = true;
            this.buttonHangHoa.Click += new System.EventHandler(this.buttonHangHoa_Click);
            // 
            // buttonHoaDon
            // 
            this.buttonHoaDon.Location = new System.Drawing.Point(461, 55);
            this.buttonHoaDon.Name = "buttonHoaDon";
            this.buttonHoaDon.Size = new System.Drawing.Size(123, 50);
            this.buttonHoaDon.TabIndex = 3;
            this.buttonHoaDon.Text = "Hóa Đơn";
            this.buttonHoaDon.UseVisualStyleBackColor = true;
            this.buttonHoaDon.Click += new System.EventHandler(this.buttonHoaDon_Click);
            // 
            // buttonPThuChi
            // 
            this.buttonPThuChi.Location = new System.Drawing.Point(692, 55);
            this.buttonPThuChi.Name = "buttonPThuChi";
            this.buttonPThuChi.Size = new System.Drawing.Size(123, 50);
            this.buttonPThuChi.TabIndex = 4;
            this.buttonPThuChi.Text = "PThu/Chi";
            this.buttonPThuChi.UseVisualStyleBackColor = true;
            this.buttonPThuChi.Click += new System.EventHandler(this.buttonPThuChi_Click);
            // 
            // labelKH
            // 
            this.labelKH.AutoSize = true;
            this.labelKH.Location = new System.Drawing.Point(147, 66);
            this.labelKH.Name = "labelKH";
            this.labelKH.Size = new System.Drawing.Size(0, 29);
            this.labelKH.TabIndex = 5;
            // 
            // labelHang
            // 
            this.labelHang.AutoSize = true;
            this.labelHang.Location = new System.Drawing.Point(370, 66);
            this.labelHang.Name = "labelHang";
            this.labelHang.Size = new System.Drawing.Size(0, 29);
            this.labelHang.TabIndex = 6;
            // 
            // labelHD
            // 
            this.labelHD.AutoSize = true;
            this.labelHD.Location = new System.Drawing.Point(590, 68);
            this.labelHD.Name = "labelHD";
            this.labelHD.Size = new System.Drawing.Size(0, 29);
            this.labelHD.TabIndex = 7;
            // 
            // labelPThuCHi
            // 
            this.labelPThuCHi.AutoSize = true;
            this.labelPThuCHi.Location = new System.Drawing.Point(821, 66);
            this.labelPThuCHi.Name = "labelPThuCHi";
            this.labelPThuCHi.Size = new System.Drawing.Size(0, 29);
            this.labelPThuCHi.TabIndex = 8;
            // 
            // labelCTHD
            // 
            this.labelCTHD.AutoSize = true;
            this.labelCTHD.Location = new System.Drawing.Point(1046, 66);
            this.labelCTHD.Name = "labelCTHD";
            this.labelCTHD.Size = new System.Drawing.Size(0, 29);
            this.labelCTHD.TabIndex = 10;
            // 
            // buttonCTHD
            // 
            this.buttonCTHD.Location = new System.Drawing.Point(917, 55);
            this.buttonCTHD.Name = "buttonCTHD";
            this.buttonCTHD.Size = new System.Drawing.Size(123, 50);
            this.buttonCTHD.TabIndex = 9;
            this.buttonCTHD.Text = "CTHD";
            this.buttonCTHD.UseVisualStyleBackColor = true;
            this.buttonCTHD.Click += new System.EventHandler(this.buttonCTHD_Click);
            // 
            // FormXuLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 586);
            this.Controls.Add(this.labelCTHD);
            this.Controls.Add(this.buttonCTHD);
            this.Controls.Add(this.labelPThuCHi);
            this.Controls.Add(this.labelHD);
            this.Controls.Add(this.labelHang);
            this.Controls.Add(this.labelKH);
            this.Controls.Add(this.buttonPThuChi);
            this.Controls.Add(this.buttonHoaDon);
            this.Controls.Add(this.buttonHangHoa);
            this.Controls.Add(this.buttonKhachHang);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormXuLy";
            this.Text = "FormXuLy";
            this.Load += new System.EventHandler(this.FormXuLy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKhachHang;
        private System.Windows.Forms.Button buttonHangHoa;
        private System.Windows.Forms.Button buttonHoaDon;
        private System.Windows.Forms.Button buttonPThuChi;
        private System.Windows.Forms.Label labelKH;
        private System.Windows.Forms.Label labelHang;
        private System.Windows.Forms.Label labelHD;
        private System.Windows.Forms.Label labelPThuCHi;
        private System.Windows.Forms.Label labelCTHD;
        private System.Windows.Forms.Button buttonCTHD;
    }
}