   M S B A M L   `   `   `  ����G  CWetr.Cockpit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Wetr.Cockpit.ViewWetr.Cockpit.View  5   	   +clr-namespace:Wetr.CockpitWetr.Cockpit  5   	   "    Wetr.Cockpit.View.AddStation   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Wetr.Cockpit.View     5   	   *srcclr-namespace:Wetr.Cockpit     5   	     � Title$  Station hinzufügen��5	   	   $	��450��6$   $	��350��61   $	��250��6=   $	��400��6L    � 	Resources 5         validationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $��Bottom=�66   .+�5      � $��12��6   $��12��6&   .+�5      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   �� 5      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�5   "   $ Center=�6=    6T   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5   !   5      �� 5      
���  ��$��10(�61   $��2,0,0,0q�6?   ��6P   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      $ ErrorAdorner��6,   5      5      5      .��5      � .+�5   
   �� -   5        $��lbStationname��5      $��Stationsname:��6%   $	��Top=�6=   $
��Left=�5      $��20,20,20,20q�6+   �� 5    
   -   5        $��tbStationname��5       $	��Top=�6'   $��Stretch=�6?   $
��Left=�5!      $��20,45,20,20q�64    =� ErrorTemplate# [  6I   .��5"      ��5#      �� 5$      $
 Name�6   	 �� Mode$	 OneWayToSource=�6&   
 �� UpdateSourceTrigger$
 PropertyChanged=�5&   	    �� ValidationRules 5'      %   Wetr.Cockpit.NameValidationRule  5(      63   5*      .��5+      5,      �� 5.   
   -   5        $��lbStationtype��5.      $��Stationstyp:��6%   $	��Top=�6<   $
��Left=�5/      $��20,80,20,20q�6+   �� 51   
   -   5        $��tbStationtype��51      $	��Top=�6'   $��Stretch=�6?   $
��Left=�52      $��20,105,20,20q�64   # [  6J   .��53      ��54      �� 55      $
 Name�6   $	 OneWayToSource=�6&   $
 PropertyChanged=�57   	    58        59      63   5;      .��5<      5=      �� 5>   
   -   5        $��lbLongitude��5>      $��Längengrad:��6#   $	��Top=�69   $
��Left=�5?      $��20,140,20,20q�6+   �� 5A   
   -   5        $��tbLongitude��5A      $	��Top=�6%   $��Stretch=�6=   $
��Left=�5B      $��20,165,20,20q�64   # [  6J   .��5C      ��5D      �� 5E      $
 Name�6   $	 OneWayToSource=�6&   $
 PropertyChanged=�5G   	    5H      '   !Wetr.Cockpit.DegreeValidationRule  5I      65   5K      .��5L      5M      �� 5N   
   -   5        $��
lbLatitude��5N      $��Breitengrad:��6"   $	��Top=�69   $
��Left=�5O      $��20,200,20,20q�6+   �� 5Q   
   -   5        $��
tbLatitude��5Q      $	��Top=�6$   $��Stretch=�6<   $
��Left=�5R      $��20,225,20,20q�64   # [  5S      .��5T      ��5U      �� 5V      $
 Name�6   $	 OneWayToSource=�6&   $
 PropertyChanged=�5X   	    5Y        5Z      65   5\      .��5]      5^      �� 5_   
   -	   5        $��lbPostalcode��5_      $��Postleitzahl:��6$   $	��Top=�6<   $
��Left=�5`      $��20,260,20,20q�6+   �� 5b   
   -
   5        $��tbPostalcode��5b      $	��Top=�6&   $��Stretch=�6>   $
��Left=�5c      $��20,285,20,20q�64   # [  5d      .��6V   ��5e      �� 5f      $
 Name�6   $	 OneWayToSource=�6&   $
 PropertyChanged=�5h   	    5i      +   %Wetr.Cockpit.PostalcodeValidationRule  5j      69   5l      .��5m      5n      �� 5p   
   -   5        $��btAdd��5p      $��1��6   $��Hinzufügen��6+   $
��Left=�5q      $��	20,0,0,20q�6-   $��Bottom=�6A   $	��100��5r      ��5s      �� 5t       �� 
TargetType" ��6   .�5u      ��  �� Property � {� �� Value .  62    �� Triggers 5v      ^� 5w       ^� 
Conditions 5x      �� 5y   "    �� Binding 6,   �� $ (Validation.HasError)�$ tbStationname�� �� Value	 False6v   �� 5z   "    6,   �� $ (Validation.HasError)�$ tbStationtype��	 False6v   �� 5{   "    6,   �� $ (Validation.HasError)�$ tbLongitude��	 False6t   �� 5|   "    6,   �� $ (Validation.HasError)�$ 
tbLatitude��	 False6s   �� 5}   "    6,   �� $ (Validation.HasError)�$ tbPostalcode��	 False6u   .0�5      ��  � {� . 6:   5�      5�      5�      �� 5�   
   -   5        $��btCancel��5�      $��1��6"   $��	Abbrechen��6/   $��Right=�6C   $��	0,0,20,20q�5�      $��Bottom=�6%   $	��100��6@   5�      5�      5�      