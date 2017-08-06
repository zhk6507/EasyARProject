using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShowPart : MonoBehaviour {
    [SerializeField]
    List<GameObject> parts;
    [SerializeField]
    GameObject model_Camera;
	// Use this for initialization
	void Start () {
        
        GetComponent<Button>().onClick.AddListener(delegate
        {
            //GetComponentInChildren<Text>().text=
            Show();
        });
	}

    private void Show()
    {
        for (int i = 0; i < parts.Count; i++)
        {
            if (parts[i].gameObject.name==GetComponentInChildren<Text>().text)
            {
                parts[i].SetActive(true);
                model_Camera.GetComponent<MoveCameraByMouse>().SetTarget(parts[i]);
            }
            else
            {
                parts[i].SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
