using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 720f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Lecture des touches
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");     // W/S

        // Avancer/reculer selon l’orientation du joueur
        Vector3 forwardMove = transform.forward * vertical;
        // Strafe gauche/droite
        Vector3 rightMove = transform.right * horizontal;

        Vector3 moveDir = (forwardMove + rightMove).normalized;

        if (moveDir.magnitude > 0.01f)
        {
            // Rotation vers la direction combinée
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Déplacement
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            // Animation
            if (animator != null)
                animator.SetFloat("MoveAmount", moveDir.magnitude);
        }
        else
        {
            if (animator != null)
                animator.SetFloat("MoveAmount", 0f);
        }
    }
}
