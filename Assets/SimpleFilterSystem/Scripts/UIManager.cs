using UnityEngine;
using TMPro;
using FancyScrollView.Example08;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GetJsonData getJsonData;
    public GameObject productPanel;
    public Example08 gridView;
    public TextMeshProUGUI productName;
    public List<Toggle> toggles;
    public List<Text> toggleTexts;
    public int currentCategory;
    public string currentFilter;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void SetCategory(int val)
    {
        currentCategory = val;
    }


    public void SetFilterType(string setFilter)
    {
        List<string> filterOptions = new List<string>();
        var filter = setFilter;
        switch (filter)
        {
            case "subcategory":
                filterOptions = getJsonData.ecommerceData[0].categories[currentCategory].filters.subcategory;
                break;
            case "brand":
                filterOptions = getJsonData.ecommerceData[0].categories[currentCategory].filters.brand;
                break;
            case "type":
                filterOptions = getJsonData.ecommerceData[0].categories[currentCategory].filters.type;
                break;
            case "size":
                filterOptions = getJsonData.ecommerceData[0].categories[currentCategory].filters.size;
                break;
            case "material":
                filterOptions = getJsonData.ecommerceData[0].categories[currentCategory].filters.material;
                break;
            default:
                break;
        }

        SetToggleData(filterOptions);
    }

    void SetToggleData(List<string> filterOptions)
    {
        for (int i = 0; i < toggles.Count; i++)
        {
            if (i < filterOptions.Count)
            {
                toggles[i].gameObject.SetActive(true);
                toggleTexts[i].text = filterOptions[i];
            }
            else
            {
                toggles[i].gameObject.SetActive(false);
            }
        }
    }
}
