using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OptionsSelected : MonoBehaviour
{

    public void Selected(){
        string  text =  GameObject.Find("application/view/BoardCanvas/RulePanel/SetRules/Dropdown").GetComponent<TMP_Dropdown>().captionText.text;
        GameObject inputField = GameObject.Find("application/view/BoardCanvas/RulePanel/InputField");


        if(text == "No Action"){
            inputField.SetActive(false);
        }
        else if(text == "Move") {
            inputField.SetActive(true);
            inputField.GetComponent<TMP_InputField>().text = "";

        }
        else if(text == "Loose Turn") {
            inputField.SetActive(false);

        }
        else if(text == "Get extra Turn") {
            inputField.SetActive(false);

        }
    }
}
