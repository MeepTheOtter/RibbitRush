using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawnStart : MonoBehaviour
{
    public GameObject Log;
    public GameObject WhirlPool;
    GameObject Target;
    float Counter = 0;
    int Count = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLogs();
        Target = GameObject.Find("MakerTarget");
    }

    // Update is called once per frame
    void Update()
    {
        Counter += 140f * Time.deltaTime;
        if (gameObject.name == "Start11"&& Counter >= 230 || gameObject.name == "Start12" && Counter >= 230 || gameObject.name == "Start13" && Counter >= 230 || gameObject.name == "Start14" && Counter >= 230 || gameObject.name == "Start15" && Counter >= 230)
        {
            Vector3 S = transform.position;
            float M = Random.Range(0.0f, 1.0f);
            S.z += (M > 0.5f) ? -.5f : .5f;
            Instantiate(Log, S, Quaternion.identity);
            Counter = 0;
        }
        if (gameObject.name == "Start52" && Count == 0 || gameObject.name == "Start54" && Count == 0)
        {
            float T = Random.Range(0.0f, 1.0f);
            Vector3 P = transform.position;
            Instantiate(WhirlPool, P, Quaternion.identity);
            Count++;
        }
        if (Target.transform.position.y <= transform.position.y - 5)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnLogs()
    {
        Vector3 P = transform.position;
        float M = Random.Range(0.0f, 1.0f);
        P.z += (M > 0.5f) ? -.5f : .5f;
        Instantiate(Log, P, Quaternion.identity);
        P = transform.position;
        M = Random.Range(0.0f, 1.0f);
        P.z += (M > 0.5f) ? -.5f : .5f;
        P.z += 5;
        Instantiate(Log, P, Quaternion.identity);
    }
}
