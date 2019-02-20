using UnityEngine;
using System.Collections;

public class CanvasRotate : MonoBehaviour {

    Transform cameraTransform;
	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
	}
}
