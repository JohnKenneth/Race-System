   M S B A M L   `   `   `  ����  
RaceSystem$    RaceSystem.PnlAddDriverToEvent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � ColumnDefinitions  5   
   �� 5	      $
��229* �6   �� 5
      $
��170* �6   �� 5      $	��49* �6    � RowDefinitions 5   
   �� 5      $
��670* �6   �� 5      $	��73* �6   .+�5   
   �� $��Events Criteria��6   $��
10,10,10,0q�6,   $	��228��6@   $	��Top=�6M   $��3��6e   .��5      � $��10,10,-2,-12q�6   $	��208��6)   $	��Top=�66   $
��Left=�6N   $	��856��6i    5      �� 5        5      �� 5      .+�5      �� $��
Event Name��6   $��	10,10,0,0q�6-   $
��Left=�6@   $��96��6[   $��25��6f   $	��Top=�6r   �� 5      $��
Race Class��6   $��	10,40,0,0q�6-   $
��Left=�6@   $��96��6[   $��25��6f   $	��Top=�6r   �� 5      $y�	Collapsed=�6   $��Race Session��6/   $��	10,70,0,0q�6F   $
��Left=�6Y   $��96��6t   $��25��6   $	��Top=�6�   �� 5      -   5         ��Name$ eventComboBox��5       �� DisplayMemberPath$ 	EventName��6c   $��124,10,472,0q�6�   $��20��6�   $	��Top=�6�   �� 5      -   5        $ raceClassComboBox��5      $
 Name��6l   $��124,40,472,0q�6�   $��20��6�   $	��Top=�6�   �� 5      -   5        $ raceSessionComboBox��5   2   $y�	Collapsed=�6   $
 Name��6�   $��124,70,472,0q�6�   $��20��6�   $	��Top=�6�   5      5       �� 5!   
   -   5         ��Name$ registeredDriverList��5!      $��10,145,10,10q�6]   $��3��6s    �� View 5"      �� 5#      .P�5%      �� $��
Racer Name��6%    �� Width$	 200��69    �� DisplayMemberBinding 6E   �� *Name+�� 5&      $��RFID No.��6%   $	 200��67    6C   �� *	Rfid_No+�� 5'      $��	Team Name��6%   $	 200��68    6D   �� *	Team_id+�� 5(      $��Vehicle Model��6%   $	 200��6<    6H   �� *Vehicle_model+5*      5,      �� 5-   
   -   5         ��Name$ buttonAddDriver��5-      $��	Add Racer��6*   $��209,10,74,0q�6>   $��25��6l   $��1��6x   $	��Top=�6�   �� 5.   
   -   5        $ buttonRemoveDriver��5.      $��Remove Racer��6-   $��44,10,119,0q�6D   $��1��6u   $��1��6�   $��25��6�   $	��Top=�6�   50      51      