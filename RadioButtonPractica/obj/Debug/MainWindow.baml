   M S B A M L   `   `   `  ����N  JRadioButtonPractica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:RadioButtonPracticaRadioButtonPractica  5   	   $    RadioButtonPractica.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:RadioButtonPractica     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��75 �6   6*   �� 5      $��* �6   6)   .+�5   
   �� $��26(�6   
���**��$��0��65    �� TextAlignment$ Center=�6B   Ejemplo de radios6l   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��0.5* �6#   62   �� 5      $
��0.5* �6#   62   .+�5      �� $��0��6   $��50,10,50,10q�6)   .+�5      	� -   5        $��Color��5      .��5      �� Rojo6&   5      	� 5      -   5        $��Color1��5      .��5      �� 
Amarillo6*   5      	� 5      -   5        $��Color2��5      .��5      �� Verde6'   5      5      �� 5       
���   �$��2q�6)   $��1��6=   ._�5!      � .+�5"      �� $��.\static\img\semaforo.bmp��6   6A   A� 5#      -   5        $��eRojo��5#      $��171,52,159.6,229.6q�6+   
���  ��$y�Hidden=�6R   A� 5$      -   5        $��	eAmarillo��5$      $��171,143,159.6,138.6q�6/   
��� ���$y�Hidden=�6Z   A� 5%      -   5        $��eVerde��5%      $��171,239,159.6,42.6q�6,   
��� � � J� RenderTransformOrigin$ 0.502,-0.32&�6U   $y�Hidden=�6y   5&      5'      5(      5)      5*      