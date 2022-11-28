using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoonUI : MonoBehaviour
{
    BoonStats boonStats;

    public TextMeshProUGUI blessing;
    public TextMeshProUGUI curse;

    // Start is called before the first frame update
    void Start()
    {
        boonStats = gameObject.AddComponent<BoonStats>();
        blessing.text = "Blessing goes here: " + boonStats.getBlessing();
        curse.text = "Curse Goes here" + boonStats.getCurse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
