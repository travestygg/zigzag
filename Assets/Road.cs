using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offset = 1f;
    // Start is called before the first frame update

    private int roadCount = 0;

    private void Awake()
    {
        InvokeRepeating("CreateNewRoadPart", 0.1f, 0.5f);
    }

    public void CreateNewRoadPart()

    {
        Debug.Log("CreateNewRoadPart() CALLED");

        Vector3 spawnPos = lastPos;
        float chance = Random.Range(0, 100);
        if(chance < 50)
        {

                spawnPos = lastPos + new Vector3(-1, 0, 0);
            ;
        }
        else
        {
            spawnPos = lastPos + new Vector3(0, 0, 1);
        }

        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.identity, transform);
        g.transform.position = spawnPos;
        lastPos = g.transform.position;

        roadCount++;

        if(roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewRoadPart();

        }
    }
}
