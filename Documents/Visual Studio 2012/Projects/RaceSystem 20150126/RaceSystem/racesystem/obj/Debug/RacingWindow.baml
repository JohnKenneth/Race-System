   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    
RaceSystem   RaceSystem.RacingWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  Racing Window��5   	   $��420.912��6   $��857.457��60    � 	Resources 5       �� MergedDictionaries �� Source�� 5       5   
   �� 5	      $G Apack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml?�6!   �� 5
      $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6!   �� 5      $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6!   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6!   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6!   %    5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��37 �6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $
��111* �6   �� 5      $
��344* �6   �� 5      $
��289* �6   .+�5   
   �� $��Event Name: ��6   $��1��6'   $��	15,10,0,0q�67   $	��Top=�6J   $��18��6b   $
��Bold"�6n   $
��Left=�6�   $��95��6�   $	��0,1q�6�    � IsSharedSizeScope . 6�   �� 5   
   $��Class Name:��6   $��1��6&   $��	15,30,0,0q�66   $	��Top=�6I   $��18��6a   $
��Bold"�6m   $
��Left=�6   $��95��6�   $	��0,1q�6�   �� 5   
   $��Session Name:��6   $��1��6(   $��	15,50,0,0q�68   $	��Top=�6K   $��18��6c   $
��Bold"�6o   $
��Left=�6�   $��95��6�   $	��0,1q�6�   �� 5   
   $��
15,70,15,5q�6   $��4��6+   $��Disabled=�6?   $
��Auto=�6h   .��5       &   System.Windows.Controls.DataGrid  -   5          Name$ tblRacingInfo��5          AutoGenerateColumns .  {�. 	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .     CanUserSortColumns .     CanUserResizeRows .     RowDetailsVisibilityMode$ Visible=�6�      CanUserAddRows .  $��1��6     HeadersVisibility$ Column=�6  |�.   J� IsHitTestVisible .     	CellStyle 5!      �� 5"       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5#      ��  �� Property � �� �� Value$ 15,0,0,0q�64   �� 5$       � �� 5%      �� 5&   "    �� 
TargetType"  62   .R�5'   &   ��  �� Padding# z��6-   #��z��6Q   #��z��6}   #��z��6�    J� SnapsToDevicePixels . ._�5(   *   �� # z 6;   5)   '   5*   #   5,      5-         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$	 Pos��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *positionNumber+6Z     51      $ Racer��6)   $ * 6V    68   �� *	racerName+6V     52      $	 Lap��6)   $ 35 6T    66   �� *	lapNumber+6T     53      $ Lap Time(s)��6)   $ 90 6Z    6>   �� *	lapTime+6Z     54      $ Best Lap Time(s)��6)   $	 110 6c    6C   �� *bestLapTime+6c     55      $ Lap Speed(m/s)��6)   $	 110 6^    6A   �� *
lapSpeed+6^     56      $ Best Lap Speed(m/s)��6)   $	 140 6g    6F   �� *bestLapSpeed+6g     57      $ Total Time(s)��6)   $	 100 6^    6@   �� *	totalTime+6^   59      5:      �� 5;   
   -   5         ��Name$ btnStartRace��5;      $��
Start Race��6'   $��3��6<   $��0,5,15,0q�6L   $��22��6^   $	��Top=�6j   $��1��6�   $��Right=�6�   $��86��6�   �� 5<   
   -   5         ��Name$ lblEventName��5<      $��Label��6&   $��2��66   $��	0,10,10,0q�6F   $	��Top=�6Y   $��18��6q   $	��0,1q�6}   �� 5=   
   -   5        $ lblClassName��5=      $��Label��6&   $��2��66   $��	0,30,10,0q�6F   $	��Top=�6Y   $��18��6q   $	��0,1q�6}   �� 5>   
   -   5        $ lblSessionName��5>      $��Label��6(   $��2��68   $��	0,50,10,0q�6H   $	��Top=�6[   $��18��6s   $	��0,1q�6   �� 5?   
   -   5        $ btnReset��5?      $��Reset��6#   $��3��63   $��	0,5,120,0q�6C   $��22��6V   $	��Top=�6b   $��1��6�   $��Right=�6�   $��86��6�   �� 5@   
   -   5        $��1��5@      $��3��6   $
��Left=�6-   $��0,10,0,0q�6H   $	��Top=�6Z   $��75��6r   $y�Hidden=�6�   $��22��6�   �� 5A   
   -   5        $��2��5A      $��3��6   $
��Left=�6-   $��	86,10,0,0q�6H   $	��Top=�6[   $��75��6s   $y�Hidden=�6�   $��22��6�   �� 5B   
   -	   5        $��3��5B      $��3��6   $
��Left=�6-   $��
180,10,0,0q�6H   $	��Top=�6\   $��75��6t   $y�Hidden=�6�   $��22��6�   �� 5C   
   -
   5        $ 	lblStatus��5C      $��Stand By��6#   $��1��66   $
��Left=�6F   $	��Top=�6a   $��18��6y   $��95��6�   $	��0,1q�6�   $��1��6�   
����������	#FFF50000$��2��6�   $��58,3,0,0q�6�   �� 5D   
   $��Status: ��6   $��1��6#   $
��Left=�63   $��15,3,0,0q�6N   $	��Top=�6`   $��18��6x   $��38��6�   $	��0,1q�6�   $��1��6�   $
��Bold"�6�   �� 5E   
   $��Time:��6   $��3��6    $��8,10,0,0q�60   $	��Top=�6B   $��18��6Z   $
��Bold"�6f   $
��Left=�6x   $��41��6�   $	��0,1q�6�    . 6�   �� 5F   
   -   5        $ lblTime��5F      $��Label��6!   $��3��61   $��	54,10,0,0q�6A   $	��Top=�6T   $��18��6l   $	��0,1q�6x   $
��Left=�6�   $	��158��6�   5H      5I      