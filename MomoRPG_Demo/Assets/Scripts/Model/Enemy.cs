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
    public EnemyT EnemyType { get; private set; }
    public int ExpDrop { get; private set; }
    public int HP { get; private set; }
    public int Damage { get; private set; }

    public Enemy() { }
    public Enemy(int id, int name, int level, string sprite, BaseModelType baseType, RaceType race, ProfessionType profession, GenderType gender, EnemyT enemyType, int expDrop, int hp, int damage) :
        base(id, name, level, sprite, baseType, race, profession, gender)
    {
        this.EnemyType = enemyType;
        this.ExpDrop = expDrop;
        this.HP = hp;
        this.Damage = damage;
    }

}
