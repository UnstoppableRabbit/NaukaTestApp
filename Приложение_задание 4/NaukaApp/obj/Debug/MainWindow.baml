   M S B A M L   `   `   `  ����C  ?NaukaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:NaukaAppNaukaApp  5   	       NaukaApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:NaukaApp     5   	     � Title$  Наука БД��5   	   $	��600��6   $
��1000��6'   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $��2��6   $��40(�6(   $��Center=�66   $��Center=�6S   $@��:Выберите объект взаимодействия��6n   6�   �� 5   
   -   5         ��Name$ ProductButton��5      $��0��6(   $��1��68   $��20q�6E   $��30(�6Q   .��6{   Товары6�   �� 5   
   -   5        $ ProviderButton��5      $��1��6)   $��1��69   $��20q�6F   $��30(�6R   .��6}   Поставщики6�   �� 5   
   -   5        $ WarehouseButton��5      $��0��6*   $��2��6:   $��20q�6G   $��30(�6S   .��6   Склады6�   �� 5   
   -   5        $ OrderButton��5      $��1��6&   $��2��66   $��20q�6C   $��30(�6O   .��6w   Ордеры6   5      5      