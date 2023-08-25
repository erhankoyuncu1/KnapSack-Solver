using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Markup;
using Npgsql;

namespace KnapSack
{
    public partial class Form1 : Form
    {
        private int[] values;
        private int[] weights;
        private int[] selectedItems;
        private int capacity;
        private int itemCount;
        private int totalValue;
        private int totalWeight;
        private string connectionString;
        private string dataName;
        public Form1()
        {
            values = new int[0];
            weights = new int[0];
            selectedItems = new int[0];
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] txtFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

            foreach (string txtFile in txtFiles)
            {
                string fileName = Path.GetFileName(txtFile);
                cmbData.Items.Add(fileName);
            }
        }

        private void cmbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMaxValue.Text = string.Empty;
            lblSize.Text = string.Empty;
            lblCapacity.Text = string.Empty;
            txtSelectedItems.Clear();
            lbResults.Items.Clear();

            dataName = cmbData.Text;

            if (cmbData.SelectedIndex != -1)
            {
                txtError.Text = string.Empty;
            }
            string selectedFileName = cmbData.SelectedItem.ToString();
            string[] fileLines = File.ReadAllLines(selectedFileName);
            int lineCount = fileLines.Length;
            if (lineCount > 0)
            {
                itemCount = int.Parse(fileLines[0].Split(' ')[0]);
                capacity = int.Parse(fileLines[0].Split(' ')[1]);

                values = new int[itemCount];
                weights = new int[itemCount];

                for (int i = 1; i <= lineCount - 1; i++)
                {
                    try
                    {
                        string[] lineParts = fileLines[i].Split(' ');
                        values[i - 1] = int.Parse(lineParts[0]);
                        weights[i - 1] = int.Parse(lineParts[1]);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Index was outside the bounds of the array."))
                        {
                            txtError.Text = "Dizi sınırlarının dışına çıkıldı. Veri dosyasında belirtilen item sayısından fazlası var. Belirtilen item sayısından fazlası dikkate alınmayacak... ";
                            btnCalculate.Enabled = false;
                        }
                        else if (ex.Message.Contains("Object reference not set to an instance of an object."))
                        {
                            txtError.Text = "Nesne başvurusu boş olamaz.";
                            btnCalculate.Enabled = false;
                        }
                    }
                }
            }
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] <= 0 || weights[i] <= 0)
                {
                    txtError.Text = "Geçersiz değer aralığından değer bulunmakta.";
                    btnCalculate.Enabled = false;
                }
                else
                {
                    btnCalculate.Enabled = true;
                }
            }
            lblSize.Text = itemCount.ToString();
            lblCapacity.Text = capacity.ToString();
        }


        public int knapsackSolver(int capacity, int[] weights, int[] values, int n)
        {
            int[,] dp = new int[n + 1, capacity + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                        dp[i, w] = 0;
                    else if (weights[i - 1] <= w)
                        dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                    else
                        dp[i, w] = dp[i - 1, w];
                }
            }
            selectedItems = new int[n];
            int currentItem = n, currentCapacity = capacity;
            while (currentItem > 0 && currentCapacity > 0)
            {
                if (dp[currentItem, currentCapacity] != dp[currentItem - 1, currentCapacity])
                {
                    selectedItems[currentItem - 1] = 1;
                    currentCapacity -= weights[currentItem - 1];
                }
                currentItem--;
            }

            return dp[n, capacity];
        }

        public void resultController(int capacity, int maxValue, int[] values, int[] weights, int[] selectedItems)
        {
            totalValue = 0;
            totalWeight = 0;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                if (selectedItems[i] == 1)
                {
                    totalValue += values[i];
                    totalWeight += weights[i];
                }
            }

            if (totalValue != maxValue)
            {
                txtError.Text = "Hesaplamada Hata Var, Maksimum Değer Doğrulanmadı...\n";
            }
            if (totalWeight > capacity)
            {
                txtError.Text += "Hesaplamada Hata Var, Kapasite Aşıldı...\n";
            }
        }

        private void loadDataToDatabase(int size, int capacity, int maxValue, int[] selectedItems, int usedCapacity, string errorMessage,string name)
        {
            try
            {
                connectionString = "Host=localhost;Username=postgres;Password=erhnkync;Database=dbknapsack;";
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                NpgsqlCommand query = new NpgsqlCommand("insert into tbl_data_set(size,capacity,maxvalue,items,usedcapacity,errormessage,name) values (@size, @capacity, @maxvalue,@items,@usedcapacity,@errormessage,@name)", connection);
                query.Parameters.AddWithValue("@capacity", capacity);
                query.Parameters.AddWithValue("@size", size);
                query.Parameters.AddWithValue("@items", selectedItems);
                query.Parameters.AddWithValue("@maxvalue", maxValue);
                query.Parameters.AddWithValue("@usedcapacity", usedCapacity);
                query.Parameters.AddWithValue("@errormessage", errorMessage);
                query.Parameters.AddWithValue("@name", name);
                query.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                txtError.Text = "Veri eklenemedi ! \n" + e.Message;
            }
        }

        private void readData(string name)
        {
            connectionString = "Host=localhost;Username=postgres;Password=erhnkync;Database=dbknapsack;";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand query = new NpgsqlCommand("SELECT maxvalue FROM tbl_data_set WHERE name = @name ORDER BY maxvalue DESC LIMIT 5 ", connection);
                query.Parameters.AddWithValue("@name", name);

                NpgsqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lbResults.Items.Add(reader.GetInt32(0));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                txtError.Text = e.Message;
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {   
            lbResults.Items.Clear();
            readData(dataName);

            if (cmbData.SelectedIndex == -1)
            {
                txtError.Text = "Lütfen önce bir veri boyutu seçin.";
                return;
            }
            int maxValue = knapsackSolver(capacity, weights, values, itemCount);
            lblMaxValue.Text = maxValue.ToString();
            string selectedItemsText = string.Join(" ", selectedItems);
            txtSelectedItems.Text = selectedItemsText;

            resultController(capacity, maxValue, values, weights, selectedItems);
            loadDataToDatabase(itemCount, capacity, maxValue, selectedItems, totalWeight,txtError.Text,dataName);
        }
        
        private void txtError_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtError.Text))
            {
                txtError.Visible = false;
            }
            else
            {
                txtError.Visible = true;
            }
        }
    }
}