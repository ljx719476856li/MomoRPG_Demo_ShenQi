﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC类
/// </summary>

public enum NPCType
{
    None,//无功能，交流用
    Businessman,
    Principal,//委托人，接任务
    WarehouseManager//仓库管理员
}


public class NPC : BaseModel
{
    //TODO交互

    public NPCType NpcType { get; private set; }

    public NPC() { }
    public NPC(int id, int name, int level, string sprite, BaseModelType baseType, RaceType race, ProfessionType profession, GenderType gender, NPCType npcType) : base(id, name, level, sprite, baseType, race, profession, gender)
    {
        this.NpcType = npcType;
    }
}
