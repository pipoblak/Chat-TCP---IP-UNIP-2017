   M S B A M L   `   `   `  ���� J  FCHAT TCP-IP APS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CHAT_TCP_IP_APSCHAT_TCP_IP_APS       CHAT_TCP_IP_APS.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:CHAT_TCP_IP_APS     -     � Title$  FFL - Chat Tcp IP��$	��500��$	��500�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � Icon$ Resources/aps.jpg����Z� .���� $��0q� �� CornerRadius$ 3�����	#FFECF0F1._��� $
��Left=�$	��Top=�$	��500��$	��500��.+��� -    ��Name$ 
btnCliente��$��Cliente��$	��250��$	��290�����	#FF2C3E50$��36(�
�������
 �� Top$	 210������  �� 
TargetType" ��.R��� 	 ��Name$	 border��#��z��#��z��#��z��
 J� SnapsToDevicePixels
 . ._���  ��Name$ contentPresenter��#��z��#��z�� �� ContentStringFormat �� ContentStringFormat# z |�.  #��z��#��z����. #
 z
 #��z�� �� Triggers P�  P� Property �@��IsDefaulted P� Value . . ���  �� 
TargetName$ border�� �� Value# � �� �� Property � ��P�  �@J�IsMouseOver . . ��� $ border�� � �� �#34495EP�  � �� . . ��� $ border�� � �� �#BDC3C7P�  �@d�	IsChecked$
 TrueY�P�  � {� .  . ��� $ border�� � �� �	#FFF4F4F4�� $ border�� � �� �	#FFADB2B5�� $ contentPresenter�� � �� �	#FF838383�� -   $ btnServidor��$��Servidor��$	��250��$	��290�����	#FF27AE60$��36(�
������� �� Left$	 250��$	 210������ " ��.R��� $	 border��#��z��#��z��#��z��
 . ._��� $ contentPresenter��#��z��#��z��# z |�.  #��z��#��z����. #
 z
 #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . . ��� $ border�� � �� �#2ECC71P�  � �� . . ��� $ border�� � �� �#BDC3C7P�  �@d�	IsChecked$
 TrueY�P�  � {� .  . ��� $ border�� � �� �	#FFF4F4F4�� $ border�� � �� �	#FFADB2B5�� $ contentPresenter�� � �� �	#FF838383�� -    ��Name$ label��$��Entrar como��$	 116��$ 83��$��48(��� -    ��Name$ 	textBlock��$	 476��$
��Wrap=�$��X��$ 8��$��18(�$
��Bold"����	#FF7F8C8D