   M S B A M L   `   `   `  ����  
RaceSystem     RaceSystem.PnlManageRfidNo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � $��0,0,0,10q�6     � RowDefinitions  5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $
��276* �6   �� 5      $	��33* �6   �� 5      $
��109* �6   �� 5      $	��30* �6   .+�5   
   �� $��	RFID List��6   $��
10,10,12,0q�6&   .��5      �� -   5         ��Name$ 	RFID_list��5      $��
0,10,0,-12q�6W    �� View 5      �� 5      .P�5      �� $��RFID No��6)    �� Width$	 170��6:    �� DisplayMemberBinding 6F   �� *	Rfid_No+�� 5      $��RFID Tag No��6)   $	 300��6>    6J   �� *Rfid_Tag_No+5      5      5      �� 5    
   -   5         ��Name$ 
Start_RFID��5       $��Start��6%   $��
38,94,44,0q�65   $��21��6]   $	��Top=�6i   $��2��6�   �� 5!   
   -   5        $ Delete_RFID��5!      $��Delete��6&   $��38,193,44,0q�67   $��21��6a   $	��Top=�6m   $��2��6�   �� 5"   
   -   5        $ 	Stop_RFID��5"      $
��Stop��6$   $��38,145,44,0q�63   $��21��6[   $	��Top=�6g   $��2��6   �� 5#   
   $��	Com Port:��6   $��16,42,190,0q�6$   $��25��69   $	��Top=�6E   $��1��6]   $��2��6m   �� 5$   
   -   5         ��Name$ comPort��5$      $��
38,45,44,0q�6$    �� TextWrapping$
 Wrap=�68   $�� ��6L   $��21��6T   $	��Top=�6`   $��2��6x   5&      5'      