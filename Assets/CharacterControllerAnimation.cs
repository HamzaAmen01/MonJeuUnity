using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterControllerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;

    private Vector3 inputDir = Vector3.zero;
    private bool jumpRequested = false;
    private float currentSpeed = 0f;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDir = new Vector3(h, 0f, v).normalized;

        // Update animator speed (0=idle, 1=walk, >3=run)
        currentSpeed = inputDir.magnitude * moveSpeed;
        animator.SetFloat("Speed", currentSpeed);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            animator.SetTrigger("Jump");
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if (inputDir.magnitude >= 0.1f)
        {
            Vector3 camForward = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * inputDir;
            Vector3 targetPos = rb.position + camForward * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPos);

            Quaternion targetRot = Quaternion.LookRotation(camForward);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);
        }

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
