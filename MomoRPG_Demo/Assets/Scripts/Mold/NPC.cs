using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC类
/// </summary>

public enum ENPCType
{
    eNone,//无功能，交流用
    eBusinessman,
    ePrincipal,//委托人，接任务
    eWarehouseManager//仓库管理员
}


public class NPC : BaseModel
{
    //TODO交互

    public ENPCType NpcType { get;  set; }

    public NPC() { }
    public NPC(int id, EModelName name, int level,EBaseModelType baseType, ERaceType race, EProfessionType profession, EGenderType gender, ENPCType npcType) : base(id, name, level,baseType, race, profession, gender)
    {
        this.NpcType = npcType;

    }
}
