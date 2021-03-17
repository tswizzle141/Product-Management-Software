namespace QLSP
{
    partial class f001_dang_nhap
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
            this.m_txt_taikhoan = new System.Windows.Forms.TextBox();
            this.m_txt_matkhau = new System.Windows.Forms.TextBox();
            this.m_rdb_admin = new System.Windows.Forms.RadioButton();
            this.m_rdb_user = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmd_question = new System.Windows.Forms.Button();
            this.m_cmd_thoat = new System.Windows.Forms.Button();
            this.m_cmd_dangnhap = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txt_taikhoan
            // 
            this.m_txt_taikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txt_taikhoan.Location = new System.Drawing.Point(575, 144);
            this.m_txt_taikhoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_txt_taikhoan.Name = "m_txt_taikhoan";
            this.m_txt_taikhoan.Size = new System.Drawing.Size(260, 26);
            this.m_txt_taikhoan.TabIndex = 1;
            // 
            // m_txt_matkhau
            // 
            this.m_txt_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txt_matkhau.Location = new System.Drawing.Point(575, 190);
            this.m_txt_matkhau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_txt_matkhau.Name = "m_txt_matkhau";
            this.m_txt_matkhau.PasswordChar = '*';
            this.m_txt_matkhau.Size = new System.Drawing.Size(260, 26);
            this.m_txt_matkhau.TabIndex = 2;
            // 
            // m_rdb_admin
            // 
            this.m_rdb_admin.AutoSize = true;
            this.m_rdb_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_rdb_admin.Location = new System.Drawing.Point(575, 250);
            this.m_rdb_admin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_rdb_admin.Name = "m_rdb_admin";
            this.m_rdb_admin.Size = new System.Drawing.Size(77, 24);
            this.m_rdb_admin.TabIndex = 3;
            this.m_rdb_admin.TabStop = true;
            this.m_rdb_admin.Text = "Admin";
            this.m_rdb_admin.UseVisualStyleBackColor = true;
            this.m_rdb_admin.CheckedChanged += new System.EventHandler(this.m_rdb_admin_CheckedChanged);
            // 
            // m_rdb_user
            // 
            this.m_rdb_user.AutoSize = true;
            this.m_rdb_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_rdb_user.Location = new System.Drawing.Point(709, 250);
            this.m_rdb_user.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_rdb_user.Name = "m_rdb_user";
            this.m_rdb_user.Size = new System.Drawing.Size(114, 24);
            this.m_rdb_user.TabIndex = 4;
            this.m_rdb_user.TabStop = true;
            this.m_rdb_user.Text = "Người dùng";
            this.m_rdb_user.UseVisualStyleBackColor = true;
            this.m_rdb_user.CheckedChanged += new System.EventHandler(this.m_rdb_user_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(388, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên đăng nhập :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(443, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mật khẩu :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(571, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 39);
            this.label3.TabIndex = 7;
            this.label3.Text = "ĐĂNG NHẬP";
            // 
            // m_cmd_question
            // 
            this.m_cmd_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmd_question.Image = global::QLSP.Properties.Resources.anh;
            this.m_cmd_question.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_cmd_question.Location = new System.Drawing.Point(769, 310);
            this.m_cmd_question.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_cmd_question.Name = "m_cmd_question";
            this.m_cmd_question.Size = new System.Drawing.Size(109, 38);
            this.m_cmd_question.TabIndex = 10;
            this.m_cmd_question.Text = "      Hỏi đáp";
            this.m_cmd_question.UseVisualStyleBackColor = true;
            this.m_cmd_question.Click += new System.EventHandler(this.m_cmd_question_Click);
            // 
            // m_cmd_thoat
            // 
            this.m_cmd_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmd_thoat.Image = global::QLSP.Properties.Resources.cancel;
            this.m_cmd_thoat.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_cmd_thoat.Location = new System.Drawing.Point(604, 310);
            this.m_cmd_thoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_cmd_thoat.Name = "m_cmd_thoat";
            this.m_cmd_thoat.Size = new System.Drawing.Size(139, 38);
            this.m_cmd_thoat.TabIndex = 9;
            this.m_cmd_thoat.Text = "Thoát";
            this.m_cmd_thoat.UseVisualStyleBackColor = true;
            this.m_cmd_thoat.Click += new System.EventHandler(this.m_cmd_thoat_Click);
            // 
            // m_cmd_dangnhap
            // 
            this.m_cmd_dangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmd_dangnhap.Image = global::QLSP.Properties.Resources.tick;
            this.m_cmd_dangnhap.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_cmd_dangnhap.Location = new System.Drawing.Point(419, 310);
            this.m_cmd_dangnhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_cmd_dangnhap.Name = "m_cmd_dangnhap";
            this.m_cmd_dangnhap.Size = new System.Drawing.Size(161, 38);
            this.m_cmd_dangnhap.TabIndex = 8;
            this.m_cmd_dangnhap.Text = "Đăng nhập";
            this.m_cmd_dangnhap.UseVisualStyleBackColor = true;
            this.m_cmd_dangnhap.Click += new System.EventHandler(this.m_cmd_dangnhap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLSP.Properties.Resources.login;
            this.pictureBox1.Location = new System.Drawing.Point(39, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 313);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // f001_dang_nhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 421);
            this.Controls.Add(this.m_cmd_question);
            this.Controls.Add(this.m_cmd_thoat);
            this.Controls.Add(this.m_cmd_dangnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_rdb_user);
            this.Controls.Add(this.m_rdb_admin);
            this.Controls.Add(this.m_txt_matkhau);
            this.Controls.Add(this.m_txt_taikhoan);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "f001_dang_nhap";
            this.Text = "f001_dang_nhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox m_txt_taikhoan;
        private System.Windows.Forms.TextBox m_txt_matkhau;
        private System.Windows.Forms.RadioButton m_rdb_admin;
        private System.Windows.Forms.RadioButton m_rdb_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_cmd_dangnhap;
        private System.Windows.Forms.Button m_cmd_thoat;
        private System.Windows.Forms.Button m_cmd_question;
    }
}