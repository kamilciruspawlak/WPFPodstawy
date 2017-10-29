using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<PersonData> listOfPeople = new ObservableCollection<PersonData>();

        string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public MainWindow()
        {
                                 
            InitializeComponent();

            listOfPeople.Add(new ListView.PersonData() {Name="Kamil", Age=29, Email="aaa@aa.aa"});
            listOfPeople.Add(new ListView.PersonData() { Name = "Marta", Age = 40, Email = "yyy@aa.aa" });
            listOfPeople.Add(new ListView.PersonData() { Name = "Marta", Age = 20, Email = "bbb@aa.aa" });
            listOfPeople.Add(new ListView.PersonData() { Name = "Maja", Age = 18, Email = "ccc@aa.aa" });

            ListaImion.ItemsSource = listOfPeople;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var name = imie.Text.Trim();
            var age = int.Parse(wiek.Text);
            var email = Regex.IsMatch(majl.Text.Trim(), pattern) ? majl.Text.Trim() : string.Empty;
            

            if (!string.IsNullOrWhiteSpace(imie.Text) && !string.IsNullOrWhiteSpace(wiek.Text) && !string.IsNullOrWhiteSpace(majl.Text))
            {

                listOfPeople.Add(new ListView.PersonData() { Name = name, Age = age, Email = email });
                imie.Text = "";
                wiek.Text = "";
                majl.Text = "";
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
           var selectedName = ListaImion.SelectedItem as PersonData;
            if(selectedName != null)
            {
                listOfPeople.Remove(selectedName);
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = (sender as GridViewColumnHeader);
            string columnNameToSort = null;
            if (header!= null)
            {
                columnNameToSort = header.Content.ToString();

            }

            var howToSort = ListSortDirection.Ascending;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListaImion.ItemsSource);

            if (view.SortDescriptions.Any())
            {
                SortDescription item = view.SortDescriptions.ElementAt(0);

                if(columnNameToSort == item.PropertyName.ToString())
                {
                    if(item.Direction == ListSortDirection.Ascending)
                    {
                        howToSort = ListSortDirection.Descending;
                    }
                    else
                    {
                        howToSort = ListSortDirection.Ascending;
                    }
                }
            }
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(columnNameToSort, howToSort));
        }
                     

    }
}
