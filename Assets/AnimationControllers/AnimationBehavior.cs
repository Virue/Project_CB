using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{
    Animator anim;
    public Rigidbody myRig;
    public float speed = 5.0f;
    public float maxspeed = 10.0f;
    bool canJump = true;
    bool CollisionUnder = false;

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
        playercamera.GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        
        HandleCameraLook();
        CollisionUnder = false;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
        Debug.Log("The Direction variable = "+ h);
        RaycastHit info;
        if (Physics.Raycast(this.transform.position, this.transform.up * -1, out info))
        {
            if (info.distance < 0.50)
            {
                CollisionUnder = true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            myRig.velocity = Vector3.zero+ new Vector3(0, myRig.velocity.y, 0);

        }
        if (Input.GetAxisRaw("Jump") > 0 && canJump == true)
        {
            canJump = false;
            myRig.velocity += new Vector3(myRig.velocity.x, 3, 0);
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
