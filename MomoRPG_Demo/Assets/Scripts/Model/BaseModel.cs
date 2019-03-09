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


public class BaseModel : MonoBehaviour
{
    public int ID { get; private set; }
    public int Name { get; private set; }
    public int Level { get; private set; }
    public string Sprite { get; private set; }
    public BaseModelType BaseType { get; private set; }
    public RaceType Race { get; private set; }
    public ProfessionType Profession { get; private set; }
    public GenderType Gender { get; private set; }

    public BaseModel() { }
    public BaseModel(int id, int name, int level, string sprite, BaseModelType baseType, RaceType race, ProfessionType profession, GenderType gender)
    {
        this.ID = id;
        this.Name = name;
        this.Level = level;
        this.Sprite = sprite;
        this.BaseType = baseType;
        this.Race = race;
        this.Profession = profession;
        this.Gender = gender;

    }
}
