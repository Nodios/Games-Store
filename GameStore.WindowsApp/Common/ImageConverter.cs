using System;
using System.IO;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace GameStore.WindowsApp.Common 
{
    /// <summary>
    /// Image converter class 
    /// </summary>
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Get bytes and create new bitmap image
            byte[] bytes = value as byte[];
            BitmapImage image = new BitmapImage();

            // Write bytes to stream
            InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
            stream.AsStreamForWrite().Write(bytes, 0, bytes.Length);
            stream.Seek(0);

            // Set stream as image source
            image.SetSource(stream);
            ImageSource source = image;

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
