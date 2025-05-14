using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float moveSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    private Vector3 moveDirection;
    private bool isOnStair = false;
    private bool isClimbing = false; 
    private Rigidbody rb;

    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
     
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (moveDirection.magnitude > 0.01f)
        {
            animator.SetBool("IsWalking", true);

            if (moveDirection.x < 0)
                spriteRenderer.flipX = false;
            else if (moveDirection.x > 0)
                spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

      
        if (!isOnStair)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

       
        if (isOnStair)
        {
            float verticalInput = 0f;

            if (Input.GetKey(KeyCode.W)) 
                verticalInput = 1f;
            else if (Input.GetKey(KeyCode.S)) 
                verticalInput = -1f;

          
            if (verticalInput != 0f)
            {
                transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);
                animator.SetBool("IsClimbing", true); 
                rb.useGravity = false;
                isClimbing = true;
            }
        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stair"))
        {
            isOnStair = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stair"))
        {
            isOnStair = false;
            animator.SetBool("IsClimbing", false); 
            rb.useGravity = true;
        }
    }


   
}
