using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class AnimationBehavior : MonoBehaviour
{
    SceneController sceneController;
    public Animator anim;
    PlayerController myControl;
    SkeletonController skeletonController;
    ArcherController archerController;
    KnightController knightController;
    MageController mageController;
    BossController bossController;
    BoonStats boonStats;

    public Rigidbody myRig;
    public GameObject SwordRender;
    public GameObject AxeRender;
    public GameObject MaceRender;
    public GameObject BowRender;
    public GameObject WandRender;
    public GameObject StaffRender;
    public GameObject myPrefab;
    public GameObject myPrefabice;
    public GameObject myPrefabArrow;

    public GameObject pressEUI;
    public GameObject pressTUI;
    public GameObject panel;
    public Camera MainCamera;

    public AudioSource source;
    public AudioClip bow;
    public AudioClip swing;
    public AudioClip magicFire;
    public AudioClip magicIce;
    public AudioClip Hit;

    public float speed = 5.0f;
    public float maxspeed = 10.0f;
    public float reset=0.0f;
    float damagereset=0;
    bool canJump = true;
    public bool CollisionUnder = false;
    public bool melee=true;
    public bool magic = false;
    public bool Bow = true;
    public bool fire = false;
    public bool ice = false;
    public float damage;
    public float health;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookspeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookspeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 1.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 1.0f;

    public Camera playercamera;

    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sceneController= GetComponent<SceneController>();
        myControl = new PlayerController();
        boonStats = gameObject.AddComponent<BoonStats>();
        source = GetComponent<AudioSource>();
        damage = 15;
        pressEUI = GameObject.Find("Blessing_CurseCanvas");
        health = myControl.Player_Max_HP;
        SwordRender = GameObject.Find("SwordRender");
        AxeRender = GameObject.Find("AxeRender");
        MaceRender = GameObject.Find("MaceRender");
        BowRender = GameObject.Find("BowRender");
        WandRender = GameObject.Find("WandRender");
        StaffRender = GameObject.Find("StaffRender");
        

        playercamera.GetComponentInChildren<Camera>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        SwordRender.SetActive(true);
        AxeRender.SetActive(false);
        MaceRender.SetActive(false);
        BowRender.SetActive(false);
        WandRender.SetActive(false);
        StaffRender.SetActive(false);
        anim.SetBool("Bow", false);
        anim.SetBool("Magic", false);

        pressEUI.SetActive(false);





    }
    private void OnTriggerStay(Collider other)
    {
       
        Vector3 CollisonPoint = other.ClosestPoint(myRig.position);
        if ((other.gameObject.tag == "Floor") && (CollisonPoint - myRig.position).normalized.y < .8)
        {
            canJump = true;
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Boon")
        {
            Debug.Log("Player Collided with Boon");
            pressEUI.SetActive(true);
            boonStats.getBlessing();
            boonStats.getCurse();
            //MainCamera.GetComponentInChildren<Camera>();
           // Cursor.lockState = CursorLockMode.Confined;
           // Cursor.visible = true;
            Debug.Log("Boon");
            
            Debug.Log("UI");
        }
        if (other.gameObject.tag == "SkeletonWeapon" && damagereset<=0)
        {
            Debug.Log("Player Hit by Skeleton");
            skeletonController = GameObject.Find("Skeleton").GetComponent<SkeletonController>();
            if (skeletonController.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= skeletonController.Enemydamage;
                Debug.Log("Player took "+skeletonController.Enemydamage);
                damagereset = 1;
            }
            
        }
        if (other.gameObject.tag == "FireBall" && damagereset <= 0)
        {
            Debug.Log("Player Hit by Mage");
            mageController = GameObject.Find("Mage").GetComponent<MageController>();

                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= mageController.Enemydamage;
                Debug.Log("Player took " + mageController.Enemydamage);
                damagereset = 1;


        }
        if (other.gameObject.tag == "Arrow" && damagereset <= 0)
        {
            Debug.Log("Player Hit by Archer");
            archerController = GameObject.Find("Archer").GetComponent<ArcherController>();
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= archerController.Enemydamage;
                Debug.Log("Player took " + archerController.Enemydamage);
                damagereset = 1;

        }
        if (other.gameObject.tag == "KnightWeapon" && damagereset <= 0)
        {
            knightController = GameObject.Find("Knight").GetComponent<KnightController>();
            
                Debug.Log("Player Hit by Knight");
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= knightController.Enemydamage;
                Debug.Log("Player took " + knightController.Enemydamage);
                damagereset = 1;


        }
        if (other.gameObject.tag == "BossWeapon" && damagereset <= 0)
        {
                Debug.Log("Player Hit by Boss");
                bossController = GameObject.Find("Boss").GetComponent<BossController>();
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= bossController.Enemydamage;
                Debug.Log("Player took " + bossController.Enemydamage);
                damagereset = 1;


        }


    }
    private void die()
    {
        if (myControl.Player_Min_HP<=0) 
        {
            anim.SetBool("Death", true);
            myControl.Player_Min_HP = 0;
            Debug.Log("Player Died");
        }
    }

    private void HandleCameraLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookspeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playercamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X")*lookspeedX,0);
    }
    // Update is called once per frame
    void Update()
    {
        die();
        myControl.ManaRegen();
        HandleCameraLook();
        CollisionUnder = false;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
       // Debug.Log("The Direction variable = "+ h);
        RaycastHit info;
        if (Physics.Raycast(this.transform.position, this.transform.up * -1, out info))
        {
            if (info.distance < 0.50)
            {
                CollisionUnder = true;
            }
        }
        if (reset>0.0f)
        {
            reset-= Time.deltaTime;
        }
        if (damagereset > 0.0f)
        {
            damagereset -= Time.deltaTime;
        }
        if (myControl.Player_Min_HP < 0)
        {
            anim.SetBool("Death", true);
            myRig.constraints = RigidbodyConstraints.FreezeAll;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(melee) 
            {
                anim.SetBool("Bow",false);
                anim.SetBool("Magic", false);
                anim.SetTrigger("Attack");
                myRig.velocity = Vector3.zero+ new Vector3(0, myRig.velocity.y, 0);
                source.clip = swing;
                source.Play();
            }
            if(melee!=true) 
            {
                if (Bow && myControl.ammoCount > 0)
                {
                    anim.SetBool("Bow", true);
                    anim.SetTrigger("Attack");
                    myRig.velocity = Vector3.zero + new Vector3(0, myRig.velocity.y, 0);
                    GameObject p = Instantiate(myPrefabArrow, this.transform.localPosition, transform.rotation);
                    Rigidbody pRig = p.GetComponent<Rigidbody>();
                    pRig.position = myRig.transform.position -myRig.transform.right *0.0f + myRig.transform.up * 1.2f + myRig.transform.forward * 1.5f;
                    p.GetComponent<Rigidbody>().velocity = myRig.transform.forward;
                    myControl.ammoCount -= 1;
                    source.clip = bow;
                    source.Play();
                }
                if (reset <= 0)
                {
                    if (magic && fire && myControl.Player_Min_MP >0)
                    {
                        anim.SetBool("Magic", true);
                        anim.SetTrigger("Attack");
                        myRig.velocity = Vector3.zero + new Vector3(0, myRig.velocity.y, 0);
                        GameObject p = Instantiate(myPrefab, this.transform.localPosition, transform.rotation);
                        Rigidbody pRig = p.GetComponent<Rigidbody>();
                        pRig.position = myRig.transform.position + myRig.transform.right * 5.0f + myRig.transform.up * 1.2f + myRig.transform.forward * 1.5f;
                        p.GetComponent<Rigidbody>().velocity = myRig.transform.forward;
                        source.clip = magicFire;
                        source.Play();
                        myControl.Player_Min_MP -= 5;
                        reset = 5;
                    }
                    else
                    if (magic && ice && myControl.Player_Min_MP > 0)
                    {
                        anim.SetBool("Magic", true);
                        anim.SetTrigger("Attack");
                        myRig.velocity = Vector3.zero + new Vector3(0, myRig.velocity.y, 0);
                        GameObject p = Instantiate(myPrefabice, this.transform.localPosition, transform.rotation);
                        Rigidbody pRig = p.GetComponent<Rigidbody>();
                        pRig.position = myRig.transform.position + myRig.transform.right * 5.0f + myRig.transform.up * 1.2f + myRig.transform.forward * 1.5f;
                        p.GetComponent<Rigidbody>().velocity = myRig.transform.forward;
                        source.clip = magicIce;
                        source.Play();
                        reset = 5;
                        myControl.Player_Min_MP -= 5;
                    }
                }
                else 
                {
                    Debug.Log("Magic not ready");
                }
            }
            

        }

        if (Input.GetMouseButtonDown(1))
        {
            SwordRender.SetActive(false);
            AxeRender.SetActive(false);
            MaceRender.SetActive(false);
            BowRender.SetActive(false);
            WandRender.SetActive(false);
            StaffRender.SetActive(true);
            ice = true;
            fire = false;
            melee = false;
            magic = true;
            Bow = false;
            damage = 150;

        }
        if (Input.GetAxisRaw("Jump") > 0 && canJump == true)
        {
            canJump = false;
            myRig.velocity = new Vector3(myRig.velocity.x, 5, 0);
            anim.SetBool("Jump", true);
        }
        if (myRig.velocity.y < -1)
        {
            anim.SetBool("Fall", true);
        }
        else 
        if (myRig.velocity.y>=1 || CollisionUnder == true)
        {
            anim.SetBool("Fall", false);
        }
       
            if (v > 0.15)
            {
                myRig.velocity = transform.forward * speed + new Vector3(0, myRig.velocity.y, 0);
            }
            if (v < -0.15)
            {
                myRig.velocity = -transform.forward * speed + new Vector3(0, myRig.velocity.y, 0);
            }
            if (h > 0.15)
            {
                myRig.velocity = transform.right *speed+ new Vector3(0, myRig.velocity.y, 0);
            }
            if (h < -0.15)
            {
                myRig.velocity = -transform.right *speed+ new Vector3(0, myRig.velocity.y, 0);
            }
      
    }
   
}
