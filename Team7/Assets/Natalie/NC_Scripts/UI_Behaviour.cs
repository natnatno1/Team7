using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Behaviour : MonoBehaviour
{
    public GameManager_Script GM_Script;
    public Text AmmoPercentage;
    public float AmmoLeft;

    public GameObject AmmoBar;
    public Text Score;


    // Start is called before the first frame update
    void Start()
    {
        GM_Script = GetComponentInParent<GameManager_Script>();
        AmmoPercentage = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        AmmoLeft = GM_Script.Ammo;

        AmmoPercentage.text = "Ammo:" + AmmoLeft.ToString();

        AmmoBar.transform.localScale = new Vector3(1, (AmmoLeft/100), 1);

        Score.text = "Score:" + GM_Script.Score.ToString();

    }


}
