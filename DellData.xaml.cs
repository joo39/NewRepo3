using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для DellData.xaml
    /// </summary>
    public partial class DellData : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;
        public DellData()
        {
            InitializeComponent();
        }
        private void DTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ButtonDell_Click(object sender, RoutedEventArgs e)
        {
            if (Name_btn.Text != "")
            {
                string sql = $"delete from Airplanes where airplane_id = {Name_btn.Text}";
                AeroportTable = new DataTable();

                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    adapter = new SqlDataAdapter(command);
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    if (connection != null)
                        connection.Close();
                }
            }
            else
            {
                MessageBox.Show("не все поля заполнены");
            }
        }
    }
}
