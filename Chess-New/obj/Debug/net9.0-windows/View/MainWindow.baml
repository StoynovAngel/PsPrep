   M S B A M L   `   `   `  ����D  @Chess-New, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Chess_New.ViewModelChess_New.ViewModel  5   	       Chess_New.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7	viewModel!clr-namespace:Chess_New.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Bold"�6M   $��0��6_   $��0,0,0,10q�5      ��5      �� *	Game.Id+ �� StringFormat$  Партия шах №{0}��5      �� 5   
   $��Противник 1:��6   $��1��6'   �� 5   
    �� 
IsReadOnly$
 True��63   $��1��6E   $��	100,0,0,0q�6R   $	��200��6e   ��6   �� *P1+ �� Mode$ OneWay=�6e   �� 5   
   $��Противник 2:��6   $��2��6'   �� 5   
   $
 True��63   $��2��6E   $��	100,0,0,0q�6R   $	��200��6e   ��6   �� *P2+$ OneWay=�6e   �� 5   
   $��Цвят 1:��6   $��3��6"   �� 5   
   -   5        $��tbClr��5      $��3��6=   $��	100,0,0,0q�6J   $	��200��6]   ��6   �� *Game.P1Color+6]   �� 5!   
   $��Време за игра:��6   $��4��6)   �� 5"   
   -   5        $
��tbTi��5"      $��4��6>   $��	100,0,0,0q�6K   $	��200��6^   ��6   �� *Game.TimeLimit+6^   �� 5$   
   $��Начало:��6   $��5��6"   �� 5%   
   -   5        $
��tbSt��5%      $��5��6:   $��	100,0,0,0q�6G   $	��200��6Z   ��6   �� *
Game.Start+6Z   �� 5'   
   -   5         ��Name$ FormattedOutput��5'      $��6��6   ��66   �� *FormattedOutput+5(      5)      