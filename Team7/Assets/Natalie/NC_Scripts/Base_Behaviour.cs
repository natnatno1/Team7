using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Behaviour : MonoBehaviour
{

    public int Base_Health;
    public GameManager_Script GM_Script;


    // Start is called before the first frame update
    void Start()
    {
        Base_Health = 100;
        GM_Script = GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();
        GM_Script.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        GM_Script.Health = Base_Health;
    }
    
}
