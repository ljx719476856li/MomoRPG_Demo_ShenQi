using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    /// <summary>
    /// _cusor单列
    /// </summary>
    private static CursorManager _cursor;
    public static CursorManager Cusor
    {
        get
        {
            if(_cursor == null)
            {
                var go = new GameObject();
                _cursor = go.AddComponent<CursorManager>();
                DontDestroyOnLoad(go);
                go.name = "CursorManager";
            }
            return _cursor;
        }
    }

    float m_h = 0.0f;
    float m_v = 0.0f;
    public float H
    {
        get
        {
            return m_h;
        }
    }
    public float V
    {
        get
        {
            return m_v;
        }

    }


    private void Update()
    {
        Debug.Log("赋值前 " + m_v + m_h);
        m_v = Input.GetAxisRaw("Vertical");
        m_h = Input.GetAxisRaw("Horizontal");
        Debug.Log("赋值后 " + m_v + m_h);
    }
}
