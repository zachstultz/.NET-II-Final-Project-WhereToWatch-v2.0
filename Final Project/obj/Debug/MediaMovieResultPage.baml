   M S B A M L   `   `   `  ����H  DFinal Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Final_ProjectFinal_Project  5   	   (    "Final_Project.MediaMovieResultPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Final_Project     5   	   -   5          �Name$  windowMediaResultPage��5   	    � Title$% WhereToWatch v2.0 - Result Page��5   	   $	��600��61   $	��730��6>    � 
ResizeMode$ NoResize=�6J   ��5	      �� 5
   
    �� Color$ #232533��6   6,   .��5      �  � RowDefinitions 5   
   �� 5      6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      -   5         ��Name$ emptyOne��5   #   $��0 �65   6A   �� 5      -   5        $ poster��5   #   $	��185 �63   6A   �� 5      -   5        $ overview��5   #   $	��295 �65   6C   �� 5      -   5        $ streamAndType��5   #   $	��255 �6:   6H   .+�5      � -   5         �Name$ PosterAndRankingSection��5   #   $��1��6    5      �� 5      -   5         ��Name$ rdPosterArt��5   $   $	��234 �69   6H   �� 5      -   5        $ rdLength��5   $   $��60 �66   6D   �� 5      -	   5        $ rdRating��5   $   $	��100 �66   6E   �� 5      -
   5        $ 	rdRanking��5   $   $��60 �67   6E   .+�5      �� -   5        	 ��Name$	 imgPosterArt��5      $D��>http://image.tmdb.org/t/p/w500/f4aul3FyD3jv3v4bul1IrkWZvzq.jpg��6.   $	��163��6v   $	��215��6�   $��10q�6�   $��0��6�   �� 5       -   5        
 ��Name$
 	tbRunTime��5       
������� �� Padding$ 30, 5q�6B   ���#282A39$��3q�6g   $��34(�6r   $��Medium"�6�   $��1��6�   $��Center=�6�   $��Center=�6�   1h 31m6�   �� 5!      -   5        $
 tbRating��5!      ���#348FFF$ 35, 5q�6C   ���#282A39$��3q�6h   $��44(�6s   $��Medium"�6�   $��2��6�   $��Center=�6�   $��Center=�6�   6.316�   �� 5"      -   5        $
 	tbRanking��5"      ���#348FFF$ 18, 5q�6D   ���#282A39$��3q�6i   $��44(�6t   $��Medium"�6�   $��3��6�   $��Center=�6�   $��Center=�6�   #19196�   5#      � 5%      -   5        $ TitleOverviewSection��5%   #   $��2��6    5&      �� 5'      -   5        $ rdTitle��5'   0   $��60 �6$   6C   �� 5(      -   5        $ rdReleaseDate��5(   0   $��30 �6$   6I   �� 5)      -   5        $ rdDescriptionTitle��5)   0   $��36 �6$   6N   �� 5*      -   5        $ rdDescription��5*   1   $	��220 �6$   6J   �� 5+      -   5        $ rdCreatedByTitle��5+   0   $��30 �6$   6L   �� 5,      -   5        $ rdCreatedByContent��5,   0   $��30 �6$   6N   �� 5-      -   5        $ rdGenresTitle��5-   0   $��30 �6$   6I   �� 5.      -   5        $ rdGenresContent��5.   2   $
��Auto �6$   6M   �� 5/      -   5        $ rdTagsTitle��5/   0   $��30 �6$   6G   �� 50      -   5        $ rdTagsContent��50   0   $��30 �6$   6I   .+�52      �� -   5        $
 tbTitle��52      
�������$��28(�6A   $��0��6P   $
��Wrap=�6]   $
��Left=�6q   $��Center=�6�   Young Einstein6�   �� 53      -   5        $
 tbReleaseDate��53      ���#348FFF$��Medium"�6H   $ 4q�6\   $��20(�6h   $��1��6w   $
��Left=�6�   $��Center=�6�   19886�   �� 54      -   5        $
 tbOverviewTitle��54      ���#7C889E$��Medium"�6J   $��16(�6^   $ 4q�6l   $��2��6y   $
��Left=�6�   $��Bottom=�6�   Description6�   �� 55      -   5        $
 tbOverviewContent��55      ���#7C889E$��12(�6L   $ 4q�6Z   $��3��6g   $
��Left=�6t   $
��Wrap=�6�   $	��Top=�6�   ��Albert Einstein is the son of a Tasmanian apple farmer, who discovers the secret of splitting the beer atom to put the bubbles back into beer. When Albert travels to Sydney to patent his invention he meets beatuiful French scientist Marie Curie, as well as several unscrupulous types who try to take advantage of the naive genius and his invention.6  �� 56      -   5        $
 tbStudiosTitle��56      ���#7C889E$��Medium"�6I   $ 4q�6]   $��14(�6i   $��4��6x   $
��Left=�6�   $��Center=�6�   
Created By6�   �� 57      -   5        $
 tbStudiosContent��57      ���#348FFF$��Medium"�6K   $��12(�6_   $ 4q�6m   $��5��6z   $
��Left=�6�   $
��Wrap=�6�   $	��Top=�6�   (&Dax Productions | Lantis | Nomad | Ray6�   �� 58      -    5        $
 tbGenresTitle��58      ���#7C889E$��Medium"�6H   $ 4q�6\   $��14(�6h   $��6��6w   $
��Left=�6�   $��Center=�6�   Genres6�   �� 59      -!   5        $
 tbGenresContent��59      ���#348FFF$��2q�6J   $��Medium"�6U   $��12(�6i   $
 4, 4q�6w   $��7��6�   $
��Left=�6�   $
��Wrap=�6�   $	��Top=�6�   Comedy6�   �� 5:      -"   5        $
 tbTagsTitle��5:      ���#7C889E$��Medium"�6F   $ 4q�6Z   $��14(�6f   $��8��6u   $
��Left=�6�   $��Center=�6�   Tags6�   �� 5;      -#   5        $
 tbTagsContent��5;      
�������$��2q�6F   $��Medium"�6Q   $��12(�6e   $
 4, 4q�6s   $��9��6�   $
��Left=�6�   $
��Wrap=�6�   $	��Top=�6�   $	��-/-��5<   9   5=      5>      � 5@      -$   5        $ StreamButtonSection��5@   #   $��3��6   $��570.4��6@   $��224.8��6O    5A      �� 5B      -%   5        $ rdTrailerButton��5B   $   $��55 �6=   6K   �� 5C      -&   5        $ rdType��5C   $   $��35 �64   6B   �� 5D      -'   5        $ rdBroadcast��5D   $   $��35 �69   6G   �� 5E      -(   5        $ 	rdSeasons��5E   $   $��35 �67   6E   �� 5F      -)   5        $ 
rdEpisodes��5F   $   $��35 �68   6F   �� 5G      $��35 �6$   62   �� 5H      $��41 �6$   62   �� 5I      6&   �� 5J      6&   .+�5L      �� -*   5         ��Name$ 
btnTrailer��5L      
�������$��32, 3q�6@   $��3q�6P   ���#348FFF$��30(�6q   $��Light"�6   $��0��6�   $��Center=�6�   $	��Top=�6�   $��Open Trailer��6�   $	��215��6�   6�   �� 5M      -+   5        $
 tbTypeTitle��5M      ���#7C889E$��Medium"�6F   $ 4q�6Z   $��14(�6f   $��1��6u   $
��Left=�6�   $	��Top=�6�   Type:6�   �� 5N      -,   5        $
 tbTypeContent��5N      
�������$��2q�6F   ���#616161$��Medium"�6f   $��12(�6z   $
 4, 4q�6�   $��1��6�   $��Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $��Movie��5O   ;   5P      �� 5Q      --   5        $
 tbLaunchTitle��5Q      ���#7C889E$��Medium"�6H   $ 4q�6\   $��14(�6h   $��2��6w   $
��Left=�6�   $	��Top=�6�   	Launch:6�   �� 5R      -.   5        $
 tbLaunchContent��5R      
�������$��2q�6H   ���#4CAF50$��Medium"�6h   $��12(�6|   $
 4, 4q�6�   $��2��6�   $��Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $��Launch��5S   <   5T      �� 5U      -/   5        $
 tbBroadcastTitle��5U      ���#7C889E$��Medium"�6K   $ 4q�6_   $��14(�6k   $��3��6z   $
��Left=�6�   $	��Top=�6�   
Broadcast:6�   �� 5V      -0   5        $
 tbBroadcastContent��5V      
�������$��2q�6K   ���#4CAF50$��Medium"�6k   $��12(�6   $
 4, 4q�6�   $��3��6�   $��Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $��Sundays��5W   =   5X      �� 5Y      -1   5        $
 tbSeasonsTitle��5Y      ���#7C889E$��Medium"�6I   $ 4q�6]   $��14(�6i   $��4��6x   $
��Left=�6�   $	��Top=�6�   	Seasons6�   �� 5Z      -2   5        $
 tbSeasonsContent��5Z      
�������$��2q�6I   ���#616161$��Medium"�6i   $��12(�6}   $
 4, 4q�6�   $��4��6�   $��Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $��2��5[   7   5\      �� 5]      -3   5        $
 tbEpisodesTitle��5]      ���#7C889E$��Medium"�6K   $ 4q�6_   $��14(�6k   $��5��6z   $
��Left=�6�   $	��Top=�6�   	Episodes:6�   �� 5^      -4   5        $
 tbEpisodesContent��5^      
�������$��2q�6J   ���#616161$��Medium"�6j   $��12(�6~   $
 4, 4q�6�   $��5��6�   $��Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $��2��5_   7   5`      �� 5a      -5   5        $ btnAddToFavorites��5a      
�������$��40, 3q�6H   $��3q�6X   ���#348FFF$��20(�6y   $��Light"�6�   $��6��6�   $��Center=�6�   $	��Top=�6�   .��6�   Add To Favorites6  �� 5b      -6   5        $
 tbStreamOnTitle��5b      ���#7C889E$��Medium"�6K   $ 4q�6_   $��14(�6k   $��7��6z   $
��Left=�6�   $	��Top=�6�   6�   �� 5c      -7   5        $
 tbStreamOnContent��5c      
�������$��2q�6J   ���#4CAF50$��Medium"�6j   $��12(�6~   $
 4, 4q�6�   $��7��6�   $��Center=�6�   $
��Wrap=�6�   $	��Top=�6�   6�   �� 5d      -8   5        $	 ImageStreamOnLogo��5d      $��50��6T   $��50��6_   $��10q�6k   $��8��6w   ��63   �� *ImageFilePath+6w   5e      5f      5g      5h      