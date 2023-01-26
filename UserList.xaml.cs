using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xMap;

namespace SHINS
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : Window
    {
        private static Person person;

        public UserList()
        {
            InitializeComponent();
        }

        
            
        private void ReadPage_Loaded(object sender, RoutedEventArgs e)
        {



                var persons =  Getdata().ToList();
                personListView.ItemsSource = persons;
            
        }
        private List<Person> persons = new List<Person>();

        private  List<Person> Getdata()
        {

            string myslqcon = "server=localhost;user=root;database=smarthouse;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(myslqcon);


            try
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select * from user", mySqlConnection);
                MySqlDataReader Reader = mySqlCommand.ExecuteReader();

                while (Reader.Read())
                {

                    persons.Add(new Person() { Id = Reader.GetString("id"), FirstName = Reader.GetString("firstname"), LastName = Reader.GetString("lastname"), Type = Reader.GetString("type") });
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { mySqlConnection.Close(); }

            return persons;

        }

        private void log_out_Click(object sender, RoutedEventArgs e)
        {

            MainWindow log_in = new MainWindow();
            this.Close();
            log_in.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserList list = new UserList();
            this.Close();
            list.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sysdesec sec = new sysdesec();
            this.Close();
            sec.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            systemp sect = new systemp();
            this.Close();
            sect.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dashboard dash = new dashboard();
            this.Close();
            dash.Show();
        }
    }
}
