using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Wander : MonoBehaviour
{
    public GameManager_Script GM_Script;
    public GameObject[] Waypoints;
    public GameObject NextWaypoint;
    public float speed;
    public int Range;
    public bool Attacking;
    public GameObject Base;
    public GameObject GMBase;
    



    void Start()
    {
        GM_Script = GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();
        Range = (Random.Range(0, 9));
        NextWaypoint = Waypoints[Range];
        speed = 1;
        Attacking = false;

        InvokeRepeating("SendDamage", 0, 1);


    }
    

        void GotoNextPoint()
    {
        Range = (Random.Range(0, 9));
        NextWaypoint = Waypoints[Range];

    }


    void Update()
    {
        //gameObject.transform.position = NextWaypoint.transform.position;

        //gameObject.transform.position = new Vector3(NextWaypoint.transform.position.x, NextWaypoint.transform.position.y, NextWaypoint.transform.position.z);

        if (Attacking == false)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, NextWaypoint.transform.position, step);
        }

        else if (Attacking == true)
        {
            speed = 0;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, NextWaypoint.transform.position, step);

            
        }
            

           
            
       
           
        }
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            GotoNextPoint();
        }

        else if (other.gameObject.tag == "Obstacle")
        {
            GotoNextPoint();
        }

        else if (other.gameObject.tag == "Base")
        {
            Attacking = true;
        }
    }

    void SendDamage()
    {

        if (Attacking == true)
        {
            Base.GetComponent<Base_Behaviour>().Base_Health -= 1;
        }
        
    }
    




}





