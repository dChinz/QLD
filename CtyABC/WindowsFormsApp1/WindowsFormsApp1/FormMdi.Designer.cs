namespace WindowsFormsApp1
{
    partial class FormMdi
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
            this.buttonCapnhat = new System.Windows.Forms.Button();
            this.buttonXuly = new System.Windows.Forms.Button();
            this.buttonBaocao = new System.Windows.Forms.Button();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "CÔNG TY ABC";
            // 
            // buttonCapnhat
            // 
            this.buttonCapnhat.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapnhat.Location = new System.Drawing.Point(814, 62);
            this.buttonCapnhat.Name = "buttonCapnhat";
            this.buttonCapnhat.Size = new System.Drawing.Size(312, 119);
            this.buttonCapnhat.TabIndex = 1;
            this.buttonCapnhat.Text = "Cập Nhật";
            this.buttonCapnhat.UseVisualStyleBackColor = true;
            this.buttonCapnhat.Click += new System.EventHandler(this.buttonCapnhat_Click);
            // 
            // buttonXuly
            // 
            this.buttonXuly.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXuly.Location = new System.Drawing.Point(814, 187);
            this.buttonXuly.Name = "buttonXuly";
            this.buttonXuly.Size = new System.Drawing.Size(312, 119);
            this.buttonXuly.TabIndex = 2;
            this.buttonXuly.Text = "Xử Lý";
            this.buttonXuly.UseVisualStyleBackColor = true;
            this.buttonXuly.Click += new System.EventHandler(this.buttonXuly_Click);
            // 
            // buttonBaocao
            // 
            this.buttonBaocao.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBaocao.Location = new System.Drawing.Point(814, 312);
            this.buttonBaocao.Name = "buttonBaocao";
            this.buttonBaocao.Size = new System.Drawing.Size(312, 119);
            this.buttonBaocao.TabIndex = 3;
            this.buttonBaocao.Text = "Báo Cáo";
            this.buttonBaocao.UseVisualStyleBackColor = true;
            this.buttonBaocao.Click += new System.EventHandler(this.buttonBaocao_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.Location = new System.Drawing.Point(814, 437);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(312, 119);
            this.buttonThoat.TabIndex = 4;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // FormMdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 652);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.buttonBaocao);
            this.Controls.Add(this.buttonXuly);
            this.Controls.Add(this.buttonCapnhat);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormMdi";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCapnhat;
        private System.Windows.Forms.Button buttonXuly;
        private System.Windows.Forms.Button buttonBaocao;
        private System.Windows.Forms.Button buttonThoat;
    }
}

