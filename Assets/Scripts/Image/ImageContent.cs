using System;
using System.IO;
using UnityEngine;

namespace Image
{
    public class ImageContent
    {
        public Texture2D Texture { get; private set; }
        public string FileName { get; private set; }
        public TimeSpan TimeSinceCreation { get; private set; }

        public ImageContent(Texture2D texture, FileInfo fileInfo)
        {
            Texture = texture;
            FileName = fileInfo.Name;
            TimeSinceCreation = DateTime.Now.Subtract(fileInfo.CreationTime);
        }
    }
}