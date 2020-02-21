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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionToGibdd = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=gibdd; Integrated Security=True");
            var usersQuery = new SqlCommand($"SELECT login FROM users WHERE login = '{textBox1.Text}' and password = '{textBox2.Text}'", connectionToGibdd);
            connectionToGibdd.Open();
            var reader = usersQuery.ExecuteReader(); 
            if (reader.HasRows)
            {
                MessageBox.Show("OK");
            }
            else
            {
                if (Properties.Settings.Default.banTime < DateTime.UtcNow)
                {
                    Properties.Settings.Default.banCount++;
                    if (Properties.Settings.Default.banCount == 3)
                    {
                        Properties.Settings.Default.banTime = DateTime.UtcNow.AddMinutes(1);
                        Properties.Settings.Default.banCount = 0;
                        button1.Enabled = false;
                    }
                    MessageBox.Show("not OK");
                    Properties.Settings.Default.Save();
                }
            }
            connectionToGibdd.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.banTime < DateTime.UtcNow)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.banTime < DateTime.UtcNow)
            { 
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
