using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IMGENUMERABLELECTURE
{
    public class Insta
    {
        BitmapImage _image;
        string _content;

        public Insta (BitmapImage image, string content)
        {
            _image = image;
            _content = content;
        }
        public Insta (string filePath, string content)
        {
            _image = new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
            _content = content; 
        }

        public BitmapImage Image { get => _image; set => _image = value; }
        public string Content { get => _content; set => _content = value; }
    }
    public FormatConvertedBitmap GreyScale()
    {
        FormatConvertedBitmap newformatedBitmapSource = new FormatConvertedBitmap();

        // BitmapSource objects like FormatConvertedBitmap can only have their properties
        // changed within a BeginInit/EndInit block.
        newformatedBitmapSource.BeginInit();

        // Use the BitmapSource object defined above as the source for this new
        // BitmapSource (chain the BitmapSource objects together).
        newformatedBitmapSource.Source = Image;

        // Set the new format to Gray32Float (grayscale).
        newformatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
        newformatedBitmapSource.EndInit();

        return newformatedBitmapSource; 
    }
}
