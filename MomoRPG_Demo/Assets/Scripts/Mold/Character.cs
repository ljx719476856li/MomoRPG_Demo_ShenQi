using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色类
/// 
/// 耐力影响PhysicDenfence与MagicDenfence
/// 体力影响HP
/// 力量影响AttackDamage
/// 智力影响AbilityPower
/// 敏捷影响MissRate
/// </summary>
public class Character : BaseModel
{
    public int HP { get;  set; }
    public int HpRecoverRate { get;  set; }//hp恢复速度
    public int MP { get;  set; }
    public int MpRecoverRate { get;  set; }//mp恢复速度
    public int Exp { get;  set; } //人物当前经验
    public int LevelExp { get;  set; } //升级所需经验
    public float ExpPercentRate { get;  set; } //当前经验百分比
    public int LevelUpperLimit { get;  set; } //等级上限
    public int Intelligence { get;  set; } //智力
    public int Strength { get;  set; } //力量
    public int Agility { get;  set; } //敏捷
    public int Stamina { get;  set; } //耐力
    public int Energy { get;  set; }//体力


    public float MissRate { get;  set; } //闪避率
    public int MissValue { get; set; }//闪避值
    public float CritRate { get; set; }//暴击率
    public int CriValue { get; set; }//暴击值
    public int AttackDamage { get;  set; } //攻击力
    public int PhysicDenfence { get;  set; } //物抗
    public int MagicDenfence { get;  set; } //法抗

    public Character() { }
    public Character(int id, EModelName name, int level,EBaseModelType baseType, ERaceType race, EProfessionType profession, EGenderType gender, int hp, int hpRR,int mp, int mpRR,int exp, int levelExp, float ExpPR, int LevelUL,
        int intelligence, int strength, int agility, int stamina, int energy, float missRate, int missValue,int attack,float criRate,int criValue, int pDenfence, int mDenfence) : base(id, name, level, baseType, race, profession, gender)
    {
        this.HP = hp;
        this.HpRecoverRate = hpRR;
        this.MP = mp;
        this.MpRecoverRate = mpRR;
        this.Exp = exp;
        this.LevelExp = levelExp;
        this.ExpPercentRate = ExpPR;
        this.LevelUpperLimit = LevelUL;
        this.Intelligence = intelligence;
        this.Strength = strength;
        this.Agility = agility;
        this.Stamina = stamina;
        this.Energy = energy;
        this.MissRate = missRate;
        this.AttackDamage = attack;
        this.PhysicDenfence = pDenfence;
        this.MagicDenfence = mDenfence;
        this.CriValue = criValue;
        this.MissValue = missValue;
        this.CritRate = criRate;
    }

    public override string GetModelName()
    {
        return base.GetModelName();
    }
}
