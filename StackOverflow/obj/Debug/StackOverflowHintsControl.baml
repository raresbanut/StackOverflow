   M S B A M L   `   `   `  ����i  eMicrosoft.VisualStudio.Shell.15.0, Version=15.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3avUclr-namespace:Microsoft.VisualStudio.Shell;assembly=Microsoft.VisualStudio.Shell.15.0Microsoft.VisualStudio.Shell  5       StackOverflow-   'StackOverflow.StackOverflowHintsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ivsshellUclr-namespace:Microsoft.VisualStudio.Shell;assembly=Microsoft.VisualStudio.Shell.15.0     5      -   5        $��MyToolWindow��5      ,   &Microsoft.VisualStudio.Shell.VsBrushes    	WindowKey#���   5         WindowTextKey#���  5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��updateButton��5   }   $��55��63   $��20��6>   $	��Top=�6J   $
��Left=�6b   .��6�   Update6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
MyDatagrid��5   !   $��1��6      AutoGenerateColumns .  $��Stretch=�6Q   $	��Top=�6o      CanUserAddRows .  ��6�   ��  �� Path$ 	ErrorList� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Code��6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Code+6N     5      $
 Description��6E    6%   �� *Description+6\   5  /System.Windows.Controls.DataGridHyperlinkColumn  5      $
 Tooltip��6G    6+   �� *	Tooltip+   ElementStyle 5      �� 5      .�5      -   5        5      5        5      $
 Project��6A    6%   �� *	Project+6T     5      $

 File��6B    6%   �� *
FileName+6R     5      $

 Line��6>    6%   �� *Line+6N      
IsReadOnly . 5"      5#      5$      