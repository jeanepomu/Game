using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;

    //Audio Personagem 
    public AudioSource audioSource;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip damageSound;
    public AudioClip dashSound;

    
    public Transform floorCollider;
    public Transform skin;

    public int comboNum;
    public float comboTime;
    public float dashTime;
    public float jumpForce;

    public LayerMask floorLayer;
    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
               
        }


        if(GetComponent<Character>().life <= 0)
        {
            rb.simulated = false;
            this.enabled = false;
        }

        dashTime = dashTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && dashTime > 1) 
        {
            audioSource.PlayOneShot(dashSound, 0.5f);

            dashTime = 0;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(skin.localScale.x * 650, 0));
        }

        comboTime = comboTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && comboTime > 0.5f)
        {
            comboNum++;
            if(comboNum > 2) 
            {
                comboNum = 1;
            }

            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);

            if(comboNum == 1)

            {
                audioSource.PlayOneShot(attack1Sound, 0.5f);
            }

            if (comboNum == 1)

            {
                audioSource.PlayOneShot(attack2Sound, 0.5f);
            }
        }
       if(comboTime >= 1)
        {
            comboNum = 0;
        }


       //Pulo do personagem 

        bool canJump = Physics2D.OverlapCircle(floorCollider.position, 1f, floorLayer);
        Debug.Log(canJump);
        Debug.Log(floorLayer.value);
        if (canJump && Input.GetButtonDown("Jump") && comboTime > 0.5f)
        {
            Debug.Log("executor");
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));
        }
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * 5.5f, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }

    }
    private void FixedUpdate()
    {
        if (dashTime > 0.5)
        {

            rb.velocity = vel;
        }
    }
}  