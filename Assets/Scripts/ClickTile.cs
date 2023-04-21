using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickTile : MonoBehaviour
{
    // Start is called before the first frame update
    public int Tilenumber;
    public GameObject rulePanel;
    void Start()
    {
        
        rulePanel = GameObject.Find("application/view/BoardCanvas/RulePanel");
    }

    void OnMouseUp(){

        rulePanel.SetActive(true);
        PlayerPrefs.SetInt("editRuleId", Tilenumber);

        GameObject.Find("application/view/BoardCanvas/RulePanel/TileId").GetComponent<TMP_Text>().text = "tile "+Tilenumber;


    }
}
