using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public float spawnRate;
    public List<GameObject> cubeL;
    public List<GameObject> cubeR;
    public Vector3 spawnPosForL;
    public Vector3 spawnPosForR;
    public Vector3 spawnPosForL2;
    public Vector3 spawnPosForR2;
    public int indexR;
    public int indexL;
    public int indexL2;
    public int indexR2;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosForL = new Vector3(48, 1, 7);
        spawnPosForR = new Vector3(-48, 1, 15);
        spawnPosForL2 = new Vector3(48, 1, 22);
        spawnPosForR2 = new Vector3(-48, 1, 30);
        
        InvokeRepeating("SpawnCubeForLeft", 1, spawnRate);

        if ((SceneManager.GetActiveScene().name) != "LEVEL01")
        {
            InvokeRepeating("SpawnCubeForRight", 1, spawnRate);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCubeForLeft()
    {
        indexL = Random.Range(0, cubeL.Count);
        if ((SceneManager.GetActiveScene().name) == "LEVEL04")
        {
            indexL2 = Random.Range(0, cubeL.Count);
            Instantiate(cubeL[indexL2], spawnPosForL2, cubeL[indexL2].transform.rotation);
        }
        Instantiate(cubeL[indexL], spawnPosForL, cubeL[indexL].transform.rotation);
    }

    void SpawnCubeForRight()
    {
        indexR = Random.Range(0, cubeR.Count);
        if ((SceneManager.GetActiveScene().name) == "LEVEL04")
        {
            indexR2 = Random.Range(0, cubeR.Count);
            Instantiate(cubeR[indexR2], spawnPosForR2, cubeR[indexR2].transform.rotation);
        }
        Instantiate(cubeR[indexR], spawnPosForR, cubeR[indexR].transform.rotation);
    }
}
