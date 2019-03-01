using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour {

    public GameManager_Script GM_Script;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GM_Script = GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();

        speed = 150;

        transform.position = Vector3.MoveTowards(GM_Script.BulletVelocity, GM_Script.BulletVelocity, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Target")
        {
            Debug.Log("Target Shot");
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
