   M S B A M L   `   `   `  ����H  DFinal Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Final_ProjectFinal_Project  5   	       Final_Project.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Final_Project     5   	   -   5          �Name$  
mainWindow��5   	    � WindowStartupLocation$ CenterScreen=�6A    � Title$% WhereToWatch v2.0 - Search Page��5   	   $	��750��61   $
��1000��6>    � 
ResizeMode$ NoResize=�6K   ��5	      �� 5
   
    �� Color$ #232533��6   6,   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��32 �6   6*   �� 5      6   �� 5      $��63 �6   6*   .+�5   
   o� -   5         o�Name$ mnuMain��5       o� 
IsMainMenu . ���#307AD7���#232533���#307AD7.@�5      m� -   5         m�Name$ mnuAbout��5      $��5q�6)   $��About��65   
������ 6]   5      � 5   
   $��0��6    5      �� 5      6"   	 � ColumnDefinitions	 5      �� 5      $	��200 �6#   61   �� 5      6%   �� 5      $	��220 �6#   61   �� 5       $	��220 �6#   61   �� 5!      $	��120 �6#   61   .+�5$      �� -   5        
 ��Name$
 btnLogin��5$      $��4��6'   $��90��67   $��25��6B   ���#348FFF
�������.��6v   Login6}   �� 5&      -   5         ��Name$ lblUsername��5&      $��	Username:��6)   
�������$��2��6P   $��Center=�6`   $
��Left=�6{   $
��Bold"�6�   �� 5'      -   5         ��Name$ txtUsername��5'      $��2��6+   $��Right=�6;   $
��10 3q�6W   $�� ��6e   $��25��6m   $	��125��6y   {�.  6�   �� 5)      -   5        $ lblPassword��5)      $��	Password:��6)   
�������$��3��6P   $��Center=�6`   $
��Left=�6{   $
��Bold"�6�   G� 5*      -   5         G�Name$ pwdPassword��5*      $��3��6/   $��Right=�6?   $
��10 3q�6[   $��25��6i   $	��125��6u   {�.  6�   5+      � 5,   
   $��1��6   $y�Hidden=�6   62   � 5-   
   -	   5         �Name$ 
gridRowTwo��5-      $��2��6    5.      �� 5/      $��0 �6    6-   �� 50      $��49 �6    6.   �� 51      $
��32.8 �6    60   �� 52      $��484.8 �6    61   .+�55      �� -
   5        $ lblSearchSuggestion��55      
�������$%��SEARCH FOR ANY MOVIE OR TV SHOW��6D   $��Center=�6n   $��Center=�6�   $��40(�6�   $��Franklin Gothic Book)�6�    J� RenderTransformOrigin$ 0,0.5&�6�   $��69��6�   $��2��6  $	��657��6  $��172,0.2,164.6,14q�6  $��1��68  �� 56      -   5        $ txtSearchBox��56       �� TextAlignment$ Center=�6,   ���#282A39���#348FFF$��2��6m   $��Center=�6z   $��Center=�6�   $��20��6�   $	��700��6�   $��139,7.6,146.6,6q�6�   &   System.Windows.Controls.DataGrid  57      -   5        $��dgMediaResults��57      $��3��6-   
������ ��.  $��Stretch=�6{      AutoGenerateColumns .     HeadersVisibility$
 None=�6�   
������    RowBackground
 ����    GridLinesVisibility$
 None=�6     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����$��23,0,-0.4,-0.4q�58   W      
IsReadOnly .    RowStyle 59      �� 5:       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5;      -   5        5<         Columns 5>      4  .System.Windows.Controls.DataGridTemplateColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6<      SortMemberPath$ Title��6H      CanUserSort .    CellTemplate 5@      �� 5A      .R�5B   "   ��   ��Name$  stackOne��6-   .+�5C   &   �� ! ��Name$! tbPosterPath��6,   $	��165��6`   $	��230��6l   $��10q�6y   ��6B   �� *
PosterPath+6y   �� 5D   &   " ��Name$" tbTitle��60   
�������$
��Auto��6k   $��Medium"�6x   ���#282A39# �� Padding$# 5q�6�   $
��Wrap=�6�   $��Center=�6�   ��6T   �� *Title+6�   �� 5E   &   $" tbReleaseDate��60   
�������$
��Auto��6}   $��Medium"�6�   ���#282A39$# 5q�6�   $
��Wrap=�6�   $��Center=�6�   ��6Z   �� *ReleaseDateString+6�   5F   #   5G      5I        5J      $ Overview��6-   $	 464 6?    5K      �� 5L      .R�5M   "   �� .+�5N   &   �� 
�������$��3q�6]   $
��Wrap=�6h   ��6C   �� *
Overview+6h   5O   #   5P      5R        5S      $ Genres��6-   $	 150 6=    5T      �� 5U      .R�5V   "   �� .+�5W   &   �� 
�������$��3q�6a   $
��Wrap=�6l   ��6C   �� *GenresString+6l   5X   #   5Y      5[        5\      $ 
Popularity��6-   $	 130 6A    5]      �� 5^      .R�5_   "   �� .+�5`   &   �� 
�������$��3q�6_   $
��Wrap=�6j   $��Center=�6~   ��6C   �� *
Popularity+6~   5a   #   5b      5d      5f      �� 5g      -   5        $
 btnShowFavorites��5g      $��Show Favorites��6/   $
��Left=�6H   $��865,7.6,0,0q�6c   $��2��6x   $	��Top=�6�   $��85��6�   $��20��6�   ���	#FF348FFF
�������6�   5h      �� 5i   
   -   5        $ ��Name$$ sbarMain��5i      $��3��6&   ���#282A39.@�5j      �� -   5        % ��Name$% sbarItemMessage��5j      $��Center=�5k      $
��Left=�67   $
��10 3q�6R   $��16(�6a   ���#282A39
�������6�   5l      �� 5m   
   -   5        $ 
lblResults��5m      $��3��6$   $��Right=�61   $��Center=�6M   
�������$��Medium"�6{   $��20(�6�   $
��5, 0q�6�   $y�Hidden=�6�   .��6�   Loading Results...6�   5n      5o      