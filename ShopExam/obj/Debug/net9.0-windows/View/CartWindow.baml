   M S B A M L   `   `   `  ����  ShopExam    ShopExam.View.CartWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	     � Title$  
CartWindow��5   	   $	��450��6   $	��800��6)   .��5      � $��10q�6    � RowDefinitions 5	   
   �� 5
      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *
CartList+��5      �� 5      .R�5      �� .+�5      �� $
��Bold"�6:   ��6$   �� *Name+6:   �� 5      ��6$   �� *SinglePrice+ �� StringFormat$ Цена: {0} лв.��5      5      5      �� 5   
   $��1��6   $��14(�5      $
��Bold"�5      $��Center=�5      $��0,10,0,0q�5      ��5      �� *
TotalPrice+$" Обща сума: {0} лв.��5      �� 5    
   $��2��6   $#��Завърши поръчка��5!      $��14(�5#      $
��Bold"�5$      $��Center=�5%      $��0,10,0,0q�5&      ��5"      �� *CreateOrderCommand+5&      5'      5(      