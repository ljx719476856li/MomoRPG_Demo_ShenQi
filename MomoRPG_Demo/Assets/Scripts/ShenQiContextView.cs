using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShenQiContextView : ContextView
{
    private void Awake()
    {
        this.context = new ShenQiContext(this); //初始化后即自带启动StrangeIOC框架
    }
}
