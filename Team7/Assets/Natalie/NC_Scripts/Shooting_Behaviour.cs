using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Behaviour : MonoBehaviour
{
    RaycastHit hitpoint;
   // public Collider coll;
    public GameObject bulletCheck;

    public Vector3 Target;
    public Vector3 Origin;
    public float Aimx;
    public float Aimz;
    public float speed;
    public Rigidbody BulletRB;
    public float CameraY;

    void Start()
    {
        //coll = GetComponent<Collider>();
        speed = 150;
        
    }

    private void Update()
    {
        CameraY = Camera.main.gameObject.transform.position.y;

        if (Input.GetButtonDown("Fire1"))
        {

            

            Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(transform.position, transform.forward * 50, Color.yellow, 5, true);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            var fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hitpoint, 60))
            {
                Debug.Log("Target Hit");

                //Aimx = hitpoint.point.x;
                // Aimz = hitpoint.point.z;








                //Target.x = Aimx;
                //Target.z = Aimz;

                // Target.y = CameraY -= 10;
                //Target.x = Camera.main.gameObject.transform.position.x;
                // Target.z = Camera.main.gameObject.transform.position.z;

                Origin.x = ray.origin.x;
                Origin.z = ray.origin.z;
                Origin.y = ray.origin.y;

                Target.x = hitpoint.point.x;
                Target.z = hitpoint.point.z;
                Target.y = hitpoint.point.y;

                //Instantiate(bulletCheck, Target, Quaternion.identity);

                Rigidbody bulletCheck = Instantiate(BulletRB, Origin, Quaternion.identity)as Rigidbody;

                bulletCheck.velocity = transform.TransformDirection(new Vector3(Target.x, Target.y, speed));


            }
        }
    }
}


