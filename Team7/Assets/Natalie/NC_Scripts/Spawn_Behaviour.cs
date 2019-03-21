using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Behaviour : MonoBehaviour
{

    public GameObject ImageTarget;
    public GameObject Zombie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageTarget.GetComponent<SpawnMoreZombies>().Spawn == true)
        {
            Instantiate(Zombie);
            Instantiate(Zombie);
            Instantiate(Zombie);
            Instantiate(Zombie);
        }
    }
}
