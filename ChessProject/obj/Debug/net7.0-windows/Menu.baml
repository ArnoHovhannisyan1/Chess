   M S B A M L   `   `   `  ����G  CChessProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ChessProjectChessProject  5   	       ChessProject.Menu   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ChessProject     5   	     � Title$
  Menu��5   	   $	��450��6   $	��800��6#   
�������.��5
      � -   5        $��MyGrid��5
       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��400 �6   �� 5      $	��200 �6   .+�5   
   �� -   5         ��Name$ 
PlayButton��5      $	��130��6%   $��40��61   $
��Play��6=   
�����f�$��25(�6j   $��35,30,35,30q�6x   6�   �� 5   
   -   5        $ PuzzlesButton��5      $	��180��6(   $��40��64   $��Solve Puzzles��6@   
�����f�$��25(�6v   $��10,30,10,30q�6�   $��1��6�   �� 5   
   -   5        $ InterestingButton��5      $	��130��6,   $��40��68   $��Interesting��6D   
�����f�$��25(�6x   $��35,30,35,30q�6�   $��2��6�   �� 5   
   -   5        $ SettingsButton��5      $	��130��6)   $��40��65   $��Settings��6A   
�����f�$��25(�6r   $��35,30,35,30q�6�   $��3��6�   �� 5   
   -   5         ��Name$ 	NameField��5      $��30��6(   $��25(�64   $��2��6B   $��	75,5,0,65q�6R   $��1��6e   $��cursive)�6r   �� 5   
   
�������$	��100��6(   $	��100��64   $��2��6A    K� ZIndex$ 1��6Q   $��	50,0,50,0q�6b   ._�5   
   �� -   5        $��	UserImage��5      $��Uniform=�6!   5      5       5!      