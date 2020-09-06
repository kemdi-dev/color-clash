using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceGameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Transform cbGenerator;
    private Vector3 cbStartPoint;

    private PlatformDestroyer[] platformList;
    private ColorBlockDestroyer[] colorBlockList;

    /*public Transform startingColorBlocks;
    private Vector3 startingColorBlocksStartPoint;

    public Transform colorBlockGenerator;
    private Vector3 colorBlockStartPoint;*/

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    //private ColorBlockDestroyer colorBlockList;

    //public ColorBlockDestroyer[] colorBlockList;

    private ScoreManager theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        //startingColorBlocksStartPoint = startingColorBlocks.position;
        platformStartPoint = platformGenerator.position;
        cbStartPoint = cbGenerator.position;
        //colorBlockStartPoint = colorBlockGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
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

        //startingColorBlocks.transform.position = startingColorBlocksStartPoint;
        //colorBlockList = FindObjectOfType<ColorBlockDestroyer>();
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        cbGenerator.position = cbStartPoint;
        //colorBlockGenerator.position = colorBlockStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }
}
