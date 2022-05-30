using UnityEngine;

[CreateAssetMenu]
public class SearchSettings : ScriptableObject
{
    public string path;
    public bool recursiveSearch = false;
    public string extension = "*.png";
}
