using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private SearchSettings searchSettings;

    [SerializeField] private TMP_InputField pathInputField;
    [SerializeField] private Toggle recursiveSearchToggle;
    [SerializeField] private ToggleGroup toggleGroup;

    private ExtensionToggle[] extensionToggles;

    private void Awake()
    {
        extensionToggles = toggleGroup.GetComponentsInChildren<ExtensionToggle>();
    }

    private void Start()
    {
        SetUI();

        pathInputField.onEndEdit.AddListener(OnPathEdited);
        recursiveSearchToggle.onValueChanged.AddListener(OnRecursiveSearchChanged);
        searchSettings.extension = GetActiveExtension();

        foreach (var toggle in extensionToggles)
        {
            toggle.onValueChanged.AddListener((value) => searchSettings.extension = GetActiveExtension());
        }
    }

    private void SetUI()
    {
        pathInputField.text = searchSettings.path;
        recursiveSearchToggle.isOn = searchSettings.recursiveSearch;

        foreach (var toggle in extensionToggles)
        {
            if (toggle.extension == searchSettings.extension)
                toggle.isOn = true;
        }
    }

    private string GetActiveExtension()
    {
        var activeToggle = extensionToggles.Where(toggle => toggle.isOn).FirstOrDefault();
        return activeToggle.extension;
    }

    //private void OnExtensionsChanged(bool value)
    //{
    //    var activeToggle = extensionToggles.Where(toggle => toggle.isOn).FirstOrDefault();
    //    searchSettings.extension = activeToggle.extension;
    //}

    //private string GetActiveExtension()
    //{
    //    var activeToggle = extensionToggles.Where(toggle => toggle.isOn).FirstOrDefault();
    //    searchSettings.extension = activeToggle.extension;
    //}

    private void OnRecursiveSearchChanged(bool value) => searchSettings.recursiveSearch = value;

    public void OnPathEdited(string path) => searchSettings.path = path;


}
