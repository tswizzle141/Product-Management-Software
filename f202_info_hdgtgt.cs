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
    public partial class f202_info_hdgtgt : Form,IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        public object Handle_(object request)
        {
            if ((request as string) == "Hóa đơn GTGT")
            {
                this.Show();
            }
            else
            {
                return this._nextHandler.Handle_(request);

            }
            return 0;
        }
        public f202_info_hdgtgt()
        {
            InitializeComponent();
            m_img_label.Visible = false;
            load_Currency();
            m_img_label2.Visible = false;
             
        }
        string m_str_json_bill = @"..\..\Data\hoadonGTGT.json";
        string m_str_json_product = @"..\..\Data\op_sanpham_baogia.json";
        string m_type;
        public void rec_type(int ip_i_type)
        {
            if (ip_i_type == 1)
            {
                m_cmd_add.Enabled = false;
                m_cmd_check.Enabled = false;
                m_cmd_repair.Enabled = false;
            }
            else
            {
                m_cmd_delete.Enabled = false;
            }
        }
        public void load_Currency()
        {

            using (StreamReader file = File.OpenText(m_str_json_product))
            {
                JsonSerializer serializer = new JsonSerializer();

                Name_currency<Currency> us_currency = (Name_currency<Currency>)serializer.Deserialize(file, typeof(Name_currency<Currency>));

                foreach (var menh_gia in us_currency.currency)
                {
                    m_type = menh_gia.Type;
                }
            }

        }
        private void check_Click(object sender, EventArgs e)
        {

            m_img_label.Visible = false;
            m_lbl_notice1.Text = null;
            Double v_db_tong_tien = 0;
            f204_hdgtg us_hdgtgt = new f204_hdgtg();
                
            JsonSerializer serializer = new JsonSerializer();
            Name_product<Product> us_productb = JsonConvert.DeserializeObject<Name_product<Product>>(File.ReadAllText(m_str_json_product));
            us_hdgtgt.dt_DataSource(us_productb);               
            foreach (var tien in us_productb.products)
                {
                if (m_type == "VND") v_db_tong_tien += double.Parse(tien.VND);
                else if (m_type == "USD") v_db_tong_tien += double.Parse(tien.USD);
                else if (m_type == "EUR") v_db_tong_tien += double.Parse(tien.EUR);
                else if (m_type == "RMB") v_db_tong_tien += double.Parse(tien.RMB);
                else if (m_type == "KRW") v_db_tong_tien += double.Parse(tien.KRW);
            }
            us_hdgtgt.display(m_txt_tenkh.Text, m_txt_tendv.Text, m_txt_tendc.Text, m_txt_sotk.Text, m_cbo_thanhtoan.SelectedItem.ToString(), m_txt_masothue.Text, v_db_tong_tien, m_type);
            us_hdgtgt.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            m_img_label2.Visible = false;
            m_lbl_notice4.Text = null;
            if (m_txt_tenkh.Text == "" || m_txt_tendv.Text == "" || m_txt_tendc.Text == "" || m_txt_sotk.Text == "" || m_cbo_thanhtoan.SelectedItem==null || m_txt_masothue.Text == "" )
            {
                MessageBox.Show("Các mục (*) không được để trống !");
            }
            else
            {
                string v_str_json;
                DateTime us_UTCNow = DateTime.UtcNow;
                int v_i_year = us_UTCNow.Year;
                int v_i_month = us_UTCNow.Month;
                int v_i_day = us_UTCNow.Day;
                m_lbl_notice1.Text = "Click vào đây để xem hóa đơn";
                m_img_label.Visible = true;
                
                JsonSerializer serializer = new JsonSerializer();
                Info_bill_add<Bill_GTGT> us_bill = JsonConvert.DeserializeObject<Info_bill_add<Bill_GTGT>>(File.ReadAllText(m_str_json_bill));
                us_bill.bill.Add(new Bill_GTGT()
                {
                    Date = v_i_day.ToString()+"/"+v_i_month.ToString() + "/" + v_i_year.ToString(),
                    Name = m_txt_tenkh.Text,
                    Company = m_txt_tendv.Text,
                    Address = m_txt_tendc.Text,
                    Account = m_txt_sotk.Text,
                    Pay = m_cbo_thanhtoan.SelectedItem.ToString(),
                    Tax = m_txt_masothue.Text,
                    
                }) ;
                v_str_json = JsonConvert.SerializeObject(us_bill, Formatting.Indented);
                System.IO.File.WriteAllText(m_str_json_bill, v_str_json);
            }
        }

        private void repair_Click(object sender, EventArgs e)
        {
            bool v_bl_check_exist;
            if (m_txt_name_repair.Text != "") {
                m_lbl_notice2.Text = null;
                
                string v_str_json;
                string v_str_date;

                m_txt_tenkh.Text = null;
                m_txt_tendv.Text = null;
                m_txt_tendc.Text = null;
                m_txt_sotk.Text = null;
                m_txt_masothue.Text = null;
                JsonSerializer serializer = new JsonSerializer();
                Info_bill_repair<Bill_GTGT> us_bill_repair = JsonConvert.DeserializeObject<Info_bill_repair<Bill_GTGT>>(File.ReadAllText(m_str_json_bill));
                Info_bill_add<Bill_GTGT> us_bill_add = JsonConvert.DeserializeObject<Info_bill_add<Bill_GTGT>>(File.ReadAllText(m_str_json_bill));
                if (us_bill_repair.bill.Length != 0)
                {
                    foreach (var name_kh in us_bill_repair.bill)
                    {
                        if (name_kh.Name == m_txt_name_repair.Text)
                        {
                            m_txt_tenkh.Text = name_kh.Name;
                            m_txt_tendv.Text = name_kh.Company;
                            m_txt_tendc.Text = name_kh.Address;
                            m_txt_sotk.Text = name_kh.Account;
                            m_txt_masothue.Text = name_kh.Tax;
                            v_str_date = name_kh.Date;

                        }
                    }
                    v_bl_check_exist = false;
                    for (int i = 0; i < us_bill_add.bill.Count; i++)
                    {
                        if (us_bill_add.bill[i].Name == m_txt_name_repair.Text)
                        {
                            v_bl_check_exist = true;
                            us_bill_add.bill.RemoveAt(i);
                            m_img_label2.Visible = true;
                            m_lbl_notice4.Text = "Cập nhật lại thông tin !";
                            v_str_json = JsonConvert.SerializeObject(us_bill_add, Formatting.Indented);
                            System.IO.File.WriteAllText(m_str_json_bill, v_str_json);
                            break;
                        }
                    }
                    if (!v_bl_check_exist) MessageBox.Show("Không tồn tại tên này , kiểm tra lại tên nhập vào !");
                }
                else
                {
                    MessageBox.Show("Dữ liệu trống !");
                } 
            }
            else
            {
                m_lbl_notice2.Text = "Điền đầy đủ họ và tên vào ô trống !";
            }
        }
       
        private void delete_Click(object sender, EventArgs e)
        {
            bool v_bl_check_exist;
            if (m_txt_name_delete.Text != "")
            {
                m_lbl_notice3.Text = null;
                string v_str_json;
                string v_str_date;
                string v_str_currency;
                m_txt_tenkh.Text = null;
                m_txt_tendv.Text = null;
                m_txt_tendc.Text = null;
                m_txt_sotk.Text = null;
                m_txt_masothue.Text = null;          
                JsonSerializer serializer = new JsonSerializer();
                Info_bill_add<Bill_GTGT> us_bill_add = JsonConvert.DeserializeObject<Info_bill_add<Bill_GTGT>>(File.ReadAllText(m_str_json_bill));
                if (us_bill_add.bill.Count != 0)
                {
                    v_bl_check_exist = false;
                    for (int i = 0; i < us_bill_add.bill.Count; i++)
                    {
                        if (us_bill_add.bill[i].Name == m_txt_name_delete.Text)
                        {
                            us_bill_add.bill.RemoveAt(i);
                            v_bl_check_exist = true;
                            v_str_json = JsonConvert.SerializeObject(us_bill_add, Formatting.Indented);
                            System.IO.File.WriteAllText(m_str_json_bill, v_str_json);
                            MessageBox.Show("Xóa Thành Công !");
                            break;
                        }
                    }
                    if (!v_bl_check_exist) MessageBox.Show("Không tồn tại tên này , kiểm tra lại tên nhập vào !");

                }
                else
                {
                    MessageBox.Show("Dữ liệu trống !");
                }
            }            
            else
            {
                m_lbl_notice3.Text = "Điền đầy đủ họ và tên vào ô trống !";
            }
        }

        
    }   
    
}
