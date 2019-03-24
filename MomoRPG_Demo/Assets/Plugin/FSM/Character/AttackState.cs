using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateTemplate<CharacterTest>, IState
{
    public AttackState(CharacterTest ch) : base(ch) { }


    public void OnEnter(string prevState)
    {
        Debug.Log("进入动画 Attack");
        owner.m_ani.Play("Attack1");
    }

    public void OnExit(string nextState)
    {

    }

    public void OnUpdate()
    {

    }
}
