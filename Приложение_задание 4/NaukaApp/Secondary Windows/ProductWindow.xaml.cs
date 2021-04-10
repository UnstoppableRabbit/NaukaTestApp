using NaukaApp.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NaukaApp.Secondary_Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        Product CurrentProduct = null;
        public ProductWindow()
        {
            InitializeComponent();
            RefreshDB();
            ProductGrid.CellEditEnding += ProductGrid_CellEditEnding;
            ProductGrid.SelectedCellsChanged += ProductGrid_SelectedCellsChanged;
        }

        private void ProductGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(CurrentProduct != null)
            {
                if (CurrentProduct.ProductNumber != 0)
                {
                    using (var con = new naukaEntities()) //update
                    {
                        Product curr = (from item in con.Product
                                        where item.ProductNumber == CurrentProduct.ProductNumber
                                        select item).First();
                        curr.Name = CurrentProduct.Name;
                        curr.Description = CurrentProduct.Description;
                        curr.Cost = CurrentProduct.Cost;
                        con.SaveChanges();
                    }
                }
                else
                {
                    using (var con = new naukaEntities()) //create
                    {
                        con.Product.Add(new Product
                        {
                            Cost = CurrentProduct.Cost,
                            Name = CurrentProduct.Name,
                            Description = CurrentProduct.Description
                        });
                        con.SaveChanges();
                    }
                }
                CurrentProduct = null;
            }
        }
        private void RefreshDB() //read
        {
            using (var con = new naukaEntities())
            {
                ProductGrid.ItemsSource = (from prods in con.Product
                                           select prods).ToList();
            }
        }

        private void ProductGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrentProduct = (Product)e.Row.Item;
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
                Product row = (Product)ProductGrid.SelectedItem;
                using (var con = new naukaEntities())
                {
                    Product curr = (from item in con.Product
                                    where item.ProductNumber == row.ProductNumber
                                    select item).First();
                    con.Product.Remove(curr);
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
