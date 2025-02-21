using Proyecto26;
using System.IO;
using UnityEngine;

public class GetJsonData : MonoBehaviour
{
    public TextAsset asset;
    public EcommerceData.AllData[] ecomData;

    void Awake()
    {
        GetDataFromJson();
    }


    [SerializeField]
    public void GetDataFromJson()
    {
        ecomData = JsonHelper.FromJsonString<EcommerceData.AllData>(asset.text);
    }
}
