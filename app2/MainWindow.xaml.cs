using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace app2
{    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string sqlCon = @"Data Source=LAB108PC12\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True;";

        private void usernameClear(object sender, RoutedEventArgs e)
        {

            if (txtFirstname.Text == "First Name")
            {
                txtFirstname.Text = "";
            }
        }

        private void Insert_(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);

            try
            {
                string query = $"Insert into UserCredentials(Username,FirstName,LastName,Email,Password) values ('{txtUsername.Text}','{txtFirstname.Text}','{txtLastname.Text}','{txtEmail.Text}','{pswdBox.Password}')";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("success!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);

            try
            {
                string query = $"Delete from UserCredentials Where Username = '{txtUsername.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("success!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);

            try
            {
                string query = $"Update UserCredentials SET FirstName = '{txtFirstname.Text}', LastName = '{txtFirstname.Text}', Email = '{txtEmail.Text}', Password = '{pswdBox.Password}' WHERE Username = '{txtUsername.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("success!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
