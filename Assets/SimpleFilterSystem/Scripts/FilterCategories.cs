using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FilterCategories : MonoBehaviour
{
    public GetJsonData getJsonData;
    public Transform productListContainer;
    public Button applyFilterButton;
    public Button resetFilterButton;
    public Text menSubCategoryText;
    public Text woomenSubCategoryText;
    public Text kidsSubCategoryText;
    public Toggle menSubCategoryToggle;
    public Toggle womenSubCategoryToggle;
    public Toggle kidsSubCategoryToggle;

    public List<EcommerceData.Product> filteredProducts = new List<EcommerceData.Product>();

    void Start()
    {
        applyFilterButton.onClick.AddListener(ApplyFilter);
        resetFilterButton.onClick.AddListener(ResetFilter);
        filteredProducts = getJsonData.ecomData[0].products;
        UIManager.Instance.gridView.GenerateCells(filteredProducts.Count);
    }

    void ApplyFilter()
    {
        string selectedCategory = UIManager.Instance.selectedcategory;
        string selectedSubCategory_men = "";
        string selectedSubCategory_women = "";
        string selectedSubCategory_kids = "";
        if (menSubCategoryToggle.isOn)
            selectedSubCategory_men = menSubCategoryText.text;
        if (womenSubCategoryToggle.isOn)
            selectedSubCategory_women = woomenSubCategoryText.text;
        if (kidsSubCategoryToggle.isOn)
            selectedSubCategory_kids = kidsSubCategoryText.text;

        filteredProducts = getJsonData.ecomData[0].products
            .Where(p => p.category == selectedCategory && (p.subCategory == selectedSubCategory_men || p.subCategory == selectedSubCategory_women || p.subCategory == selectedSubCategory_kids))
            .ToList();

        DisplayProducts();
    }

    void ResetFilter()
    {
        filteredProducts = getJsonData.ecomData[0].products;
        menSubCategoryToggle.isOn = false;
        womenSubCategoryToggle.isOn = false;
        kidsSubCategoryToggle.isOn = false;
        DisplayProducts();
    }

    void DisplayProducts()
    {
        UIManager.Instance.gridView.GenerateCells(filteredProducts.Count);
    }
}
