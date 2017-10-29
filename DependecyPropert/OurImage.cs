using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurDependencyProperty
{
    public class OurImage
    {
        public string PathOfImage { get; set; }
        public string NameOfImage { get; set; }
        public bool IsFound { get; set; }

        public OurImage()
        {
            this.PathOfImage = "default.png";
            this.NameOfImage = "Default";
            this.IsFound = true;
        }
        public OurImage(string pathOfImage, string nameOfImage)
        {
            this.PathOfImage = pathOfImage;
            this.NameOfImage = nameOfImage;
            this.IsFound = File.Exists(Path.Combine(Directory.GetCurrentDirectory(), pathOfImage));
        }
    }
}
