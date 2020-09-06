using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Material ballMaterial;
    public Color[] colors = { new Color(0.88f, 0.23f, 0.23f, 1f), new Color(0.23f, 0.88f, 0.66f, 1f), new Color(0.11f, 0.38f, 0.66f, 1f) };
    Color currentColor;
    Color nextColor;

    Color colorBlock;

    public GameManager theGameManager;

    public bool playerIsDead = false;


    public float forwardSpeed = 5.0f;
    public float moveSpeedStore;

    public float speedMultiplier = 1.05f;
    private float speedIncreaseMilestone = 50;
    public float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMileStoneCountStore;

    public float upForce = 500;
    public float rightForce = 20; //250 when using GetKey

    public float downForce = 100; //520 when using GetKey NOT for GetKeyDown

    private Rigidbody rigi;

    bool isgrounded = true;


    public int scoreToGive;
    private ScoreManager theScoreManager;


    public AudioSource mainSound;
    public AudioSource deathSound;
    public AudioSource matchSound;

    // Start is called before the first frame update
    void Start()
    {
        ballMaterial = GetComponent<Renderer>().material;
        ballMaterial.color = colors[Random.Range(0, colors.Length)];

        rigi = GetComponent<Rigidbody>();
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = forwardSpeed;
        speedMileStoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;


        theScoreManager = FindObjectOfType<ScoreManager>();

        //mainSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            forwardSpeed = forwardSpeed * speedMultiplier;
        }
        rigi.velocity = new Vector3(rigi.velocity.x, rigi.velocity.y, forwardSpeed);

        if (isgrounded == true)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || SwipeControls.swipedUp)
            {
                rigi.AddForce(Vector3.up * upForce);
            }
        }
        
        if (Input.GetKey(KeyCode.A) || SwipeControls.swipedLeft)
        {
            rigi.AddForce(Vector3.left * rightForce);
        }

        if (Input.GetKey(KeyCode.D) || SwipeControls.swipedRight)
        {
            rigi.AddForce(Vector3.right * rightForce);
        }

        if (Input.GetKey(KeyCode.S) || SwipeControls.swipedDown)
        {
            rigi.AddForce(Vector3.down * downForce);
        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }

        if (theCollision.gameObject.CompareTag("ColorBlock"))
        {
            currentColor = ballMaterial.color;
            nextColor = colors[Random.Range(0, colors.Length)];

            colorBlock = theCollision.gameObject.GetComponent<Renderer>().material.color;

            if (colorBlock == ballMaterial.color)
            {
                matchSound.Play();
                theScoreManager.AddScore(scoreToGive);
                theCollision.gameObject.SetActive(false);
            }
            else
            {
                PlayerDead();
                deathSound.Play();
            }

            if (theCollision.gameObject.CompareTag("ColorBlock"))
            {
                while (nextColor == currentColor)
                {
                    nextColor = colors[Random.Range(0, colors.Length)];
                }
                ballMaterial.color = nextColor;
            }
        }
    }

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

    public void PlayerDead()
    {
        playerIsDead = true;
        theGameManager.RestartGame();
        forwardSpeed = moveSpeedStore;
        speedMilestoneCount = speedMileStoneCountStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
    }
}
