   M S B A M L   `   `   `  ����G  CWetr.Cockpit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Wetr.Cockpit.ViewWetr.Cockpit.View  5   	   +clr-namespace:Wetr.CockpitWetr.Cockpit  5   	   #    Wetr.Cockpit.View.EditStation   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Wetr.Cockpit.View     5   	   *srcclr-namespace:Wetr.Cockpit     5   	     � Title$  Station bearbeiten��5	   	   $	��450��6$   $	��350��61   $	��250��6=   $	��400��6L    � 	Resources 5         validationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $��Bottom=�66   .+�5      � $��12��6   $��12��6&   .+�5      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   �� 5      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�5   "   $ Center=�6=    6T   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5   !   5      �� 5      
���  ��$��10(�61   $��2,0,0,0q�6?   ��6P   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      $ ErrorAdorner��6,   5      5      5      .��5      � .+�5   
   �� -   5        $��lbStationname��5      $��Stationsname:��6%   $	��Top=�6=   $
��Left=�5      $��20,20,20,20q�6+   �� 5    
   -   5        $��tbStationname��5       $	��Top=�6'   $��Stretch=�6?   $
��Left=�5!      $��20,45,20,20q�64   {�.  6I   �� 5#   
   -   5        $��lbStationtype��5#      $��Stationstyp:��6%   $	��Top=�6<   $
��Left=�5$      $��20,80,20,20q�6+   �� 5&   
   -   5        $��tbStationtype��5&      $	��Top=�6'   $��Stretch=�6?   $
��Left=�5'      $��20,105,20,20q�64    =� ErrorTemplate# [  6J   .��5(      ��5)      �� 5*      $
 Name�6   	 �� Mode$	 OneWayToSource=�6&   
 �� UpdateSourceTrigger$
 PropertyChanged=�5,   	    �� ValidationRules 5-      %   Wetr.Cockpit.NameValidationRule  5.      63   50      .��51      52      �� 53   
   -   5        $��lbLongitude��53      $��Längengrad:��6#   $	��Top=�69   $
��Left=�54      $��20,140,20,20q�6+   �� 56   
   -   5        $��tbLongitude��56      $	��Top=�6%   $��Stretch=�6=   $
��Left=�57      $��20,165,20,20q�64   # [  6J   .��58      ��59      �� 5:      $
 Name�6   $	 OneWayToSource=�6&   $
 PropertyChanged=�5<   	    5=      '   !Wetr.Cockpit.DegreeValidationRule  5>      65   5@      .��5A      5B      �� 5C   
   -   5        $��
lbLatitude��5C      $��Breitengrad:��6"   $	��Top=�69   $
��Left=�5D      $��20,200,20,20q�6+   �� 5F   
   -   5        $��
tbLatitude��5F      $	��Top=�6$   $��Stretch=�6<   $
��Left=�5G      $��20,225,20,20q�64   # [  5H      .��5I      ��5J      �� 5K      $
 Name�6   $	 OneWayToSource=�6&   $
 PropertyChanged=�5M   	    5N        5O      65   5Q      .��5R      5S      �� 5T   
   -	   5        $��lbPostalcode��5T      $��Postleitzahl:��6$   $	��Top=�6<   $
��Left=�5U      $��20,260,20,20q�6+   �� 5W   
   -
   5        $��tbPostalcode��5W      $	��Top=�6&   $��Stretch=�6>   $
��Left=�5X      $��20,285,20,20q�64   # [  5Y      .��6V   ��5Z      �� 5[      $
 Name�6   $	 OneWayToSource=�6&   $
 PropertyChanged=�5]   	    5^      +   %Wetr.Cockpit.PostalcodeValidationRule  5_      69   5a      .��5b      5c      �� 5d   
   -   5        $��btEdit��5d      $��1��6   $��Ändern��6,   $
��Left=�5e      $��	20,0,0,20q�6-   $��Bottom=�6A   $	��100��5f      ��5g      �� 5h       �� 
TargetType" ��6   .�5i      ��  �� Property � {� �� Value .  62    �� Triggers 5j      ^� 5k       ^� 
Conditions 5l      �� 5m   "    �� Binding 6,   �� $ (Validation.HasError)�$ tbStationname�� �� Value	 False6v   �� 5n   "    6,   �� $ (Validation.HasError)�$ tbStationtype��	 False6v   �� 5o   "    6,   �� $ (Validation.HasError)�$ tbLongitude��	 False6t   �� 5p   "    6,   �� $ (Validation.HasError)�$ 
tbLatitude��	 False6s   �� 5q   "    6,   �� $ (Validation.HasError)�$ tbPostalcode��	 False6u   .0�5s      ��  � {� . 6:   5t      5v      5x      �� 5y   
   -   5        $��btCancel��5y      $��1��6"   $��	Abbrechen��6/   $��Right=�6C   $��	0,0,20,20q�5z      $��Bottom=�6%   $	��100��6@   5{      5|      5}      