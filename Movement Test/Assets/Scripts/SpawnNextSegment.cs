using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextSegment : MonoBehaviour
{
    public GameObject continueSpawn;
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
        stageList = new List<GameObject>();
        if (playerRef == null) playerRef = GameObject.Find("player");
        Vector3 mainPos = playerRef.transform.position;
        for (int i = 0; i < maxSpawn; i++)
        {
            print(i);
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
        stageList.Remove(patch);
        Destroy(patch);
    }

    void spawnNewSegment()
    {
        GameObject spawn = Instantiate(continueSpawn, transform.position + new Vector3(0, yOffsetSegment, 0) + (dist * offset), Quaternion.identity);
        stageList.Add(spawn);
        counter++;
    }
    void spawnNewWaterfall()
    {
        yOffset -= 6;
        offset += .2f;
        GameObject spawn = Instantiate(waterfallSpawn, transform.position + new Vector3(-2,yOffset,0) + (dist * offset), Quaternion.identity);
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
