using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShenQiContext : MVCSContext
{
    public ShenQiContext(MonoBehaviour view): base(view) { }


    protected override void mapBindings()
    {
        //Manager

        //Model
        injectionBinder.Bind<Character>().To<Character>().ToSingleton();  //ToSingleton() 表示这个对象只会在整个工程中生成一个
        injectionBinder.Bind<Enemy>().To<Enemy>().ToSingleton(); 
        injectionBinder.Bind<NPC>().To<NPC>().ToSingleton(); 


        //Mediator 
        mediationBinder.Bind<NPCView>().To<NPCMediator>(); //view层与mediator的绑定，用于隔离View层与Command层
        mediationBinder.Bind<EnemyView>().To<EnemyMediator>(); //view层与mediator的绑定，用于隔离View层与Command层
        mediationBinder.Bind<UIVIew>().To<UIMediator>(); //view层与mediator的绑定，用于隔离View层与Command层
        mediationBinder.Bind<CharacterView>().To<CharacterMediator>(); //view层与mediator的绑定，用于隔离View层与Command层

        //Command
        commandBinder.Bind(UpdateCommandEvent.evtUpdateNPCStatus).To<UpdateNPCStatus>();
        commandBinder.Bind(UpdateCommandEvent.evtUpdateEnemyStatus).To<UpdateEnemyStatus>();
        commandBinder.Bind(UpdateCommandEvent.evtUpdateCharacterStatus).To<UpdateCharacterStatus>();//event与事件的绑定，绑定成功后执行Execute函数
        //Service

        //绑定开始事件
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once(); //.Once()命令执行一次后删除

    }
}
