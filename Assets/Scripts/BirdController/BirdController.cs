using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public static BirdController instance; //dong bo giua cac bien va cac script
    public float bounceForce; //do nhay 
    public float flag = 0;
    public int score = 0;
    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField] //ren file audioSource unity
    private AudioSource audioSource;

    [SerializeField] 
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive; //con song
    private bool didFlap; // die
    private GameObject spawner;

	// Use this for initialization
    void Awake () {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }
    void _MakeInstance () {
        if (instance == null){
            instance = this;
        }
    }
    void FixedUpdate()
    {
        _BirdMoveMent();
    }
    void _BirdMoveMent(){
        if (isAlive == true){
            if(didFlap == true){
                didFlap = false; 
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce); //nhan chuot trai se nhay len
                audioSource.PlayOneShot(flyClip);
            }
        }
        //if (Input.GetMouseButtonDown(0)){
        //    myBody.velocity = new Vector2(myBody.velocity.x, bounceForce); //nhan chuot trai se nhay len
        //    audioSource.PlayOneShot(flyClip);
        //}
        if (myBody.velocity.y >0){
            float engel = 0;
            engel = Mathf.Lerp(0, 99, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, engel);
        }
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y <0){
            float engel = 0;
            engel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, engel);
        }
    }
    public void FlapButton(){
        didFlap = true;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder") ; //set va cham pipe holder
        audioSource.PlayOneShot(pingClip);
        score++;
    }
    private void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground"){
            flag = 1;
            if(isAlive){
                isAlive = false; //click k nhay
                Destroy(spawner); //ko sinh ra spawner
                audioSource.PlayOneShot(diedClip); //audio died
                anim.SetTrigger("Died");  
            }
                  
        }
        
    }

     





}
