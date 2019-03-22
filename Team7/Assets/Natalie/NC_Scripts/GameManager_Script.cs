using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{

    public int Score;
    public int bullets;
    public GameObject Plane;
    public float yvalue;

    public Vector3 BulletVelocity;

    public float Ammo;
    public float Health;

    public bool GameOver;

    public int Scene;

    public List<int> HighScore = new List<int>();
    public List<string> PlayerName = new List<string>();

    public int NewHighScore;
    public int PlayerNameInt;
    public bool isplayerinputactive = true;
    public string NewPlayerName;
    public bool HighScore4;
    public bool HighScore3;
    public bool HighScore2;
    public bool HighScore1;
    public bool HighScore0;
    public bool CameraPrompt_;


    public void Awake()
    {
        // Make sure that this game object is not destroyed when the next scene is loaded
        DontDestroyOnLoad(this);

        // Check if there are any more of this game object in the scene
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // If yes, then destroy this game object
            Destroy(gameObject);
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        Ammo = 100;
        Health = 100;
        GameOver = false;
        PlayerNameInt = 5;
        Score = 0;

        // Add default high scores to the "HighScore" list
        HighScore.Add(3000);
        HighScore.Add(2000);
        HighScore.Add(1000);
        HighScore.Add(500);
        HighScore.Add(200);

        // Add default player names to the "PlayerName" list
        PlayerName.Add("Natalie");
        PlayerName.Add("Matt");
        PlayerName.Add("Jimi");
        PlayerName.Add("Calamity");
        PlayerName.Add("Riley");

        // Add an extra player name list which will not be shown
        PlayerName.Add("");



    }

    // Update is called once per frame
    void Update()
    {
        Scene = SceneManager.GetActiveScene().buildIndex;
        

       if (Scene == 1)
        {

            bool focusModeSet = CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

            if (!focusModeSet)
            {
                Debug.Log("Failed to set focus mode (unsupported mode).");
            }


            yvalue = GameObject.Find("Game_Manager").transform.position.y;

            if (Health == 0)
            {
                GameOver = true;

            }

            if (Health < 0)
            {
                GameOver = true;
                Health = 0;
            }

            // Check if the HighScore variable is more than or equal to the 4th value in the HighScore list
            if (Score >= HighScore[4])
            {
                // If yes, set the NewHighScore to the Score value
                NewHighScore = Score;
            }

            if (NewHighScore >= HighScore[0])
            {
                HighScore0 = true;
                HighScore1 = false;
                HighScore2 = false;
                HighScore3 = false;
                HighScore4 = false;
            }

            else if (NewHighScore >= HighScore[1])
            {
                HighScore0 = false;
                HighScore1 = true;
                HighScore2 = false;
                HighScore3 = false;
                HighScore4 = false;
            }

            else if (NewHighScore >= HighScore[2])
            {
                HighScore0 = false;
                HighScore1 = false;
                HighScore2 = true;
                HighScore3 = false;
                HighScore4 = false;

            }

            else if (NewHighScore >= HighScore[3])
            {
                HighScore0 = false;
                HighScore1 = false;
                HighScore2 = false;
                HighScore3 = true;
                HighScore4 = false;
            }

            else if (NewHighScore >= HighScore[4])
            {
                HighScore0 = false;
                HighScore1 = false;
                HighScore2 = false;
                HighScore3 = false;
                HighScore4 = true;
            }

            else
            {
                HighScore0 = false;
                HighScore1 = false;
                HighScore2 = false;
                HighScore3 = false;
                HighScore4 = false;
            }

        }
       

       if (GameOver == true)
        {
            // Check if the HighScore variable is more than or equal to the 4th value in the HighScore list
            if (Score >= HighScore[4])
            {
                // If yes, set the NewHighScore to the Score value
                NewHighScore = Score;
            }

            HighScores();
        }
       

        
        
    }

    void AddScore(int NewScore)
    {
        Score += NewScore;
    }

    void AmmoBar(float ammo)
    {
        Ammo -= ammo;
    }

    void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }


    void HighScores()
    {
        // If the current score is higher than the 0 value in the HighScore list
        if (HighScore[0] <= NewHighScore && HighScore0 == true)
        {
            // If yes, then set each entry of the HighScore list after the 0 entry to the next one
            HighScore[4] = HighScore[3];
            HighScore[3] = HighScore[2];
            HighScore[2] = HighScore[1];
            HighScore[1] = HighScore[0];

            // Set the 0 entry of the HighScore list to the new score
            HighScore[0] = NewHighScore;

            // Set each entry of the PlayerName list after the 0 entry to the next one 
            PlayerName[4] = PlayerName[3];
            PlayerName[3] = PlayerName[2];
            PlayerName[2] = PlayerName[1];
            PlayerName[1] = PlayerName[0];

            // Set the 0 entry of the PlayerName list to nothing
            PlayerName[0] = "";

            // Set the PlayerNameInt variable to 0
            PlayerNameInt = 0;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;

            HighScore0 = false;

            
        }

        // If the current score is not equal or higher than the 0 value in the HighScore list, then check if the current scoreis equal or higher than the 1st entry in the HighScore list
        else if (HighScore[1] <= NewHighScore && HighScore1 == true)
        {
            // If yes, then set each entry of the HighScore list after the 1st entry to the next one
            HighScore[4] = HighScore[3];
            HighScore[3] = HighScore[2];
            HighScore[2] = HighScore[1];

            // Set the 1st entry of the HighScore list to the current score
            HighScore[1] = NewHighScore;

            // Seteach entry of the PlayerName list after the 1st entry to the next one 
            PlayerName[4] = PlayerName[3];
            PlayerName[3] = PlayerName[2];
            PlayerName[2] = PlayerName[1];

            // Set the 1st entry of the PlayerName list to nothing
            PlayerName[1] = "";

            // Set the PlayerNameInt variable to 1
            PlayerNameInt = 1;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;

            HighScore1 = false;
        }

        // If the current score is not equal or higher than the 1st value in the HighScore list, then check if the current score is equal or higher than the 2nd entry in the HighScore list
        else if (HighScore[2] <= NewHighScore && HighScore2 == true)
        {
            // If yes, then set each entry of the HighScore list after the 2nd entry to the next one
            HighScore[4] = HighScore[3];
            HighScore[3] = HighScore[2];

            // Set the 2nd entry in the HighScore list to the current score
            HighScore[2] = NewHighScore;

            // Set each entry of the PlayerName list after the 2nd entry to the next one
            PlayerName[4] = PlayerName[3];
            PlayerName[3] = PlayerName[2];

            // Set the 2nd entry in the PlayerName list to nothing
            PlayerName[2] = "";

            // Set the PlayerNameInt variable to 2;
            PlayerNameInt = 2;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;

            HighScore2 = false;
        }

        // If the current score is not equal or higher than the 2nd value in the HighScore list, then check if the current score is equal or higher than the 3rd entry in the HighScore list
        else if (HighScore[3] <= NewHighScore && HighScore3 == true)
        {
            // If yes, then set each entry of the HighScore list after the 3rd entry to the next one
            HighScore[4] = HighScore[3];

            // Set the 3rd entry in the HighScore list to the current score
            HighScore[3] = NewHighScore;

            // Set each entry in the PlayerName list after the 3rd entry to the next one
            PlayerName[4] = PlayerName[3];

            // Set the 3rd entry in the PlayerName list to nothing
            PlayerName[3] = "";

            // Set the PlayerNameInt variable to 3
            PlayerNameInt = 3;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;

            HighScore3 = false;

        }

        // If the current score is not equal or higher than the 3rd value in the HighScore list, then check if the current score is equal or higher than the 4th entry in the HighScore list
        else if (HighScore[4] <= NewHighScore && HighScore4 == true)
        {
            // If yes, then set the 4th entry in the HighScore list to the current score
            HighScore[4] = NewHighScore;

            // Set the 4th entry in the PlayerName list to nothing
            PlayerName[4] = "";

            // Set the PlayerNameInt variable to 4
            PlayerNameInt = 4;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;

            HighScore4 = false;
        }

        // If the current score is less than the last vakue in the HighScore list
        else if (HighScore[4] > NewHighScore)
        {
            // If there is no new high score, set the PlayerNameInt variabe to 5 (so that it is set, but won't be seen)
            PlayerNameInt = 5;

            // Set the isplayeractive boolean to false
            isplayerinputactive = false;

        }

    }

}
