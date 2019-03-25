using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 基础模型类
/// </summary>
/// 
public enum EBaseModelType
{
    eCharacter,
    eNPC,
    eEnemy
}

public enum ERaceType
{
    eHuman,
    eAnimal,
    eDemon//恶魔族
}

public enum EProfessionType
{
    eArcher,//弓箭手(敌人远程)
    eMage,//魔法师
    eWarrior//战士（敌人近战）

}
public enum EGenderType
{
    eMale,
    eFemale,
    eNone//无性别
}

public enum EModelName
{
    eWuNiang,
    eYangJian,
    eHuli
}


public class BaseModel
{
    public int ID { get;  set; }
    public EModelName ModelName { get;  set; }
    public int Level { get;  set; }
    //public string Sprite { get; private set; }
    public EBaseModelType BaseType { get;  set; }
    public ERaceType Race { get;  set; }
    public EProfessionType Profession { get;  set; }
    public EGenderType Gender { get;  set; }

    public BaseModel() { }
    public BaseModel(int id, EModelName name, int level, EBaseModelType baseType,ERaceType race, EProfessionType profession, EGenderType gender)
    {
        this.ID = id;
        this.ModelName = name;
        this.Level = level;
        //this.Sprite = sprite;
        this.BaseType = baseType;
        this.Race = race;
        this.Profession = profession;
        this.Gender = gender;

    }


    public virtual string GetModelName()
    {
        string Name = "";
        switch (ModelName)
        {
            case EModelName.eWuNiang:
                Name = "舞娘";
                break;
            case EModelName.eYangJian:
                Name = "杨戬";
                break;
            case EModelName.eHuli:
                Name = "狐狸";
                break;
            default:
                break;
        }
        return Name;
    }
}
