   M S B A M L   `   `   `  ����B  >Flowers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FlowersFlowers  5   	   5clr-namespace:Flowers.ViewModelFlowers.ViewModel  5   	       Flowers.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Flowers     5   	   .vmclr-namespace:Flowers.ViewModel     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $��Достовка №:��6   �� 5      ��6   �� *FlowerDelivery.Id+5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� $��Address:��6   �� 5      ��6   �� *FlowerDelivery.Address+5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� $��Phone:��6   �� 5      ��6   �� *FlowerDelivery.Phone+5      �� 5    
   $��3��6   $ 
Horizontal=�6"   $
��Left=�6;   .+�5!      �� $��Delivery date:��6   (  "System.Windows.Controls.DatePicker  5"         Text 6   �� *FlowerDelivery.DeliveryDate+5#      �� 5$   
   $��4��6   $��50��6   $	��200��6*   $��Center=�66   $��Доставка��6S   ��6f   �� *	Delivered+�� 5%   
   $��5��6   ��6!   �� *Amount+5&      5'      