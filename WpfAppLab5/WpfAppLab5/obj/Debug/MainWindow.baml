   M S B A M L   `   `   `  ����E  AWpfAppLab5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfAppLab5
WpfAppLab5  5   	       WpfAppLab5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfAppLab5     5   	     � Title$  
MainWindow��5   	   $	��500��6   $
��1000��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��4* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��2��5      $��0��5      $��Visible=�5      $��Visible=�5      $��Stretch=�5      $��Stretch=�5      ��5      �� *	Devices+ �� Mode$ TwoWay=� �� SelectedItem 5      �� *SelectedDevice+ �� View 5      �� 5      .P�5      ��  �� Width$
 auto��6%   $��	ClassGuid��5   %    �� DisplayMemberBinding 5   %   �� *	ClassGuid+$ TwoWay=��� 5       $
 auto��6%   $��
HardWareID��5!   %    5"   %   �� *
HardWareID+$ TwoWay=��� 5#      $
 auto��6%   $��DeviceID��5$   %    5%   %   �� *
DeviceID+$ TwoWay=��� 5&      $
 auto��6%   $��Manufacturer��5'   %    5(   %   �� *Manufacturer+$ TwoWay=��� 5)      $
 auto��6%   $
��Name��5*   %    5+   %   �� *Name+$ TwoWay=��� 5,      $
 auto��6%   $��Description��5-   %    5.   %   �� *Description+$ TwoWay=��� 5/      $
 auto��6%   $��PathName��50   %    51   %   �� *
PathName+$ TwoWay=�52      54      �� 56   
   $��Отключить��6   $��30(�57      $��0��58      $��1��59      $��Stretch=�5:      $��Stretch=�5;      ��5<      �� *DisableDevice+�� 5>   
   $��Включить��6   $��30(�5?      $��1��5@      $��1��5A      $��Stretch=�5B      $��Stretch=�5C      ��5D      �� *EnableDevice+5F      5G      