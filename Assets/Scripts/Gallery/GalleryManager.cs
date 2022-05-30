using Image;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;
using System;
using System.IO;
using System.Collections.Generic;

namespace Gallery
{
    public class GalleryManager : MonoBehaviour
    {
        [SerializeField] private ScrollRect scroll;
        [SerializeField] private GalleryElement galleryElementPrefab;
        [SerializeField] private SearchSettings SearchSettings;

        private List<GalleryElement> gallery;

        private void Start()
        {
            gallery = new List<GalleryElement>();
        }

        public void LoadGalleryFromPath()
        {
            ClearGallery();
            string galleryPath = SearchSettings.path;
            var files = ImageFinder.GetFiles(galleryPath, SearchSettings.extension, SearchSettings.recursiveSearch);

            if (files is null)
                return;
            
            for (int i = 0; i < files.Length; i++)
            {
                if(!ImageLoader.TryLoadImageFromPath(files[i].FullName, out Texture2D texture))
                    continue;

                ImageContent imageContent = new ImageContent(texture, files[i]);
                GetGalleryElement(imageContent);
            }
        }

        private GalleryElement GetGalleryElement(ImageContent imageContent)
        {
            var galleryElement = GetPooledObject();
            galleryElement.Initialize(imageContent);
            galleryElement.gameObject.SetActive(true);
            return galleryElement;
        }

        public GalleryElement GetPooledObject()
        {
            for (int i = 0; i < gallery.Count; i++)
            {
                if (!gallery[i].gameObject.activeInHierarchy)
                    return gallery[i];
            }

            var newElement = Instantiate(galleryElementPrefab, scroll.content);
            newElement.gameObject.SetActive(false);
            gallery.Add(newElement);
            return newElement;
        }

        public void ClearGallery()
        {
            for (int i = 0; i < gallery.Count; i++)
            {
                gallery[i].gameObject.SetActive(false);
            }
        }
    }
}