using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Vector3 camRight;
    public Vector3 camForward;

    // Start is called before the first frame update
    void Start()
    {
        camRight = Camera.main.transform.TransformDirection(Vector3.right);
        camForward = Camera.main.transform.TransformDirection(Vector3.forward);
        camRight.y = 0;
        camForward.y = 0;
        camRight.Normalize();
        camForward.Normalize();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
