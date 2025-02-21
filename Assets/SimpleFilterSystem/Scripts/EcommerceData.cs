using System;
using System.Collections.Generic;
using UnityEngine;

public class EcommerceData : MonoBehaviour
{
    [Serializable]
    public class Product
    {
        public string name;
        public string category;
        public string subCategory;
    }

    [Serializable]
    public class AllData
    {
        public List<Product> products;
    }
}
