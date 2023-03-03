using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForse = 400f;
    public TextMeshProUGUI pointsText;

    public AudioClip jumpSound;
    AudioSource AS;

    Rigidbody rb; //referenssi caragtercontroller komponentti
    Vector3 playerInput;
    Animator anim;

    int points = 0; //pelaajan syöteen tallenus 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim= GetComponentInChildren<Animator>();
        AS= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   //haetaan käyttäjän horizontal syöteen aja d nuoli tai ad
        playerInput.x = Input.GetAxis("Horizontal") *speed;
        playerInput.z = Input.GetAxis("Vertical") * speed; //w/a tai nuoli ylös/alas
        playerInput.y = rb.velocity.y;

        //jos pelaaja painaa välilyöntii
        if(rb.velocity.y > -0.05f && rb.velocity.y <0.05f) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //lisätää hyppy voimaa ylöspäin kerrotuna hypyn vpoiman arvolla 
                rb.AddForce(Vector3.up * jumpForse);
                AS.PlayOneShot(jumpSound, 1);
                anim.Play("jump", 0);
            }
        }

        anim.SetFloat("velosity", playerInput.magnitude);
        
    }
    private void FixedUpdate()
    {
        rb.velocity= playerInput;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "coin")
        {
            Destroy(other.gameObject);
            points++;
            pointsText.text = "points: " + points;
        }
    }
}