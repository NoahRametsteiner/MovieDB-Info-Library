   M S B A M L   `   `   `  ���� O  KMovieDB-Info-Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MovieDB_Info_Library.ViewModelMovieDB_Info_Library.ViewModel  E'clr-namespace:MovieDB_Info_Library.ViewMovieDB_Info_Library.View  *    $MovieDB_Info_Library.View.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <src,clr-namespace:MovieDB_Info_Library.ViewModel     8view'clr-namespace:MovieDB_Info_Library.View     _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
MainWindow��$	��450��$	��800��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � DataContext 4  .MovieDB_Info_Library.ViewModel.ParentViewModel  .��� -    �Name$ MovieDB������  �� ImageSource$ ../image/background.jpg�� �� Opacity$	 0.9Q� j� Stretch$
 Fill=� � RowDefinitions �� $
��0.2* ��� $
��0.2* ��� $
��0.2* ��� $
��0.3* ��� $
��0.2* �	 � ColumnDefinitions	 �� $
��0.2* ��� $
��0.2* ��� $
��0.2* ��� $
��0.2* ��� $
��0.2* �.+��� -   $��	FavButton��$��2��$��0�����#2F2F2F���#FFCB75  MaterialDesignRaisedButton#��[ +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10�� � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��$
��Auto��$��10,23,10,25q�����  �� Path$	 Fav�{���  �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.���� $��Fav-List��$��0,0,10,0q��� -   $��SearchButton��$��1��$��0�����#2F2F2F���#FFCB75#��[ $
 10��$3 -MaterialDesignRaisedButton with Round Corners��$
��Auto��$��10,23,10,25q����� $ Search�{���  �� *FindAncestor+$ WindowL�.���� $��Search��$��0,0,10,0q��� -   $��Logout��$��0��$��4�����#2F2F2F���#FFCB75#��[ $
 10��$3 -MaterialDesignRaisedButton with Round Corners��$
��Auto��$��10,23,10,25q����� $ Logout�{���  �� *FindAncestor+$ WindowL�.���� $��Logout��$��0,0,10,0q��� -   $��ContentControl1��$��1��$��1��$��4��$��4��