using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解析角色Json文件,并将角色数据存入List<BaseModel> CharacterModelList
/// </summary>

public class ParseCharacterJson : MonoBehaviour
{
    [Inject]
    public IRequestDataFromWeb requestDataFromWeb { get; set; }

    private List<BaseModel> characterModelList;
    public List<BaseModel> CharacterModelList
    {
        get
        {
            if (characterModelList == null)
                characterModelList = new List<BaseModel>();
            return characterModelList;
        }
    }

    public ParseCharacterJson()
    {
        characterModelList = new List<BaseModel>();
    }

    public void ParseModelJson()
    {
        JSONObject j =  requestDataFromWeb.RequestCharacterData();

        foreach (JSONObject temp in j.list)
        {
            //公有属性
            int id = (int)temp["ID"].n;
            EModelName name = (EModelName)System.Enum.Parse(typeof(EModelName), temp["ModelName"].str);
            int level = (int)temp["Level"].n;
            EBaseModelType baseType = (EBaseModelType)System.Enum.Parse(typeof(EBaseModelType), temp["BaseType"].str);//基础类型（玩家，敌人，npc）
            ERaceType race = (ERaceType)System.Enum.Parse(typeof(ERaceType), temp["Race"].str);
            EProfessionType profession = (EProfessionType)System.Enum.Parse(typeof(EProfessionType), temp["Profession"].str);
            EGenderType gender = (EGenderType)System.Enum.Parse(typeof(EGenderType), temp["Gender"].str);

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
            characterModelList.Add(baseModel);
        }
    }

    //获取角色列表里存放角色的类型
    public void GetCharacterType()
    {
        foreach(BaseModel b in characterModelList)
        {
            
        }
    }

}
