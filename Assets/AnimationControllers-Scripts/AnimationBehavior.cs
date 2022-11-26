using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    public float speed = 5.0f;
    public float maxspeed = 10.0f;
    public float reset=0.0f;
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
        damage = 15;
        pressEUI = GameObject.Find("Blessing_CurseCanvas"); ;
        pressEUI.SetActive(false);

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
            Debug.Log("Boon");
            //pressEUI.SetActive(true);
            Debug.Log("UI");
        }
        if (other.gameObject.tag == "SkeletonWeapon")
        {
            Debug.Log("Player Hit by Skeleton");
            skeletonController = GameObject.Find("Skeleton").GetComponent<SkeletonController>();
            if (skeletonController.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            { 
                myControl.Player_Min_HP -= skeletonController.Enemydamage;
                Debug.Log("Player took "+skeletonController.Enemydamage);
            }
            
        }
        if (other.gameObject.tag == "FireBall")
        {
            Debug.Log("Player Hit by Mage");
            mageController = GameObject.Find("Mage").GetComponent<MageController>();
            
            
                myControl.Player_Min_HP -= mageController.Enemydamage;
                Debug.Log("Player took " + mageController.Enemydamage);
            
            
        }
        if (other.gameObject.tag == "Arrow")
        {
            Debug.Log("Player Hit by Archer");
            archerController = GameObject.Find("Archer").GetComponent<ArcherController>();
            
            
                myControl.Player_Min_HP -= archerController.Enemydamage;
                Debug.Log("Player took " + archerController.Enemydamage);
            
            
        }
        if (other.gameObject.tag == "KnightWeapon")
        {
            Debug.Log("Player Hit by Knight");
            knightController = GameObject.Find("Knight").GetComponent<KnightController>();
            if (knightController.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                myControl.Player_Min_HP -= knightController.Enemydamage;
                Debug.Log("Player took " + knightController.Enemydamage);
            }
            
        }
        if (other.gameObject.tag == "BossWeapon")
        {
            Debug.Log("Player Hit by Boss");
            bossController = GameObject.Find("Boss").GetComponent<BossController>();
                myControl.Player_Min_HP -= bossController.Enemydamage;
                Debug.Log("Player took " + bossController.Enemydamage);
            
            
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
        health = myControl.Player_Min_HP;
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
