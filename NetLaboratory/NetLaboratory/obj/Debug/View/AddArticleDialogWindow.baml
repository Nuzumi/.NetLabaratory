   M S B A M L   `   `   `  ����H  DNetLaboratory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:NetLaboratory.ViewNetLaboratory.View  5   	   /    )NetLaboratory.View.AddArticleDialogWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:NetLaboratory.View     5   	     � Title$  AddArticleDialogWindow��5   	   $	��300��6(   $	��300��65    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       '� M     �� 5
   
   " ��6   .�5      ��  � ��$ 3,5,3,8q�6'   5      �� 5   
   " �6   .�5      ��  � ��$ 4q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      �� $��Tytuł��6   $��2q�6$   �� 5      $��1��6   $��2q�6&    �� TextWrapping$
 Wrap=�6x   ��61   �� *NewArticleTitle+ �� UpdateSourceTrigger$ PropertyChanged=�6x   5       �� 5"   
   $��1��6   $��6q�6   $
 Wrap=�6p   ��6*   �� *NewArticleText+$ PropertyChanged=�.��6�   5$      � 5&   
   $��2��6    5'      �� 5(      $��* �6#   �� 5)      $��* �6#   .+�5,      �� $��Nie ok��6   ��6&   �� *CancelForArticleCommand+�� 5-      $��OK��6   $��1��6"   ��62   �� *AddArticleCommand+5.      50      51      