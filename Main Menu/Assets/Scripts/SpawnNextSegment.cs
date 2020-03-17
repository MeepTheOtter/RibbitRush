using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextSegment : MonoBehaviour
{
    public GameObject continueSpawn;

    public GameObject Section1;
    public GameObject Section2;
    public GameObject Section3;
    public GameObject Section4;
    public GameObject Section5;
    public GameObject Section6;
    public GameObject Section7;
    public GameObject Section8;
    public GameObject Section9;
    public GameObject Section10;

    GameObject[] S = new GameObject[10];

    public GameObject waterfallSpawn;
    public GameObject playerRef;
    public GameObject log;
    public int maxSpawn;
    List<GameObject> stageList;
    public Vector3 dist = new Vector3(0, 0, 30);
    private int counter = 0;
    private float offset = 1;
    private float yOffset = 0;
    private float yOffsetSegment = 0;
    private bool testingOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        PushToSection();
        stageList = new List<GameObject>();
        if (playerRef == null) playerRef = GameObject.Find("player");
        Vector3 mainPos = playerRef.transform.position;
        for (int i = 0; i < maxSpawn; i++)
        {
            //print(i);
            if (counter % 10 == 0 && !testingOnce && counter != 0)
            {
                //waterfall code goes here
                spawnNewWaterfall();
                //testingOnce = true;

            }
            if (counter < 10)
            {
                //Spawn another segment

                spawnNewSegment();
                offset++;


            }
        }
    }

    void PushToSection()
    {
        S[0] = Section1;
        S[1] = Section2;
        S[2] = Section3;
        S[3] = Section4;
        S[4] = Section5;
        S[5] = Section6;
        S[6] = Section7;
        S[7] = Section8;
        S[8] = Section9;
        S[9] = Section10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerRef.transform.position;


        if (playerPos.z >= stageList[0].transform.Find("end").position.z)
        {
            remove(stageList[0]);
            if (counter % 10 == 0 && !testingOnce && counter != 0)
            {
                //waterfall code goes here
                spawnNewWaterfall();
                //testingOnce = true;

            }
            if (counter < 10)
            {
                //Spawn another segment

                spawnNewSegment();
                offset++;


            }
        }
    }

    private void remove(GameObject patch)
    {
        if (PowerUpController.isDead == false)
        {
            stageList.Remove(patch);
            Destroy(patch);
        }
    }

    void spawnNewSegment()
    {
        float R = Random.Range(1, 10);
        int i = 0;
        if (R < 1.5f) i = 0;
        if (R >= 1.5f && R < 2.5f) i = 1;
        if (R >= 2.5f && R < 3.5f) i = 2;
        if (R >= 3.5f && R < 4.5f) i = 3;
        if (R >= 4.5f && R < 5.5f) i = 4;
        if (R >= 5.5f && R < 6.5f) i = 5;
        if (R >= 6.5f && R < 7.5f) i = 6;
        if (R >= 7.5f && R < 8.5f) i = 7;
        if (R >= 8.5f && R < 9.5f) i = 8;
        if (R > 9.5f) i = 9;
        GameObject spawn = Instantiate(S[i], transform.position + new Vector3(0, yOffsetSegment, 0) + (dist * offset), Quaternion.identity);
        stageList.Add(spawn);
        counter++;
    }
    void spawnNewWaterfall()
    {
        yOffset -= 6;
        offset += .2f;
        GameObject spawn = Instantiate(waterfallSpawn, transform.position + new Vector3(-2, yOffset, 0) + (dist * offset), Quaternion.identity);
        stageList.Add(spawn);
        yOffsetSegment -= 8.3f;
        offset += 1;
        yOffset -= 2.3f;
        counter = 0;
        spawnLogs();
    }
    private void spawnLogs()
    {
        Vector3 posi = waterfallSpawn.transform.Find("logSpawn1").position;
        GameObject loggy = Instantiate(log, posi, Quaternion.identity);
        loggy.transform.position = waterfallSpawn.transform.Find("logSpawn1").position;

    }
}
