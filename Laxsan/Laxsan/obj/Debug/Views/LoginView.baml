   M S B A M L   `   `   `  ����A  =Laxsan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Laxsan.ViewsLaxsan.Views  5   	       Laxsan.Views.LoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,localclr-namespace:Laxsan.Views     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$ 
ToolWindow=�5   	    � Title$ Login��5   	   $	��345��6   $	��300��6$   $��14(�60   ���#04c582*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5
      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Closed��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *CancelCommand+5      .��5      �� ���#2e3137 �� CornerRadius$ 20��6"   $��20q�64   ._�5   
   �� $��20,20,0,20.4q�6   $
��Left=�6+   $	��214��6F   .+�5      �� $��Login��6   
�������$��25(�67   $��Center=�6E   �� 5      6   �� 5      $��UserId��6   
�������6%   �� 5      -   5        $��	txtUserId��5      ���#545d6a
�������$��18(�6�   ��6'   �� *UserId+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��Password��6   
�������6'   G� 5      -   5        $��txtPassword��5      ���#545d6a
�������$��18(�6U    5        5      $ PasswordChanged��6%   . 5         60   �� *PasswordChangedCommand+$ PropertyChanged=�	   CommandParameter	 6�   �� 
 �� ElementName$
 txtPassword�� �� Mode$ OneWay=�5      5      �� 5      -   5        $��btnLogin��5      $��Login��6k   $��60 10q�6{   ���#545d6a$��18(�6�   ��6%   �� *LoginCommand+$ PropertyChanged=�6�   �� 5      
���  ����6   �� *Notification+$ PropertyChanged=�6\   5       5!      5"      