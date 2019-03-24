using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSmoothing = 5f;
    public float rayLength = 100f;
    public Rigidbody rigidbody;

    private int floorMask;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
            TurningWithMouse();
    }

    void TurningWithMouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, rayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(playerToMouse, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
            rigidbody.MoveRotation(newRotation);

        }
    }
}