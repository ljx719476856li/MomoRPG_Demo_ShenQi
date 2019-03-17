using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationPlay
{
    Moving,
    Idle
}

public class PlayerMove : MonoBehaviour
{
    public float m_speed = 1.0f;
    public AnimationPlay state = AnimationPlay.Idle;

    private bool m_isMoving = false;
    public bool IsMoving { get { return m_isMoving; } }

    private PlayerDir m_dir;
    private CharacterController m_controller;

    // Start is called before the first frame update
    void Start()
    {
        m_dir = this.GetComponent<PlayerDir>();
        m_controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector3.Distance(m_dir.TargetPos, this.transform.position); //鼠标点击位置到人物当前位置，间的距离

        if (distance > 0.333f)
        {
            state = AnimationPlay.Moving;
            m_isMoving = true;
            m_controller.SimpleMove(transform.forward * m_speed);
        }
        else
        {
            distance = 0.0f;
            state = AnimationPlay.Idle;
            m_isMoving = false;
            //m_dir.LookAtTarget(m_dir.TargetPos);
        }
    }


}
