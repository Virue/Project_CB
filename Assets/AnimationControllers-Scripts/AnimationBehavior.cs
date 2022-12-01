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
    public BoonStats boonStats;
    PlayerStats stats;

    public bool boss = true;

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
    bool weapon1;
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
    public float basedamage;
    public float damage;
    public float health;

    public float doubleStrike;
    public float burn;
    public float slow;

    public bool boonApplied;

    public float enemyHealthBuff;
    public float enemyDamage;

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
        sceneController= GameObject.Find("SceneController").GetComponent<SceneController>();
        stats = GameObject.Find("HUD").GetComponent<PlayerStats>();
        myControl = new PlayerController();
        boonStats = gameObject.AddComponent<BoonStats>();
        boonStats.gameObject.GetComponent<BoonStats>();
        SetStats();
        source = GetComponent<AudioSource>();
        damage = (18 + myControl.Player_Damage) + ((18 + myControl.Player_Damage) * (myControl.Player_Vuln / 100)); ;
        //pressEUI = GameObject.Find("Blessing_CurseCanvas");
        health = myControl.Player_Max_HP;
        SwordRender = GameObject.Find("SwordRender");
        AxeRender = GameObject.Find("AxeRender");
        MaceRender = GameObject.Find("MaceRender");
        BowRender = GameObject.Find("BowRender");
        WandRender = GameObject.Find("WandRender");
        StaffRender = GameObject.Find("StaffRender");
        playercamera.GetComponentInChildren<Camera>();
        boss = true;
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
        StartCoroutine(Boss());
        //pressEUI.SetActive(false);





    }
    public void SetStats()
    { 
        myControl.Player_Min_MP = stats.ReturnStat("Player_Min_MP"); 
        myControl.Player_Max_MP = stats.ReturnStat("Player_Max_MP"); 
        myControl.Player_Min_HP = stats.ReturnStat("Player_Min_HP"); 
        myControl.Player_Max_HP = stats.ReturnStat("Player_Max_HP");
        myControl.ammoCount = stats.ReturnStat("ammoCount"); 
        myControl.ammoCountMax = stats.ReturnStat("ammoCountMax"); 
        myControl.Player_DR = stats.ReturnStat("Player_DR"); 
        myControl.Player_Vuln = stats.ReturnStat("Player_Vuln"); 
        myControl.Player_Luck = stats.ReturnStat("Player_Luck"); 
        myControl.Player_LifeSteal = stats.ReturnStat("Player_LifeSteal"); 
        myControl.Player_ManaSap = stats.ReturnStat("Player_ManaSap"); 
        myControl.Player_DS = stats.ReturnStat("Player_DS");
        myControl.Player_MS = stats.ReturnStat("Player_MS");
        myControl.Player_MPR = stats.ReturnStat("Player_MPR");
        myControl.Player_ManaCost = stats.ReturnStat("Player_Mana_Cost");
        myControl.Player_Burn = stats.ReturnStat("Player_Burn");
        myControl.Player_Slow = stats.ReturnStat("Player_Slow");
        myControl.Player_Damage = stats.ReturnStat("Player_Damage");
    }
    public void SendStats()
    {
        stats.SetStat("Player_Min_MP",myControl.Player_Min_MP);
        stats.SetStat("Player_Maxn_MP", myControl.Player_Max_MP); 
        stats.SetStat("Player_Min_HP", myControl.Player_Min_HP);
        stats.SetStat("Player_Max_HP", myControl.Player_Max_HP);
        stats.SetStat("ammoCount", myControl.ammoCount);
        stats.SetStat("ammoCountMax", myControl.ammoCountMax);
        stats.SetStat("Player_DR", myControl.Player_DR);
        stats.SetStat("Player_Vuln", myControl.Player_Vuln);
        stats.SetStat("Player_Luck", myControl.Player_Luck);
        stats.SetStat("Player_LifeSteal", myControl.Player_LifeSteal);
        stats.SetStat("Player_ManaSap", myControl.Player_ManaSap);
        stats.SetStat("Player_DS", myControl.Player_DS);
        stats.SetStat("Player_MS", myControl.Player_MS);
        stats.SetStat("Player_MPR", myControl.Player_MPR);
        stats.SetStat("Player_ManaCost", myControl.Player_ManaCost);
        stats.SetStat("Player_Burn", myControl.Player_Burn);
        stats.SetStat("Player_Slow", myControl.Player_Slow);
        stats.SetStat("Player_Damage", myControl.Player_Damage);
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
    public IEnumerator Boss()
    {
        yield return new WaitWhile(() => boss);
        sceneController.sceneScore += 100;
        sceneController.PlayerDied();
    }
    public void applyBoon()
    {
        boonApplied = true;
        myControl.Player_Min_HP += boonStats.Blessing_Player_HP; 
        myControl.Player_Min_HP -= (myControl.Player_Min_HP*(boonStats.Curse_Player_HP/100));
        myControl.Player_Max_HP += boonStats.Blessing_Player_Max_HP;
        myControl.Player_Max_HP += boonStats.Blessing_Player_HP;
        myControl.Player_Max_HP -= boonStats.Curse_Player_Max_HP;
        myControl.Player_Min_MP += boonStats.Blessing_Player_MP;
        myControl.Player_Min_MP -= boonStats.Curse_Player_MP;
        myControl.Player_Max_MP += boonStats.Blessing_Player_Max_MP;
        myControl.Player_Max_MP -= boonStats.Curse_Player_Max_MP;
        myControl.Player_Max_MP += boonStats.Blessing_Player_MP;
        myControl.Player_LifeSteal += boonStats.Blessing_Player_LifeSteal;
        myControl.Player_LifeSteal -= boonStats.Curse_Player_LifeSteal;
        myControl.Player_ManaSap += boonStats.Blessing_Player_ManaSap;
        myControl.Player_ManaSap -= boonStats.Curse_Player_ManaSap;
        myControl.Player_MS += myControl.Player_MS*(boonStats.Blessing_Player_MoveSpeed/100);
        myControl.Player_MS -= myControl.Player_MS*(boonStats.Curse_Player_MoveSpeed/100);
        myControl.Player_Vuln += boonStats.Blessing_Player_Vulnerable;
        myControl.Player_Vuln -= boonStats.Curse_Player_Vulnerable;
        myControl.Player_DR += boonStats.Blessing_Player_Damage_Reduction;
        myControl.Player_DR -= boonStats.Curse_Player_Damage_Reduction;
        myControl.Player_Luck += boonStats.Blessing_Player_Luck;
        myControl.Player_Luck -= boonStats.Curse_Player_Luck;
        myControl.Player_ManaCost += boonStats.Blessing_Player_ManaCost;
        myControl.Player_ManaCost -= boonStats.Curse_Player_ManaCost;
        myControl.Player_Damage += myControl.Player_Damage * (boonStats.Blessing_Player_Attack / 100);
        myControl.Player_Damage -= myControl.Player_Damage * (boonStats.Curse_Player_Attack / 100);
        myControl.Player_Burn += boonStats.Blessing_Player_Burn;
        myControl.Player_Burn -= boonStats.Curse_Player_Burn;
        myControl.Player_Slow += boonStats.Blessing_Player_Slow;
        myControl.Player_Slow -= boonStats.Curse_Player_Slow;
        myControl.Player_DS += boonStats.Blessing_Player_DoubleStrike;
        myControl.Player_DS -= boonStats.Curse_Player_DoubleStrike;
        boonApplied = false;
        sceneController.sceneScore += 10;
        boonStats.Reset();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="LevelChange")
        {
            sceneController.sceneCounter++;
            sceneController.switchScenes();
        }
        
        if (other.gameObject.tag == "Boon")
        {
            Debug.Log("Player Collided with Boon");
            //pressEUI.SetActive(true);
            sceneController.BoonUIActivate();
            boonStats.getBlessing();
            boonStats.getCurse();
            //MainCamera.GetComponentInChildren<Camera>();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Debug.Log("Boon");
            Object.Destroy(other.gameObject);
            Debug.Log("UI");
        }
        if (other.gameObject.tag == "SkeletonWeapon" && damagereset<=0)
        {
            Debug.Log("Player Hit by Skeleton");
            skeletonController = GameObject.FindGameObjectWithTag("Skeleton").GetComponent<SkeletonController>();
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= skeletonController.Enemydamage-(skeletonController.Enemydamage*(myControl.Player_DR/100));
                Debug.Log("Player took " + skeletonController.Enemydamage);
                damagereset = 1;
            
            
        }
        if (other.gameObject.tag == "FireBall" && damagereset <= 0)
        {
            Debug.Log("Player Hit by Mage");
            mageController = GameObject.FindGameObjectWithTag("Mage").GetComponent<MageController>();

                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= mageController.Enemydamage - (mageController.Enemydamage * (myControl.Player_DR / 100));
            Debug.Log("Player took " + mageController.Enemydamage);
                damagereset = 1;


        }
        if (other.gameObject.tag == "Arrow" && damagereset <= 0)
        {
            Debug.Log("Player Hit by Archer");
            archerController = GameObject.FindGameObjectWithTag("Archer").GetComponent<ArcherController>();
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= archerController.Enemydamage - (archerController.Enemydamage * (myControl.Player_DR / 100));
            Debug.Log("Player took " + archerController.Enemydamage);
                damagereset = 1;

        }
        if (other.gameObject.tag == "KnightWeapon" && damagereset <= 0)
        {
            knightController = GameObject.FindGameObjectWithTag("Knight").GetComponent<KnightController>();
            
                Debug.Log("Player Hit by Knight");
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= knightController.Enemydamage - (knightController.Enemydamage * (myControl.Player_DR / 100));
                Debug.Log("Player took " + knightController.Enemydamage);
                damagereset = 1;


        }
        if (other.gameObject.tag == "BossWeapon" && damagereset <= 0)
        {
                Debug.Log("Player Hit by Boss");
                bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
                source.clip = Hit;
                source.Play();
                myControl.Player_Min_HP -= bossController.Enemydamage - (bossController.Enemydamage * (myControl.Player_DR / 100));
            Debug.Log("Player took " + bossController.Enemydamage);
                damagereset = 1;


        }


    }
    public void Steal()
    {
        if (myControl.Player_Min_HP < myControl.Player_Max_HP)
        {
            myControl.Player_Min_HP += myControl.Player_LifeSteal;
        }
        if (myControl.Player_Min_MP < myControl.Player_Max_MP)
        {
            myControl.Player_Min_MP += myControl.Player_ManaSap;
        }
        
    }
    public void ControlMPHP()
    {
        if ((myControl.Player_Min_MP > myControl.Player_Max_MP))
        {
            myControl.Player_Min_MP = myControl.Player_Max_MP;
        }
        if ((myControl.Player_Min_HP > myControl.Player_Max_HP))
        {
            myControl.Player_Min_HP = myControl.Player_Max_HP;
        }
        if ((myControl.Player_Min_MP <= 0))
        {
            myControl.Player_Min_MP = 0;
        }
        if ((myControl.Player_Min_HP <= 0))
        {
            myControl.Player_Min_HP = 0;
        }
    }
    public void DeathSteal()
    {
        sceneController.sceneScore += 20;
        if (myControl.Player_Min_HP < myControl.Player_Max_HP)
        {
            myControl.Player_Min_HP += myControl.Player_LifeSteal;
        }
        if (myControl.Player_Min_MP < myControl.Player_Max_MP)
        {
            myControl.Player_Min_MP += myControl.Player_ManaSap;
        }
        if (myControl.Player_LifeSteal == 0 && myControl.Player_Min_HP < myControl.Player_Max_HP)
        {
            myControl.Player_Min_HP += 5;
        }
    }
    private void die()
    {
        if (myControl.Player_Min_HP<=0) 
        {
            anim.SetBool("Death", true);
            myControl.Player_Min_HP = 0;
            sceneController.PlayerDied();
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
        ControlMPHP();
        SendStats();
        health = myControl.Player_Max_HP;
        myControl.ManaRegen();
        HandleCameraLook();
        burn = myControl.Player_Burn;
        slow = myControl.Player_Slow;
        doubleStrike = myControl.Player_DS;
        if (stats.acceptBoon == true)
        {
            applyBoon();
            stats.acceptBoon = false;
        }
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
                    if (magic && fire && myControl.Player_Min_MP > (10 - (10 * myControl.Player_ManaCost / 100)))
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
                        myControl.Player_Min_MP -= 10-(10*myControl.Player_ManaCost/100);
                        reset = 3;
                    }
                    else
                    if (magic && ice && myControl.Player_Min_MP > (10 - (10 * myControl.Player_ManaCost / 100)))
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
                        reset = 3;
                        myControl.Player_Min_MP -= 10-(10 * myControl.Player_ManaCost / 100);
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
            if (weapon1==true)
            {
                weapon1 = false;
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
                damage = (18 + basedamage)+((18 + basedamage) * (myControl.Player_Vuln / 100));
            }
            else
            if (weapon1==false)
            {
                weapon1 = true;
                SwordRender.SetActive(true);
                AxeRender.SetActive(false);
                MaceRender.SetActive(false);
                BowRender.SetActive(false);
                WandRender.SetActive(false);
                StaffRender.SetActive(false);
                ice = true;
                fire = false;
                melee = true;
                magic = false;
                Bow = false;
                damage = (15 + basedamage)+((15 + basedamage) * (myControl.Player_Vuln / 100));
            }
            

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
                myRig.velocity = transform.forward * myControl.Player_MS + new Vector3(0, myRig.velocity.y, 0);
            }
            if (v < -0.15)
            {
                myRig.velocity = -transform.forward * myControl.Player_MS + new Vector3(0, myRig.velocity.y, 0);
            }
            if (h > 0.15)
            {
                myRig.velocity = transform.right * myControl.Player_MS + new Vector3(0, myRig.velocity.y, 0);
            }
            if (h < -0.15)
            {
                myRig.velocity = -transform.right * myControl.Player_MS + new Vector3(0, myRig.velocity.y, 0);
            }
      
    }
   
}
