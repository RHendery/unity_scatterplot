using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hudmanager : MonoBehaviour {

    public Text name_text;

    private string testname = "Temp";

	// Use this for initialization
	void Start () {

        name_text.text = "Name: " + testname;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
