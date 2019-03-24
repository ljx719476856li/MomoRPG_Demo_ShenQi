using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class HumanMove : MoveState
    {
        public float moveSpeed = 0;
        public float walkSpeed = 8.0f;
        public float rotateSpeed = 500;
        public float speedSmoothing = 10;

        static HumanMove _humanMove;
        public static HumanMove HmMove
        {
            get
            {
                if (_humanMove == null)
                    _humanMove = new HumanMove();
                return _humanMove;
            }

        }

        /// <summary>
        /// 进入move状态
        /// </summary>
        public override void EnterState()
        {
            Debug.Log("Enter Player Move State");
            base.EnterState();
            SetAttrState(CharacterState.Running);
            aiCharacter.SetRun();
        }

        //TODO 并未返回IDLE状态
        public override IEnumerator RunLogic()
        {
            var playerMove = GetAttr().GetComponent<MoveController>();

            var physics = playerMove.GetComponent<PhysicComponent>();


            Debug.Log(quit);
            while (!quit)
            {
                if (CheckEvent())
                    yield break;

                float v = 0.0f;
                float h = 0.0f;
                if (CursorManager.Cusor.H != 0 || CursorManager.Cusor.V != 0)
                {
                    v = CursorManager.Cusor.V;
                    h = CursorManager.Cusor.H;
                }

                bool isMoving =  Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f ;
                isMoving = Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1;
                Debug.Log("h: " + h + "v: " + v);
                if (!isMoving)
                {
                    aiCharacter.ChangeState(EAIStateEnum.eIDLE); //移动状态 → 闲置
                    break;
                }

                Rotating(v, h);
                yield return null;
            }

        }

        /// <summary>
        /// 处理模型的平滑旋转 + 移动
        /// </summary>
        /// <param name="v"></param>
        /// <param name="h"></param>
        private void Rotating(float v, float h)
        {
            var playerMove = GetAttr().GetComponent<MoveController>();
            var camRight = playerMove.camRight;
            var camForward = playerMove.camForward;

            Vector3 moveDirection = Vector3.zero;

            Vector3 targetDirection = h * camRight +v * camForward;

            moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, 500.0f * Mathf.Deg2Rad * Time.deltaTime, 1000);
            moveDirection = moveDirection.normalized;


            var curSmooth = /*speedSmoothing*/10.0f * Time.deltaTime;
            var targetSpeed = Mathf.Min(targetDirection.magnitude, 1.0f);
            targetSpeed *= HumanMove.HmMove.walkSpeed;
            HumanMove.HmMove.moveSpeed = Mathf.Lerp(HumanMove.HmMove.moveSpeed, targetSpeed, curSmooth);

            var movement = moveDirection * HumanMove.HmMove.moveSpeed;

            PhysicComponent.PHC.MoveSpeed(movement);
            PhysicComponent.PHC.TurnTo(moveDirection);

        }
    }
}


