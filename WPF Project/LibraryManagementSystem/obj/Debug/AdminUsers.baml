   M S B A M L   `   `   `  ����R  NLibraryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LibraryManagementSystemLibraryManagementSystem  5      (    "LibraryManagementSystem.AdminUsers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:LibraryManagementSystem     5      .��5	      � .+�5
   
   �� $
��Left=�6   $	��332��60   $	��Top=�6=   $	��655��6U   $��10,30,-10,0q�6a   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dgUsers��5   �       
IsReadOnly  . $	��332��6)   #��� ��66   $��0,0,25,0q�6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ User Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *UserId+6W     5      $ 	User Name��6)    6<   �� *
UserName+6[     5      $ Admission No��6)    6?   �� *
UserAdNo+6^     5      $ Email Address��6)    6@   �� *	UserEmail+6`     5      $ Password��6)    6;   �� *
UserPass+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6-      CellTemplate 5      �� 5      .R�5   "   ��  ��Name$ BtnEdit��6)   -   5        $�� Edit ��5   :   6c   5      5        5      $  ��6-    5      �� 5      .R�5   "   �� $ 	BtnDelete��6)   -   5        $�� Delete ��5   <   6i   5      5      5#      5$      �� 5%   
   -   5        $��BtnAdd��5%   t   $��Add User��6   $
��Left=�6$   $	��Top=�6?   $��75��6W   $��11,0,0,0q�6b   6�   �� 5&   
   $��User Section��6   $
��Left=�6'   $��
521,-6,0,0q�6B   $	��Top=�6V   
�������$��NORTHEN)�6�   $��20(�6�   ��6n   Z� 6�   5(      5)      