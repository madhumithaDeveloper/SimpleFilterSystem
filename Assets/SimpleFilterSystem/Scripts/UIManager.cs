using UnityEngine;
using TMPro;
using FancyScrollView.Example08;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public string selectedcategory;
    public GameObject productPanel;
    public Example08 gridView;
    public TextMeshProUGUI productName;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void SetSelectedCategory(TextMeshProUGUI textMeshProUGUI)
    {
        selectedcategory = textMeshProUGUI.text;
    }
}
