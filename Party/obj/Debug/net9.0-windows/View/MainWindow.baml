   M S B A M L   `   `   `  ����@  <Party, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Party.ViewModelParty.ViewModel  5   	       Party.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3	viewModelclr-namespace:Party.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	         Party.ViewModel.ViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Заявка��6   $��Center=�5      $��Center=�5      $��32(�5      $��10q�5      �� 5   
   $��1��6   .��6   #!Имена на заявител:61   �� 5   
   -   5         ��Name$
 ApIN��5      $��1��6   $	��200��5      $��
0, 10 0, 0q�5       ��5!      �� *Request.Applicant+ �� Mode$ TwoWay=��� 5#   
   $��2��6   .��6   " Телефон заявител:61   �� 5$   
   -   5        $ ApIPN��5$      $��2��6   $	��200��5%      $��
0, 10 0, 0q�5&      ��5'      �� *Request.ApplicantPN+$ TwoWay=��� 5)   
   -   5         ��Name$ PCapt��5)      $��3��6   ��6,   �� *CaptionName+�� 5*   
   $��3��6   $	��200��5+      $��
0, 10 0, 0q�5,      ��5-      �� *Request.BirthdayPerson+$ TwoWay=��� 5/   
   -   5        $ ACapt��5/      $��4��6   ��6,   �� *
CaptionAge+(  "System.Windows.Controls.DatePicker  50   
   -   5          Name$
 BDPA��50   "   $��4��6   $	��100��51      $��
0, 10 0, 0q�52         Text 53      �� *Request.BirthdayPersonAge+�� 55   
   -   5        $ DCapt��55      $��5��6   ��6,   �� *CaptionDate+  56   
   -   5        $ Bd��56   "   $��5��6   $	��100��57      $��
0, 10 0, 0q�58       59      �� *Request.Birthday+�� 5;   
   $��6��6   .��6   Дата на парти:6-     5<   
   $��6��6   $	��100��5=      $��0, 10, 0, 0q�5>       5?      �� *Request.Partydate+�� 5A   
   $��7��6   .��6   Брой балони:6+   �� 5B   
   -   5        $	 Bal��5C      $��7��5B      $	��200��5D      $��0, 10, 0, 0q�5E      ��5F      �� *Request.Baloons+�� 5H   
   -	   5        $��8��5H      $	��200��5I      $��50��5J      $��Bottom=�5K      $��0,0,0,20q�5L      $��Complete��5M      ��5O      �� *
AddCommand+��5P      �� *	Request+5Q      5R      