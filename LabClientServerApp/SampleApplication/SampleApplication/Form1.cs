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


namespace SampleApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ConnectToSql()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=localhost\\SQL2012X64;"
            + "Initial Catalog=RedBook;" +
            "User ID=sa;" +
            "Password=Qwerty123;";
            try
            {
                conn.Open();
                ListOfConnectionTest.Items.Add("Соединение открыто");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ListOfConnectionTest.Items.Add("Ошибка соединения");
            }
            finally
            {
                conn.Close();
                ListOfConnectionTest.Items.Add("Соединение закрыто");
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            ConnectToSql();
        }
    }
}
