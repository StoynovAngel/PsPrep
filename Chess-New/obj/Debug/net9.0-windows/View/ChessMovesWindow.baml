   M S B A M L   `   `   `  ����D  @Chess-New, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Chess_New.ViewModelChess_New.ViewModel  5   	   %    Chess_New.View.ChessMovesWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   0vm!clr-namespace:Chess_New.ViewModel     5   	     � Title$  ChessMovesWindow��5	   	   $	��450��6"   $	��800��6/   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� ��6   �� *
Game.Moves+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��10q�6>   ��6$   �� *
StartPos+6>   �� 5      $��10q�6<   ��6$   �� *EndPos+6<   �� 5      $��10q�6[   ��6$   �� *
MoveTime+ �� StringFormat$ {0:HH:mm:ss}��6[   5      5      5      5      5      