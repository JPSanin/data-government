   M S B A M L   `   `   `  ����S  Oworkshop-government-data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:workshop_government_dataworkshop_government_data  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   )    #workshop_government_data.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:workshop_government_data     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  Government Data��5	   	   $	��450��6!   $	��800��6.   .��5
      � $��10,10,10,10q�6    J� RenderTransformOrigin$ 
0.499,0.57&�6     � ColumnDefinitions 5   
   �� 5      $	��17* �6   �� 5      $	��61* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ loadBtn��5      $
��Left=�6"   $��Center=�6=   $��49��6X   $	��104��6d   $y�Visible=�6�   $��10,0,0,0q�6�   .��6�   Cargar Archivo6�   �� 5   
   -   5        $ loadGph��5      $
��Left=�6"   $��Center=�6=   $��49��6X   $	��104��6d   $y�Hidden=�6�   $��10,0,0,0q�6�   .��6�   Generar grafico6�   �� 5   
   -   5        $ 	loadTable��5      $
��Left=�6$   $��Center=�6?   $��49��6Z   $	��104��6f   $y�Hidden=�6�   $��10,0,0,0q�6�   .��6�   Cargar tabla6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��10,10,10,10q�6%   $��1��6R   $��2��6_   ��6:   �� 6_   �� 5   
   -   5         ��Name$ cmbType��5      $
��Left=�6$   $��	354,0,0,0q�6?   $��Center=�6R   $	��237��6m    �� Text$
 Tipo��6�   $y�Hidden=�6�   $��1��6�   #  LiveCharts.Wpf.CartesianChart  5   
   -   5          Name$ graphic��5      $y�Hidden=�6.   &   LiveCharts.Wpf.Charts.Base.Chart	   LegendLocation$	 Bottom=�6f   $��39,52,34,34q�6~   $��1��6�   $��2��6�   
   Series
 6B   �� *SeriesCollection+   AxisX 5        LiveCharts.Wpf.Axis     Title$ Salesman��6      LabelFormatter 6,   �� *	Formatter+6S      AxisY 5        $ 	Sold Apps��6      Labels 6-   �� *Labels+6I      DataTooltip 5!      #  LiveCharts.Wpf.DefaultTooltip  5"         SelectionMode SharedYValues6%   6E   5$      5(      5)      