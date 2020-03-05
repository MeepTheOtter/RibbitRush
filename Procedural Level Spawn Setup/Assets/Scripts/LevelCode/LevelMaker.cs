using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    // The level prefabs that spawn the logs
    public GameObject StartPoint;
    public GameObject EndPoint;
    public GameObject Env1;
    public GameObject Env2;
    public GameObject Wat;
    public GameObject Snack;

    public Transform Target;
    private Vector3 Op;

    // This is a value that is added to the prefab names so they can be selected easier
    public static int PartNumber = 1;
    
    // Y offset for the chunks Z offset for the points
    float Yoffset = 0;
    [Range(5, 15)] public static int Zoffset = 10;
    
    // Z offset value applied to the level creator
    float MakerOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Spawns the initial chunk
        SpawnChunk();
        Op = Target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target.position.z >= Op.z + 50)
        {
            SpawnChunk();
            Op = Target.position;
            Op.z += 10;
        }
    }

    // Spawns 5 parts next to one another
    private void SpawnChunk()
    {
        float M = Random.Range(0.0f, 1.0f);
        int K = 0;
        if (M <= 0.3f) K = 7;
        if (M > 0.3f && M < 0.7f) K = 9;
        if (M >= 0.7f) K = 11;

        for(int i = 0; i < K; i++)
        {
            SpawnPart(transform.position, i, K);
        }
        Vector3 D = transform.position;
        D.z += MakerOffset;
        transform.position = D;
        PartNumber = 1;
        Yoffset -= 10;
    }

    // Spawns three sections side by side
    private void SpawnPart(Vector3 P, int i, int K)
    {
        SpawnSection(P, 6f, i, K, 1);
        SpawnSection(P, 3f, i, K, 2);
        SpawnSection(P, 0, i, K, 3);
        SpawnSection(P, -3f, i, K, 4);
        SpawnSection(P, -6f, i, K, 5);
        if (i % 2 == 0 || i == 0) SpawnEnv(P, 11, 1);
        if (i == 0)
        {
            P.z -= Zoffset;
            P.y += 5f;
            P.y += Yoffset;
            Instantiate(Wat, P, Quaternion.identity);
        }
        PartNumber++;
        Vector3 D = transform.position;
        D.z += MakerOffset;
        transform.position = D;
    }

    // Spawns individual sections of the level
    // it takes in a position and an x offset
    private void SpawnSection(Vector3 Part, float offset, int i, int K, int T)
    {
        Vector3 P = Part;
        Vector3 B = P;
        P.z -= Zoffset;
        P.x += offset;
        P.y += Yoffset;
        B.z += Zoffset;
        B.x += offset;
        B.y += Yoffset;
        var End = Instantiate(EndPoint, B, Quaternion.identity);
        End.name = ("End" + PartNumber);
        if ((i + 1)  == K)
        {
            End.name = ("END");
        }
        var Start = Instantiate(StartPoint, P, Quaternion.identity);
        Start.name = ("Start" + PartNumber + T);
    }

    private void SpawnEnv(Vector3 Part, float Xoffset, float YOffset)
    {
        Vector3 P1 = Part;
        Vector3 P2 = Part;
        Vector3 D = Part;
        P1.x += Xoffset;
        P2.x -= Xoffset;
        D.y -= YOffset;
        P1.y += Yoffset;
        P2.y += Yoffset;
        D.y += Yoffset;
        float C = Random.Range(0.0f, 1.0f);
        var ENV = Instantiate(Env1, P1, Quaternion.identity);
        ENV.name = ("ENV" + PartNumber);
        P1.x -= 1.5f;
        P1.y += 1;
        P2.x += 1.5f;
        P2.y += 1f;
        Instantiate(Snack, P1, Quaternion.identity);
        ENV = Instantiate(Env1, P2, Quaternion.identity);
        ENV.name = ("ENV" + PartNumber);
        Instantiate(Snack, P2, Quaternion.identity);
        ENV = Instantiate(Env2, D, Quaternion.identity);
        ENV.name = ("ENV" + PartNumber + " V2");
    }
}
