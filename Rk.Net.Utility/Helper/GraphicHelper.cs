using System;
using System.Drawing;
using System.IO;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class GraphicHelper
    {
        #region Methods
        /// <summary>
        /// Resizes the image stream.
        /// </summary>
        /// <param name="imageBytes">The image bytes.</param>
        /// <param name="maxWidth">The maximum width. Value 0 or below to ignore.</param>
        /// <param name="maxHeight">The maximum height. Value 0 or below to ignore</param>
        /// <returns></returns>
        public static byte[] ResizeImage(byte[] imageBytes, double maxWidth, double maxHeight)
        {
            if (imageBytes == null || imageBytes.Length == 0) return imageBytes;
            byte[] resizedImageBytes;
            using (MemoryStream imageStream = new MemoryStream(), resizedImageStream = new MemoryStream())
            {
                // write the string to the stream  
                imageStream.Write(imageBytes, 0, imageBytes.Length);
                // create the start Bitmap from the MemoryStream that contains the image  
                Bitmap startBitmap = new Bitmap(imageStream);
                // set thumbnail height and width proportional to the original image.  
                double newHeight = 0;
                double newWidth = 0;
                double HW_ratio;
                if (maxHeight > 0 && startBitmap.Height > maxHeight)//resize if max Height specified and image Height is out or range
                {
                    newHeight = maxHeight;
                    HW_ratio = maxHeight / startBitmap.Height;
                    newWidth = HW_ratio * startBitmap.Width;
                    if (maxWidth > 0 && newWidth > maxWidth)
                    {
                        newWidth = maxWidth;
                        HW_ratio = maxWidth / newWidth;
                        newHeight = HW_ratio * newHeight;
                    }
                }
                else if (maxWidth > 0 && startBitmap.Width > maxWidth) //resize if max Width specified and image Width is out or range
                {
                    newWidth = maxWidth;
                    HW_ratio = maxWidth / startBitmap.Width;
                    newHeight = HW_ratio * startBitmap.Height;
                    if (maxHeight > 0 && newHeight > maxHeight)
                    {
                        newHeight = maxHeight;
                        HW_ratio = maxHeight / newHeight;
                        newWidth = HW_ratio * newWidth;
                    }
                }

                //Check if their is a new height and new width if not return original image
                if (newHeight == 0 || newWidth == 0)
                {
                    return imageBytes;
                }
                // create a new Bitmap with dimensions for the thumbnail.  
                Bitmap newBitmap = new Bitmap((int)newWidth, (int)newHeight);
                // Copy the image from the START Bitmap into the NEW Bitmap.  
                // This will create a thumnail size of the same image.  
                newBitmap = ResizeImage(startBitmap, (int)newWidth, (int)newHeight);
                // Save this image to the specified stream in the specified format.  
                newBitmap.Save(resizedImageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Fill the byte[] for the thumbnail from the new MemoryStream.  
                resizedImageBytes = resizedImageStream.ToArray();
            }
            // return the resized image as a string of bytes.  
            return resizedImageBytes;
        }

        // Resize a Bitmap  
        /// <summary>
        /// Resizes the image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            if (image == null) throw new ArgumentNullException("image");
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }  
        #endregion
    }
}