using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{

    /// <summary>
    /// 当这个命令被执行的时候，默认会调用Execute方法，此处常用于初始化各个资源
    /// </summary>
    /// 

    [Inject]
    public ParseCharacterJson parseCharacterJson { get; set; }
    public override void Execute()
    {
        Debug.Log("start command execute");
    }


}
