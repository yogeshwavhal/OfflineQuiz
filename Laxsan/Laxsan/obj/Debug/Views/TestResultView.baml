   M S B A M L   `   `   `  ����A  =Laxsan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Laxsan.ViewsLaxsan.Views  5   	   !    Laxsan.Views.TestResultView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Laxsan.Views     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	     � WindowStartupLocation$  CenterOwner=�5	   	    � WindowStyle$ 
ToolWindow=�5
   	      WindowStyle#��[  5   	    � Title$ Test Result��5   	   $	��300��6   $	��300��6*   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Closed��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *CancelCommand+5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��130 �6   �� 5      $��5 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��5 �6   �� 5      $��* �6   �� 5       $��5 �6   �� 5!      $��* �6   �� 5"      $��5 �6   �� 5#      $��* �6   �� 5$      $��5 �6   �� 5&      $��50 �6   .+�5(   
   �� $��0��6   $��0��6!   $��3��61     TextBlockStyle#��[ 6f   ��6E   �� *GreetingMessage+6f   �� 5*   
   $��2��6   $��0��6!   $��Status :��61   #��[ 6A   �� 5+   
   $��2��6   $��3��6!   #��[ 6O   ��61   �� *ResultStatus+6O   �� 5-   
   $��4��6   $��0��6!   $��Total Questions:��61   #��[ 6I   �� 5.   
   $��4��6   $��3��6!   #��[ 6Q   ��61   �� *TotalQuestions+6Q   �� 50   
   $��6��6   $��0��6!   $��Correct Answered:��61   #��[ 6J   �� 51   
   $��6��6   $��3��6!   #��[ 6R   ��61   �� *CorrectAnswered+6R   �� 53   
   $��8��6   $��0��6!   $��Percentage(%):��61   #��[ 6G   �� 54   
   $��8��6   $��3��6!   #��[ 6M   ��61   �� *
Percentage+6M   �� 56   
   -   5        	 ��Name$	 BtnCloseResult��58   .   $��2��56      $��10��57      $��Right=�58      $��OK��5:        ButtonStyle#��[ 6   ��59      �� *	OkCommand+5:      5;      5<      