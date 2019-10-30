using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10f;
    Vector3 forward, right;
    Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("ISOHorizontal"), 0, Input.GetAxis("ISOVertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("ISOHorizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("ISOVertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.2f)
        {
            animator.SetFloat("Blend", 1f, .2f, Time.deltaTime);
        }
    }
}
