   M S B A M L   `   `   `  ���� J  FCHAT TCP-IP APS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CHAT_TCP_IP_APSCHAT_TCP_IP_APS      CHAT_TCP_IP_APS.UserForm   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:CHAT_TCP_IP_APS     -     � Title$  FFL - Chat Tcp IP��$��341.5��$	��433�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=���Z� .���� $��0q� �� CornerRadius$ 3�����	#FFECF0F1._��� $
��Left=�$	��Top=�$	��433��$	��342��.+��� $
��Wrap=�
 �� Top$ 44��$��36(�$��Informações de Usuário�����	#FF27AE60$	��432��$��Center=�$��Center=� �� TextAlignment$ Center=��� -    ��Name$ txtName��$��32�� �� TextWrapping$
 Wrap=�$	 152��$	��298��	 �� TextAlignment$	 Center=�$��18(�
�������
 �� SelectionBrush
 �	#FF95A5A6���	#FF2C3E50$��0q�$��Center=�$��Center=� �� Left$ 70����Z� .������  �� 
TargetType" ��.R���  ��Name$ border��#��z��#��z��#��z�� J� SnapsToDevicePixels . ._���  ��Name$ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� �� Triggers P�  P� Property � {� P� Value .  . ���  �� 
TargetName$ border�� �� Property �@J�Opacity �� Value$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#FF95A5A6P�  �@J�IsKeyboardFocused . . ��� $ border�� � �� �	#FF95A5A6.���� $
��Wrap=�$ 44��$��36(�$��Informações de Usuário�����	#FF27AE60$	��432��$��Center=�$��Center=�$ Center=��� -   $ txtIp��$��32��$
 Wrap=�$	 230��$	��298��$	 Center=�$��18(�
�������
 �	#FF95A5A6���	#FF2C3E50$��0q�$��Center=�$��Center=�$ 70��$��	127.0.0.1����Z� .������ " ��.R��� $ border��#��z��#��z��#��z�� . ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#FF95A5A6P�  �@J�IsKeyboardFocused . . ��� $ border�� � �� �	#FF95A5A6.���� -    ��Name$ 	btnEntrar��$��Entrar��$��54��$	 288��$	��433��
����������	#FF7F8C8D$��0q�$��18(� �� 	IsDefault . ��Z� �� -    ��Name$ 	textBlock��$	 408��$
��Wrap=�$��X��$ 10��$��18(�$
��Bold"����	#FF7F8C8D�� -   $ 
textBlock2��$ 70��$
��Wrap=�$��Nome de Exibição��$	 121��$��18(�$	��298��$ Center=��� -   $ textBlock2_Copy��$ 70��$
��Wrap=�$��Endereço de IP��$	 201��$��18(�$	��298��$ Center=�