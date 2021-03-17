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
    public partial class f101_bang_gia : Form
    {
        private int m_i_type = 0;
        public f101_bang_gia()
        {
            InitializeComponent();
            
        }
        public void rec_type(int ip_i_type)
        {
            m_i_type = ip_i_type;
            if (ip_i_type == 1)
            {
                rbtn_baogia.Enabled = false;
            }
            else
            {
                rbtn_kho.Enabled = false;
            }
        }
        private void m_cmd_next_Click(object sender, EventArgs e)
        {
            if (rbtn_kho.Checked)
            {
                f102_kho f102 = new f102_kho();
                f102.Show();
                Close();
            }
            else if (rbtn_baogia.Checked)
            {
                f103_bao_gia f103 = new f103_bao_gia();
                f103.authen(m_i_type);
                f103.Show();
                Close();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            f002_menu f002 = new f002_menu();
            f002.authen(m_i_type);
            f002.Show();
            this.Close();
        }
    }
}
