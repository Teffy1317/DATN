using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace DATN
{
    public partial class Database_Scr : Form
    {
        private const string API_URL = "https://qaajrngsbpdnkqjeacmo.supabase.co/rest/v1";
        private const string API_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFhYWpybmdzYnBkbmtxamVhY21vIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI5MTYzNzIsImV4cCI6MjAyODQ5MjM3Mn0.eTgoIxnUjyCPqTT4FqLFCGz16mPObhXobseTeiZ1OSA";

        public Database_Scr()
        {
            InitializeComponent();
        }

        private void SQL_Scr_Load(object sender, EventArgs e)
        {
            btnDatabase.Enabled = false;
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            
            Windows_colection.system_window.Show();
            this.Hide();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            Windows_colection.user_window.Show();
            this.Hide();
        }
        private void btnOPCUA_Click(object sender, EventArgs e)
        {
            Windows_colection.opcUA_window.Show();
            this.Hide();
        }
        private void btnDecode_Click(object sender, EventArgs e)
        {
            Windows_colection.decode_window.Show();
            this.Hide();
        }
        private void btnParamater_Click(object sender, EventArgs e)
        {
            Windows_colection.parameter_window.Show();
            this.Hide();
        }
        private void btnDatabase_Click(object sender, EventArgs e)
        {

        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            Windows_colection.alarm_window.Show();
            this.Hide();
        }

        private void btnTrend_Click(object sender, EventArgs e)
        {
            Windows_colection.trend_window.Show();
            this.Hide();
        }

        private void picHome_DoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        static async void LoadData()
        {
            using (HttpClient client = new HttpClient())
            {
                MessageBox.Show("Hello");
                string apiUrl = "https://qaajrngsbpdnkqjeacmo.supabase.co/rest/v1";
                string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFhYWpybmdzYnBkbmtxamVhY21vIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI5MTYzNzIsImV4cCI6MjAyODQ5MjM3Mn0.eTgoIxnUjyCPqTT4FqLFCGz16mPObhXobseTeiZ1OSA";

                // Set up HTTP client headers
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("apikey", apiKey);

                // Example: Sending a GET request to retrieve data
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/users");
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(responseData);
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
        }

        private async void UpdateData()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://qaajrngsbpdnkqjeacmo.supabase.co/rest/v1";
                string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFhYWpybmdzYnBkbmtxamVhY21vIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI5MTYzNzIsImV4cCI6MjAyODQ5MjM3Mn0.eTgoIxnUjyCPqTT4FqLFCGz16mPObhXobseTeiZ1OSA";

                // Data to be updated
                string newData = "{\"name\": \"Teffy\"}";

                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), apiUrl + "/users?id=eq.1");
                request.Headers.Add("apikey", apiKey);
                request.Content = new StringContent(newData, Encoding.UTF8, "application/json");

                // Example: Sending a PATCH request to update data
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data updated successfully");
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
        }

        public static async void InsertData(string data, string table)
        {
            using (HttpClient client = new HttpClient())
            { 
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, API_URL + "/" + table);
                request.Headers.Add("apikey", API_KEY);
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");

                // Example: Sending a POST request to insert new data
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data inserted successfully");
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
        }

    }
}
