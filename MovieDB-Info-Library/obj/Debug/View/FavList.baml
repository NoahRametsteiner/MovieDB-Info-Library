   M S B A M L   `   `   `  ����O  KMovieDB-Info-Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MovieDB_Info_Library.ViewModelMovieDB_Info_Library.ViewModel  5   	   E'clr-namespace:MovieDB_Info_Library.ViewMovieDB_Info_Library.View  5   	   '    !MovieDB_Info_Library.View.FavList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <src,clr-namespace:MovieDB_Info_Library.ViewModel     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local'clr-namespace:MovieDB_Info_Library.View  5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   ���#F6F6F6  MaterialDesignFont#���  5   	    � DataContext 5      3  -MovieDB_Info_Library.ViewModel.MovieViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   6,   �� 5      $
��0.1* �6   6,   �� 5      $
��0.6* �6   6,    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   6.   �� 5      $
��0.5* �6   6.   �� 5      6!   �� 5      $
��0.5* �6   6.   �� 5      $
��0.1* �6   6.   .+�5"   
   � $��2��6   $��1��6   $��3��6,   .+�5#      &   System.Windows.Controls.DataGrid  -   5        $��	ListView1��5#         AutoGenerateColumns .     
IsReadOnly .  �� SelectedItem 6D   �� *SelectedItem+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ImdbID��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *ImdbID+  5(      $
	 Name��6)   
 67   �� *Title+5+      5,      �� 5/   
   -   5        $��0��5/      $��3��6   ���#2F2F2F���#FFCB75  MaterialDesignRaisedButton#��[ 53      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��54       � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��55      $
��Auto��56   e   $��5,5,5,5q�6s   ��50      ��  �� Path$ CallFavDetail�{�56      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��57      �� $��Show Details��6   $��0,0,10,0q�6,   58      5;      5<      