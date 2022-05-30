using Image;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery
{
    public class GalleryElement : MonoBehaviour
    {
        [SerializeField] private RawImage thumbnail;
        [SerializeField] private AspectRatioFitter aspectRatioFitter;
        [SerializeField] private TextMeshProUGUI fileInfo;

        public void Initialize(ImageContent imageContent)
        {
            thumbnail.texture = imageContent.Texture;
            aspectRatioFitter.aspectRatio = (float)imageContent.Texture.width / imageContent.Texture.height;
            fileInfo.text = $"{imageContent.FileName} {Environment.NewLine} " +
                $"{imageContent.TimeSinceCreation.Days}/{imageContent.TimeSinceCreation.Hours}";
        }
    }
}