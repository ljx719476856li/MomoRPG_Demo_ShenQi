using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 从服务器获取数据
/// </summary>

public class RequestDataFromWeb : IRequestDataFromWeb
{
    public JSONObject RequestCharacterData()
    {
        TextAsset modelText = Resources.Load<TextAsset>("CharcaterDataJson");
        string characterJson = modelText.text;
        JSONObject j = new JSONObject(characterJson);
        return j;
    }
}
