   M S B A M L   `   `   `  ����V  RSupportTechEstibenMontoyaM1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SupportTechEstibenMontoyaM1.views!SupportTechEstibenMontoyaM1.views  5   	   0    *SupportTechEstibenMontoyaM1.views.Personal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:SupportTechEstibenMontoyaM1.views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ Personal��5
   	   $	��600��6   $
��1300��6'    � Icon$ /img/Icon.jpg��64   ���	#FF020202.��5      � .+�5   
   �� $��Listado de Personal��6   $
��Left=�6.   $��
364,77,0,0q�6I   $	��Top=�6]   $
��Bold"�6u   $��28(�6�   �� 5   
   $��	Documento��6   $
��Left=�6$   $��	55,76,0,0q�6?   $	��Top=�6R    J� RenderTransformOrigin$ 	0.65,1.35&�6j   $��26��6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Nombre��6   $
��Left=�6!   $��
80,128,0,0q�6<   $	��Top=�6P   $ 	0.65,1.35&�6h   $��26��6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $��	Apellidos��6   $
��Left=�6$   $��
73,178,0,0q�6?   $	��Top=�6S   $��14(�6k   $
��Bold"�6y   �� 5   
   $��Especialidad��6   $
��Left=�6'   $��
54,230,0,0q�6B   $	��Top=�6V   $
��Bold"�6n   $��14(�6�   �� 5   
   $��Fecha de ingreso��6   $
��Left=�6+   $��
24,282,0,0q�6F   $	��Top=�6Z   $��32��6r   $��14(�6~   $
��Bold"�6�   �� 5   
   $��Horario��6   $
��Left=�6"   $��
84,334,0,0q�6=   $	��Top=�6Q   $
��Bold"�6i   $��14(�6{   �� 5   
   $
��Mail��6   $
��Left=�6   $��103,386,0,0q�6:   $	��Top=�6O   $��14(�6g   $
��Bold"�6u   �� 5   
   $��Whats��6   $
��Left=�6    $��
90,438,0,0q�6;   $	��Top=�6O   $
��Bold"�6g   $��14(�6y   �� 5   
   $��Nuevo Personal��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $
��Bold"�6o   $��28(�6�   �� 5   
   -   5        $��txtDocumento��5      $
��Left=�6&   $��
154,76,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��145��6�   $��26��6�   �� 5   
   -   5        $��	txtNombre��5      $
��Left=�6#   $��154,128,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtApellidos��5      $
��Left=�6&   $��154,181,0,0q�6A   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtEspecialidad��5      $
��Left=�6)   $��154,233,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��145��6�   $��26��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpkFechaIngreso��5      $
��Left=�6,   $��154,287,0,0q�6G   $	��Top=�6\   $��26��6t   �� 5   
   -   5        $��
txtHorario��5      $
��Left=�6$   $��154,337,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtEmail��5      $
��Left=�6"   $��154,389,0,0q�6=   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtWhast��5      $
��Left=�6"   $��154,441,0,0q�6=   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��145��6�   $��26��6�   �� 5   
   -	   5        $��
btnLimpiar��5      $��Limpiar��6#   $
��Left=�65   $��
99,498,0,0q�6P   $	��Top=�6d   $��86��6|   $��32��6�   
����������	#FF020202���	#FF020202$ 0.562,1.335&�6�   6�   �� 5   
   -
   5        $��
btnGuardar��5      $��Guardar��6#   $
��Left=�65   $��213,498,0,0q�6P   $	��Top=�6e   $��86��6}   $��32��6�   ���	#FF3327C8���	#FF020202
�������6�   �� 5    
   -   5        $��	btnEditar��5       $��Editar��6"   $
��Left=�63   $��
364,34,0,0q�6N   $	��Top=�6b   $��86��6z   $��32��6�   ���	#FF5BB3CA���	#FF020202
�������6�   &   System.Windows.Controls.DataGrid  5!   
   -   5        $��dtgPersonal��5!         
IsReadOnly . $��364,142,10,10q�68   
����������	#FF3327C8   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 55 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5$      $ 	Documento��6%   $		 120 6V   
 68   �� *	documento+6V     5%      $ Nombre��6%   $		 120 6P   
 65   �� *nombre+6P     5&      $ 	Apellidos��6%   $		 120 6V   
 68   �� *	apellidos+6V     5'      $ Especialidad��6%   $		 100 6\   
 6;   �� *especialidad+6\     5(      $ Fecha de Ingreso��6%   $		 110 6`   
 6?   �� *fechaIngreso+6`     5)      $ Horario��6%   $	 80 6R   
 66   �� *	horario+6R     5*      $ E-MAIL��6%   $		 120 6N   
 65   �� *mail+6N     5+      $ WhatsApp��6%   $		 100 6Q   
 67   �� *whats+6Q   5/      51      52      