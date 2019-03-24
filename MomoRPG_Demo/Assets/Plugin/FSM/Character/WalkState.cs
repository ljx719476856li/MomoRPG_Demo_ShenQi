using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateTemplate<CharacterTest>, IState
{
    public WalkState(CharacterTest ch) : base(ch) { }


    public void OnEnter(string prevState)
    {
        Debug.Log("进入动画 walk");
        owner.m_ani.Play("Walk");
    }

    public void OnExit(string nextState)
    {
        Debug.Log("退出动画 walk");
    }

    public void OnUpdate()
    {
        Debug.Log("保持动画 walk");
    }
}
