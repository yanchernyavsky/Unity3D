using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public Rigidbody2D rb;
    public Camera Cam;
    Vector2 Movement;
    Vector2 MousePosition;

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        MousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * Speed * Time.fixedDeltaTime);
        Vector2 LookDirection = MousePosition - rb.position;
        float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
