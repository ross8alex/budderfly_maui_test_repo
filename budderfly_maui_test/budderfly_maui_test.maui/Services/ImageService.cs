using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budderfly_MAUI_Test.Services
{
    public class ImageService
    {
        public string[] GetImages()
        {
            return ["solar_power.jpg", "wind_power.jpg", "water_power.jpg", "nuclear_power.jpg", "power_lines.jpg"];
        }

        public string GetRandomImage()
        {
            var random = new Random();
            var images = GetImages();
            return images[random.Next(0, images.Length - 1)];
        }
    }
}
