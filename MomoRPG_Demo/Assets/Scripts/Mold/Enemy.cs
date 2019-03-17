using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人类
/// </summary>
/// 
public enum EnemyT//敌人类型
{
    Easy,
    Normal,
    Diffcult
}

public class Enemy : BaseModel
{
    public EnemyT EnemyType { get;  set; }
    public int ExpDrop { get;  set; }
    public int HP { get;  set; }
    public int Damage { get;  set; }

    public Enemy() { }
    public Enemy(int id, string name, int level,BaseModelType baseType, RaceType race, ProfessionType profession, GenderType gender, EnemyT enemyType, int expDrop, int hp, int damage) :
        base(id, name, level, baseType, race, profession, gender)
    {
        this.EnemyType = enemyType;
        this.ExpDrop = expDrop;
        this.HP = hp;
        this.Damage = damage;
    }

}
