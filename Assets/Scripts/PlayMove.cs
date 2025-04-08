using System.Collections;
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

    private int jumpCount = 0;
    public int maxJumpCount = 2;

    [SerializeField]
    private ParticleSystem hitEffect;


    //[Header("Obsctacle")]
    //public float knockbackForce = 10f;
    //public float knockbackUpwardForce = 2f;
    //public float knockbackDuration = 0.2f;
    //private bool isKnockedBack = false;





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

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount<maxJumpCount)
        {
            PlayerAudio.PlayOneShot(JumpClip);
            rb.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
            isGround = false;
            jumpCount++;

            
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
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle" )
        {
            other.gameObject.SetActive(false);
            hitEffect.Play();
            camShake.Shake();
            //StartCoroutine(Knockback());
        }

        else if (other.gameObject.tag == "Coin")
        {
            PlayerAudio.PlayOneShot(CoinClip);
        }

    }

    //private IEnumerator Knockback()
    //{
    //    isKnockedBack = true;

    //    // 현재 방향과 반대 방향으로 힘을 가함
    //    Vector3 knockbackDirection = (-transform.forward + Vector3.up * knockbackUpwardForce).normalized;
    //    rb.angularVelocity = Vector3.zero; // 기존 속도 제거
    //    rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

    //    yield return new WaitForSeconds(knockbackDuration);

    //    isKnockedBack = false;
    //}
}
