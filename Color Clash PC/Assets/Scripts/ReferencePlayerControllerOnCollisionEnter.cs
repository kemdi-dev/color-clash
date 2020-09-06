using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencePlayerControllerOnCollisionEnter : MonoBehaviour
{
    Material ballMaterial;
    public Color[] colors = { new Color(0.88f, 0.23f, 0.23f, 1f), new Color(0.23f, 0.88f, 0.66f, 1f), new Color(0.23f, 0.66f, 0.88f, 1f) };
    Color currentColor;
    Color nextColor;
    //public GameObject[] colorBlocks;
    Color colorBlock;

    public GameManager theGameManager;

    //public PlayerMovement thePlayerControls;

    //private bool isDead = false;

    public bool playerIsDead = false;
    public bool colorMatch = false;

    // Start is called before the first frame update
    void Start()
    {
        ballMaterial = GetComponent<Renderer>().material;
        ballMaterial.color = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isDead)
        {
            return;
        }*/
    }

    void OnCollisionEnter(Collision theCollision)
    {
        
        if (theCollision.gameObject.CompareTag("ColorBlock"))
        {
            currentColor = ballMaterial.color;
            nextColor = colors[Random.Range(0, colors.Length)];

            colorBlock = theCollision.gameObject.GetComponent<Renderer>().material.color;

            if (colorBlock == ballMaterial.color)
            {
                theCollision.gameObject.SetActive(false);
                //Destroy(theCollision.gameObject);
                Debug.Log("had similar color");
            }
            else
            {
                //this.gameObject.SetActive(false);
                //Destroy(gameObject);

                //theGameManager.RestartGame();
                //colorMatch = true;
                PlayerDead();
                

                //Death();
                Debug.Log("dead! did not have similar color");
            }
            Debug.Log("touched color block");
            Debug.Log(ballMaterial.color);

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

    public void PlayerDead()
    {
        playerIsDead = true;
        theGameManager.RestartGame();
        /*thePlayerControls.forwardSpeed = thePlayerControls.moveSpeedStore;
        thePlayerControls.speedMilestoneCount = thePlayerControls.speedMileStoneCountStore;*/
    }

    /*private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }*/
}
