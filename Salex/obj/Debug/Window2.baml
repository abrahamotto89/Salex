   M S B A M L   `   `   `  ����@  <Salex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SalexSalex  5   	       Salex.Window2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Salex     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Window2��5	   	   $	��250��6   $	��400��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterScreen=�6H    � WindowStyle$
 None=�6m   .��5
      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $	��43* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   � $��0��6   $��0,0,0,1.667q�6   
�������.+�5      �� $!��Nagykereskedés hozzáadás��6   $
��Left=�69   $��15(�6T   $��Italic$�6b   $��Georgia Pro Black)�6u   $
��Bold"�6�   $��6,0,0,0q�6�   �� 5      $��Right=�6    �� Orientation$ 
Horizontal=�65   .+�5      �� -   5        $��50��5   .   $
��Auto��69   $��0,0,0,0.333q�6G   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6(   69   5      5      5      � 5    
   $��1��6   .+�5!      �� .+�5"      � .+�5#      �� $��Nagyker Neve:��6   $��86��64   6A   �� 5$      -   5         ��Name$ 
nagykernev��5$   *   $	��158��6   6@   5%      � 5&      .+�5'      �� $��NagyKer Címe:��6   66   �� 5(      -   5        $
 ncim��5(      $	��158��6,   6:   5)      � 5*      .+�5+      �� $��Nagyker Tel:��6   $��83��63   6@   �� 5,      -   5        $
 ntel��5,      $	��162��6,   6:   5-      � 5.      .+�5/      �� $��Nagyker Email��6   $��85��64   6A   �� 50      -   5        $ nemail��50      $	��158��6.   6<   51      � 53      .+�54      �� -   5        	 ��Name$	 Hozzáad��54      $��Hozzáad��6.   56      57      58      5:      5;      5<      