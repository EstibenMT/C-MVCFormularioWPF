   M S B A M L   `   `   `  ����V  RSupportTechEstibenMontoyaM1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SupportTechEstibenMontoyaM1.views!SupportTechEstibenMontoyaM1.views  5   	   0    *SupportTechEstibenMontoyaM1.views.Usuarios   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:SupportTechEstibenMontoyaM1.views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Usuarios��5	   	   $	��500��6   $	��800��6'    � Icon$ /img/Icon.jpg��63   ���	#FF020202.��5
      � .+�5   
   �� $��Nuevo Usuario��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V   $
��Bold"�6n   $��28(�6�   �� 5   
   $��Usuario��6   $
��Left=�6"   $��	36,89,0,0q�6=   $	��Top=�6P   $
��Bold"�6h   $��14(�6z   �� 5   
   $��Contraseña��6   $
��Left=�6%   $��
273,89,0,0q�6@   $	��Top=�6T    J� RenderTransformOrigin$ 0.798,0.515&�6l   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Confirmar Contraseña��6   $
��Left=�6/   $��
498,89,0,0q�6J   $	��Top=�6^   $��14(�6v   $
��Bold"�6�   �� 5   
   $��Empleado��6   $
��Left=�6#   $��
21,127,0,0q�6>   $	��Top=�6R   $��14(�6j   $
��Bold"�6x   �� 5   
   $��Nivel��6   $
��Left=�6    $��313,131,0,0q�6;   $	��Top=�6P   $��14(�6h   $
��Bold"�6v   �� 5   
   $��Estado��6   $
��Left=�6!   $��599,131,0,0q�6<   $	��Top=�6Q   $��14(�6i   $
��Bold"�6w   �� 5   
   -   5        $��
txtUsuario��5      $
��Left=�6$   $��
101,92,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��159��6�   $��22��6�   G� 5   
   -   5        $��txtClave��5      $
��Left=�6&   $��
362,92,0,0q�6A   $	��Top=�6U   $	��134��6m   $��22��6y   G� 5   
   -   5        $��txtConfirmar��5      $��658,92,18,0q�6*   $	��Top=�6?   $��22��6W   �� 5   
   -   5        $��	chkEstado��5      $��Activo��6$   $
��Left=�65   $��658,137,0,0q�6P   $	��Top=�6e   �� 5   
   -   5        $��cmbEmpleado��5      $
��Left=�6&   $��101,131,0,0q�6A   $	��Top=�6V   $	��159��6n   �� 5   
   -   5        $��cmbNivel��5      $
��Left=�6#   $��362,135,0,0q�6>   $	��Top=�6S   $	��134��6k   �� 5   
   -   5        $��
btnGuardar��5      $��Guardar��6#   $
��Left=�65   $��180,180,0,0q�6P   $	��Top=�6e   $��86��6}   $��32��6�   ���	#FF3327C8
����������	#FF0202026�   �� 5   
   -   5        $��	btnEditar��5      $��Editar��6"   $
��Left=�63   $��279,180,0,0q�6N   $	��Top=�6c   $��86��6{   $��32��6�   ���	#FF5BB3CA
����������	#FF0202026�   �� 5   
   -	   5        $��btnCambiarEstado��5      $��Cambiar Estado��6)   $
��Left=�6B   $��384,180,0,0q�6]   $	��Top=�6r   $��90��6�   $��32��6�   ���	#FFB11010���	#FFF9EEEE���	#FF0202026�   �� 5   
   -
   5        $��
btnLimpiar��5      $��Limpiar��6#   $
��Left=�65   $��489,180,0,0q�6P   $	��Top=�6e   $��86��6}   $��32��6�   ���	#FF020202���	#FFF9EEEE���	#FF0202026�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgUsuarios��5         
IsReadOnly . $��74,226,46,14q�68      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+6H     5      $ Usuario��6%   $	 120 6Q   	 66   �� *login+6Q     5       $ Contraseña��6%   $	 120 6S   	 69   �� *pass+6S     5!      $ Nivel��6%   $	 100 6O   	 64   �� *nivel+6O     5"      $ Empleado��6%   $	 100 6U   	 67   �� *
empleado+6U     5#      $ 
IdEmpleado��6%   $	 100 6X   	 69   �� *
idPersonal+6X     5$      $ Estado��6%   $	 100 6Q   	 65   �� *estado+6Q   5&      5'      5(      