using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMediator : Mediator
{
    [Inject]
    public NPCView npcView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)] //注入为全局的分配器
    public IEventDispatcher dispatcher { get; set; } //分发器

    public override void OnRegister()
    {
        npcView.Init();

        dispatcher.Dispatch(UpdateCommandEvent.evtUpdateNPCStatus);
    }

    public override void OnRemove()
    {

    }
}

