using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public int NewHighScore;
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text Score4;
    public Text Score5;
    public InputField InputPlayerName;
    public Text YourName;
    public string PlayerName;
    public int PlayerNameInt;
    public GameManager_Script GM_Script;

    // Start is called before the first frame update
    void Start()
    {
        GM_Script = GameObject.Find("Game_Manager").GetComponent<GameManager_Script>();

        // Set the PlayerNameInt variable to the PlayerNameInt variable from the Game Manager script
        PlayerNameInt = GM_Script.PlayerNameInt;

        // Add the entries from the HighScore list in the Game Manager to their relevent text boxes
        Score1.text = "" + GM_Script.PlayerName[0] + "- " + GM_Script.HighScore[0];
        Score2.text = "" + GM_Script.PlayerName[1] + "- " + GM_Script.HighScore[1];
        Score3.text = "" + GM_Script.PlayerName[2] + "- " + GM_Script.HighScore[2];
        Score4.text = "" + GM_Script.PlayerName[3] + "- " + GM_Script.HighScore[3];
        Score5.text = "" + GM_Script.PlayerName[4] + "- " + GM_Script.HighScore[4];

        // Set the NewPlayerName variable in the Game Manager script to what the player inputs into the Input Field
        GM_Script.NewPlayerName = InputPlayerName.text;

        // Add the new player name at the PlayerNameInt value entry in the PlayerName list to the NewPlayerName variable in the Game Manager Script
        GM_Script.PlayerName[PlayerNameInt] = GM_Script.NewPlayerName;

        // Check if the isplayerinputactive boolean in the Game Manager is true
        if (GM_Script.isplayerinputactive == false)
        {
            // If no, deactivate the input field
            InputPlayerName.gameObject.SetActive(false);

            // Deactivate the "Your Name" textbox
            YourName.gameObject.SetActive(false);
        }

        else if (GM_Script.isplayerinputactive == true)
        {
            // If yes, activate the input field
            InputPlayerName.gameObject.SetActive(true);

            // Avtivate the "Your Name" textbox
            YourName.gameObject.SetActive(true);

        }

    }
}
    