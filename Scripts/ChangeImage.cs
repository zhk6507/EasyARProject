using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Button btn;
    public Sprite[] sprits;
    public bool isOn = false;
	// Use this for initialization
	void Start () {
        btn.onClick.AddListener(delegate
        {
            OnClick_Btn();
        });
	}
	
	// Update is called once per frame
	void Update () {
        if (isOn)
        {
            this.GetComponentInChildren<Image>().sprite = sprits[1];
        }
        else
        {
            this.GetComponentInChildren<Image>().sprite = sprits[0];
        }
	}
    public void OnClick_Btn()
    {
        isOn = !isOn;
    }
}
