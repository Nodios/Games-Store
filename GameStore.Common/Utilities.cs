using System;
using System.IO;

namespace GameStore.Common
{
    /// <summary>
    /// Provides helper methods
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Convert image to byte array
        /// </summary>
        /// <param name="image">Image</param>
        /// <returns>Byte array</returns>
        public static byte[] ImageToArray(System.Drawing.Image image)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return stream.ToArray();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Constructs image from byte array
        /// </summary>
        /// <param name="byteArray">Byte array</param>
        /// <returns>Image</returns>
        public static System.Drawing.Image ImageFromArray(byte[] byteArray)
        {
            try
            {
                MemoryStream stream = new MemoryStream(byteArray);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

                return image;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
