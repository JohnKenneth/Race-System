   M S B A M L   `   `   `  ����  
RaceSystem%    RaceSystem.AddDriverToEventForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AddDriverToEventForm��5   	   $	��379��6&   $	��467��63    � 
ResizeMode$ NoResize=�6?   .��5      � .+�5   
   �� -   5         ��Name$ 
driverList��5       �� SelectionMode$ Single=�6'   $
��Left=�6b   $	��300��6}   $��	10,38,0,0q�6�   $	��Top=�6�   $	��208��6�    �� View 5      �� 5      .P�5	      �� $��
Racer Name��6%    �� Width$	 200��69    �� DisplayMemberBinding 6E   �� *Name+5      5      �� 5   
   $��
Racer Name��6   $
��Left=�6%   $��
223,30,0,0q�6@   $	��Top=�6T   $��92��6l   �� 5   
   $��	Team Name��6   $
��Left=�6$   $��
223,83,0,0q�6?   $	��Top=�6S   $��92��6k   �� 5   
   $��Vehicle Model��6   $
��Left=�6(   $��223,129,0,0q�6C   $	��Top=�6X   $��92��6p   �� 5   
   $��Rfid No.��6   $
��Left=�6#   $��223,185,0,0q�6>   $	��Top=�6S   $��92��6k   �� 5   
   -   5         ��Name$ 
driverName��5       �� 
IsReadOnly . $��23��68   $��320,30,12,0q�6D   	 �� TextWrapping$
	 Wrap=�6Y   $�� ��6m   $	��Top=�6u   {�.  6�   �� 5   
   -   5        $ teamId��5       . $��23��64   $��320,83,12,0q�6@   $
	 Wrap=�6U   $�� ��6i   $	��Top=�6q   {�.  6�   �� 5   
   -   5        $ vehicleModel��5      $��23��6(   $��320,132,12,0q�64   $
	 Wrap=�6J   $�� ��6^   $	��Top=�6f   �� 5   
   -   5        
 ��Name$
 rfidComboBox��5       �� DisplayMemberPath$ Rfid_No��6)   $��320,185,12,0q�6v   $��22��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$	 Add��5      $	��Add��6   $
��Left=�6,   $��255,270,0,0q�6G   $	��Top=�6\   $��75��6t   6   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $
��Left=�62   $��362,270,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5        $��	txtFilter��5      $
��Left=�6B   $��23��6]   $��	10,10,0,0q�6i   $
	 Wrap=�6|   $�� ��6�   $	��Top=�6�   $	��208��6�   5      5      