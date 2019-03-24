using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class HumanIdle : IdleState
    {
        bool first = true;
        public override void EnterState()
        {
            base.EnterState();
            SetAttrState(CharacterState.Idle);
            aiCharacter.SetIdle();
            if (first)
                first = false;
        }

        public override IEnumerator RunLogic()
        {
            var playerMove = GetAttr().GetComponent<MoveController>();
           // var vcontroller = playerMove.vcontroller;
           while(!quit)
            {
                if (CheckEvent())
                    yield break;

                float v = 0;
                float h = 0;
                if (CursorManager.Cusor.H != 0 || CursorManager.Cusor.V != 0)
                {
                    v = CursorManager.Cusor.V;
                    h  = CursorManager.Cusor.H;
                }

                bool isMoving = ( Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f );
                Debug.Log("isMoving" + isMoving);
                if (isMoving)
                    aiCharacter.ChangeState(EAIStateEnum.eMOVE);  //闲置状态 → 移动状态

                yield return null;
            }
        }
    }
}

