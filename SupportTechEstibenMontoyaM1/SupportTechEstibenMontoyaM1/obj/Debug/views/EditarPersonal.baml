   M S B A M L   `   `   `  ����V  RSupportTechEstibenMontoyaM1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SupportTechEstibenMontoyaM1.views!SupportTechEstibenMontoyaM1.views  5   	   6    0SupportTechEstibenMontoyaM1.views.EditarPersonal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:SupportTechEstibenMontoyaM1.views     5   	     � WindowStartupLocation$  CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ EditarPersonal��5
   	   $	��600��6    $	��400��6-    � Icon$ /img/Icon.jpg��69   ���	#FF020202.��5      � .+�5   
   �� $��	Documento��6   $
��Left=�6$   $��	55,76,0,0q�6?   $	��Top=�6R    J� RenderTransformOrigin$ 	0.65,1.35&�6j   $��26��6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Nombre��6   $
��Left=�6!   $��
80,128,0,0q�6<   $	��Top=�6P   $ 	0.65,1.35&�6h   $��26��6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $��	Apellidos��6   $
��Left=�6$   $��
73,178,0,0q�6?   $	��Top=�6S   $��14(�6k   $
��Bold"�6y   �� 5   
   $��Especialidad��6   $
��Left=�6'   $��
54,230,0,0q�6B   $	��Top=�6V   $
��Bold"�6n   $��14(�6�   �� 5   
   $��Fecha de ingreso��6   $
��Left=�6+   $��
24,282,0,0q�6F   $	��Top=�6Z   $��32��6r   $��14(�6~   $
��Bold"�6�   �� 5   
   $��Horario��6   $
��Left=�6"   $��
84,334,0,0q�6=   $	��Top=�6Q   $
��Bold"�6i   $��14(�6{   �� 5   
   $
��Mail��6   $
��Left=�6   $��103,386,0,0q�6:   $	��Top=�6O   $��14(�6g   $
��Bold"�6u   �� 5   
   $��Whats��6   $
��Left=�6    $��
90,438,0,0q�6;   $	��Top=�6O   $
��Bold"�6g   $��14(�6y   �� 5   
   $��Editar Personal��6   $
��Left=�6*   $��	53,10,0,0q�6E   $	��Top=�6X   $
��Bold"�6p   $��28(�6�   �� 5   
   -   5        $��txtDocumento��5      $
��Left=�6&   $��
154,76,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��145��6�   $��26��6�   �� 5   
   -   5        $��	txtNombre��5      $
��Left=�6#   $��154,128,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtApellidos��5      $
��Left=�6&   $��154,181,0,0q�6A   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtEspecialidad��5      $
��Left=�6)   $��154,233,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��145��6�   $��26��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpkFechaIngreso��5      $
��Left=�6,   $��154,287,0,0q�6G   $	��Top=�6\   $��26��6t   �� 5   
   -   5        $��
txtHorario��5      $
��Left=�6$   $��154,337,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtEmail��5      $
��Left=�6"   $��154,389,0,0q�6=   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��145��6�   $��26��6�   �� 5   
   -   5        $��txtWhast��5      $
��Left=�6"   $��154,441,0,0q�6=   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��145��6�   $��26��6�   �� 5   
   -	   5        $��btnCancelar��5      $��Cancelar��6$   $
��Left=�67   $��
99,498,0,0q�6R   $	��Top=�6f   $��86��6~   $��32��6�   
����������	#FF020202���	#FF020202$ 0.562,1.335&�6�   6�   �� 5   
   -
   5        $��btnActualizar��5      $��
Actualizar��6&   $
��Left=�6;   $��213,498,0,0q�6V   $	��Top=�6k   $��86��6�   $��32��6�   ���	#FF3327C8���	#FF020202
�������6�   �� 5   
   -   5        $��txtId��5      $y�Hidden=�6   $
��Left=�63   $��
288,22,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $��73��6�   $��25��6�   5       5!      