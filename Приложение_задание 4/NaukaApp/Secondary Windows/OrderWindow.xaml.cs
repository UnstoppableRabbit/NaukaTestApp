using NaukaApp.Models;
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
using System.Windows.Shapes;

namespace NaukaApp.Secondary_Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        ReceiptOrder CurrentOrder = null;
        ReceiptOrder_Product CurrentOrderProduct = null;
        public OrderWindow()
        {
            InitializeComponent();
            RefreshDB();
            OrderGrid.CellEditEnding += OrderGrid_CellEditEnding;
            OrderGrid.SelectedCellsChanged += OrderGrid_SelectedCellsChanged;
            OrderProductGrid.CellEditEnding += OrderProductGrid_CellEditEnding;
            OrderProductGrid.SelectedCellsChanged += OrderProductGrid_SelectedCellsChanged;
        }

        private void OrderProductGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (CurrentOrderProduct != null)
            {
                try
                {
                    if (CurrentOrderProduct.ID != 0)
                    {
                        using (var con = new naukaEntities()) //update
                        {
                            ReceiptOrder_Product curr = (from item in con.ReceiptOrder_Product
                                                 where item.ID == CurrentOrderProduct.ID
                                                 select item).First();
                            curr.OrderNum = CurrentOrderProduct.OrderNum;
                            curr.ProductNumber = CurrentOrderProduct.ProductNumber;
                            curr.Quantity = CurrentOrderProduct.Quantity;
                            curr.WarehouseID = CurrentOrderProduct.WarehouseID;
                            
                            con.SaveChanges();
                        }
                    }
                    else
                    {
                        using (var con = new naukaEntities()) //create
                        {
                            con.ReceiptOrder_Product.Add(new ReceiptOrder_Product
                            {
                                 OrderNum = CurrentOrderProduct.OrderNum,
                                 ProductNumber = CurrentOrderProduct.ProductNumber,
                                 Quantity = CurrentOrderProduct.Quantity,
                                WarehouseID = CurrentOrderProduct.WarehouseID
                            });
                            con.SaveChanges();
                        }
                    }
                    CurrentOrderProduct = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OrderProductGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrentOrderProduct = (ReceiptOrder_Product)e.Row.Item;
        }

        private void OrderGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (CurrentOrder != null)
            {
                try
                {
                    if (CurrentOrder.OrderNum != 0)
                    {
                        using (var con = new naukaEntities()) //update
                        {
                            ReceiptOrder curr = (from item in con.ReceiptOrder
                                                 where item.OrderNum == CurrentOrder.OrderNum
                                                 select item).First();
                            curr.OrderDate = CurrentOrder.OrderDate;
                            curr.ProviderID = CurrentOrder.ProviderID;
                            curr.DeliveryContract = CurrentOrder.DeliveryContract;
                            curr.TotalPrice = CurrentOrder.TotalPrice;
                            con.SaveChanges();
                        }
                    }
                    else
                    {
                        using (var con = new naukaEntities()) //create
                        {
                            con.ReceiptOrder.Add(new ReceiptOrder
                            {
                                OrderDate = CurrentOrder.OrderDate,
                                ProviderID = CurrentOrder.ProviderID,
                                DeliveryContract = CurrentOrder.DeliveryContract,
                                TotalPrice = CurrentOrder.TotalPrice
                            });
                            con.SaveChanges();
                        }
                    }
                    CurrentOrder = null;
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void OrderGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CurrentOrder = (ReceiptOrder)e.Row.Item;
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshDB();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem != null)
            {
                try
                {
                    ReceiptOrder row = (ReceiptOrder)OrderGrid.SelectedItem;
                    using (var con = new naukaEntities())
                    {
                        ReceiptOrder curr = (from item in con.ReceiptOrder
                                             where item.OrderNum == row.OrderNum
                                             select item).First();
                        con.ReceiptOrder.Remove(curr);
                        con.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshDB();
            }
            if (OrderProductGrid.SelectedItem != null)
            {
                try
                {
                    ReceiptOrder_Product row = (ReceiptOrder_Product)OrderProductGrid.SelectedItem;
                    using (var con = new naukaEntities())
                    {
                        ReceiptOrder_Product curr = (from item in con.ReceiptOrder_Product
                                             where item.ID == row.ID
                                             select item).First();
                        con.ReceiptOrder_Product.Remove(curr);
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RefreshDB() //read
        {
            using (var con = new naukaEntities())
            {
                OrderGrid.ItemsSource = (from x in con.ReceiptOrder
                                         select x).ToList();

                OrderProductGrid.ItemsSource = (from x in con.ReceiptOrder_Product
                                                select x).ToList();
            }
        }
    }
}
