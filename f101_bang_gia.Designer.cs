namespace QLSP
{
    partial class f101_bang_gia
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
            this.back = new System.Windows.Forms.Button();
            this.m_cmd_next = new System.Windows.Forms.Button();
            this.rbtn_kho = new System.Windows.Forms.RadioButton();
            this.rbtn_baogia = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn chức năng";
            // 
            // back
            // 
            this.back.BackgroundImage = global::QLSP.Properties.Resources.phai3;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.back.Location = new System.Drawing.Point(97, 160);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(99, 29);
            this.back.TabIndex = 7;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // m_cmd_next
            // 
            this.m_cmd_next.BackgroundImage = global::QLSP.Properties.Resources.phai2;
            this.m_cmd_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmd_next.ForeColor = System.Drawing.Color.Red;
            this.m_cmd_next.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_cmd_next.Location = new System.Drawing.Point(325, 160);
            this.m_cmd_next.Name = "m_cmd_next";
            this.m_cmd_next.Size = new System.Drawing.Size(99, 29);
            this.m_cmd_next.TabIndex = 6;
            this.m_cmd_next.UseVisualStyleBackColor = true;
            this.m_cmd_next.Click += new System.EventHandler(this.m_cmd_next_Click);
            // 
            // rbtn_kho
            // 
            this.rbtn_kho.AutoSize = true;
            this.rbtn_kho.Location = new System.Drawing.Point(272, 57);
            this.rbtn_kho.Name = "rbtn_kho";
            this.rbtn_kho.Size = new System.Drawing.Size(68, 17);
            this.rbtn_kho.TabIndex = 8;
            this.rbtn_kho.TabStop = true;
            this.rbtn_kho.Text = "Xem Kho";
            this.rbtn_kho.UseVisualStyleBackColor = true;
            // 
            // rbtn_baogia
            // 
            this.rbtn_baogia.AutoSize = true;
            this.rbtn_baogia.Location = new System.Drawing.Point(272, 97);
            this.rbtn_baogia.Name = "rbtn_baogia";
            this.rbtn_baogia.Size = new System.Drawing.Size(91, 17);
            this.rbtn_baogia.TabIndex = 8;
            this.rbtn_baogia.TabStop = true;
            this.rbtn_baogia.Text = "Xem Bảng giá";
            this.rbtn_baogia.UseVisualStyleBackColor = true;
            // 
            // f101_bang_gia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 245);
            this.Controls.Add(this.rbtn_baogia);
            this.Controls.Add(this.rbtn_kho);
            this.Controls.Add(this.back);
            this.Controls.Add(this.m_cmd_next);
            this.Controls.Add(this.label1);
            this.Name = "f101_bang_gia";
            this.Text = "f101_bang_gia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button m_cmd_next;
        private System.Windows.Forms.RadioButton rbtn_kho;
        private System.Windows.Forms.RadioButton rbtn_baogia;
    }
}