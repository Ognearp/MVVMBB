   M S B A M L   `   `   `  ����F  BNotMVMMSuck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NotMVMMSuck.ViewNotMVMMSuck.View  5   	   !    NotMVMMSuck.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NotMVMMSuck.View     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $��	0,71,0,80q�5
      $��Stretch=�6p   $��Stretch=�6�   $��Stretch=�6�   ��6&   �� *
FilterList+ �� SelectedItem 6I   �� *SelectProduct+��5      �� 5       �� DataType" ��6   .R�5      �� 
���   �$��1q�61   ._�5      � .+�5      �� $
��Left=�6$   $��0,0,0,0q�6?   $	��100��6P   $��80��6\   ��6h   �� *images+   Con �� 	Converter# [  6�   �� 5      $��	100,0,0,0q�6*   $��Stretch=�6=   $	��Top=�6[   .+�5   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5   &   �� ��60   �� *name_product+6P   �� 5   &   $	�� | ��60   6=   �� 5   &   ��60   �� *tip_product+6O   5   #   �� 5   "   ��6,   �� *	articul+6G   5      �� 5      $��0,0,40,0q�6(   $	��Top=�6:   $��Right=�6R   $��Цена��6n   6|   �� 5      $��Right=�6(   ��6D   �� *
min_cost+6`   5      5      5      ��5      �� 5        �� 
TargetType" ��6   .�5!      -   5        5"      5$      �� 5%   
   -   5         ��Name$ Search��5%      $
��Left=�6b   $��23��6}   $��	10,43,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��171��6�   ��6"   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5&   
   $
��Left=�6Z   $��
236,43,0,0q�6u   $	��Top=�6�   $	��144��6�   ��6   �� *
FilterType+ 66   �� *
SelectType+6�   �� 5'   
   	 �� DisplayMemberPath$	 Title��6Z   $
��Left=�6t   $��
416,44,0,0q�6�   $	��Top=�6�   $	��216��6�   ��6   �� *
SortParams+ 66   �� *
SelectSort+6�   �� 5(   
   -   5        $��Вперед��5(      $
��Left=�6"   $��662,374,0,0q�6=   $	��Top=�6R   $��75��6j   6u   �� 5)   
   -   5        $��
Назад��5)      $
��Left=�6!   $��472,374,0,0q�6<   $	��Top=�6Q   $��75��6i   6t   �� 5*   
   $
��Left=�6   $��588,374,0,0q�6/   $
��Wrap=�6D   $	��Top=�6u   ��6X   �� *PageDisplay+6u   �� 5+   
   $
��Left=�6   $��44��60   $��
652,21,0,0q�6<   $	��Top=�6P   $	��130��6h   
 J� RenderTransformOrigin$
 0.747,0.594&�6t   .+�5,      	� -   5        $!��По возрастанию��5,      6U   	� 5-      -   5        $��По убыванию��5-      6P   5.      �� 5/   
   -   5        $��Добавить��5/      $
��Left=�6$   $��
32,374,0,0q�6?   $	��Top=�6S   $��90��6k   6v   50      51      