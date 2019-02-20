using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Script : MonoBehaviour
{

    public int Score;
    public int bullets;
    public GameObject Plane;
    public float yvalue;

    public Vector3 BulletVelocity;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yvalue = GameObject.Find("Game_Manager").transform.position.y;
    }

    void AddScore(int NewScore)
    {
        Score += NewScore;
    }
}
