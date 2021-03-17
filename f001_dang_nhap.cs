using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSP
{
    public partial class f001_dang_nhap : Form
    {
        public f001_dang_nhap()
        {
            InitializeComponent();
        }

        private void m_cmd_dangnhap_Click(object sender, EventArgs e)
        {
            if (m_rdb_user.Checked)
            {
                f002_menu us_menu = new f002_menu();
                us_menu.authen(0);
                us_menu.Show();
                this.Hide();
            }
            else if (m_rdb_admin.Checked)
            {
                if (m_txt_taikhoan.Text == "" && m_txt_matkhau.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập tài khoản và mật khẩu !");
                }
                else
                {
                    if (m_txt_taikhoan.Text == "admin" && m_txt_matkhau.Text == "admin")
                    {
                        f002_menu us_menu = new f002_menu();
                        us_menu.authen(1);
                        us_menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        m_txt_taikhoan.Text = null;
                        m_txt_matkhau.Text = null;
                        MessageBox.Show("Cảnh báo , Sai tài khoản hoặc mật khẩu !");
                    }
                }
            }
            else {
                MessageBox.Show("Mời bạn chọn người đăng nhập !");
            }
        }

        private void m_cmd_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show(" Bạn có muốn thoát khỏi chương trình hay không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void m_cmd_question_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Người dùng tích vào ô người dùng để đăng nhập , Admin tích vào ô admin và nhập tài khoản và mật khẩu để đăng nhập ! !");
        }

        private void m_rdb_user_CheckedChanged(object sender, EventArgs e)
        {
            m_txt_matkhau.Enabled = false;
            m_txt_taikhoan.Enabled = false;
        }

        private void m_rdb_admin_CheckedChanged(object sender, EventArgs e)
        {
            m_txt_matkhau.Enabled = true;
            m_txt_taikhoan.Enabled = true;
        }
    }
}
