using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorToCharacter : MonoBehaviour
{
    private Animator m_animator;
    private AnimatorStateInfo m_animState;
    private float moveSpeed = 5.0f;
    private const string m_idleState = "Idle";
    private const string m_attack1State = "Attack1";
    private const string m_attack2State = "Attack2";
    private const string m_attack3State = "Attack3";
    private int m_hitCount = 0;

    public float smothing = 1.5f;


    void Start()
    {
        m_animator = this.GetComponent<Animator>();
        m_animator.SetFloat("moveSpeed", moveSpeed);

        m_animator.SetBool("isMoving", false);
        m_animator.SetBool("isAttack", false);
        m_animator.SetBool("isAttackBack", false);
        m_animator.SetFloat("moveSpeed", 5.0f);
    }

    void Update()
    {
        m_animState = m_animator.GetCurrentAnimatorStateInfo(0);
        if(!m_animState.IsName(m_idleState) && m_animState.normalizedTime > 1.0f)
        {
            m_animator.SetInteger("attack", 0);
            m_hitCount = 0;
        }
        if (/*Input.GetKey(KeyCode.W)*/Input.GetMouseButton(1))
        {
            moveSpeed += Time.deltaTime * smothing;
            Debug.Log(moveSpeed);
            m_animator.SetBool("isMoving", true);
            m_animator.SetFloat("moveSpeed", moveSpeed);
            if (moveSpeed >= 10.0f)
                m_animator.SetFloat("moveSpeed", 10.01f);

        }
        if (/*Input.GetKeyUp(KeyCode.W)*/Input.GetMouseButtonUp(1))
        {
            moveSpeed = 5.0f;
            m_animator.SetFloat("moveSpeed", 5.0f);
            m_animator.SetBool("isMoving", false);

        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("get mouse button");
            //TODO attack动画
            Attack();
        }
    }

    void Attack()
    {
        if(m_animState.IsName(m_idleState) && m_hitCount == 0 && m_animState.normalizedTime > 0.50f)
        {
            m_animator.SetInteger("attack", 1);
            m_hitCount = 1;
            Debug.Log("1 combat");
        }
        else if(m_animState.IsName(m_attack1State) && m_hitCount == 1 && m_animState.normalizedTime > 0.65f)
        {
            m_animator.SetInteger("attack", 2);
            m_hitCount = 2;
            Debug.Log("2 combat");
        }
        else if (m_animState.IsName(m_attack2State) && m_hitCount == 2 && m_animState.normalizedTime > 0.70f)
        {
            m_animator.SetInteger("attack", 3);
            m_hitCount = 3;
            Debug.Log("3 combat");
        }
    }
}