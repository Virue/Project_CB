using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    PlayerController playerController;
    //use for Visual bits for bars on top left corner
    public GameObject hpBar;
    public RectTransform hpTran;
    public GameObject mpBar;
    public RectTransform mpTran;
    public TextMeshProUGUI ammoCountText;
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

    // Update is called once per frame
    void Update()
    {
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
