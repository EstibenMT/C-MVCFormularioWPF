   M S B A M L   `   `   `  ����V  RSupportTechEstibenMontoyaM1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SupportTechEstibenMontoyaM1.views!SupportTechEstibenMontoyaM1.views  5   	   4    .SupportTechEstibenMontoyaM1.views.Seguimientos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:SupportTechEstibenMontoyaM1.views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Seguimientos��5	   	   $	��600��6   $	��900��6+    � Icon$ /img/Icon.jpg��67   ���	#FF020202.��5
      � .+�5   
   �� -   5        $��txtSeguimiento��5      $
��Left=�6(   $��230,156,0,0q�6C    �� TextWrapping$
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��193��6�   $��39��6�   �� 5   
   $��Código Ticket��6   $
��Left=�6(   $��
119,99,0,0q�6C   $	��Top=�6W   $
��Bold"�6o   $��14(�6�   �� 5   
   $��Tecnico��6   $
��Left=�6"   $��508,101,0,0q�6=   $	��Top=�6R   $
��Bold"�6j   $��14(�6|   �� 5   
   -   5        $��	cmbTicket��5      $
��Left=�6$   $��
230,96,0,0q�6?   $	��Top=�6S   $	��193��6k   $��35��6w   �� 5   
   -   5        $��
cmbTecnico��5      $
��Left=�6%   $��
578,98,0,0q�6@   $	��Top=�6T   $	��192��6l   $��35��6x   �� 5   
   $��Estado��6   $
��Left=�6!   $��513,164,0,0q�6<   $	��Top=�6Q   $
��Bold"�6i   $��14(�6{   �� 5   
   $��Seguimiento��6   $
��Left=�6&   $��126,158,0,0q�6A   $	��Top=�6V   $
��Bold"�6n   $��14(�6�   �� 5   
   $��Agregar Seguimiento��6   $
��Left=�6.   $��	10,10,0,0q�6I   $	��Top=�6\   $
��Bold"�6t   $��28(�6�   �� 5   
   -   5        $��
btnAgregar��5      $��Agregar��6#   $
��Left=�65   $��273,225,0,0q�6P   $	��Top=�6e   $��86��6}   $��32��6�   ���	#FF3327C8
�������$
��Bold"�6�   ���	#FF0202026�   �� 5   
   -   5        $��
btnLimpiar��5      $��Limpiar��6#   $
��Left=�65   $��559,225,0,0q�6P   $	��Top=�6e   $��86��6}   $��32��6�   ���	#FF020202
�������$
��Bold"�6�   ���	#FF0202026�   �� 5   
   -   5        $��	btnEditar��5      $��Editar��6"   $
��Left=�63   $��369,225,0,0q�6N   $	��Top=�6c   $��86��6{   $��32��6�   ���	#FF5BB3CA
�������$
��Bold"�6�   ���	#FF0202026�   �� 5   
   -   5        $��btnEliminar��5      $��Eliminar��6$   $
��Left=�67   $��464,225,0,0q�6R   $	��Top=�6g   $��86��6   $��32��6�    J� RenderTransformOrigin$ 0.402,0.487&�6�   ���	#FFBD0F0F
�������$
��Bold"�6�   ���	#FF0202026  &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgSeguimientos��5         
IsReadOnly . $��90,286,89,31q�6<   $ 0.5,0.5&�6R   
����������	#FF3327C8���	#FF020202   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+6H     5      $ Código Ticket��6%   $	 100 6Y   	 6<   �� *
idTicket+6Y     5      $ Asunto��6%   $	 100 6P   	 65   �� *asunto+6P     5      $ Id Técnico��6%   $	 150 6X   	 69   �� *
idPersonal+6X     5      $ Técnico��6%   $	 150 6R   	 66   �� *	tecnico+6R     5      $ Seguimeinto��6%   $	 170 6Z   	 6:   �� *seguimiento+6Z     5      $ Especialidad��6%   $	 150 6\   	 6;   �� *especialidad+6\     5       $ Estado��6%   $	 100 6P   	 65   �� *estado+6P   5"      �� 5#   
   -	   5        $��	cmbEstado��5#      $
��Left=�6$   $��577,162,0,0q�6?   $	��Top=�6T   $	��192��6l   $��35��6x   5$      5%      