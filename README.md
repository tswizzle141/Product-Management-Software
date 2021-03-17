# Product-Management-Software

My main role is played on form `f102_kho.cs` and `f103_bao_gia.cs`, with the use of Observer Design Pattern.

## Form `f102_kho.cs`

This `f102_kho.cs` performs 5 purposes: 
- `f102_kho.cs` is designed only for Admin, not the Customer.
- Read products from a `.json` file from the head warehouse. I program 2 functions, `getJSONData()` and `btnImport_Clicked(object sender, EventArgs e)` that Admin could click on button `Import` to get data into `DataTable`.
- Admin will give out a `VND` price until it is exchanged into various monetary price.
- Admin can `Add`, `Update`, `Delete`, `Save` items
- After completing, `Export` to create another `.json` file for Customers to pick up products later.

**`jsonGeneration(DataTable table)` from `Datatable`**

        `public string jsonGeneration(DataTable table)
        
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
            
        }`

**While `getstate(Subject subject)` gets a param of VND price, button `Exchange` will provide `setstate()` for various monetary prices**

        `private void btnExchange_Clicked(object sender, EventArgs e)
        
        {
        
            Subject subject = new Subject();

            subject.setState(double.Parse(rtbVND.Text));
            
            rtbEuro.Text = new Euro(subject).Update();
            
            rtbDollar.Text = new USDollar(subject).Update();
            
            rtbRMB.Text = new RMB(subject).Update();
            
            rtbWon.Text = new Won(subject).Update();
            
        }`

## Form `f103_bao_gia.cs`

This `f103_bao_gia.cs` performs 5 purposes: 
- `f103_bao_gia.cs` is designed only for Customer, not the Admin.
- Read products from a `.json` file from the Customer's `.json` file given from `f101`. I program 2 functions, `getJSONData()` and `btnImport_Clicked(object sender, EventArgs e)` that Customer could click on button `Import` to get data into `DataGridView`.
- According to Customer's monetary choices, my program will enable only corresponding monetary columns and shipping fee TextBox.
- Customer can `Add`, `Update`, `Delete`, `Save` items
- After completing, `Export` to create another `.json` file for Customers to create bill later.

**Select chosen monetary units**

                    `if (cbbUnit.SelectedItem.ToString() == "VND")
                    
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
                        
                    }`
                    
**Select chosen monetary shipping fee**

(for example, `USD` and `EUR`)

            `else if (cbbUnit.SelectedItem.ToString() == "USD")
            
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
            }`

**Update the amount of products in chosen monetary units**

(for example USD)

            `int idx = ((ComboBox)sender).SelectedIndex;

            if (idx == 0)
            
            {
            
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                
                {
                
                    dataGridView1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), 3));
                    
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) / 23067.5, 3));
                    
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + 2.000, 3));
                
                }
                
            }`


