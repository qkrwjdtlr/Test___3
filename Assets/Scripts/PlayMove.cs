using UnityEngine;

public class PlayMove : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float JumpSpeed;


    private bool isGround = false;
    private Rigidbody rb;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        this.transform.Translate(0, 0, Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
            isGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
