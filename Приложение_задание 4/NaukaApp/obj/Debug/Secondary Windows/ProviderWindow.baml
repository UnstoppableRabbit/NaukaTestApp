   M S B A M L   `   `   `  ����C  ?NaukaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NaukaApp.Secondary_WindowsNaukaApp.Secondary_Windows  5   	   /    )NaukaApp.Secondary_Windows.ProviderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:NaukaApp.Secondary_Windows     5   	     � Title$  Поставщики��5   	   $	��450��6   $	��800��6)   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��8* �6   6*   �� 5      $��* �6   6)   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ProviderGrid��5   &      
IsReadOnly .     HorizontalGridLinesBrush
 �����   RowBackground
 �����   AlternatingRowBackground
 �����   AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$%
 Номер поставщика��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *
ProviderID+5        5      $
 Наименование��6%    6;   �� *Name+5      5      �� 5   
   -   5         ��Name$ RefreshButton��5      $��1��6)   $	��170��66   $
��Left=�6B   $��15(�6]   .��6�   Обновить6�   �� 5   
   -   5        $ CloseButton��5      $��1��6&   $	��170��63   $��Right=�6?   $��15(�6[   .��6�   Закрыть окно6�   �� 5   
   -   5        $ ButtonRemove��5      $��1��6'   $	��170��64   $��Center=�6@   $��12(�6]   .��6�   20Удалить выбранный элемент6�   5      5      