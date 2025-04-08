using UnityEngine;


public class PlayMove : MonoBehaviour
{
    [SerializeField]
    private float normalSpeed;
    [SerializeField]
    private float JumpSpeed;

    private bool isGround = false;
    private Rigidbody rb;
    private Animator anim;

    [SerializeField]
    private CamShake camShake;


    [Header("Slide")]
    [SerializeField]
    public float slideBoost = 3f;
    public float slideDuration = 1f;       // 슬라이딩 지속 시간
    private bool isSliding = false;
    private float slideTimer = 0f;

    private float currentSpeed;

    private AudioSource PlayerAudio;

    [SerializeField]
    private AudioClip JumpClip;
    [SerializeField]
    private AudioClip CoinClip;



    private void Start()
    {
        PlayerAudio = this.GetComponent<AudioSource>();
        currentSpeed = normalSpeed;
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        this.transform.Translate(0, 0, currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            PlayerAudio.PlayOneShot(JumpClip);
            rb.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
            isGround = false;
        }

        if(!isSliding && Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("Slide");
            isSliding = true;
            currentSpeed += slideBoost;
            slideTimer = slideDuration;
        }

        if (isSliding)
        {
            slideTimer -= Time.deltaTime;

            if (slideTimer <= 0f)
            {
                currentSpeed = normalSpeed;
                isSliding = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            camShake.Shake();
        }

        else if (other.gameObject.tag == "Coin")
        {
            PlayerAudio.PlayOneShot(CoinClip);
        }

    }
}
