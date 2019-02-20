using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Behaviour3 : MonoBehaviour
{

    RaycastHit hitpoint;
    public GameObject bulletCheck;
    public GameObject Plane;

    public GameManager_Script GM_Script;

    public Vector3 Target;
    public Vector3 Origin;
    public float Aimx;
    public float Aimz;
    public float speed;
    public GameObject BulletRB;
    public float CameraY;

    // Start is called before the first frame update
    void Start()
    {
        speed = 150;
        GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();

    }

    //Update is called once per frame
    void Update()
    {
        CameraY = Camera.main.gameObject.transform.position.y;

        if (Input.GetButtonDown("Fire1"))
        {

            Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(transform.position, transform.forward * 250, Color.yellow, 0.01f, true);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            var fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hitpoint, 250))
            {
                Debug.Log("Target Hit");

                Origin.x = ray.origin.x;
                Origin.z = ray.origin.z;
                Origin.y = ray.origin.y;

                Target.x = hitpoint.point.x;
                Target.z = hitpoint.point.z;
                Target.y = hitpoint.point.y;

                if (hitpoint.collider.tag == ("Target"))
                {
                    Destroy(hitpoint.transform.gameObject); // destroy the object hit
                }

                //Destroy(hitpoint.transform.gameObject); // destroy the object hit


            }

        }
    }
    
}