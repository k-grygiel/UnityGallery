using System.IO;
using UnityEngine;

namespace Image
{
    public class ImageFinder : MonoBehaviour
    {
        public static FileInfo[] GetFiles(string path, string searchPattern, bool searchRecursive)
        {
            if (!Directory.Exists(path))
            {
                Debug.Log("Directory doesnt exist! " + path);
                return null;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var searchOption = searchRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            return directoryInfo.GetFiles(searchPattern, searchOption);
        }
    }
}