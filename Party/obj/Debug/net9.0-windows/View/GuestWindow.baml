   M S B A M L   `   `   `  ����@  <Party, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Party.ViewModelParty.ViewModel  5   	       Party.View.GuestWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   3	viewModelclr-namespace:Party.ViewModel     5   	     � Title$  GuestWindow��5   	   $	��450��6   $	��800��6*    � DataContext 5	         Party.ViewModel.ViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Guests��6   $��Center=�6!   $��32(�6>   �� 5   
   $��1��6   $��10q�6F   $
��Auto=�5      ��5      �� *Request.Guests+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� ��6$   �� *	GuestName+�� 5      ��6$   �� *
GuestAge+5      5      5!      �� 5"   
   $��2��6   $��10,0,0,0q�6   .��6/   Write guest id to be deleted:6N   �� 5#   
   -   5        $��GuestIdComboBox��5#       $��2��6   $	��200��5$       �� DisplayMemberPath$ Id��5%       �� SelectedValuePath$ Id��5&      $��10q�5(      �� 5)   
   -   5         ��Name$ 	BtnDelete��5)      $��3��6   $��Delete Guest��61   $��Bottom=�6H   $��10q�6c   6o   �� 5*   
   -   5        $ BtnSaveOrder��5*      $��4��6   $
��Save��64   $��Bottom=�6C   $��10q�6^   6j   5+      5,      