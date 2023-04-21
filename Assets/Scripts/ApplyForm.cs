using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ApplyForm : MonoBehaviour
{
    public int ApplyTileId;
    public Button Apply;
    public GameObject inputField;
    public GameObject dropDown;

    // Start is called before the first frame update
    void Start()
    {
        Apply = GameObject.Find("application/view/BoardCanvas/RulePanel/ApplyRule").GetComponent<Button>();
        inputField = GameObject.Find("application/view/BoardCanvas/RulePanel/InputField");
        dropDown =  GameObject.Find("application/view/BoardCanvas/RulePanel/SetRules/Dropdown");

        Apply.onClick.AddListener(onApplyClick);
    }

    void onApplyClick(){
        ApplyTileId = PlayerPrefs.GetInt("editRuleId");

        Controller controller = GameObject.FindObjectOfType<Controller>();                 //need to set the rules , getTileController??? No idea
        TileModel tilemodel = controller.getTileController().getTileModel();

        string  dropDownText =  dropDown.GetComponent<TMP_Dropdown>().captionText.text;    //current Option selected


        Debug.Log(dropDownText);

        if(dropDownText == "No Action"){
            // No action
        }
        else if(dropDownText == "Move") {
            string text = inputField.GetComponent<TMP_InputField>().text;
            Debug.Log(text);
            tilemodel.getTiles().setRule(ApplyTileId,text);

        }
        else if(dropDownText == "Loose Turn") {
            tilemodel.getTiles().setRule(ApplyTileId,"stop");
        }
        else if(dropDownText == "Get extra Turn") {
            tilemodel.getTiles().setRule(ApplyTileId,"extra");
        }

        GameObject.Find("application/view/BoardCanvas/RulePanel").SetActive(false);
        ClearFields();
    
    }

    void ClearFields(){
        inputField.GetComponent<TMP_InputField>().text = "";
        dropDown.GetComponent<TMP_Dropdown>().value = 0;

    }
}
