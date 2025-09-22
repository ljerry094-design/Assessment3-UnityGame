using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastMoveDir; 

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

   
        if (movement != Vector2.zero)
        {
            lastMoveDir = movement;
        }

       
        animator.SetFloat("MoveX", lastMoveDir.x);
        animator.SetFloat("MoveY", lastMoveDir.y);
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
