using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCopter : MonoBehaviour
{
    public PlayerController.Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        GameManager.instance.CharacterSelect(color);
    }
}
