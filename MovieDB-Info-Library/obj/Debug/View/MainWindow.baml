   M S B A M L   `   `   `  ����O  KMovieDB-Info-Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MovieDB_Info_Library.ViewModelMovieDB_Info_Library.ViewModel  5   	   E'clr-namespace:MovieDB_Info_Library.ViewMovieDB_Info_Library.View  5   	   *    $MovieDB_Info_Library.View.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <src,clr-namespace:MovieDB_Info_Library.ViewModel     5   	   8view'clr-namespace:MovieDB_Info_Library.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � DataContext 5      4  .MovieDB_Info_Library.ViewModel.ParentViewModel  5   
   .��5      � -   5         �Name$ MovieDB��5      ��5   
   �� 5       �� ImageSource$ ../image/background.jpg��6    �� Opacity$	 0.9Q�6?    j� Stretch$
 Fill=�6M    � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.3* �6   �� 5       $
��0.2* �6   	 � ColumnDefinitions	 5#   
   �� 5$      $
��0.2* �6   �� 5%      $
��0.2* �6   �� 5&      $
��0.2* �6   �� 5'      $
��0.2* �6   �� 5(      $
��0.2* �6   .+�5,   
   �� -   5        $��	FavButton��5.      $��0��5,      $��1��6   ���#2F2F2F���#FFCB75  MaterialDesignRaisedButton#��[ 51      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10��52       � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��53      $
��Auto��54   e   $��10,23,10,25q�6s   ��5-      ��  �� Path$	 Fav�{�54      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��55      �� $��Fav-List��6   $��0,0,10,0q�6(   56      �� 57   
   -   5        $��SearchButton��59      $��0��57      $��0��6   ���#2F2F2F���#FFCB75#��[ 5<      $
 10��5=      $3 -MaterialDesignRaisedButton with Round Corners��5>      $
��Auto��5?   e   $��10,23,10,25q�6s   ��58      �� $ Search�{�5?      ��  �� *FindAncestor+$ WindowL�.��5A      �� $��Search��6   $��0,0,10,0q�6&   5B      �� 5C   
   -   5        $��Logout��5E      $��0��5C      $��4��6   ���#2F2F2F���#FFCB75#��[ 5H      $
 10��5I      $3 -MaterialDesignRaisedButton with Round Corners��5J      $
��Auto��5K   e   $��10,23,10,25q�6s   ��5D      �� $ Logout�{�5K      ��  �� *FindAncestor+$ WindowL�.��5M      �� $��Logout��6   $��0,0,10,0q�6&   5N      �� 5O   
   -   5        $��ContentControl1��5O   [   $��1��6   $��0��6&   $��5��66   $��5��6G   6[   5P      5Q      