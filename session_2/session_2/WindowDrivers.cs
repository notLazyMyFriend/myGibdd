using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace session_2
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = gibdd; Integrated Security = True");

        public Form2()
        {
            InitializeComponent();
        }

        private void AddNewDriver_Click(object sender, EventArgs e)
        {
            con.Open();
            var insertCity = new SqlCommand($"INSERT INTO Cities (city_name) VALUES  ('{Life_city.Text}')", con);
            insertCity.ExecuteNonQuery();
            if (Life_city.Text.ToUpper() != Registration_city.Text.ToUpper())
            {
                var insertCity2 = new SqlCommand($"INSERT INTO Cities (city_name) VALUES  ('{Registration_city.Text}')", con);
                insertCity2.ExecuteNonQuery();
            }
            
            var insertDrv = new SqlCommand($"INSERT INTO Drivers VALUES ({drv_id.Text}, '{Name.Text}', '{MiddleName.Text}'," +
                $" {Passport_serial.Text}, { Passport_number.Text},'{Registration_city.Text}','{Life_city.Text}'," +
                $"'{Company.Text}','{Jobname.Text}','{phone.Text}','{email.Text}','{photo.Text}'", con);
            if (postcode.Text != "")
            {
                insertDrv.CommandText += $", '{postcode.Text}'";
            }
            else
            {
                insertDrv.CommandText += $",' '";
            }
            if (note.Text != "")
            {
                insertDrv.CommandText += $", '{note.Text}'";
            }
            else
            {
                insertDrv.CommandText += $",' '";
            }
            insertDrv.CommandText += ")";
            insertDrv.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("New driver is added!");
            Cleaner();
        }

        private void WindowDrivers_Load(object sender, EventArgs e)
        {
            
        }
        public void Cleaner()
        {
            drv_id.Clear();Name.Clear();MiddleName.Clear();Passport_serial.Clear();Passport_number.Clear();
            Registration_address.Clear();Registration_city.Clear();Life_city.Clear();Address_life.Clear();Company.Clear();
            Jobname.Clear();phone.Clear();email.Clear();photo.Clear();note.Clear();postcode.Clear();
        }
    }
}
