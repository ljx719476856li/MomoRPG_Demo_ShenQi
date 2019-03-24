using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateTemplate<CharacterTest>, IState 
{
    public IdleState(CharacterTest ch) : base(ch) { }

    public void OnEnter(string prevState)
    {
        Debug.Log("进入动画 idle");
        owner.m_ani.Play("Idle");
    }

    public void OnExit(string nextState)
    {
        Debug.Log("退出动画 idle");
    }

    public void OnUpdate()
    {
        Debug.Log("保持动画 idle");
    }
}
