using UnityEngine;
using System.Collections;

public class SelfRotat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(1.0f, 0.5f, 0f));
	}
}
