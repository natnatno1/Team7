using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class UI_Behaviour : MonoBehaviour
{
    public GameManager_Script GM_Script;
    public Text AmmoPercentage;
    public float AmmoLeft;
    public Text HealthPercentage;
    public float HealthLeft;
    public GameObject HealthBar;
    public GameObject AmmoBar;
    public Text Score;
    public RawImage GameOver;
    public RawImage PlaceCameraPrompt;
    public GameObject City;
    public int scene;
    public GameObject GameOverButtons;

    

    // Start is called before the first frame update
    void Start()
    {

        GM_Script = GetComponentInParent<GameManager_Script>();
        AmmoPercentage = GameObject.Find("AmmoBars").GetComponentInChildren<Text>();
        HealthPercentage = GameObject.Find("HealthBars").GetComponentInChildren<Text>();
        GameOver = GameObject.Find("GameOver").GetComponent<RawImage>();
        GameOverButtons = GameObject.Find("GameOverButtons");


        GameOver.color = new Color(0, 0, 0, 0);
        GameOver.GetComponentInChildren<Text>().enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        
        if (GM_Script.Health > 0)
        {
            GameOver.color = new Color(0, 0, 0, 0);
            GameOver.GetComponentInChildren<Text>().enabled = false;
            GameOverButtons.SetActive(false);
            GM_Script.GameOver = false;
            GameObject.Find("Game_Manager/UI/GameOverButtons").SetActive(false);
        }

        if (scene == 1)
        {

            if (GM_Script.CameraPrompt_ == false)
            {
                PlaceCameraPrompt.color = new Color(225, 225, 225, 225);

            }

            else if (GM_Script == true)
            {
                PlaceCameraPrompt.color = new Color(0, 0, 0, 0);
            }

            AmmoLeft = GM_Script.Ammo;

            AmmoPercentage.text = "Ammo:" + AmmoLeft.ToString();

            AmmoBar.transform.localScale = new Vector3(1, (AmmoLeft / 100), 1);

            HealthLeft = GM_Script.Health;

            HealthPercentage.text = "Health:" + HealthLeft.ToString();

            HealthBar.transform.localScale = new Vector3(1, (HealthLeft / 100), 1);

            Score.text = "Score:" + GM_Script.Score.ToString();

            

            if (GM_Script.GameOver == false)
            {
                GameOver.color = new Color(0, 0, 0, 0);
                GameOver.GetComponentInChildren<Text>().enabled = false;
                GameOverButtons.SetActive(false);
            }

            else if (GM_Script.GameOver == true)
            {
                GameOver.color = new Color(225, 225, 225, 225);
                GameOver.GetComponentInChildren<Text>().enabled = true;
                GameOverButtons.SetActive(true);
                Time.timeScale = 0;
                HealthLeft = 0;


            }
        }

       
    }

       


}
