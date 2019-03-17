using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject m_player;
    private Vector3 m_offsetPos; //偏移值
    private float m_distance = 0.0f;
    private bool m_isRotation = false;

    /// <summary>
    ///拉近拉远速度
    /// </summary>
    public float m_scrollSpeed = 6.0f;

    /// <summary>
    ///旋转速度
    /// </summary>
    public float m_rotateSpeed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        transform.LookAt(m_player.transform.position);

        m_offsetPos = transform.position - m_player.transform.position; //更新偏移值, 镜头随时跟随玩家
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = m_offsetPos + m_player.transform.position; //更新镜头位置
        RotateView();
        ScrollView();
    }

    /// <summary>
    /// 鼠标滚轴控制拉近或拉远
    /// </summary>
    private void ScrollView()
    {
        //print(Input.GetAxis("Mouse ScrollWheel"));
        m_distance = m_offsetPos.magnitude;
        m_distance -= Input.GetAxis("Mouse ScrollWheel") * m_scrollSpeed;
        //print("Distance: " + distance);
        m_distance = Mathf.Clamp(m_distance, 2.0f, 18.0f);
        m_offsetPos = m_offsetPos.normalized * m_distance; //更新偏移值
    }

    /// <summary>
    /// 鼠标控制水平或垂直旋转
    /// </summary>
    private void RotateView()
    {
        //Input.GetAxis("Mouse X"); //得到鼠标水平方向的滑动
        //Input.GetAxis("Mouse Y"); //得到鼠标垂直方向的滑动
        if (Input.GetMouseButtonDown(0) /*&& !(PlayerDir.IsTouchedUI())*/)
        {
            m_isRotation = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_isRotation = false;
        }

        if (m_isRotation)
        {
            transform.RotateAround(m_player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * m_rotateSpeed);//水平


            Vector3 originalPos = transform.position;
            Quaternion originalRotate = transform.rotation;
            transform.RotateAround(m_player.transform.position, transform.right, -(Input.GetAxis("Mouse Y") * m_rotateSpeed)); //垂直

            float x = transform.eulerAngles.x;
            //当垂直旋转度数超过80°或者小于10°时，无法再次增大或者减小即失效，只可在(80°-30°)之间
            if (x > 80.0f || x < 10.0f)
            {
                transform.position = originalPos;
                transform.rotation = originalRotate;
            }
        }
        m_offsetPos = transform.position - m_player.transform.position; //更新偏移值
    }
}
