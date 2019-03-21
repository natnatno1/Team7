using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoreZombies : MonoBehaviour
{

    public bool Spawn;
    public GameObject Zombies;

    // Start is called before the first frame update
    void Start()
    {
        Spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there are any more of this game object in the scene
        if (GameObject.FindGameObjectsWithTag("Target").Length < 0)
        {
            Spawn = true;
        }
        

        else
        {
            Spawn = false;
        }
    }
}
