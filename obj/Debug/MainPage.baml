   M S B A M L   `   `   `  ����R  NGermogenovSubscriptions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GermogenovSubscriptionsGermogenovSubscriptions  5      &     GermogenovSubscriptions.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:GermogenovSubscriptions     5        N� Title$  MainPage��5	      .��5      � $��10q�6   .+�5   
   �� $��Subscription Tracker��6   $��22(�60   $
��Bold"�6>      PrimaryColor#��[  6P   $��Center=�6{   $��	0,10,0,20q�6�   �� 5   
   -   5         ��Name$ SubscriptionListView��5      $��	0,60,0,60q�6�     HeaderBackgroundColor#��[ 5      $��0q�6;   $��Disabled=�5      $
��Auto=�6=   ��5   1   �� *Subscriptions+ �� SelectedItem 6W   �� *SelectedSubscription+ �� Mode$ TwoWay=� �� View 5      �� 5      .P�5      �� $��Service��6%    �� DisplayMemberBinding 66   �� *ServiceName+ �� Width 5      �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ ListViewL�  ColumnWidthConverter	 �� 	Converter#	 [ 
 �� ConverterParameter$
 5���� 5      $��Next Payment��6%    6;   �� *NextPaymentDate+ 5      �� *ActualWidth+ �� $ ListViewL�#	 [ $
 5���� 5      $
��Cost��6%    63   �� *MonthlyCost+ 5      �� *ActualWidth+ �� $ ListViewL�#	 [ $
 5���� 5      $��Payment Method��6%    6=   �� *PaymentMethod+ 5      �� *ActualWidth+ �� $ ListViewL�#	 [ $
 5���� 5      $
��Plan��6%    63   �� *Plan+ 5      �� *ActualWidth+ �� $ ListViewL�#	 [ $
 5��5      5       �� 5#   
   -   5        $��Edit Subscription��5#        FlatButtonStyle#��[ 6-   $	��200��6V   $��30��6b   $��0,0,0,15q�6n   $��Center=�6�   $��Bottom=�6�   6�   5$      5%      