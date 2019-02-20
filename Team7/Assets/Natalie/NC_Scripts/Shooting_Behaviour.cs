using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Behaviour : MonoBehaviour
{
    RaycastHit hitpoint;
   // public Collider coll;
    public GameObject bulletCheck;

    public GameManager_Script GM_Script;

    public Vector3 Target;
    public Vector3 Origin;
    public float Aimx;
    public float Aimz;
    public float speed;
    public GameObject BulletRB;
    public float CameraY;

    void Start()
    {
        //coll = GetComponent<Collider>();
        speed = 150;
        GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();
        
    }

    private void Update()
    {
        CameraY = Camera.main.gameObject.transform.position.y;

        if (Input.GetButtonDown("Fire1"))
        {

            

            Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(transform.position, transform.forward * 50, Color.yellow, 0.01f, true);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            var fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hitpoint, 60))
            {
                Debug.Log("Target Hit");

                //Aimx = hitpoint.point.x;
                // Aimz = hitpoint.point.z;

                Destroy(hitpoint.collider.gameObject);








                //Target.x = Aimx;
                //Target.z = Aimz;

                // Target.y = CameraY -= 10;
                //Target.x = Camera.main.gameObject.transform.position.x;
                // Target.z = Camera.main.gameObject.transform.position.z;

                //Origin.x = ray.origin.x;
                //Origin.z = ray.origin.z;
                //Origin.y = ray.origin.y;

                //Target.x = hitpoint.point.x;
                //Target.z = hitpoint.point.z;
                //Target.y = hitpoint.point.y;

                //Instantiate(bulletCheck, Target, Quaternion.identity);

                //Instantiate(BulletRB, Origin, Quaternion.identity);

                //bulletCheck.Vector3.MoveTowards(Target.x, Target.y, speed);

                //CreateBullet();





            }
        }
    }

   // private void CreateBullet()
   // {
   //     GameObject obj = (GameObject)Instantiate(BulletRB, Origin, Quaternion.identity);
        //obj.transform.position = Vector3.MoveTowards(Target, Target, speed);
    //    obj.GetComponent<Rigidbody>().velocity = transform.GetComponent<Rigidbody>().velocity;
    //    GM_Script.BulletVelocity = Target;
   // }


}


