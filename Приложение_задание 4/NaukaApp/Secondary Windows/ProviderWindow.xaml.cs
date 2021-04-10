using NaukaApp.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NaukaApp.Secondary_Windows
{
    /// <summary>
    /// Логика взаимодействия для ProviderWindow.xaml
    /// </summary>
    public partial class ProviderWindow : Window
    {
        Provider CurrentProvider = null;
        public ProviderWindow()
        {
            InitializeComponent();
            RefreshDB();
            ProviderGrid.CellEditEnding += ProviderGrid_CellEditEnding;
            ProviderGrid.SelectedCellsChanged += ProviderGrid_SelectedCellsChanged;
        }

        private void RefreshDB() //read
        {
            using (var con = new naukaEntities())
            {
                ProviderGrid.ItemsSource = (from item in con.Provider
                                           select item).ToList();
            }
        }

        private void ProviderGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (CurrentProvider != null)
            {
                if (CurrentProvider.ProviderID != 0)
                {
                    using (var con = new naukaEntities()) //update
                    {
                        Provider curr = (from item in con.Provider
                                        where item.ProviderID == CurrentProvider.ProviderID
                                        select item).First();
                        curr.Name = CurrentProvider.Name;                  
                        con.SaveChanges();
                    }
                }
                else
                {
                    using (var con = new naukaEntities()) //create
                    {
                        con.Provider.Add(new Provider
                        { 
                            Name = CurrentProvider.Name,
                        });
                        con.SaveChanges();
                    }
                }
                CurrentProvider = null;
            }
        }
        private void ProviderGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrentProvider = (Provider)e.Row.Item;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshDB();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e) //delete
        {
            try
            {
                Provider row = (Provider)ProviderGrid.SelectedItem;
                using (var con = new naukaEntities())
                {
                    Provider curr = (from item in con.Provider
                                    where item.ProviderID == row.ProviderID
                                    select item).First();
                    con.Provider.Remove(curr);
                    con.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RefreshDB();
        }
    }
}
