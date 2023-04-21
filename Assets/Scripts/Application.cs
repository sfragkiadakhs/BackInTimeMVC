using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Element: MonoBehaviour
{
    // Gives access to application and all instances.
    public Application app { get { return GameObject.FindObjectOfType<Application>(); }}
}


public class Application : MonoBehaviour
{
    // Reference to the root instances of the MVC.
    public Model model;
    public View view;
    public Controller controller;


    // Start is called before the first frame update
    void Start()
    {
        
    }

}