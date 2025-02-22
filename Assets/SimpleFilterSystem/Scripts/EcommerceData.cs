using System;
using System.Collections.Generic;
using UnityEngine;

public class EcommerceData : MonoBehaviour
{
    [Serializable]
    public class Category
    {
        public string name ;
        public Filters filters ;
        public List<Item2> items ;
    }

    [Serializable]
    public class Filters
    {
        public List<string> subcategory ;
        public List<string> brand ;
        public List<string> priceRange ;
        public List<string> type ;
        public List<string> size ;
        public List<string> material ;
    }

    [Serializable]
    public class Item
    {
        public List<Category> categories ;
    }

    [Serializable]
    public class Item2
    {
        public string name ;
        public string subcategory ;
        public string brand ;
        public int price ;
        public string type ;
        public string size ;
        public string material ;
    }

    [Serializable]
    public class Data
    {
        public List<Item> Items ;
    }
}
