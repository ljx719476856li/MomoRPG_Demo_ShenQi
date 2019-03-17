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
public enum GenderType
{
    eMale,
    eFemale,
    eNone//无性别
}


public class BaseModel
{
    public int ID { get;  set; }
    public string Name { get;  set; }
    public int Level { get;  set; }
    //public string Sprite { get; private set; }
    public EBaseModelType BaseType { get;  set; }
    public ERaceType Race { get;  set; }
    public EProfessionType Profession { get;  set; }
    public GenderType Gender { get;  set; }

    public BaseModel() { }
    public BaseModel(int id, string name, int level, EBaseModelType baseType,ERaceType race, EProfessionType profession, GenderType gender)
    {
        this.ID = id;
        this.Name = name;
        this.Level = level;
        //this.Sprite = sprite;
        this.BaseType = baseType;
        this.Race = race;
        this.Profession = profession;
        this.Gender = gender;

    }
}
