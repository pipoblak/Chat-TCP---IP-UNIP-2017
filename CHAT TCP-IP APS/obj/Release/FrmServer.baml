   M S B A M L   `   `   `  ���� J  FCHAT TCP-IP APS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CHAT_TCP_IP_APSCHAT_TCP_IP_APS      CHAT_TCP_IP_APS.FrmServer   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:CHAT_TCP_IP_APS     -     � Title$  FFL - Chat Tcp IP��$	��700��$
��1024�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � Icon$ Resources/aps.jpg����Z� .���� $��0q� �� CornerRadius$ 3�����	#FFECF0F1._��� $
��Left=�$	��Top=�$
��1024��$	��700��.+��� $	��504��$	��800��
 �� Top$ 90�����	#FFBDC3C7.+��� -    ��Name$ serverConsole��$	��504��$	��800�� �� SelectionBrush �	#FF95A5A6
�������	 �� IsReadOnlyCaretVisible	 . ��Z� ���� 
 �� 
TargetType"
 ��.R���  ��Name$ border��#��z��#��z��#��z�� J� SnapsToDevicePixels . ._���  ��Name$ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� �� Triggers P�  P� Property � {� P� Value .  . ���  �� 
TargetName$ border�� �� Property �@J�Opacity �� Value$
 0.56Q�P�  �@J�IsMouseOver . P�  �@J�IsKeyboardFocused . . �/� .T�J� .*�.*��� $� ���� $	��504��$	��224�� �� Left$	 800��$ 90�����	#FF95A5A6�� -    ��Name$ 
textBlock1��$
��Wrap=�$ 20��$��36(�$��Servidor�����	#FF27AE60$
��1024��$��Center=�$��Center=� �� TextAlignment$ Center=��� -    ��Name$ txtMensagem��$��32�� �� TextWrapping$
 Wrap=�$	 592��$	��800�� �� TextAlignment$ Center=�$��18(�
������� �	#FF95A5A6���	#FF2C3E50$��0q�$��Center=�$��Center=���Z� .������ "
 ��.R��� $ border��#��z��#��z��#��z�� . ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#FF95A5A6P�  �@J�IsKeyboardFocused . . ��� $ border�� � �� �	#FF95A5A6.���� -    ��Name$ 	btnEnviar��$��Enviar��$��32��$	 800��$	 592��$	��224��
����������	#FF7F8C8D$��0q�$��18(� �� 	IsDefault . ��Z� �� -    ��Name$ lvConnectedUsers��$	��497��$	 800��$ 90��$	��224��$��0q� �� SelectionMode$ Single=���Z� ���� .R��� -   $
��Auto��$��40��$��Center=�$��Center=�.+��� $
��Wrap=�$	��154�����#F1C40F$��9(�$ Right=�$ 0������ *current_ping+�� $
��Wrap=�$	��154��$ Center=�$ 11������ *
nickname+�� $
��Wrap=�$	��154�����	#FFECF0F1$��9(�$ Right=�$ 27������ *current_connection_datetime+�� $y�Hidden=����� *connection_id+�� -   $ 
textBlock2��$	 860��$
��Wrap=�$��Clientes Conectados��$ 73�����	#FFE74C3C�� -	   $ 	textBlock��$	 998��$
��Wrap=�$��X��$ 12��$��18(�$
��Bold"����	#FF7F8C8D