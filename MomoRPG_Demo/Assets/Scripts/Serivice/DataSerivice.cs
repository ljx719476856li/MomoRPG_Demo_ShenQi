using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 解析各模型数据（玩家，npc，敌人）的Json
/// </summary>

public class DataSerivice : MonoBehaviour
{
    private static DataSerivice _instance;
    public static DataSerivice Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.Find("YangJian_03").GetComponent<DataSerivice>();
            }
            return _instance;
        }           
    }

    private List<BaseModel> modelDataList;//存放模型数据的List
    public List<BaseModel> ModelDataList
    {
        get
        {
            return modelDataList;
        }
    }

    private void Awake()
    {
        ParseModelJson();
    }

    //解析Json
    public void ParseModelJson()
    {
        modelDataList = new List<BaseModel>();

        TextAsset modelText = Resources.Load<TextAsset>("ModelDataJson");
        string characterJson = modelText.text;
        JSONObject j = new JSONObject(characterJson);
        //Debug.Log(j);

        foreach(JSONObject temp in j.list)
        {
            //公有属性
            int id = (int)temp["ID"].n;
            string name = temp["Name"].str;
            int level = (int)temp["Level"].n;
            EBaseModelType baseType = (EBaseModelType)System.Enum.Parse(typeof(EBaseModelType), temp["BaseType"].str);//基础类型（玩家，敌人，npc）
            ERaceType race = (ERaceType)System.Enum.Parse(typeof(ERaceType), temp["Race"].str);
            EProfessionType profession = (EProfessionType)System.Enum.Parse(typeof(EProfessionType), temp["Profession"].str);
            GenderType gender = (GenderType)System.Enum.Parse(typeof(GenderType), temp["Gender"].str);

            BaseModel baseModel = null;

            switch (baseType)
            {
              
                case EBaseModelType.eCharacter:
                    int hp = (int)temp["HP"].n;
                    int hpRecoverRate = (int)temp["HpRecoverRate"].n;
                    int mp = (int)temp["MP"].n;
                    int mpRecoverRate = (int)temp["MpRecoverRate"].n;
                    int levelExp = (int)temp["LevelExp"].n;
                    int exp = (int)temp["Exp"].n;
                    float expPercentRate = (float)temp["ExpPercentRate"].n;
                    int levelUpperLimit = (int)temp["LevelUpperLimit"].n;
                    int intelligence = (int)temp["Intelligence"].n;
                    int strength = (int)temp["Strength"].n;
                    int agility = (int)temp["Agility"].n;
                    int stamina = (int)temp["Stamina"].n;
                    int energy = (int)temp["Energy"].n;
                    float missRate = (float)temp["MissRate"].n;
                    int missValue = (int)temp["MissValue"].n;
                    float criRate = (float)temp["CriRate"].n;
                    int criValue = (int)temp["CriValue"].n;
                    int attackDamage = (int)temp["AttackDamage"].n;
                    int physicDenfence = (int)temp["PhysicDenfence"].n;
                    int magicDenfence = (int)temp["MagicDenfence"].n;

                    baseModel = new Character(id, name, level, baseType, race, profession, gender, hp, hpRecoverRate, mp, mpRecoverRate, exp, levelExp, expPercentRate, levelUpperLimit,
                        intelligence, strength, agility, stamina, energy, missRate, missValue, attackDamage, criRate, criValue, physicDenfence, magicDenfence);
                    break;
                case EBaseModelType.eNPC:
                    break;
                case EBaseModelType.eEnemy:
                    break;
                default:
                    break;
            }
            modelDataList.Add(baseModel);
            //Debug.Log(baseModel);
        }
    }


}
