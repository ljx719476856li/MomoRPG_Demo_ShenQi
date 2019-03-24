using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    public enum EAIStateEnum
    {
        eINVALID = -1,
        eIDLE,
        eCOMBAT,
        eDEAD,
        eMOVE,

        eFLEE,
        eKNOCK_BACK,

        eCAST_SKILL,
        eStunned,

        eJUMP,

        eMOVE_SHOOT,
        eSTOP,
    }

    public class AIState
    {
        protected AICharacter aiCharacter;
        protected bool quit = false;

        public AICharacter AICharacters
        {
            get
            {
                return aiCharacter;
            }
            set
            {
                aiCharacter = value;
            }
        }

        public EAIStateEnum type = EAIStateEnum.eINVALID;  //初始化状态为无状态

        /// <summary>
        ///构成一个Idle组成的树状结构
        /// Idle对应的状态有自己的层 
        /// </summary>
        public int layer = 0;

        public AIState()
        {

        }

        /// <summary>
        ///重载的时候 子类需要在while中判定是否quit状态
        /// </summary>
        public virtual IEnumerator RunLogic()
        {
            while (!quit)
            {
                
                yield return null;
            }
        }

        /// <summary>
        /// 重载的时候 子类 需要 执行父类的enterState exitState 函数
        /// </summary>
        public virtual void EnterState()
        {
            quit = false;
        }

        /// <summary>
        /// 重载的时候 子类 需要 执行父类的enterState exitState 函数
        /// </summary>
        public virtual void ExitState()
        {
            quit = true;
        }

        public virtual bool CheckNextState(EAIStateEnum next)
        {
            return true;
        }

        public virtual bool CanChangeState(EAIStateEnum next)
        {
            return CheckNextState(next);
        }

        protected void PlayAni(string name, float speed, WrapMode wm)
        {
            aiCharacter.PlayAni(name, speed, wm);
        }

        protected void SetAni(string name, float speed, WrapMode wm)
        {
            aiCharacter.SetAni(name, speed, wm);
        }

        protected bool CheckAni(string name)
        {
            return aiCharacter.GetAttr().GetComponent<Animation>().GetClip(name) != null;
        }
        protected void SetAttrState(CharacterState s)
        {
            aiCharacter.GetAttr()._characterState = s;
        }


        NPCAttribute attr;

        protected NPCAttribute GetAttr()
        {
            if (attr == null)
            {
                attr = aiCharacter.GetAttr();  //返回attr值
            }
            return attr;
        }
        protected MyAnimationEvent GetEvent()
        {
            return GetAttr().GetComponent<MyAnimationEvent>();
        }

        //只检测是否受到攻击 不 显示状态变化
        bool CheckOnHit()
        {
            return false;
        }

        protected bool CheckBaseEvent()
        {

            return false;
        }

        //TODO:检测一些事件 然后进行状态切换
        //获得对应注册哪些事件， 就检测哪些事件？
        //只有状态切换成功才回 CheckEvent 返回true
        protected bool CheckEvent()
        {
            if (CheckBaseEvent())
            {
                return true;
            }
            var msg = GetEvent().NextMsg();
            if (msg != null)
            {
                if (msg.type == MyAnimationEvent.MsgType.IDLE)
                {
                    return aiCharacter.ChangeState(EAIStateEnum.eIDLE);
                }
            }
            return false;
        }


    }


    public class IdleState : AIState
    {
        public IdleState()
        {
            type = EAIStateEnum.eIDLE;
        }

    }
    public class MoveState : AIState
    {
        public MoveState()
        {
            type = EAIStateEnum.eMOVE;
        }

    }
}



