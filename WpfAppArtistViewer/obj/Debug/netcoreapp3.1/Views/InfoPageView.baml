   M S B A M L   `   `   `  ����M  IWpfAppArtistViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WpfAppArtistViewer.ViewsWpfAppArtistViewer.Views  5      C&clr-namespace:WpfAppArtistViewer.ViewsWpfAppArtistViewer.Views  5      M+clr-namespace:WpfAppArtistViewer.ViewModelsWpfAppArtistViewer.ViewModels  5      +    %WpfAppArtistViewer.Views.InfoPageView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:WpfAppArtistViewer.Views     5      8views&clr-namespace:WpfAppArtistViewer.Views     5      B
viewModels+clr-namespace:WpfAppArtistViewer.ViewModels     5      -   5          >�Name$  Control��5
   F   $��16(�68   .��5      � ��6   �� *Height+ �� ElementName$ Control�� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� TextAlignment$ Center=�6!   $��30(�68   
���� K���6Z   �� *
ArtistName+ �� StringFormat$ Info about {0}��� 5   
   $��1��6   $��1��6   
���� K�$��	15,0,15,0q�6;   � 5   
   $��2��6   $	��150��6   $��
15,15,15,0q�6)   $��Center=�6=    � ColumnDefinitions 5      �� 5      $	��120 �6#   �� 5       5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      � $��0��6   $��15q�6#   
�������.+�5      �� $��10q�68   ��6   �� *ImgageSource+6F   5      � 5       $��1��6   $��10q�6#    5!      �� 5"      �� 5#      �� 5$      .+�5&      �� $��0��6   ��6)   �� *
ArtistName+$ 	Name: {0}���� 5'      $��1��6   ��6)   �� *FirstPublished+$ First publis: {0}���� 5(      $��2��6   ��6)   �� *	Listeners+$ Listeners: {0}��5)      � 5*      $��1��6   $��2��6    $��1��64   
���� K�6?   5+      � 5,   
   $��3��6   .+�5-      �� .+�5.      �� $
��Bold"�6   $��20(�6.   $ Center=�6<   $��
15,15,15,5q�6S   Bio6l   � 5/      $��1��6   
���   �$��	60,0,60,0q�65   �� 50      $��13(�6   $ Center=�6*   $
��Wrap=�6A   $��15,15,15,15q�6U   ��6j   �� *Bio+� 51      $��1��6   
���   �$��	60,0,60,0q�65   �� 52      $��20(�6   $
��Bold"�6*   $ Center=�6<   $��
15,15,15,5q�6S   Simular Artist6w   � 53      $��Center=�6   $��Center=�62   .+�54      �� ��6   �� *SimilarArtist+��55      �� 56      .R�57   "   ��  �� Orientation$ 
Horizontal=�6-   58      ��5:      �� 5;      .R�5<   "   � $��0��6'   $	��200��64    5=   &   �� 5>   *   $��6* �68   �� 5?   *   $��1* �68   �� 5@   *   $��2* �68   .+�5B   &   � $��0��6+   $��15q�68   
�������.+�5C   *   �� ��60   �� *
image.text+6Q   5D   '   �� 5E   &   $��1��60   $ Center=�6=   ��6T   �� *name+�� 5F   &   $��2��6-   $��	15,0,15,0q�6�       MaterialDesignOutlinedButton#��[  6�    � ToolTip$" MaterialDesignOutlinedButton��6�   ��6:   �� *DataContext.ReadMoreCommand+$ Control����6�   �� .��6  	Read More5H   '   5I   #   5J      5L      5M      5N      5O      5P      5Q      