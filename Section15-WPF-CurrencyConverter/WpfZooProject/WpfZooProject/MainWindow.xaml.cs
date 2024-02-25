using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;

namespace WpfZooProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["WpfZooProject.Properties.Settings.testDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            showZoos();
            showAnimals();
        }

        private void showAnimals()
        {
            try
            {
                string query = "SELECT * from Animal";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                using (adapter)
                {
                    DataTable animalTable = new DataTable();
                    adapter.Fill(animalTable);

                    AnimalTable.DisplayMemberPath = "Name";
                    AnimalTable.SelectedValuePath = "Id";
                    AnimalTable.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not able to show animals. Error Message {0}", ex.ToString());
            }
        }

        private void showZoos()
        {
            try
            {
                string query = "SELECT * from Zoo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                using (adapter)
                {
                    DataTable zooTable = new DataTable();
                    adapter.Fill(zooTable);

                    listZoos.DisplayMemberPath = "Location";
                    listZoos.SelectedValuePath = "Id";
                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedZooInTextBox();
            showAssociatedAnimals();
        }

        private void showAssociatedAnimals()
        {
            try
            {
                string query = "SELECT * from Animal a " +
                    "inner join ZooAnimal za on a.Id = za.AnimalId " +
                    "where za.ZooId = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                using (adapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                    DataTable animalTable = new DataTable();
                    adapter.Fill(animalTable);

                    AssociatedAnimalList.DisplayMemberPath = "Name";
                    AssociatedAnimalList.SelectedValuePath = "Id";
                    AssociatedAnimalList.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void DeleteZoo(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM Zoo where id = @ZooId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally 
            { 
                sqlConnection.Close(); 
                showZoos();
            }
        }

        private void AddZoo(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO Zoo values (@Location)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", TextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showZoos();
            }
        }

        private void AddAnimalToZoo(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO ZooAnimal values (@ZooId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", AnimalTable.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAssociatedAnimals();
            }
        }

        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO Animal values (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", TextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAnimals();
            }
        }

        private void DeleteAnimal(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Animal WHERE Id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", AnimalTable.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAnimals();
            }
        }
        private void RemoveAnimalFromZoo(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM ZooAnimal WHERE ZooId = @ZooId AND AnimalId = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", AssociatedAnimalList.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAssociatedAnimals();
            }
        }

        private void ShowSelectedZooInTextBox()
        {
            try
            {
                string query = "SELECT Location from Zoo where Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                using (adapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable zooDataTable = new DataTable();
                    adapter.Fill(zooDataTable);
                    TextBox.Text = zooDataTable.Rows[0]["Location"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowSelectedAnimalInTextBox()
        {
            try
            {
                string query = "SELECT Name from Animal where Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                using (adapter)
                {
                    sqlCommand.Parameters.AddWithValue("@AnimalId", AnimalTable.SelectedValue);

                    DataTable zooDataTable = new DataTable();
                    adapter.Fill(zooDataTable);
                    TextBox.Text = zooDataTable.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AnimalTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimalInTextBox();
        }

        private void UpdateZoo(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "UPDATE ZOO set Location = @Location WHERE Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", TextBox.Text);
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showZoos();
            }
        }

        private void UpdateAnimal(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "UPDATE Animal set Name = @Name WHERE Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", TextBox.Text);
                sqlCommand.Parameters.AddWithValue("@AnimalId", AnimalTable.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAnimals();
            }
        }
    }
}
