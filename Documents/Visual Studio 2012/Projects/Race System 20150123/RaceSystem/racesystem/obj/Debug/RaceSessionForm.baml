   M S B A M L   `   `   `  ����  
RaceSystem     RaceSystem.RaceSessionForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Race Session��5   	   $	��333��6   $	��332��6+    � 
ResizeMode$ NoResize=�67   .��5      � $��	0,0,0,-19q�6    � RowDefinitions 5   
   �� 5      $
��131* �6   �� 5      $��3* �6   .+�5
   
   �� -   5         ��Name$ LDate��5
      $
��Date��6   $
��Left=�6.   $��
10,176,0,0q�6I   $	��117��6]   $��26��6i   $	��Top=�6u   �� 5   
   -   5        $ LSession_Name��5      $��Session Name��6'   $
��Left=�6>   $��	10,23,0,0q�6Y   $	��Top=�6l   $	��117��6�   �� 5   
   -   5        $ LSession_Type��5      $��Session Type��6'   $
��Left=�6>   $��	10,54,0,0q�6Y   $	��Top=�6l   $	��117��6�   �� 5   
   -   5         ��Name$ TSession_Name��5   2   -  'System.Windows.Input.KeyboardNavigation   TabIndex$ 1��6   $
��Left=�6I   $��26��6d   $��
132,23,0,0q�6p    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��173��6�   �� 5   
   -   5        $ TSession_Type��5   2   $ 2��6   $
��Left=�6I   $��26��6d   $��
132,54,0,0q�6p   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��173��6�   �� 5   
   -   5         ��Name$ Ok��5   1   $ 4��6   $��Ok��6=   $��40,250,213,0q�6J   $��22��6q   $	��Top=�6}   �� 5   
   -   5        $ Cancel��5   1   $ 5��6   $��Cancel��6A   $
��Left=�6R   $��198,250,0,0q�6m   $��75��6�   $��22��6�   $	��Top=�6�   �� 5   
   -   5        $ TSession_Distance��5   2   $ 2��6   $
��Left=�6M   $��26��6h   $��
132,85,0,0q�6t   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��173��6�   �� 5   
   -	   5        $ LSession_Distance��5      $��Distance (Meters)��6+   $
��Left=�6G   $��	10,85,0,0q�6b   $	��Top=�6u   $	��117��6�   �� 5   
   -
   5        $ TSession_Time��5   2   $ 2��6   $
��Left=�6I   $��26��6d   $��132,116,0,0q�6p   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��173��6�   �� 5   
   -   5        $ LSession_LapNumber��5      $��
Lap Number��6,   $
��Left=�6A   $��
10,147,0,0q�6\   $	��Top=�6p   $	��117��6�   $��24��6�   �� 5   
   -   5        $ TSession_LapNumber��5   2   $ 2��6   $
��Left=�6N   $��24��6i   $��132,147,0,0q�6u   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��173��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ TDate��5      $
��Left=�6%   $��26��6@   $��132,176,0,0q�6L   $	��Top=�6a   $	��173��6y   �� 5   
   -   5        $ LSession_Time��5      $��Race Time(Minutes)��6'   $
��Left=�6D   $��
10,116,0,0q�6_   $	��Top=�6s   $	��117��6�   �� 5   
   -   5        $ lblSchedTime��5      $��Schedule Time��6&   $
��Left=�6>   $��
10,207,0,0q�6Y   $	��Top=�6m   $	��117��6�   $��24��6�   �� 5   
   -   5        $ tfSchedTime��5   2   $ 2��6   $
��Left=�6G   $��24��6b   $��132,207,0,0q�6n   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��173��6�   5      5      