using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float laneWidth = 3f;
    public float laneSwitchSpeed = 10f;
    public float jumpForce = 8f;

    private Rigidbody rb;
    private int currentLane = 0;
    private bool isGrounded = true;
    private float targetX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetX = 0f;
    }

    void Update()
    {
        if (!GameManager.Instance.isPlaying) return;
        transform.position += Vector3.forward * GameManager.Instance.currentSpeed * Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > -1) currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < 1) currentLane++;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        targetX = currentLane * laneWidth;
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * laneSwitchSpeed);
        transform.position = pos;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (col.gameObject.CompareTag("Obstacle"))
            GameManager.Instance.GameOver();
    }
}