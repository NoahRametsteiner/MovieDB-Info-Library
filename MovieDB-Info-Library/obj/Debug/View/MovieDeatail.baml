   M S B A M L   `   `   `  ����O  KMovieDB-Info-Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MovieDB_Info_Library.ViewMovieDB_Info_Library.View  5   	   O,clr-namespace:MovieDB_Info_Library.ViewModelMovieDB_Info_Library.ViewModel  5   	   ,    &MovieDB_Info_Library.View.MovieDeatail   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MovieDB_Info_Library.View     5   	   <src,clr-namespace:MovieDB_Info_Library.ViewModel     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     � Title$  Titel��5	   	   $	��900��6   $
��1000��6$    � DataContext 5      4  .MovieDB_Info_Library.ViewModel.DetailViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��0.15* �6   6-   �� 5      $��0.15* �6   6-   �� 5      $��0.15* �6   6-   �� 5      $��0.15* �6   6-   �� 5      $��0.15* �6   6-   �� 5      $��0.15* �6   6-   �� 5      $��0.15* �6   6-    � ColumnDefinitions 5   
   �� 5      $��0.05* �6   6/   �� 5      $
��0.3* �6   6.   �� 5      $
��0.3* �6   6.   �� 5      $
��0.3* �6   6.   �� 5      $
��0.3* �6   6.   �� 5      $
��0.3* �6   6.   .+�5"   
   �� -   5        $��ImageViewer��5"   R   $��1��6   $��2��6    $��6��64   $��1��6E   ��6e   �� *NewDetail.movieBild+ �� UpdateSourceTrigger$ PropertyChanged=��� 5&   
   $��0��6   $��3��6!   $��5��61    �� Padding$ 10q�6E   $��10,10,10,50q�6R   $��Titel��6g   $
��Bold"�6t   #  MaterialDesignThemes.Wpf.Card  5'   
   $��0��6   $��3��6+   $��5��6;   $��10q�6O   $��15,50,15,20q�6\   .��5(      ��  $   MaterialDesignHeadline6TextBlock#���   5)      ��5*      ��  �� Path$ NewDetail.MovieTitle�$ PropertyChanged=�5+      5,      �� 5.   
   $��1��6   $��3��6!   $��5��61   $ 10q�6E   $��10,10,10,50q�6R   $��Release Year��6g     5/   
   $��1��6   $��3��6+   $��5��6;   $��10q�6O   $��15,50,15,20q�6\   .��50      �� #���   51      ��52      �� $ NewDetail.MovieYear�$ PropertyChanged=�53      54      �� 56   
   $��2��6   $��3��6!   $��5��61   $ 10q�6E   $��10,10,10,50q�6R   $��Rating��6g     57   
   $��2��6   $��3��6+   $��5��6;   $��10q�6O   $��15,50,15,20q�6\   .��58      �� #���   59      ��5:      �� $ NewDetail.MovieRated�$ PropertyChanged=�5;      5<      �� 5>   
   $��3��6   $��3��6!   $��5��61   $ 10q�6E   $��10,10,10,50q�6R   $��Runtime��6g     5?   
   $��3��6   $��3��6+   $��5��6;   $��10q�6O   $��15,50,15,20q�6\   .��5@      �� #���   5A      ��5B      �� $ NewDetail.MovieRuntime�$ PropertyChanged=�5C      5D      �� 5F   
   $��4��6   $��3��6!   $��5��61   $ 10q�6E   $��10,10,10,50q�6R   $��Genre��6g     5G   
   $��4��6   $��3��6+   $��5��6;   $��10q�6O   $��15,50,15,20q�6\   .��5H      �� #���   5I      ��5J      �� $ NewDetail.MovieGenre�$ PropertyChanged=�5K      5L      �� 5N   
   $��5��6   $��3��6!   $��5��61   $ 10q�6E   $��10,10,10,50q�6R   $��Director��6g     5O   
   $��5��6   $��3��6+   $��5��6;   $��10q�6O   $��15,50,15,20q�6\   .��5P      �� #���   5Q      ��5R      �� $ NewDetail.MovieDirector�$ PropertyChanged=�5S      5T      �� 5V   
   $��6��6   $��3��6!   $��5��61   $ 10q�6E   $��10,10,10,50q�6R   $��Actors��6g     5W   
   $��6��6   $��3��6+   $��5��6;   $��10q�6O   $��15,50,15,20q�6\   .��5X      �� #���   5Y      ��5Z      �� $ NewDetail.MovieActors�$ PropertyChanged=�5[      5\      �� 5i   
   $��0��6   $��1��6   ���#2F2F2F���#FFCB75  MaterialDesignRaisedButton#��[ 5m      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5n       � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��5o      $
��Auto��5p   e   $��5q�6s   $��10,45,10,45q�6   ��5j      �� $ CallFav�{�5p      �� 	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType$
 WindowL�.��5q      �� $��Add to favorites��6   $��0,0,10,0q�60   5r      5s      5t      