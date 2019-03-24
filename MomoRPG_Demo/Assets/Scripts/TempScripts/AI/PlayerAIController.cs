using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    [RequireComponent(typeof(MoveController))]
    [RequireComponent(typeof(PhysicComponent))]

    public class PlayerAIController : AIBase
    {
        //private MoveController moveController;
        private void Start()
        {
            attribute = GetComponent<NPCAttribute>();

            ai = new HumanCharacter();
            ai.attribute = attribute;
            ai.AddState(new HumanIdle());
            //ai.AddState(new TankMoveAndShoot());
            ai.AddState(new HumanMove());

            //moveController = transform.GetComponent<MoveController>();
            //首先的状态为空闲状态，该功能在animator controller中有
            ai.ChangeState(EAIStateEnum.eIDLE);
            //StartCoroutine(CheckFall());
            //StartCoroutine(CheckFallDead());
        }

        private void Update()
        {
            //if (CursorManager.Cusor.H != 0 || CursorManager.Cusor.V != 0)
                //Rotating();
        }

        //private void Rotating()
        //{
        //    Vector3 moveDirection = Vector3.zero;

        //    Vector3 targetDirection = CursorManager.Cusor.H * moveController.camRight + CursorManager.Cusor.V * moveController.camForward;

        //    moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, 500.0f * Mathf.Deg2Rad * Time.deltaTime, 1000);
        //    moveDirection = moveDirection.normalized;


        //    var curSmooth = /*speedSmoothing*/10.0f * Time.deltaTime;
        //    var targetSpeed = Mathf.Min(targetDirection.magnitude, 1.0f);
        //    targetSpeed *= HumanMove.HmMove.walkSpeed;
        //    HumanMove.HmMove.moveSpeed = Mathf.Lerp(HumanMove.HmMove.moveSpeed, targetSpeed, curSmooth);

        //    var movement = moveDirection * HumanMove.HmMove.moveSpeed;

        //    PhysicComponent.PHC.MoveSpeed(movement);
        //    PhysicComponent.PHC.TurnTo(moveDirection);
        //}
    }
}


