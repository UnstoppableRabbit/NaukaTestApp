using NaukaApp.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NaukaApp.Secondary_Windows
{
    /// <summary>
    /// Логика взаимодействия для WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        Warehouse CurrentWarehouse = null;
        public WarehouseWindow()
        {
            InitializeComponent();
            RefreshDB();
            WarehouseGrid.CellEditEnding += WarehouseGrid_CellEditEnding;
            WarehouseGrid.SelectedCellsChanged += WarehouseGrid_SelectedCellsChanged;
        }

        private void RefreshDB() //read
        {
            using (var con = new naukaEntities())
            {
                WarehouseGrid.ItemsSource = (from item in con.Warehouse
                                            select item).ToList();
            }
        }

        private void WarehouseGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (CurrentWarehouse != null)
            {
                if (CurrentWarehouse.WarehouseID != 0)
                {
                    using (var con = new naukaEntities()) //update
                    {
                        Warehouse curr = (from item in con.Warehouse
                                         where item.WarehouseID == CurrentWarehouse.WarehouseID
                                         select item).First();
                        curr.Address = CurrentWarehouse.Address;
                        con.SaveChanges();
                    }
                }
                else
                {
                    using (var con = new naukaEntities()) //create
                    {
                        con.Warehouse.Add(new Warehouse
                        {
                            Address = CurrentWarehouse.Address
                        });
                        con.SaveChanges();
                    }
                }
                CurrentWarehouse = null;
            }
        }
        private void WarehouseGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrentWarehouse = (Warehouse)e.Row.Item;
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
                Warehouse row = (Warehouse)WarehouseGrid.SelectedItem;
                using (var con = new naukaEntities())
                {
                    Warehouse curr = (from item in con.Warehouse
                                     where item.WarehouseID == row.WarehouseID
                                     select item).First();
                    con.Warehouse.Remove(curr);
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
