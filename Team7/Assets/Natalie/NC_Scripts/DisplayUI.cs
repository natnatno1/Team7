using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class DisplayUI : MonoBehaviour
{
    public int scene;
    public Canvas MenuButtons;
    public Canvas GunCanvas;
    public Canvas UICanvas;
    public Canvas HighScoreCanvas;
    public GameManager_Script GM_Script;
    public HighScores HS;
    public bool CameraPrompt_;
    public GameObject CameraPrompt;




    // Start is called before the first frame update
    void Start()
    {
        //HighScoreCanvas = GameObject.Find("High_Score").GetComponent<Canvas>();
        GM_Script = gameObject.GetComponent<GameManager_Script>();
        MenuButtons = GameObject.Find("Menu_Buttons").GetComponent<Canvas>();
        GunCanvas = GameObject.Find("GunCanvas").GetComponent<Canvas>();
        UICanvas = GameObject.Find("UI").GetComponent<Canvas>();
        //HS = GameObject.Find("High_Score").GetComponent<HighScores>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        scene = SceneManager.GetActiveScene().buildIndex;

        if (scene == 0)
        {
            MenuButtons.enabled = true;
            GunCanvas.enabled = false;
            UICanvas.enabled = false;
            //HighScoreCanvas.enabled = false;
        }

        else if (scene == 1)
        {
            MenuButtons.enabled = false;
            GunCanvas.enabled = true;
            UICanvas.enabled = true;
            

        }

        else if (scene == 2)
        {
            MenuButtons.enabled = false;
            GunCanvas.enabled = false;
            UICanvas.enabled = false;
            //HighScoreCanvas.enabled = true;

        }

    }
}
