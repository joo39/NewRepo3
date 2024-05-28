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
    /// Логика взаимодействия для AddData.xaml
    /// </summary>
    public partial class AddData : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;
        public AddData()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Name_btn.Text !=""&&Data_btn.Text !=""&&Capacity_btn.Text !=""&&TO_btn.Text !=""&&hours_btn.Text !="")
            {
                        string sql = $"insert into Airplanes values ('{Name_btn.Text}','{Data_btn.Text}',{Capacity_btn.Text},'{TO_btn.Text}',{hours_btn.Text})";
                        AeroportTable = new DataTable();

                try
                {
                    connection = new SqlConnection(connectionString);
                        connection.Open();
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                        adapter = new SqlDataAdapter(command);
                        MessageBox.Show("Данные добавлены");
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

