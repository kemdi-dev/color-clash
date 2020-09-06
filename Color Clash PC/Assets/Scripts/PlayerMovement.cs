using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5.0f;
    public float moveSpeedStore;

    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    private float speedMileStoneCountStore;

    public float upForce = 500;
    public float rightForce = 20;
    private Rigidbody rigi;
    //private Collider2D myCollider;

    bool isgrounded = true;

    //private PlayerController thePlayerController;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        speedMilestoneCount = speedIncreaseMilestone;
        //myCollider = GetComponent<Collider2D>();

        moveSpeedStore = forwardSpeed;
        speedMileStoneCountStore = speedMilestoneCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            forwardSpeed = forwardSpeed * speedMultiplier;
        }
        rigi.velocity = new Vector3(rigi.velocity.x, rigi.velocity.y, forwardSpeed);
        if (isgrounded == true)
        {
            //Do your action Here...
            
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigi.AddForce(Vector3.up * upForce);
                Debug.Log("jumped");
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigi.AddForce(Vector3.right * rightForce);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigi.AddForce(Vector3.left * rightForce);
        }
    }

    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter(Collision theCollision)
    {
        
        if (theCollision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
            Debug.Log("touched ground");
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.CompareTag("Ground"))
        {
            isgrounded = false;
        }
    }

    public void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    /*public void SetSpeed(float modifier) //for the "Score.cs" script
    {
        forwardSpeed = 5.0f + modifier;
    }*/
}
