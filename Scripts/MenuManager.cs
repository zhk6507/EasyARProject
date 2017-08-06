using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Toggle zhengti, chaizhuang;
    [SerializeField]
    GameObject sliderPanel_gamobj;
    [SerializeField]
    Text chaizhuangText, zhengtiText;
    [SerializeField]
    List<GameObject> lingjianIamges;
    [SerializeField]
    MoveCameraByMouse model_Cameras;
    // Use this for initialization
    void Start()
    {
        chaizhuang.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                sliderPanel_gamobj.GetComponent<VideoCtrol>().AnimStart();
                chaizhuangText.color = Color.white;
            }
            else
            {
                sliderPanel_gamobj.GetComponent<VideoCtrol>().AnimReset();
                chaizhuangText.color = Color.black;
            }
            sliderPanel_gamobj.SetActive(isOn);

        });
        zhengti.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                zhengtiText.color = Color.white;
                zhengtiText.text = "整体";
            }
            else
            {
                zhengtiText.color = Color.black;
                zhengtiText.text = "零件";
                //显示整体
                sliderPanel_gamobj.GetComponent<VideoCtrol>().model.transform.localScale = sliderPanel_gamobj.GetComponent<VideoCtrol>().initModelScale;
                model_Cameras.SetTarget(sliderPanel_gamobj.GetComponent<VideoCtrol>().model);
                model_Cameras.pers();

            }
            for (int i = 0; i < lingjianIamges.Count; i++)
            {
                lingjianIamges[i].SetActive(isOn);
            }
        });
    }
}
