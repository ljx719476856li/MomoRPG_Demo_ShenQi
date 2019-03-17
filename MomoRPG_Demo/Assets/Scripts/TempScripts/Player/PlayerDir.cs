using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour
{
    //右键点击特性 预制体
    [SerializeField]
    private  GameObject m_effectRightClickPrefab;

    //是否处于移动的状态
    private bool m_isMoving = false;
    //目标位置
    private Vector3 m_targetPos;
    public Vector3 TargetPos { get { return m_targetPos; } }
    public float m_smothing = 6.8f;

    private PlayerMove m_playerMove; //控制人物移动的脚本对象  


    // Start is called before the first frame update
    void Start()
    {
        m_targetPos = transform.position;
        m_playerMove = transform.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log("m_horizontal: " + m_horizontal + " m_vertical: " + m_vertical);

        //TODO 防止UI触发移动
        if (Input.GetMouseButtonDown(1))
        {
            //获取camera的近截面到屏幕中当前鼠标的像素坐标的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //获取碰撞信息
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            //Debug.Log("isCollider"+isCollider);
            //检测是否鼠标触碰到物体，且物体是地面
            if (isCollider && hitInfo.collider.tag == Tags.GROUND)
            {
                m_isMoving = true;
                //实例化特性
                ShowClickEffect(hitInfo.point);
                LookAtTarget(m_targetPos);

            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            m_isMoving = false;
            LookAtTarget(m_targetPos);

        }

        //鼠标未松开
        if (m_isMoving)
        {
            //获取camera的近截面到屏幕中当前鼠标的像素坐标的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //获取碰撞信息
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.GROUND)
            {
                LookAtTarget(hitInfo.point);

            }
        }
        //TODO 人物移动中途被地形改变方向时，应该重新调整哈朝向
        else
        {
            //TODO 人物移动中途被地形改变方向时，应该重新调整哈朝向
            if (m_playerMove.IsMoving)
            {
                //Debug.Log("2 y axis rotation: " + transform.rotation);
                LookAtTarget(m_targetPos);

                //Debug.Log("m_targetPos:" + m_targetPos);
                //Debug.Log("3 y axis rotation: " + transform.rotation);
            }
        }

    }

    //实例化特性
    private void ShowClickEffect(Vector3 hitPos)
    {
        //考虑特效中圆盘会与地面重合
        hitPos = new Vector3(hitPos.x, hitPos.y + 1.0f, hitPos.z);
        GameObject.Instantiate(m_effectRightClickPrefab, hitPos, Quaternion.identity);
    }

    public void LookAtTarget(Vector3 hitPos)
    {
        m_targetPos = hitPos;
        m_targetPos = new Vector3(m_targetPos.x, transform.position.y, m_targetPos.z);
        this.transform.LookAt(m_targetPos);
    }
}
