using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AnimeWatcher
{
    public class AnimeSeries
    {
        public String animeName;
        public Image animeImage;
        public List<String> animeEpisodes;

        public AnimeSeries(String name, Image image, List<String> episodes)
        {
            animeEpisodes = episodes;
            animeName = name;
            animeImage = image;
        }
    }
}
