using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMediator : Mediator
{
    [Inject]
    public EnemyView enemyView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)] //注入为全局的分配器
    public IEventDispatcher dispatcher { get; set; } //分发器

    public override void OnRegister()
    {
        enemyView.Init();

        dispatcher.Dispatch(UpdateCommandEvent.evtUpdateEnemyStatus);
    }

    public override void OnRemove()
    {

    }
}
