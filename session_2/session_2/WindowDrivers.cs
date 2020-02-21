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
    public partial class WindowDrivers : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = gibdd; Integrated Security = True");

        public WindowDrivers()
        {
            InitializeComponent();
        }

        private void AddNewDriver_Click(object sender, EventArgs e)
        {
            //con.Open();
            //var insertDrv = new SqlCommand($"INSERT INTO drivers_new VALUES ({drv_id.Text}, {FirstName.Text + SecondName.Text}, {FatherName.Text}, {Passport_serial.Text + Passport_number.Text}, {Registration_city.Text}, ,{Life_city.Text}, {Job.Text}, {Jobname.Text}, {phone.Text}, {email.Text}, {photo.Text}, {note.Text})", con);
            //int count = insertDrv.ExecuteNonQuery();
            //MessageBox.Show($"Добавлено объектов: {count.ToString()}");
        }

        private void WindowDrivers_Load(object sender, EventArgs e)
        {

        }
    }
}
