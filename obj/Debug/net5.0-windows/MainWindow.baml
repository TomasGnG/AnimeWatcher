   M S B A M L   `   `   `  ����G  CAnimeWatcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AnimeWatcherAnimeWatcher  5   	       AnimeWatcher.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AnimeWatcher     5   	     � Title$  
MainWindow��5   	   $	��461��6   $	��800��6)      backgroundImage#���   5	   	   .��5
      � -   5         �Name$
 wpf1��5
       J� RenderTransformOrigin$ 0.5,0.5&�6   .+�5   
   �� $��Wähle einen Anime aus��6   $��Center=�60   $��32��6M   $��0,10,0,0q�6Y   $	��Top=�6k   $	��780��6�   
�������$��20(�6�   $��Center=�6�   $	��Top=�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ animeComboBox��5      $��Center=�6*   $	��Top=�6G   $��0,59,0,0q�6_   $	��753��6q   6}   �� 5   
   $"��Wähle eine/n Folge/Film aus��6   $��Center=�66   $��39��6S   $��0,95,0,0q�6_   $	��Top=�6q   $	��780��6�   
�������$��20(�6�   $��Center=�6�   $	��Top=�6�   $
��Bold"�6�   �� 5   
   -   5        $ episodeComboBox��5      $��Center=�6,   $	��Top=�6I   $��	0,139,0,0q�6a   $	��752��6t   $ 0.498,0.572&�6�   �� 5   
   -   5         ��Name$ openEpisodeButton��5      $$��Klicke um die Folge zu öffnen��6,   $��Center=�6T   $��27��6q   $��	0,397,0,0q�6}   $	��Top=�6�   $	��492��6�   $	��Top=�6�   $��16(�6�   $
��Bold"�6�   6�   �� 5   
   -   5         ��Name$ animePicturePreview��5      $	��203��6-   $��304,178,0,0q�6:   $	��Top=�6O   $
��Left=�6g   $	��200��6�   5       � 	Resources 5        	imgSource �� ImageSource �� Opacity	 j� Stretch
 j� TileMode��%�   &	       &	  g     ��5   
   SOD:\Anwendungsentwicklung\source\AnimeWatcher\AnimeWatcher\images\Background.jpg��6z   �� 5   
   # �  6-   $	 0.3Q�6W   $
	 Fill=�6e   $

 None=�6t   6�   5      5      