   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Wetr.Cockpit   Wetr.Cockpit.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Cockpit��5	   	   $	��650��6   $	��850��6&   $	��600��62   $	��850��6B    � 	Resources 5       �� 
TargetType �� Property �� Value��%T   '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      5      .��5      � .+�5   
   �� .@�5      �� $��Weterstationen verwalten��6   .��5      � .+�5      �� -   5        $��lbStationsHeader��5      $��Wetterstationen:��64   $
��Left=�5      $��	10,20,0,0q�6+   $	��Top=�6>   $��14(�6V   �� 5      -   5        $��
lbStations��5      $��Stretch=�60   $��
0,50,0,130q�5   3    �� SelectedIndex$ 0��6G   ��6   �� *
Stations+��5      �� 5      .R�5   "   �� $	��9pt(�6,   �� 5      ��6$   ��  �� Path$ Station�5       5!      5#      �� 5$      -   5        $��btAddStation��5$      $��Station hinzufügen��61   $
��Left=�6N   $	��150��6i   $��20,20,20,80q�5%      $��Bottom=�6&   $��Center=�6A   6e   �� 5'      -   5        $��btEditStation��5'      $��Station ändern��62   $
��Left=�6K   $	��150��6f   $��20,20,20,50q�5(      $��Bottom=�6&   $��Center=�6A   6e   �� 5*      -   5        $��btDeleteStation��5*      $��Station löschen��64   $
��Left=�6N   $	��150��6i   $��20,20,20,20q�5+      $��Bottom=�6&   $��Center=�6A   6e   5-      5.      �� 5/      $��Analyse von Wetterdaten��6   .��50      � .+�51      �� -   5        $��lbStartDate��51      $��1��60   $��Startdatum:��6@   $
��Left=�52      $��	20,20,0,0q�6+   $	��Top=�6>   (  "System.Windows.Controls.DatePicker  54      -   5        $��dpStartDate��54   !   $��1��64      SelectedDateFormat$ Short=�6D      IsTodayHighlighted . $	��100��55   0   $��25��6<   $
��Left=�6H   $��	20,45,0,0q�56      $	��Top=�6(   	   FirstDayOfWeek$	 Monday=�6@   
 �� Today   SelectedDate# Z
 57      �� 59      -   5        $��	lbEndDate��59      $��1��6.   $��	Enddatum:��6>   $
��Left=�5:      $��	20,90,0,0q�6+   $	��Top=�6>     5<      -	   5        $��	dpEndDate��5<   !   $��1��62   $ Short=�6B    . $	��100��5=   0   $��25��6<   $
��Left=�6H   $��
20,115,0,0q�5>      $	��Top=�6)   $	 Monday=�6A   # Z
 5?      �� 5A      -
   5        $��lbStartTime��5A      $��1��60   $��
Startzeit:��6@   $
��Left=�5B      $��
150,20,0,0q�6+   $	��Top=�6?   "  Xceed.Wpf.Toolkit.TimePicker  5D      -   5        $��tpStartTime��5D   &   $��1��69   $	��100��6K   $��25��6W   $
��Left=�5E      $��
150,45,0,0q�6.   $	��Top=�6B   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   DefaultValue$ 00:00X�5F      %   DisplayDefaultValueOnEmptyText . 6(   �� 5H      -   5        $��	lbEndTime��5H      $��1��6.   $��Endzeit:��6>   $
��Left=�5I      $��
150,90,0,0q�6+   $	��Top=�6?     5K      -   5        $��	tpEndTime��5K   &   $��1��67   $	��100��6I   $��25��6U   $
��Left=�5L      $��150,115,0,0q�6.   $	��Top=�6C   $ 00:00X�5M       . 6(   �� 5P      -   5        $��btFilter��5P      $��Filter anwenden��6.   $	��230��6H   $��30��6T   $��
20,200,0,0q�5Q      $
��Left=�61   $	��Top=�6L   6d   &   System.Windows.Controls.DataGrid  5R      -   5        $��dgMeasurements��5R      $
��Left=�66   $��Stretch=�6Q   $��20,250,20,20q�5S      $	��Top=�6)      
IsReadOnly . ��6S   �� **(GetAllMeasurmentsForDataGridAsync.Result+5U      �� 5V      -   5        $��lbFilter��5V      $��1��6,   $��Filtern nach:��6<   $
��Left=�5W      $��
280,20,0,0q�6+   $	��Top=�6?   �� 5Y      -   5        $��cbFilter��5Y       $��1��60   $
��Left=�6@   $��25��5Z      $��
280,45,0,0q�6    $	��Top=�65   $	��200��5[      .@�5\      �� $��Wetterstation��6'    �� 
IsSelected . 6?   �� 5]      $��Region��6'   �� 5^      $��Gemeinde��6'   �� 5_      $��Bezirk��6'   �� 5`      $��
Bundesland��6'   5a      �� 5c      -   5        $��lbRadius��5c      $��Radius:��6,   $
��Left=�5d      $��
400,90,0,0q�6+   $	��Top=�6?   �� 5f      -   5        $��lbRadiusUnit��5f      $��km��60   $
��Left=�5g      $��455,115,0,0q�6+   $	��Top=�6@   $  Xceed.Wpf.Toolkit.DoubleUpDown  5i      -   5        $��	dudRadius��5i   (   $
��Left=�69   $��25��6T   $��400,115,0,0q�5j      $	��Top=�62   $��55��6J   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 10X�5k      �� 5m      -   5        $��lbLongitude��5m      $��Längengrad:��6/   $
��Left=�5n      $��
280,90,0,0q�6+   $	��Top=�6?     5p      -   5        $��dudLongitude��5p   (   $
��Left=�6=   $��25��6X   $��280,115,0,0q�5q      $	��Top=�62   $	��100��6J   $ 14X�6V   $y�Hidden=�5r      �� 5t      -   5        $��
lbLatitude��5t      $��Breitengrad:��6.   $
��Left=�5u      $��280,140,0,0q�6+   $	��Top=�6@     5x      -   5        $��dudLatitude��5x   (   $
��Left=�6<   $��25��6W   $��280,165,0,0q�5y      $	��Top=�62   $	��100��6J   $ 48X�6V   $y�Hidden=�5z      �� 5|      -   5        $��lbFilterStations��5|      $	��200��66   $
��Left=�6B   $	��Top=�6]   $��280,80,0,130q�5}   3   $ 0��6I   $	��150��6[   ��6   �� *
Stations+��5~      �� 5      .R�5�   "   �� $	��9pt(�6,   �� 5�      ��6$   �� $ Station�5�      5�      5�      �� 5�      -   5        $��lbFilterCommunities��5�      $	��200��69   $
��Left=�6E   $	��Top=�6`   $��280,80,0,130q�5�   6   $ 0��6L   $	��150��6^   $y�Hidden=�5�      ��5�      �� *Communities+��5�      �� 5�      .R�5�   "   �� $	��9pt(�6,   �� 5�      ��6$   �� $ 	Community�5�      5�      5�      �� 5�      -   5        $��lbFilterDistricts��5�      $	��200��67   $
��Left=�6C   $	��Top=�6^   $��280,80,0,130q�5�   4   $ 0��6J   $	��150��6\   $y�Hidden=�5�      ��5�      �� *	Districts+��5�      �� 5�      .R�5�   "   �� $	��9pt(�6,   �� 5�      ��6$   �� $ District�5�      5�      5�      �� 5�      -   5        $��lbFilterProvinces��5�      $	��200��67   $
��Left=�6C   $	��Top=�6^   $��280,80,0,130q�5�   4   $ 0��6J   $	��150��6\   $y�Hidden=�5�      ��5�      �� *	Provinces+��5�      �� 5�      .R�5�   "   �� $	��9pt(�6,   �� 5�      ��6$   �� $ Province�5�      5�      5�      �� 5�      -   5        $��lbMeasurement��5�      $��	Messwert:��61   $
��Left=�5�      $��
510,20,0,0q�6+   $	��Top=�6?   �� 5�      -   5        $��cbMeasurement��5�       $
��Left=�65   $��25��5�      $��
510,45,0,0q�6    $	��Top=�65   $	��200��5�      .@�5�      �� $��Lufttemperatur��6'    . 6@   �� 5�      $��	Luftdruck��6'   �� 5�      $��
Regenmenge��6'   �� 5�      $��Luftfeuchtigkeit��6'   �� 5�      $��Windgeschwindigkeit��6'   5�      	� 5�      -   5        $��rbMin��5�   "   $��Minimum��6/    d� 	IsChecked$
 TrueY�6A   $
��Left=�5�      $��510,100,0,0q�61   $	��Top=�6F   	� 5�      -    5        $��rbMax��5�   "   $��Maximum��6/   $
��Left=�5�      $��510,125,0,0q�61   $	��Top=�6F   	� 5�      -!   5        $��rbAvg��5�   "   $��Durchschnitt��6/   $
��Left=�5�      $��510,150,0,0q�61   $	��Top=�6F   	� 5�      -"   5        $��rbSum��5�   "   $��Summe��6/   {�.  $
��Left=�5�      $��510,175,0,0q�61   $	��Top=�6F   �� 5�      -#   5        $��btResult��5�      $��	Berechnen��6.   $	��100��6B   $��30��6N   $��620,100,0,0q�5�      $
��Left=�62   $	��Top=�6M   6e   �� 5�      -$   5        $��lbResult��5�      $��	Ergebnis:��6,   $��16(�6@   $
��Bold"�6N   $
��Left=�5�      $��620,140,0,0q�6+   $	��Top=�6@   �� 5�      -%   5        $��tbResult��5�      $
��Left=�6.   $	��Top=�6I   $��14(�6a   $	��100��5�      $��620,170,0,0q�6*   $��30��6?    �� 
IsReadOnly . 6_   �� 5�      -&   5        $��lbUnit��5�      $	��°C��6*   $
��Left=�5�      $��720,175,0,0q�6+   $	��Top=�6@   5�      5�      5�      5�      5�      