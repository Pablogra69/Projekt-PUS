   M S B A M L   `   `   `  ����I  EClient_WPF_1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Client_WPF_1._0Client_WPF_1._0  5   	   -    'Client_WPF_1._0.Window_ListPictureEmpty   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Client_WPF_1._0     5   	     � Title$  List of products��5   	    � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�5   	   
���   � � WindowStartupLocation$ CenterScreen=�5   	   ��5	   	   �� *&$SystemParameters.PrimaryScreenHeight+��5
   	   �� *%#SystemParameters.PrimaryScreenWidth+ � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value��%  '��       '�� c    �� 5   
   " ��6   .�5      ��  � ��$ Oblique$�6*   �� 5       � ��
 �����6+   �� 5       � ��$ 22(�6)   �� 5       � ��$ Stretch=�64   �� 5       � ��$ Stretch=�62   �� 5       � ��$ Oblique$�6*   �� 5       � ��
 �����6,   �� 5       � ��$ 	10,0,10,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 20(�6)   �� 5       � ��$ 3q�60   �� 5       � ��
 �����6+   �� 5        � ��$ Oblique$�6*   �� 5!       � ��
 �����6,    5#      P� 5$      	 �@J�IsMouseOver
 . . �5%      ��  � ��
 �����63   �� 5&       � ��
 �   �63   5'      5)      5-      .��5.      �  � ColumnDefinitions 5/   
   �� 50      $��* �6   �� 51      $��* �6    � RowDefinitions 53   
   �� 54      $��40 �6   �� 55      $��* �6   .+�58   
   �� -   5         ��Name$ Button_ProductModify��59      $��
Uaktualnij��5:      $	��150��5;      $
��Left=�5<      $��Stretch=�5=      $��0��5>      $��5,5,0,0q�5@      6*   �� 5B   
   -   5        $ Button_PictureModify��5C      $��
Uaktualnij��5D      $	��150��5E      $��Right=�5G      $��Stretch=�5H      $��1��5J      $��0��5K      $��0,5,5,0q�5L      6*   �� 5M   
   -   5        $ Button_Back��5N      $
��Back��5O       �� IsCancel . $	��150��5Q      $��Center=�5R      $��Stretch=�5S      $��0��5U      $��2��5V      $��0��5W      $��0,5,0,0q�5X      6*   �� 5Z   
   $��Braki��6   $��0��5[      $��1��5\      .��5]      �� -   5         ��Name$ TextBlock_Product��5]      $��22(�61   $��Regular"�5^       �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�5`      $��Disabled=�5a      $
��Auto=�5b      
�������.��5c   ,   .��5k   (   5l      5m      �� 5o   
   $��Zdjęcia��6   $��1��5p      $��1��5q      .��5s      �� -   5        $ TextBlock_Picture��5s      $��22(�61   $��Regular"�5t      
������� . $ Visible=�5x      $��Disabled=�5y      $
��Auto=�5z      .��5{      5}      5�      5�      5�      