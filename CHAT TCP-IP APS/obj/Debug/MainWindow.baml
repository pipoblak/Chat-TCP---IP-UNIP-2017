   M S B A M L   `   `   `  ����J  FCHAT TCP-IP APS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CHAT_TCP_IP_APSCHAT_TCP_IP_APS  5   	        CHAT_TCP_IP_APS.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CHAT_TCP_IP_APS     5   	   -   5          � Title$  FFL - Chat Tcp IP��5   	   $	��500��6#   $	��500��60    � AllowsTransparency .  � WindowStyle$
 None=�6V    � WindowStartupLocation$ CenterScreen=�6    � Icon$ Resources/aps.jpg��6�   ��6i   Z� .��5
      �� $��0q�6    �� CornerRadius$ 3��6!   ���	#FFECF0F1._�5   
   �� $
��Left=�6   $	��Top=�6,   $	��500��6D   $	��500��6P   .+�5      �� -   5         ��Name$ 
btnCliente��5      $��Cliente��6)   $	��250��6;   $	��290��6G   ���	#FF2C3E50$��36(�6k   
�������
 �� Top$	 210��6�   ��5      �� 5       �� 
TargetType" ��6&   .R�5      �� 	 ��Name$	 border��6!   #��z��61   #��z��6]   #��z��6�   
 J� SnapsToDevicePixels
 . ._�5      ��  ��Name$ contentPresenter��6/   #��z��6I   #��z��6}    �� ContentStringFormat �� ContentStringFormat# z 6�   |�.  #��z��6�   #��z��62  ��. #
 z
 6p  #��z��6�  5       �� Triggers 5      P� 5       P� Property �@��IsDefaulted P� Value . . �5   "   ��  �� 
TargetName$ border��6@    �� Value# � ��6T    �� Property � ��5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6?    � �� �#34495E6S   5      P� 5       � �� . . �5   "   �� $ border��6?    � �� �#BDC3C76S   5      P� 5       �@d�	IsChecked$
 TrueY�6H   5      P� 5       � {� .  . �5    "   �� $ border��6?    � �� �	#FFF4F4F46S   �� 5!   "   $ border��6@    � �� �	#FFADB2B56T   �� 5"   "   $ contentPresenter��6K    � �� �	#FF8383836i   5#      5%      5'      �� 5(      -   5        $ btnServidor��5(      $��Servidor��6*   $	��250��6=   $	��290��6I   ���	#FF27AE60$��36(�6m   
������� �� Left$	 250��6�   $	 210��6�   ��5)      �� 5*      " ��6&   .R�5+      �� $	 border��6!   #��z��61   #��z��6]   #��z��6�   
 . ._�5,      �� $ contentPresenter��6/   #��z��6I   #��z��6}   # z 6�   |�.  #��z��6�   #��z��62  ��. #
 z
 6p  #��z��6�  5-       5.      P� 5/       �@��IsDefaulted . . �50   "   �� $ border��6@   # � ��6T    � ��51      P� 52       �@J�IsMouseOver . . �53   "   �� $ border��6?    � �� �#2ECC716S   54      P� 55       � �� . . �56   "   �� $ border��6?    � �� �#BDC3C76S   57      P� 58       �@d�	IsChecked$
 TrueY�6H   5:      P� 5;       � {� .  . �5<   "   �� $ border��6?    � �� �	#FFF4F4F46S   �� 5=   "   $ border��6@    � �� �	#FFADB2B56T   �� 5>   "   $ contentPresenter��6K    � �� �	#FF8383836i   5?      5A      5C      �� 5D      -   5         ��Name$ label��5D      $��Entrar como��6#   $	 116��69   $ 83��6K   $��48(�6[   �� 5E      -   5         ��Name$ 	textBlock��5E      $	 476��6+   $
��Wrap=�6=   $��X��6Q   $ 8��6Z   $��18(�6i   $
��Bold"�6w   ���	#FF7F8C8D6�   5F      5G      5H      