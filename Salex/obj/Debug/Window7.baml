   M S B A M L   `   `   `  ����@  <Salex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SalexSalex  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       Salex.Window7   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Salex     5   	   Elive4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Window7��5
   	   $	��450��6   $	��800��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterScreen=�6H    � WindowStyle$
 None=�6m   .��5      � -   5         � ColumnDefinitions 5   
   �� 5      $	��73* �6   �� 5      $	��87* �6    � RowDefinitions 5   
   �� 5      �� 5      $	��14* �6   .+�5   
   � $��0��6   
��� ���$��2��6.   .+�5      �� $��
Grafikonok��6   $��Center=�6*   $��20(�6G   6W   �� 5      $��Right=�6    �� Orientation$ 
Horizontal=�65   .+�5      �� -   5        .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6(   6@   5      �� 5      -   5        $��0,0,0,-2q�5      .��5        $ WindowClose=�6(   5      5      5      � 5"   
   -   5         �Name$ grafikonGrid��5"   ,   $��1��6   $��0��6   $��5,5,5,5q�6B   
��� ���6h   � 5#   
   -   5        $ grafikonGrid2��5#   ,   $��1��6   $��1��6   
�������.+�5*        LiveCharts.Wpf.PieChart  -   5        	  Name$	 piechart��5*      $	��326��6.   $	��326��6;   6I   5+      5,      5-      