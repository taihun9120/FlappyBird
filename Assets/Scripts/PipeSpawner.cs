using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;


    private GameObject[] Pipes;
    private int count = 4;

    // Start is called before the first frame update
    void Start()
    {
        Pipes = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            Pipes[i] = Instantiate(pipePrefab, new Vector2(5 + i * 10, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
