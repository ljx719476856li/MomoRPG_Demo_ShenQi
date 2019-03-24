using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AICharacter
    {
        public bool canRelive = false;

        public AIState state
        {
            get;
            set;
        }
        public NPCAttribute attribute;
        Dictionary<EAIStateEnum, AIState> stateMap = new Dictionary<EAIStateEnum, AIState>(); //keyValue 是AIStateEnum， 通过抽象状态转换到实际动画，达到解耦系统的功能
        public NPCAttribute GetAttr()
        {
            return attribute;
        }

        /// <summary>
        /// 控制动画的播放
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speed"></param>
        /// <param name="wm"></param>
        public virtual void PlayAni(string name, float speed, WrapMode wm)
        {

            //var ani = GetAttr().GetComponent<Animation>();

            //ani[name].speed = speed;
            //ani[name].wrapMode = wm;
            //ani[name].time = 0;
            //ani.Play(name);
        }

        /// <summary>
        /// 混合动画播放 //TODO 如果使用Animator controller 不知道是否需要这个函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speed"></param>
        /// <param name="wm"></param>
        public virtual void SetAni(string name, float speed, WrapMode wm)
        {
            //var ani = GetAttr().GetComponent<Animation>();

            //ani[name].speed = speed;
            //ani[name].wrapMode = wm;
            //ani.CrossFade(name);
        }

        //TODO:状态机检测是否可以进入 其它状态
        //逻辑是退出当前状态后进入 其他的状态
        public bool ChangeState(EAIStateEnum es)
        {
            if(state != null && !state.CheckNextState(es))
            {
                Debug.Log("1");
                return false;
            }
            if(!stateMap.ContainsKey(es))
            {
                Debug.Log("2");
                Debug.Log("gameObject No State " + GetAttr().gameObject + " state " + es);
                return false;
            }

            if(state != null && state.type == es)
            {
                Debug.Log("3");
                return false;
            }

            if(state != null)
            {
                Debug.Log("赋值前" + state.type);
                Debug.Log("4");
                state.ExitState();
            }
            
            state = stateMap[es];
            Debug.Log("--------- " +  es + " ---------");
            Debug.Log("赋值后" + state.type);
            state.EnterState();
            attribute.StartCoroutine(state.RunLogic());
            return true;
        }


        /// <summary>
        /// 初始化状态机
        /// </summary>
        /// <param name="state"></param>
        public void AddState(AIState state)
        {
            if(stateMap.ContainsKey(state.type))
            {
                Debug.Log("Error Has SameState In Map " + state.type + " " + stateMap[state.type] + " " + state);
            }
            stateMap[state.type] = state;
            state.AICharacters = this;
        }

        //增加临时状态
        public void AddTempState(AIState state)
        {
            state.AICharacters = this;
        }


        public virtual IEnumerator ShowDead()
        {
            yield return null;
        }

        public virtual void SetRun()
        {
            throw new System.Exception("AI Characet Not Set Run " + GetAttr().gameObject.name);
        }

        public virtual void SetIdle()
        {
            throw new System.Exception("AI Characet Not Set Idle " + GetAttr().gameObject.name);
        }

        protected bool CheckAni(string name)
        {
            return GetAttr().GetComponent<Animation>().GetClip(name) != null;
        }
    }

}




