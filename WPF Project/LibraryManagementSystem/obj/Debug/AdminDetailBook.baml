   M S B A M L   `   `   `  ����R  NLibraryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LibraryManagementSystemLibraryManagementSystem  5   	   -    'LibraryManagementSystem.AdminDetailBook   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:LibraryManagementSystem     5   	     � WindowStyle$  
ToolWindow=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ Detail Book��5
   	   $	��400��6   $	��600��6*   ��5      �� 5   
    �� ImageSource$7 1Images/yoab-anderson-IHC5LPAoGrs-unsplash (2).jpg��6    j� Stretch$ UniformToFill=�6U   .��5      � $	��369��6   $	��Top=�6   {�.  .+�5   
   �� $
��Left=�6   $	��337��6/   $��	20,22,0,0q�6<   
���   �$	��Top=�6^   $	��570��6v    J� Opacity$ 0.705Q�6�   #��� ��6�   �� 5   
   $��	Book Name��6   $
��Left=�6$   $��	31,22,0,0q�6?   $	��Top=�6R   $	��120��6j   �� 5   
   $��Book Author��6   $
��Left=�6&   $��	31,79,0,0q�6A   $	��Top=�6T   $	��120��6l   �� 5   
   -   5        $��tbBName��5   h   $
��Left=�6   $��23��6-   $��	31,54,0,0q�69    �� TextWrapping$
 Wrap=�6L   $�� ��6`   $	��Top=�6w   $	��262��6�   �� 5   
   -   5        $��	tbBAuthor��5   i   $
��Left=�6   $��23��6-   $��
31,110,0,0q�69   $
 Wrap=�6M   $�� ��6a   $	��Top=�6z   $	��262��6�   �� 5   
   $��	Book ISBN��6   $
��Left=�6$   $��
31,135,0,0q�6?   $	��Top=�6S   $	��120��6k   �� 5   
   -   5        $��tbBISBN��5   i   $
��Left=�6   $��23��6-   $��
31,166,0,0q�69   $
 Wrap=�6M   $�� ��6a   $	��Top=�6y   $	��262��6�   �� 5   
   $��
Book Price��6   $
��Left=�6%   $��
31,191,0,0q�6@   $	��Top=�6T   $	��120��6l   �� 5   
   -   5        $��tbBPrice��5   i   $
��Left=�6   $��23��6-   $��
31,222,0,0q�69   $
 Wrap=�6M   $�� ��6a   $	��Top=�6y   $	��262��6�   �� 5   
   $��Book Copies��6   $
��Left=�6&   $��
31,247,0,0q�6A   $	��Top=�6U   $	��120��6m   �� 5   
   -   5        $��tbBCopy��5   i   $
��Left=�6   $��23��6-   $��
31,278,0,0q�69   $
 Wrap=�6M   $�� ��6a   $	��Top=�6x   $	��262��6�   �� 5   
   -   5         ��Name$ imagePicture��5      $
��Left=�6&   $	��233��6A   $��
355,54,0,0q�6N   $	��Top=�6b   $	��176��6z   �� 5   
   -   5        $��	cboStatus��5       �� SelectedValuePath$
 Name��6$   $
��Left=�6>   $��
31,323,0,0q�6Y   $	��Top=�6m   $	��120��6�   .@�5      �� -   5        $��Actice��5   4   $��Book available��6   6D   �� 5      -	   5        $��Deactice��5   2   $��Out of Book��6   6D   5      5       5!      