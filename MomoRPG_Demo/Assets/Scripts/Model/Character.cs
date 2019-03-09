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
    public int HP { get; private set; }
    public int HpRecoverRate { get; private set; }//hp恢复速度
    public int HpUpperLimit { get; private set; } //hp上限
    public int MP { get; private set; }
    public int MpRecoverRate { get; private set; }//mp恢复速度
    public int MpUpperLimit { get; private set; } //mp上限
    public int Exp { get; private set; } //人物当前经验
    public int LevelExp { get; private set; } //升级所需经验
    public int ExpPercentRate { get; private set; } //当前经验百分比
    public int LevelUpperLimit { get; private set; } //等级上限
    public int Intelligence { get; private set; } //智力
    public int Strength { get; private set; } //力量
    public int Agility { get; private set; } //敏捷
    public int Stamina { get; private set; } //耐力
    public int Energy { get; private set; }//体力
    public int MissRate { get; private set; } //闪避率
    public int AttackDamage { get; private set; } //攻击力
    public int AbilityPower { get; private set; } //法强
    public int PhysicDenfence { get; private set; } //物抗
    public int MagicDenfence { get; private set; } //法抗

    public Character() { }
    public Character(int id, int name, int level, string sprite, BaseModelType baseType, RaceType race, ProfessionType profession, GenderType gender, int hp, int hpRR, int hpUL, int mp, int mpRR, int mpUL, int exp, int levelExp, int ExpPR, int LevelUL,
        int intelligence, int strength, int agility, int stamina, int energy, int missRate, int attack, int power, int pDenfence, int mDenfence) : base(id, name, level, sprite, baseType, race, profession, gender)
    {
        this.HP = hp;
        this.HpRecoverRate = hpRR;
        this.HpUpperLimit = hpUL;
        this.MP = mp;
        this.MpRecoverRate = mpRR;
        this.MpUpperLimit = mpUL;
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
        this.AbilityPower = power;
        this.PhysicDenfence = pDenfence;
        this.MagicDenfence = mDenfence;
    }
}
