   M S B A M L   `   `   `  ����G  CChessProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ChessProjectChessProject  5   	       ChessProject.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ChessProject     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   
�������.��5
      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��200 �6   �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��400 �6   �� 5      $	��200 �6   .+�5   
   �� $��Create a username ��6   $	��350��6.   $��40��6:   $��30(�6F   $��25,40,25,120q�6T    K� ZIndex$ 1��6j   $��1��6{   $��1��6�   �� 5   
   -   5        $��ToMenu��5      $��Continue��6   $
��Left=�62   $��	250,0,0,0q�6M   $��Center=�6`   $��70��6�   $��30��6�   $��15(�6�   $ 1��6�   $��1��6�   $��1��6�   �� 5   
   $��Center=�6   $��Center=�60   �� 5   
   $��1��6   $��25,117,175,83q�6%   $��2��6<   $��1��6M   .+�5      	� -   5        $
��Male��5       	� 	GroupName$ GenderGroup��6)   6A   	� 5      -   5        $��Female��5      $ GenderGroup��6+   6C   	� 5      -   5        $��Other��5      $ GenderGroup��6*   6B   5      �� 5   
   -   5         ��Name$ inputTextBox��5      $��25��5       $	��Bob��5!      
�������$��25,88,175,88q�5$   4   $��1��6J   $��1��6W   5%      5&      