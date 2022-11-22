using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsDead && GameManager.instance.GameStart)
        {
            transform.Translate(Vector3.left * GameManager.instance.Speed * Time.deltaTime);
        }
    }
}
