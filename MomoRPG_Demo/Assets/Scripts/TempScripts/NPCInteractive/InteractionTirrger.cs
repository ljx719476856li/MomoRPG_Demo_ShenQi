using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTirrger : MonoBehaviour
{
    bool m_isEnter = false;
    /// <summary>
    /// 判断物体与玩家之间距离
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            m_isEnter = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            m_isEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.PLAYER)
        {
            m_isEnter = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        //TODO “GuanLiYuan”此处用于调试
        GameObject.Find("GuanLiYuan").AddComponent<MeshCollider>();//获取物体

    }

    // Update is called once per frame
    void Update()
    {
        if (m_isEnter)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit mHit;
                //射线判断
                {
                    if (Physics.Raycast(mRay, out mHit))
                    {
                        Debug.Log(mHit.collider.tag);
                        if (mHit.collider.tag == Tags.NPC)
                        {
                            //TODO
                            Debug.Log("Triggered");
                        }
                    }
                }
            }
        }
    }
}

