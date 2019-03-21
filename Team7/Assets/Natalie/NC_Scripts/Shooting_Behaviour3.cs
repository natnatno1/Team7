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

    public ParticleSystem MuzzleFlash;
    public float MuzzleFlashTimer;
    public AudioSource GunSounds;
    public AudioClip Gun_1;
    public AudioClip EmptyGun_1;

    public GameObject TargetReticle;

    public float AmmoValue;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 150;
        GM_Script = GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();
        MuzzleFlashTimer = 0.01f;
        GunSounds = GetComponent<AudioSource>();
        AmmoValue = 1;
        TargetReticle = GameObject.Find("Game_Manager/UI/Reticle/ReticleTargetOn");
        MuzzleFlash = GameObject.Find("Game_Manager/GunCanvas").GetComponentInChildren<ParticleSystem>();
        GM_Script.GameOver = false;

    }

    //Update is called once per frame
    void Update()
    {
        CameraY = Camera.main.gameObject.transform.position.y;



        /////


        Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(transform.position, transform.forward * 250, Color.red, 0.01f, true);

        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);


        var fwd1 = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd1, out hitpoint, 250))
        {

            if (hitpoint.collider.tag == ("Target"))
            {
                Debug.Log("Target In Range");

                TargetReticle.SetActive(true);

            }

            else
            {
                TargetReticle.SetActive(false);
            }
            
            



        }


        ////

        if (Input.GetButtonDown("Fire1"))

        //if (Input.touchCount > 0)
        {
            if (GM_Script.Ammo > 0  && GM_Script.GameOver == false)
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

                    MuzzleFlash.Play();

                    ShootingEffects();

                    if (hitpoint.collider.tag == ("Target"))
                    {
                        hitpoint.transform.GetComponent<Target_Behaviour>().SendMessage("Explode");
                        Destroy(hitpoint.transform.gameObject); // destroy the object hit
                        GM_Script.SendMessage("AddScore", 100);
                    }

                    //Destroy(hitpoint.transform.gameObject); // destroy the object hit
                }


            }

            else if (GM_Script.Ammo <= 0 && GM_Script.GameOver == false)
            {
                GunEmptyEffects();
            }

            

        }
    }

    void ShootingEffects()
    {
        MuzzleFlash.Play();
        GunSounds.PlayOneShot(Gun_1, 100);
        GM_Script.SendMessage("AmmoBar", AmmoValue);
        
    }

    void GunEmptyEffects()
    {
        GunSounds.PlayOneShot(EmptyGun_1, 75);
    }
    
}