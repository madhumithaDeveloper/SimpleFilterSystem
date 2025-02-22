using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FilterCategories : MonoBehaviour
{
    GetJsonData getJsonData;
    public Transform productListContainer;
    public Button applyFilterButton;
    public Button resetFilterButton;
    public List<string> filterBrand = new List<string>();
    public List<string> filterSubcategory = new List<string>();
    public List<string> filterType = new List<string>();
    public List<string> filterSize = new List<string>();
    public List<string> filterMaterial = new List<string>();
    public List<EcommerceData.Item2> filteredProducts = new List<EcommerceData.Item2>();
    public enum FilterType
    {
        subcategory = 0,
        brand = 1,
        type = 2,
        size = 3,
        material = 4
    }
    public FilterType filterTypes;


    void Start()
    {
        getJsonData = UIManager.Instance.getJsonData;
        applyFilterButton.onClick.AddListener(ApplyFilter);
        resetFilterButton.onClick.AddListener(ResetFilter);

        for (int i = 0; i < UIManager.Instance.toggles.Count; i++)
        {
            var j = i;
            UIManager.Instance.toggles[j].onValueChanged.AddListener(delegate
            {
                Filterbrand(UIManager.Instance.toggles[j], UIManager.Instance.toggleTexts[j]);
            });
        }
        filteredProducts = getJsonData.ecommerceData[0].categories[UIManager.Instance.currentCategory].items;
    }

    public void Filterbrand(Toggle toggle, Text text)
    {
        if (toggle.isOn)
        {
            var filter = filterTypes;
            switch (filter)
            {
                case FilterType.subcategory:
                    filterSubcategory.Add(text.text);
                    break;
                case FilterType.brand:
                    filterBrand.Add(text.text);
                    break;
                case FilterType.type:
                    filterType.Add(text.text);
                    break;
                case FilterType.size:
                    filterSize.Add(text.text);
                    break;
                case FilterType.material:
                    filterMaterial.Add(text.text);
                    break;
                default:
                    break;
            }
        }
        else
        {
            var filter = filterTypes;
            switch (filter)
            {
                case FilterType.subcategory:
                    filterSubcategory.Remove(text.text);
                    break;
                case FilterType.brand:
                    filterBrand.Remove(text.text);
                    break;
                case FilterType.type:
                    filterType.Remove(text.text);
                    break;
                case FilterType.size:
                    filterSize.Remove(text.text);
                    break;
                case FilterType.material:
                    filterMaterial.Remove(text.text);
                    break;
                default:
                    break;
            }
        }
    }

    void ApplyFilter()
    {
        filteredProducts = getJsonData.ecommerceData[0].categories[UIManager.Instance.currentCategory].items
               .Where(item =>
               (filterBrand != null && filterBrand.Contains(item.brand)) ||
               (filterSubcategory != null && filterSubcategory.Contains(item.subcategory)) ||
               (filterType != null && filterType.Contains(item.type)) ||
               (filterMaterial != null && filterMaterial.Contains(item.material)) ||
               (filterSize != null && filterSize.Contains(item.size))
               ).ToList();

        DisplayProducts();
    }

    void ResetFilter()
    {
        SetTogglesActive(false);
        filteredProducts = getJsonData.ecommerceData[0].categories[UIManager.Instance.currentCategory].items;
        DisplayProducts();
    }

    public void DisplayProducts()
    {
        UIManager.Instance.gridView.GenerateCells(filteredProducts.Count);
    }

    public void SetFilterType(int val)
    {
        filterTypes = (FilterType)val;
    }

    public void SetTogglesActive(bool val)
    {
        for (int i = 0; i < UIManager.Instance.toggles.Count; i++)
        {
            UIManager.Instance.toggles[i].isOn = val;
        }
    }
}
