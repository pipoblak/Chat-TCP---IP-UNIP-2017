   M S B A M L   `   `   `  ����J  FCHAT TCP-IP APS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CHAT_TCP_IP_APSCHAT_TCP_IP_APS  5   	       CHAT_TCP_IP_APS.UserForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CHAT_TCP_IP_APS     5   	   -   5          � Title$  FFL - Chat Tcp IP��5   	   $��341.5��6#   $	��433��62    � AllowsTransparency .  � WindowStyle$
 None=�6X    � WindowStartupLocation$ CenterScreen=�6�   ��6k   Z� .��5	      �� $��0q�6    �� CornerRadius$ 3��6!   ���	#FFECF0F1._�5
   
   �� $
��Left=�6   $	��Top=�6,   $	��433��6D   $	��342��6P   .+�5      �� $
��Wrap=�6   
 �� Top$ 44��6,   $��36(�6<   $��Informações de Usuário��6J   ���	#FF27AE60$	��432��6   $��Center=�6�   $��Center=�6�    �� TextAlignment$ Center=�6�   �� 5      -   5         ��Name$ txtName��5      $��32��6'    �� TextWrapping$
 Wrap=�63   $	 152��6G   $	��298��6X   	 �� TextAlignment$	 Center=�6d   $��18(�6{   
�������
 �� SelectionBrush
 �	#FF95A5A6���	#FF2C3E50$��0q�6�   $��Center=�6�   $��Center=�6   �� Left$ 70��61  ��6�   Z� .��6B  ��5      �� 5       �� 
TargetType" ��6&   .R�5      ��  ��Name$ border��6!   #��z��61   #��z��6]   #��z��6�    J� SnapsToDevicePixels . ._�5      ��  ��Name$ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5       �� Triggers 5      P� 5       P� Property � {� P� Value .  . �5   "   ��  �� 
TargetName$ border��6<    �� Property �@J�Opacity �� Value$
 0.56Q�6P   5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6@    � �� �	#FF95A5A66T   5      P� 5       �@J�IsKeyboardFocused . . �5   "   �� $ border��6@    � �� �	#FF95A5A66T   5      5      .��5   $   5      �� 5       $
��Wrap=�6   $ 44��6,   $��36(�6<   $��Informações de Usuário��6J   ���	#FF27AE60$	��432��6   $��Center=�6�   $��Center=�6�   $ Center=�6�   �� 5"      -   5        $ txtIp��5"      $��32��6%   $
 Wrap=�61   $	 230��6E   $	��298��6V   $	 Center=�6b   $��18(�6y   
�������
 �	#FF95A5A6���	#FF2C3E50$��0q�6�   $��Center=�6�   $��Center=�6  $ 70��6/  $��	127.0.0.1��6@  ��6�   Z� .��6Q  ��5#      �� 5$      " ��6&   .R�5%      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5&      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5'       5(      P� 5)       � {� .  . �5*   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5+      P� 5,       �@J�IsMouseOver . . �5-   "   �� $ border��6@    � �� �	#FF95A5A66T   5.      P� 5/       �@J�IsKeyboardFocused . . �50   "   �� $ border��6@    � �� �	#FF95A5A66T   51      53      .��54   $   55      �� 56      -   5         ��Name$ 	btnEntrar��56      $��Entrar��6(   $��54��69   $	 288��6E   $	��433��6V   
����������	#FF7F8C8D$��0q�6�   $��18(�6�    �� 	IsDefault . ��6b   Z� 6�   �� 57      -   5         ��Name$ 	textBlock��57      $	 408��6+   $
��Wrap=�6=   $��X��6Q   $ 10��6Z   $��18(�6j   $
��Bold"�6x   ���	#FF7F8C8D6�   �� 58      -   5        $ 
textBlock2��58      $ 70��6,   $
��Wrap=�6=   $��Nome de Exibição��6Q   $	 121��6i   $��18(�6z   $	��298��6�   $ Center=�6�   �� 59      -   5        $ textBlock2_Copy��59      $ 70��61   $
��Wrap=�6B   $��Endereço de IP��6V   $	 201��6l   $��18(�6}   $	��298��6�   $ Center=�6�   5:      5;      5<      