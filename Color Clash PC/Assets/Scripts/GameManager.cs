using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Transform cbGenerator;
    private Vector3 cbStartPoint;

    private PlatformDestroyer[] platformList;
    private ColorBlockDestroyer[] colorBlockList;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

    void Start()
    {
        platformStartPoint = platformGenerator.position;
        cbStartPoint = cbGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        colorBlockList = FindObjectsOfType<ColorBlockDestroyer>();
        for (int i = 0; i < colorBlockList.Length; i++)
        {
            colorBlockList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        cbGenerator.position = cbStartPoint;

        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        colorBlockList = FindObjectsOfType<ColorBlockDestroyer>();
        for (int i = 0; i < colorBlockList.Length; i++)
        {
            colorBlockList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        cbGenerator.position = cbStartPoint;

        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
