   M S B A M L   `   `   `  ����@  <Salex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SalexSalex  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       Salex.Bevetel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Salex     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ?live4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	     � Title$  Bevetel��5
   	   $	��450��6   $	��800��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterScreen=�6H    � WindowStyle$
 None=�6m   .��5      � -   5         � RowDefinitions 5   
   �� 5      �� 5      $��4* �6   �� 5      $��5* �6   .+�5   
   � $��0��6   $��0,0,0,0.333q�6   
�������.+�5      �� $��
Bevételek��6   $��Center=�6*   $��36(�6G   $��Italic$�6U   $��Georgia Pro Black)�6h   $
��Bold"�6�   �� 5      $��Right=�6    �� Orientation$ 
Horizontal=�65   .+�5      �� -   5        $��50��5   0   $��40��6;   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6(   6B   5      �� 5      -   5        $��50��5   .   $
��Auto��69   $	��0,2q�6G   .��5        $ Power=�6(   69   5      5      5       � 5"   
   $��1��6   
���� ��$��0,0.667,0,0q�60   $��2��6E    5#      �� 5$      $
��369* �6    �� 5%      $	��35* �6     � ColumnDefinitions 5'      �� 5(      $��9* �6#   �� 5)      $	��23* �6#   .+�5-      � -   5         �Name$ grafikonNapi��5-      $��0��6)   
�������$��0,0,0.333,4.333q�6I   .+�5.      �� $"��Kérem Válasszon Időszakot��6   $	��Top=�6<   $��0,0,70.333,0q�6T   �� 5/      -   5        	 ��Name$	 bevetelValaszt��5/      $
��Left=�63   $��0,29,0,0q�6N   $	��Top=�6`   $	��155��6x   .@�51      �� $
��Napi��6#   64   �� 52      $
��Heti��6#   64   �� 53      $
��Havi��6#   64   �� 54      $��	Negyedév��6#   68   �� 55      $��Félév��6#   65   �� 56      $	��Év��6#   62   58      �� 5:      $
��Left=�6   $	��122��68   $��0,57,0,0q�6E   $	��Top=�6W   $	��225��6o   �� 5;      -   5        
 ��Name$
 bevetelGomb��5;      $��0��6.   $��35(�6:   $
��Left=�6H   $��0,62,0,0q�6c   $	��Top=�6u   $	��215��6�   $	��107��6�   5A      � 5C      -   5        $
 top4��5C      $��0��6!   
��� ���$��2��6B   $��225,0,0,4.333q�6V   .+�5D      �� .+�5E      �� $��Center=�6    
���� ��$��30(�6Q   �� 6`   $�TOP 4��6d   �� 6s   $#� legjobb értékesítési nap��6w   6�   5F        LiveCharts.Wpf.PieChart  6   -   5          Name$ 	top4chart��5F   -   $��125,49,125,19q�6@   5G      5J      5M      5N      