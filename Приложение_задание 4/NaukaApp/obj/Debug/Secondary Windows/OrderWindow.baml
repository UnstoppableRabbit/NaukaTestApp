   M S B A M L   `   `   `  ����C  ?NaukaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NaukaApp.Secondary_WindowsNaukaApp.Secondary_Windows  5   	   ,    &NaukaApp.Secondary_Windows.OrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:NaukaApp.Secondary_Windows     5   	     � Title$  Ордеры��5   	   $	��500��6   $
��1100��6%   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��8* �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	OrderGrid��5   &      
IsReadOnly .  $��0,0,10,0q�69      HorizontalGridLinesBrush
 �����   RowBackground
 �����   AlternatingRowBackground
 �����   AutoGenerateColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   
IsReadOnly
 .    Header$ Номер ордера��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *
OrderNum+5        5      $ Дата��6%    63   �� *	OrderDate+5        5      $% Договор поставки��6%    6?   �� *DeliveryContract+5        5      $ Цена��6%    63   �� *
TotalPrice+5        5      $% Номер поставщика��6%    6?   �� *
ProviderID+5      5         5!   
   -   5        $ OrderProductGrid��5!   &    .  $��1��6@   $��10,0,0,0q�6P   
 �����
 �����
 ����� .  	 5#        5$      
 . $- 'Номер товара в ордере��67    6V   �� *ID+5%        5&      $ Номер ордера��6%    6;   �� *
OrderNum+5'        5(      $' !Количество товара��6%    6@   �� *
Quantity+5)        5*      $ Номер склада��6%    6;   �� *WarehouseID+5+        5,      $! Номер продукта��6%    6=   �� *ProductNumber+5-      5/      �� 50   
   -   5         ��Name$ RefreshButton��50      $��2��6(   $��1��6<   $	��170��6I   $
��Left=�6U   $��15(�6p   .��6�   Обновить6�   �� 51   
   -   5        $ CloseButton��51      $��2��6&   $��1��6:   $	��170��6G   $��Right=�6S   $��15(�6o   .��6�   Закрыть окно6�   �� 52   
   -   5        $ ButtonRemove��52      $��2��6'   $��1��6;   $	��170��6H   $��Center=�6T   $��12(�6q   .��6�   20Удалить выбранный элемент6�   53      54      