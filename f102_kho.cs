using System;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSP
{
    public partial class f102_kho : Form
    {
        DataTable table1 = new DataTable(); DataTable table2 = new DataTable();
        int m_i_idxRow, m_i_idxCol;
        string m_str_json_data;
        string m_str_dataInput = @"..\..\Data\ip_sp_kho.json";
        string m_str_dataOutput = @"..\..\Data\op_sp_kho.json";
        System.Text.Encoding Encoder = System.Text.ASCIIEncoding.Default;
        public f102_kho()
        {
            InitializeComponent();
            btnExport.Enabled = false; btnSave.Enabled = false;
            btnAdd.Enabled = false;
        }

        public void getJSONData()
        {
            string ip_str_data = File.ReadAllText(m_str_dataInput);
            var data = JsonConvert.DeserializeObject<DataProductList_Ninh>(ip_str_data);

            if (data != null)
            {
                int idx = 0;
                foreach (var prd in data.products)
                {
                    table1.Rows.Add();
                    table1.Rows[idx][0] = prd.Type;
                    table1.Rows[idx][1] = prd.Name;
                    idx++;
                }
            }
        }

        public string jsonGeneration(DataTable table)
        {
            var jsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                jsonString.Append("{\n");
                jsonString.Append("\t\"products\": [\n");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    jsonString.Append("\t\t{\n");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            jsonString.Append("\t\t\t\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",\n");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            jsonString.Append("\t\t\t\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        jsonString.Append("\n\t\t}");
                    }
                    else
                    {
                        jsonString.Append("\n\t\t},\n");
                    }
                }
                jsonString.Append("\n\t]");
            }
            jsonString.Append("\n}");
            return jsonString.ToString();
        }

        public void setJSONData(string ip_str_data)
        {
            File.WriteAllText(m_str_dataOutput, ip_str_data);
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            table1.Rows.Add(rtbType.Text, rtbProduct.Text, rtbVND.Text, rtbDollar.Text, rtbEuro.Text, rtbRMB.Text, rtbWon.Text, rtbAvai.Text);
            dataGridView1.DataSource = table1;
            btnExport.Enabled = true;
            m_str_json_data = jsonGeneration(table1);
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[m_i_idxRow];
            newDataRow.Cells[0].Value = rtbType.Text;
            newDataRow.Cells[1].Value = rtbProduct.Text;
            newDataRow.Cells[2].Value = rtbVND.Text;
            newDataRow.Cells[3].Value = rtbDollar.Text;
            newDataRow.Cells[4].Value = rtbEuro.Text;
            newDataRow.Cells[5].Value = rtbRMB.Text;
            newDataRow.Cells[6].Value = rtbWon.Text;
            newDataRow.Cells[7].Value = rtbAvai.Text;

            btnSave.Enabled = true;
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            int rowIdx = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIdx);
        }

        private void f102_Kho_Load(object sender, EventArgs e)
        {
            table1.Columns.Add("Type", typeof(string));
            table1.Columns.Add("Product", typeof(string));
            table1.Columns.Add("VND", typeof(double));
            table1.Columns.Add("USD", typeof(double));
            table1.Columns.Add("EUR", typeof(double));
            table1.Columns.Add("RMB", typeof(double));
            table1.Columns.Add("KRW", typeof(double));
            table1.Columns.Add("Availability", typeof(int));

            dataGridView1.DataSource = table1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImport_Clicked(object sender, EventArgs e)
        {
            getJSONData();
            btnAdd.Enabled = true;
        }

        private void btnExport_Clicked(object sender, EventArgs e)
        {
            setJSONData(m_str_json_data);
            MessageBox.Show("Data Exported!");
        }

        private void rtbVND_Changed(object sender, EventArgs e)
        {

        }

        private void rtbDollar_Changed(object sender, EventArgs e)
        {

        }

        private void rtbEuro_Changed(object sender, EventArgs e)
        {

        }

        private void rtbRMB_Changed(object sender, EventArgs e)
        {

        }

        private void rtbWon_Changed(object sender, EventArgs e)
        {

        }

        private void rtbProduct_Changed(object sender, EventArgs e)
        {

        }

        private void rtbType_Changed(object sender, EventArgs e)
        {

        }

        private void rtbAvai_Changed(object sender, EventArgs e)
        {

        }

        private void btnExchange_Clicked(object sender, EventArgs e)
        {
            Subject subject = new Subject();

            subject.setState(double.Parse(rtbVND.Text));
            rtbEuro.Text = new Euro(subject).Update();
            rtbDollar.Text = new USDollar(subject).Update();
            rtbRMB.Text = new RMB(subject).Update();
            rtbWon.Text = new Won(subject).Update();
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            using (TextWriter tw = new StreamWriter(@"..\..\Data\save_kho.txt"))
            {
                for (int i = 0; i < table1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < table1.Columns.Count; j++)
                    {
                        tw.Write($"{table1.Rows[i][j].ToString()}");

                        if (j != dataGridView1.Columns.Count - 1)
                        {
                            tw.Write(",");
                        }
                    }
                    tw.WriteLine();
                }
            }
            MessageBox.Show("Saved!");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            f101_bang_gia v_f101 = new f101_bang_gia();
            v_f101.rec_type(1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_i_idxRow = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[m_i_idxRow];

            rtbType.Text = selectedRow.Cells[0].Value.ToString();
            rtbProduct.Text = selectedRow.Cells[1].Value.ToString();
            rtbVND.Text = selectedRow.Cells[2].Value.ToString();
            rtbDollar.Text = selectedRow.Cells[3].Value.ToString();
            rtbEuro.Text = selectedRow.Cells[4].Value.ToString();
            rtbRMB.Text = selectedRow.Cells[5].Value.ToString();
            rtbWon.Text = selectedRow.Cells[6].Value.ToString();
            rtbAvai.Text = selectedRow.Cells[7].Value.ToString();
        }
    }
}
