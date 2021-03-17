using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Json.Net;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace QLSP
{
    public partial class f201_thanh_toan : Form
    {
        public f201_thanh_toan()
        {
            InitializeComponent();
        }
        int m_i_type;
        public void rec_type(int ip_i_type)
        {
            m_i_type = ip_i_type;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_cbo_loaihd.SelectedItem != null)
            {
                f202_info_hdgtgt us_hdgtgt = new f202_info_hdgtgt();
                us_hdgtgt.rec_type(m_i_type);
                f203_info_hdt us_hdt = new f203_info_hdt();
                us_hdt.rec_type(m_i_type);
                us_hdgtgt.SetNext(us_hdt);
                us_hdgtgt.Handle_(m_cbo_loaihd.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Mời bạn chọn chức năng !");
            }


        }

        private void back_Click(object sender, EventArgs e)
        {
            f002_menu us_menu = new f002_menu();
            us_menu.authen(m_i_type);
            us_menu.Show();
            this.Close();
        }
    }
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle_(object request);
    }
}

