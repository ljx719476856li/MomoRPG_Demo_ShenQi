using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人类
/// </summary>
/// 
public enum EEnemy//敌人类型
{
    eEasy,
    eNormal,
    eDiffcult
}

public class Enemy : BaseModel
{
    public EEnemy EnemyType { get;  set; }
    public int ExpDrop { get;  set; }
    public int HP { get;  set; }
    public int Damage { get;  set; }

    public Enemy() { }
    public Enemy(int id, string name, int level,EBaseModelType baseType, ERaceType race, EProfessionType profession, GenderType gender, EEnemy enemyType, int expDrop, int hp, int damage) :
        base(id, name, level, baseType, race, profession, gender)
    {
        this.EnemyType = enemyType;
        this.ExpDrop = expDrop;
        this.HP = hp;
        this.Damage = damage;
    }

}
