using Proyecto26;
using System.IO;
using UnityEngine;

public class GetJsonData : MonoBehaviour
{
    public TextAsset asset;
    public EcommerceData.Item[] ecommerceData;

    void Awake()
    {
        GetDataFromJson();
    }


    [SerializeField]
    public void GetDataFromJson()
    {
        ecommerceData = JsonHelper.FromJsonString<EcommerceData.Item>(asset.text);
    }
}
