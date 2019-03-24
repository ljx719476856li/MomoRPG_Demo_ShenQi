using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * mailbox receive other send message
 * message dispatch   registerListener notify listener  push
 * other checkMessage     pull
 * 类似于Mailbox的组件 用于缓存其它实体发送给该实体的消息
 * 包括：动画系统发送的消息  受到攻击的消息
 */
/// <summary>
/// 攻击事件和被攻击事件等动画事件和外部事件触发
/// AI或者状态机检测事件接着处理
/// AI也向状态机中注入事件
/// </summary>
public class MyAnimationEvent : MonoBehaviour
{
    //TODO:在发射MyAnimationEvent给Player或者怪物之前 同服务器通信 GameInterface里实现网络
    public enum MsgType
    {
        KillNpc,
        DoSkill,
        IDLE,
        STUNNED,
        EXIT_STUNNED,
        BOMB,
        DEAD,
        JUMP,
    }

    public class Message
    {
        public MsgType type;

        public Message(MsgType t)
        {
            type = t;
        }
        public Message()
        {

        }
    }

    AI.NPCAttribute attribute;
    [HideInInspector]
    List<Message> messages = new List<Message>();

    public void InsertMsg(Message msg)
    {
        //Log.Sys("AddMessage " + msg.type);
        messages.Add(msg);
    }

    public Message NextMsg()
    {
        if (messages.Count > 0)
        {
            var ret = messages[0];
            messages.RemoveAt(0);
            return ret;
        }
        return null;
    }
    public void ClearMsg()
    {
        messages.Clear();
    }
    public Message CheckMsg(MsgType type)
    {
        Message ret = null;
        if (messages.Count > 0 && messages[0].type == type)
        {
            ret = messages[0];
            messages.RemoveAt(0);
        }

        return ret;
    }
}
