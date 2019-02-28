using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameManager_Script : MonoBehaviour
{

    public int Score;
    public int bullets;
    public GameObject Plane;
    public float yvalue;

    public Vector3 BulletVelocity;

    public float Ammo;
    

    // Start is called before the first frame update
    void Start()
    {
        Ammo = 100;
       
    }

    // Update is called once per frame
    void Update()
    {
        bool focusModeSet = CameraDevice.Instance.SetFocusMode(
    CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

        if (!focusModeSet)
        {
            Debug.Log("Failed to set focus mode (unsupported mode).");
        }


        yvalue = GameObject.Find("Game_Manager").transform.position.y;
    }

    void AddScore(int NewScore)
    {
        Score += NewScore;
    }

    void AmmoBar(float ammo)
    {
        Ammo -= ammo;
    }
}
