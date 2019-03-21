using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPrompt : MonoBehaviour
{

    public bool Prompt;
    public GameManager_Script GM_Script;

    // Start is called before the first frame update
    void Start()
    {
        GM_Script = GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<MeshCollider>().enabled == true)
        {
            GM_Script.CameraPrompt_ = true;
        }

        else if (this.GetComponent<MeshCollider>().enabled == false)
        {
            GM_Script.CameraPrompt_ = false;
        }
    }
}
