using System.IO;
using UnityEngine;

namespace Image
{
    public class ImageLoader
    {
        public static bool TryLoadImageFromPath(string filePath, out Texture2D texture)
        {
            texture = new Texture2D(2,2);

            if (!File.Exists(filePath))
                return false;

            byte[] imageByteArray = File.ReadAllBytes(filePath);
            bool isLoaded = texture.LoadImage(imageByteArray);
            return isLoaded;
        }
    }
}