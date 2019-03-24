using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色所有操作 SimpleMove CharacterController 的代码都要在Physics里面进行 确保同一帧只调用一次
/// </summary>
public class PhysicComponent : MonoBehaviour
{
    private static PhysicComponent _physicComponent;
    public static PhysicComponent PHC
    {
        get
        {
            return _physicComponent;
        }
    }


    float Gravity = 20;

    Vector3 moveValue = Vector3.zero;
    Vector3 motionValue = Vector3.zero;
    //bool skillMoveFade = false;
    public float GetLastSpeed()
    {
        return lastSpeed;
    }
    float lastSpeed = 0;

    private CharacterController characterController;


    /// <summary>
    /// 从当前方向旋转到特定方向 
    /// </summary>
    /// <param name="dir">Dir.</param>
    public void TurnTo(Vector3 moveDirection)
    {
        var y1 = transform.eulerAngles.y;
        var y2 = Quaternion.LookRotation(moveDirection).eulerAngles.y;
        var y3 = Mathf.LerpAngle(y1, y2, 0.5f);
        transform.rotation = Quaternion.Euler(new Vector3(0, y3, 0));
    }
    public void TurnToImmediately(Vector3 moveDirection)
    {
        var y2 = Quaternion.LookRotation(moveDirection).eulerAngles.y;
        transform.rotation = Quaternion.Euler(new Vector3(0, y2, 0));
    }
    //键盘操控玩家移动
    public void MoveSpeed(Vector3 moveSpeed)
    {
        //if (!skillMove)
        //{
        moveValue = moveSpeed;
        moveValue.y -= Gravity;
        //}
    }

     void Awake()
    {
        _physicComponent = this;
    }
    void Start()
    {
        characterController = transform.GetComponent<CharacterController>();
    }

    void LateUpdate() 
    {
        characterController.Move(moveValue * Time.deltaTime);
        moveValue = new Vector3(0, -Gravity, 0);
        //characterController.Move(motionValue);
        //Debug.Log("motionValue" + motionValue);
    }
}
