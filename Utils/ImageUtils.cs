﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;

namespace BeatLeader_Server.Utils
{
    public class ImageUtils
    {
        public static (string, MemoryStream) GetFormatAndResize(MemoryStream memoryStream)
        {
            IImageFormat format;
            Image image = Image.Load(memoryStream, out format);
            Size size = image.Size();

            int width = Math.Min(200, size.Width);
            int height = (int)(((float)size.Height / (float)size.Width) * (float)width);

            if (width < height) {
                image.Mutate(i => i.Resize(width, height).Crop(new Rectangle(0, height / 2 - width / 2, width, width)));
            } else if (width > height) {
                image.Mutate(i => i.Resize(width, height).Crop(new Rectangle(width / 2 - height / 2, 0, height, height)));
            } else {
                image.Mutate(i => i.Resize(width, height));
            }

            var ms = new MemoryStream(5);
            string extension;

            if (format.Name == "GIF") {
                image.SaveAsGif(ms);
                extension = ".gif";
            } else {
                image.SaveAsPng(ms);
                extension = ".png";
            }
            ms.Position = 0;

            return (extension, ms);
        }
        
        public static (string, MemoryStream) GetFormat(MemoryStream memoryStream)
        {
            IImageFormat format;
            Image image = Image.Load(memoryStream, out format);

            var ms = new MemoryStream(5);
            string extension;

            if (format.Name == "GIF") {
                image.SaveAsGif(ms);
                extension = ".gif";
            } else {
                image.SaveAsPng(ms);
                extension = ".png";
            }
            ms.Position = 0;

            return (extension, ms);
        }
    }
}
