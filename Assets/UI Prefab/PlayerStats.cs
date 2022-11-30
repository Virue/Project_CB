using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    PlayerController playerController;
    //use for Visual bits for bars on top left corner
    public GameObject hpBar;
    public float health;
    public RectTransform hpTran;
    public GameObject mpBar;
    public RectTransform mpTran;
    public TextMeshProUGUI ammoCountText;
    public bool acceptBoon;
    //use for Visual bits for bars on top left corner
    public TextMeshProUGUI moveSpeedText;
    public TextMeshProUGUI DMGREDText;
    public TextMeshProUGUI VulnText;
    public TextMeshProUGUI LuckText;
    public TextMeshProUGUI LifeStealText;
    public TextMeshProUGUI ManaSapText;
    public TextMeshProUGUI DoubleStrikeText;


    // Start is called before the first frame update
    void Start()
    {
        playerController = new PlayerController();
        hpTran = hpBar.GetComponent<RectTransform>();
        mpTran = mpBar.GetComponent<RectTransform>();
        ammoCountText.text= playerController.ammoCount.ToString() + "/" + playerController.ammoCountMax.ToString();

        moveSpeedText.text = "MoveSpeed: "+playerController.Player_MS.ToString();
        DMGREDText.text = "Armor: " + playerController.Player_DR.ToString() + "%";
        VulnText.text = "Vuln: " + playerController.Player_Vuln.ToString() + "%";
        LuckText.text = "Luck: " + playerController.Player_Luck.ToString();
        LifeStealText.text = "LifeSteal: " + playerController.Player_LifeSteal.ToString();
        ManaSapText.text = "ManaSap: " + playerController.Player_ManaSap.ToString();
        DoubleStrikeText.text = "Double Strike: " + playerController.Player_DS.ToString()+"%";

    }
    public void AcceptBoon(bool response)
    {
        if (response)
        {
           acceptBoon = true;
        }
        else
        {
            acceptBoon = false;
        }


    }
    public float ReturnStat(string name)
    {
        if (name == "Player_Min_MP") { return playerController.Player_Min_MP; }
        if (name == "Player_Max_MP") { return playerController.Player_Max_MP; }
        if (name == "Player_Min_HP") { return playerController.Player_Min_HP; }
        if (name == "Player_Max_HP") { return playerController.Player_Max_HP; }
        if (name == "ammoCount") { return playerController.ammoCount; }
        if (name == "ammoCountMax") { return playerController.ammoCountMax; }
        if (name == "Player_DR") { return playerController.Player_DR; }
        if (name == "Player_Vuln") { return playerController.Player_Vuln; }
        if (name == "Player_Luck") { return playerController.Player_Luck; }
        if (name == "Player_LifeSteal") { return playerController.Player_LifeSteal; }
        if (name == "Player_ManaSap") { return playerController.Player_ManaSap; }
        if (name == "Player_DS") { return playerController.Player_DS; }
        if (name == "Player_MS") { return playerController.Player_MS; }
        if (name == "Player_MPR") { return playerController.Player_MPR; }
        if (name == "Player_ManaCost") { return playerController.Player_ManaCost; }
        if (name == "Player_Burn") { return playerController.Player_Burn; }
        if (name == "Player_Slow") { return playerController.Player_Slow; }
        else
        {
            return 0;
        }
    }
    public void SetStat(string name,float value)
    {
        if (name == "Player_Min_MP")
        { playerController.Player_Min_MP = value; }
        if (name == "Player_Max_MP")
        { playerController.Player_Max_MP = value; }
        if (name == "Player_Min_HP")
        { playerController.Player_Min_HP = value; }
        if (name == "Player_Max_HP")
        { playerController.Player_Max_HP = value; }
        if (name == "ammoCount")
        { playerController.ammoCount = value; }
        if (name == "ammoCountMax")
        { playerController.ammoCountMax = value; }
        if (name == "Player_DR")
        { playerController.Player_DR = value; }
        if (name == "Player_Vuln")
        { playerController.Player_Vuln = value; }
        if (name == "Player_Luck")
        { playerController.Player_Luck = value; }
        if (name == "Player_LifeSteal")
        { playerController.Player_LifeSteal = value; }
        if (name == "Player_ManaSap")
        { playerController.Player_ManaSap = value; }
        if (name == "Player_DS")
        { playerController.Player_DS = value; }
        if (name == "Player_MS")
        { playerController.Player_MS = value; }
        if (name == "Player_MPR")
        { playerController.Player_MPR = value; }
        if (name == "Player_ManaCost")
        { playerController.Player_ManaCost = value; }
        if (name == "Player_Burn")
        { playerController.Player_Burn = value; }
        if (name == "Player_Slow")
        { playerController.Player_Slow = value; }
    }
    // Update is called once per frame
    void Update()
    {
        health = playerController.Player_Min_HP;
        if (playerController.Player_Min_HP != playerController.Player_Max_HP)
        {
            hpTran.localScale = new Vector3(playerController.Player_Min_HP / (float)playerController.Player_Max_HP, 1f, 1f);
        }
        if (playerController.Player_Min_MP != playerController.Player_Max_MP)
        {
            mpTran.localScale = new Vector3(playerController.Player_Min_MP / (float)playerController.Player_Max_MP, 1f, 1f);
        }
    }
}
