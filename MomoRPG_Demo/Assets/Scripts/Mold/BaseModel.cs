using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 基础模型类
/// </summary>
/// 
public enum BaseModelType
{
    Character,
    NPC,
    Enemy
}

public enum RaceType
{
    Human,
    Animal,
    Demon//恶魔族
}

public enum ProfessionType
{
    Archer,//弓箭手(敌人远程)
    Mage,//魔法师
    Warrior//战士（敌人近战）

}
public enum GenderType
{
    Male,
    Female,
    None//无性别
}


public class BaseModel
{
    public int ID { get;  set; }
    public string Name { get;  set; }
    public int Level { get;  set; }
    //public string Sprite { get; private set; }
    public BaseModelType BaseType { get;  set; }
    public RaceType Race { get;  set; }
    public ProfessionType Profession { get;  set; }
    public GenderType Gender { get;  set; }

    public BaseModel() { }
    public BaseModel(int id, string name, int level, BaseModelType baseType, RaceType race, ProfessionType profession, GenderType gender)
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
