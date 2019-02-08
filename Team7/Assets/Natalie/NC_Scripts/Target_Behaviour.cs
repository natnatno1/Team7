using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Behaviour : MonoBehaviour
{

    public int TargetScore;
    public float Health;
    public GameManager_Script GM_Script;


    // Start is called before the first frame update
    void Start()
    {
        GM_Script = GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            GM_Script.SendMessage("AddScore", TargetScore);
            //Destroy(this.gameObject);
        }
    }
}
