using System;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSP
{
    public partial class f103_bao_gia : Form
    {
        System.Text.Encoding Encoder = System.Text.ASCIIEncoding.Default;
        string m_str_json_data;
        string m_str_dataInput = @"..\..\Data\ip_sanpham_baogia.json";
        string m_str_dataOutput = @"..\..\Data\op_sanpham_baogia.json";
        int m_i_idxRow, m_i_idxCol;
        int m_i_authen;
        public f103_bao_gia()
        {
            InitializeComponent();
            btnAdd.Enabled = false; btnUpdate.Enabled = false; btnDelete.Enabled = false; btnImport.Enabled = true; btnExport.Enabled = false;
            btnReturn.Enabled = false;
            cbbUnit.Enabled = false;
        }
        public void authen(int ip_i_authen)
        {
            m_i_authen = ip_i_authen;
        }
        public void displayCbb()
        {
            string ip_str_data = File.ReadAllText(m_str_dataInput);
            var data = JsonConvert.DeserializeObject<DataProductList_Ninh>(ip_str_data);

            if (data != null)
            {
                dataGridView1.ColumnCount = 8;
                foreach (var cur in data.currency)
                {
                    cbbUnit.Items.Add(cur.Type);
                }
            }
        }
        public void getJSONData()
        {
            string ip_str_data = File.ReadAllText(m_str_dataInput);
            var data = JsonConvert.DeserializeObject<DataProductList_Ninh>(ip_str_data);
            dataGridView1.Rows.Clear();
            if (data != null)
            {
                dataGridView1.ColumnCount = 8;
                int idx = 0;

                foreach (var prd in data.products)
                {
                    dataGridView1.Columns[0].Name = "Type";
                    dataGridView1.Columns[1].Name = "Name";
                    dataGridView1.Columns[2].Name = "Amount";
                    dataGridView1.Columns[3].Name = "Warranty";
                    dataGridView1.Columns[4].Name = "Prices";

                    if (cbbUnit.SelectedItem.ToString() == "VND")
                    {
                        dataGridView1.Columns[5].Name = "(No Exchange Unit)";
                        dataGridView1.Columns[7].Name = "(No Exchange Sum)";
                    }
                    else if (cbbUnit.SelectedItem.ToString() == "USD")
                    {
                        dataGridView1.Columns[5].Name = "Price per unit (USD)";
                        dataGridView1.Columns[7].Name = "USD";
                    }
                    else if (cbbUnit.SelectedItem.ToString() == "EUR")
                    {
                        dataGridView1.Columns[5].Name = "Price per unit (EUR)";
                        dataGridView1.Columns[7].Name = "EUR";
                    }
                    else if (cbbUnit.SelectedItem.ToString() == "RMB")
                    {
                        dataGridView1.Columns[5].Name = "Price per unit (RMB)";
                        dataGridView1.Columns[7].Name = "RMB";
                    }
                    else if (cbbUnit.SelectedItem.ToString() == "KRW")
                    {
                        dataGridView1.Columns[5].Name = "Price per unit (KRW)";
                        dataGridView1.Columns[7].Name = "KRW";
                    }

                    dataGridView1.Columns[6].Name = "VND";
                    //dataGridView1.Columns[7].Name = "Exchange Sum";

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[idx].Cells[0].Value = prd.Type;
                    dataGridView1.Rows[idx].Cells[1].Value = prd.Name;
                    dataGridView1.Rows[idx].Cells[2].Value = prd.Amount;
                    dataGridView1.Rows[idx].Cells[3].Value = prd.Warranty;
                    dataGridView1.Rows[idx].Cells[4].Value = prd.Prices;
                    idx++;
                }
            }
        }

        public void setJSONData(string ip_str_data)
        {
            //dataOutput = @"C:\Users\tswizzle\source\repos\input_Tuan.json";
            File.WriteAllText(m_str_dataOutput, ip_str_data);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m_i_idxRow = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[m_i_idxRow];
        }

        public string jsonGeneration(DataTable table)
        {
            var jsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                jsonString.Append("{\n");
                jsonString.Append("\t\"products\": [\n");
                for (int i = 0; i < table.Rows.Count - 1; i++)
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
                    if (i == table.Rows.Count - 2)
                    {
                        jsonString.Append("\n\t\t}");
                    }
                    else
                    {
                        jsonString.Append("\n\t\t},\n");
                    }
                }
                jsonString.Append("\n\t],");
                jsonString.Append("\n\t\"currency\": [\n");
                jsonString.Append("\t\t{\n");
                jsonString.Append("\t\t\t" + "\"Type\": " + "\"" + cbbUnit.SelectedItem.ToString() + "\"");
                jsonString.Append("\n\t\t}");
            }
            jsonString.Append("\n\t]"); jsonString.Append("\n}");
            return jsonString.ToString();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            string message = "Do you want to go back to the previous form to buy more items?";
            string title = "Add";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            // Displays the MessageBox
            result = MessageBox.Show(this, message, title, buttons);
            if (result == DialogResult.Yes)
            {
                // Closes the parent form.
                f301_chon_san_pham v_f301 = new f301_chon_san_pham();
                v_f301.Show();
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            dataGridView1.Rows[m_i_idxRow].Cells[2].Value = rtbUpdate_Num.Text;
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            if (dataGridView1.Rows.Count == 0) return;
            int idxRow = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(idxRow);
        }

        private void btnImport_Clicked(object sender, EventArgs e)
        {
            displayCbb();
            cbbUnit.Enabled = true;
        }

        private void btnExport_Clicked(object sender, EventArgs e)
        {
            m_i_authen = 3;
            setJSONData(m_str_json_data);
            MessageBox.Show("Data Exported!");
            btnReturn.Enabled = true;
        }

        private void cbbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbUSDShip.Enabled = false; cbbEURShip.Enabled = false; cbbRMBShip.Enabled = false; cbbKRWShip.Enabled = false;
            cbbUSDShip.Items.Clear();
            cbbEURShip.Items.Clear();
            cbbKRWShip.Items.Clear();
            cbbRMBShip.Items.Clear();
            int idx = ((ComboBox)sender).SelectedIndex;

            if (cbbUnit.SelectedItem.ToString() == "VND")
            {
                label6.Text = "Free Ship!";
                getJSONData();

                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                }
            }
            else if (cbbUnit.SelectedItem.ToString() == "USD")
            {
                label6.Text = "";
                getJSONData();
                cbbUSDShip.Enabled = true;

                Subject subject2 = new Subject();
                subject2.setState(120000);

                cbbUSDShip.Items.Add(new USDShipFee1(subject2).Update());
                cbbUSDShip.Items.Add(new USDShipFee2(subject2).Update());
            }
            else if (cbbUnit.SelectedItem.ToString() == "EUR")
            {
                label6.Text = "";
                getJSONData();
                cbbEURShip.Enabled = true;

                Subject subject1 = new Subject();
                subject1.setState(100000);

                cbbEURShip.Items.Add(new EuroShipFee1(subject1).Update());
                cbbEURShip.Items.Add(new EuroShipFee2(subject1).Update());
                cbbEURShip.Items.Add(new EuroShipFee3(subject1).Update());
            }
            else if (cbbUnit.SelectedItem.ToString() == "RMB")
            {
                label6.Text = "";
                getJSONData();
                cbbRMBShip.Enabled = true;

                Subject subject1 = new Subject();
                subject1.setState(30000);

                cbbRMBShip.Items.Add(new RMBShipFee(subject1).Update());
            }
            else if (cbbUnit.SelectedItem.ToString() == "KRW")
            {
                label6.Text = "";
                getJSONData();
                cbbKRWShip.Enabled = true;

                Subject subject3 = new Subject();
                subject3.setState(80000);

                cbbKRWShip.Items.Add(new WonShipFee(subject3).Update());
            }
        }

        private void cbbUSDShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = ((ComboBox)sender).SelectedIndex;

            if (idx == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 23067.5, 3));
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 2.000, 3));
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 23067.5, 3));
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 1.714, 3));
                }
            }

            btnAdd.Enabled = true; btnUpdate.Enabled = true; btnDelete.Enabled = true; btnImport.Enabled = false; btnExport.Enabled = true;

            DataTable table = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                table.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dRow = table.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                table.Rows.Add(dRow);
            }
            m_str_json_data = jsonGeneration(table);
        }

        private void cbbEURShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = ((ComboBox)sender).SelectedIndex;

            if (idx == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 27972.3, 3));
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 1.667, 3));
                }
            }
            else if (idx == 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 27972.3, 3));
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 1.429, 3));
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 27972.3, 3));
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 1.250, 3));
                }
            }

            btnAdd.Enabled = true; btnUpdate.Enabled = true; btnDelete.Enabled = true; btnImport.Enabled = false; btnExport.Enabled = true;

            DataTable table = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                table.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dRow = table.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                table.Rows.Add(dRow);
            }
            m_str_json_data = jsonGeneration(table);
        }

        private void f103_bao_gia_Load(object sender, EventArgs e)
        {

        }

        private void cbbKRWShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = ((ComboBox)sender).SelectedIndex;

            if (idx == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 21.02, 3));
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 0.800, 3));
                }
            }
            btnAdd.Enabled = true; btnUpdate.Enabled = true; btnDelete.Enabled = true; btnImport.Enabled = false; btnExport.Enabled = true;

            DataTable table = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                table.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dRow = table.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                table.Rows.Add(dRow);
            }
            m_str_json_data = jsonGeneration(table);
        }

        private void cbbRMBShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = ((ComboBox)sender).SelectedIndex;

            if (idx == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 3566.6, 3));
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 1.000, 3));
                }
            }
            btnAdd.Enabled = true; btnUpdate.Enabled = true; btnDelete.Enabled = true; btnImport.Enabled = false; btnExport.Enabled = true;

            DataTable table = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                table.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dRow = table.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                table.Rows.Add(dRow);
            }
            m_str_json_data = jsonGeneration(table);
        }

        private void CaptureScreen()
        {
            try
            {
                Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                captureBitmap.Save(@"..\..\Data\Capture.jpg", ImageFormat.Jpeg);
                MessageBox.Show("Screen Captured");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            f101_bang_gia v_f101 = new f101_bang_gia();
            v_f101.rec_type(m_i_authen);
            v_f101.Show();
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
