using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    None,
    Idle,
    Run,
    Attack
}

public class CharacterTest : MonoBehaviour
{
    public static EventSystem.Dispatcher Events = new EventSystem.Dispatcher();
    private FiniteStateMachine FSM = new FiniteStateMachine();
    public Animation m_ani;
    private PlayerState m_ps = PlayerState.Idle;

    //TODO 实现完整的动画控制系统
    void Awake()
    {
        //注册事件    
        FSM.Register("Idle", new IdleState(this));
        FSM.Register("Walk", new WalkState(this));
        FSM.Register("Attack", new AttackState(this));
        FSM.EntryPoint("Idle");

        //定义俩状态 Idle && Walk
        //并且注册状态中的消息触发action：CHARACTER_TO_WALK， BACK_TO_IDLE
        //Idle -> Walk / Walk -> Idle
        FSM.State("Idle").On("CHARACTER_TO_WALK").Enter("Walk").On("CHARACTER_TO_ATTACK").Enter("Attack");
        FSM.State("Walk").On("WALK_BACK_TO_IDLE").Enter("Idle").On("CHARACTER_TO_ATTACK").Enter("Attack");
        FSM.State("Attack").On("ATTACK_BACK_TO_IDLE", delegate (float time)
        {
            time = 0.0f;
            if (time == 2.0f)
            {
                FSM.Enter("Idle");
            }

        });
        FSM.State("Attack").On("ATTACK_BACK_TO_WALK", delegate (float time)
        {
            time = 0.0f;
            if (time == 2.0f)
            {
                FSM.Enter("Idle");
            }

        });


        //TODO 修改BUG，及状态间的关系用于画出理清楚关系
        Events.On("PlayerToWalk", delegate ()
        {
            Debug.Log("PlayerToWalk");
            if (FSM.CurrentState != FSM.State("Walk"))
                FSM.CurrentState.Trigger("CHARACTER_TO_WALK");
        });
        Events.On("WalkBackToIdle", delegate ()
        {
            Debug.Log("WalkBackToIdle");
            if(FSM.CurrentState != FSM.State("Idle"))
                FSM.CurrentState.Trigger("WALK_BACK_TO_IDLE");
        });
        Events.On("AttackBackToIdle", delegate ()
        {
            Debug.Log("AttackBackToIdle");
            if(FSM.CurrentState != FSM.State("Idle"))
                FSM.CurrentState.Trigger("ATTACK_BACK_TO_IDLE");
        });
        Events.On("AttackBackToWalk", delegate ()
        {
            Debug.Log("WalkBackToIdle");
            if (FSM.CurrentState != FSM.State("Walk"))
                FSM.CurrentState.Trigger("ATTACK_BACK_TO_WALK");
        });
        Events.On("CharacterToAttack", delegate ()
        {
            if (FSM.CurrentState != FSM.State("Attack"))
                FSM.CurrentState.Trigger("CHARACTER_TO_ATTACK");
        });


    }

    // Start is called before the first frame update
    void Start()
    {
        m_ani = transform.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        FSM.Update();
        //         if (Input.GetMouseButtonDown(0))
        //         {
        //             m_ps = PlayerState.Attack;
        //         }
        if (Input.GetKey(KeyCode.W))
        {
            m_ps = PlayerState.Run;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            m_ps = PlayerState.Idle;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            m_ps = PlayerState.Attack;
        }

        //根据枚举 让状态机器类去切换状态
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        switch (m_ps)
        {
            case PlayerState.Idle:
                //machine.TranslateState(1);
                // 实现行走动画的播放
                m_ani.Play("Idle");
                if (FSM.CurrentState == FSM.State("Attack"))
                    Events.Trigger("AttackBackToIdle");
                else if(FSM.CurrentState == FSM.State("Walk"))
                    Events.Trigger("BackToIdle"); 
                break;
            case PlayerState.Run:
                //machine.TranslateState(2);
                //实现行走动画的播放
                m_ani.Play("Walk");
                if (FSM.CurrentState == FSM.State("Attack"))
                    Events.Trigger("AttackBackToWalk");
                else if(FSM.CurrentState == FSM.State("Idle"))
                    Events.Trigger("PlayerToWalk");
                break;
            case PlayerState.Attack:
                //machine.TranslateState(3);
                m_ani.Play("Attack1");
                Events.Trigger("CharacterToAttack");
                break;
        }
    }

}
