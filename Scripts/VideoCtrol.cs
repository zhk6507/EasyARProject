using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoCtrol : MonoBehaviour {
    [SerializeField]
    public GameObject model;
    public Vector3 initModelScale;
    [SerializeField]
    Button startBtn;
	// Use this for initialization
    void OnEnable()
    {
        initModelScale = model.transform.localScale;
        startBtn.onClick.AddListener(delegate
        {
            if (model.GetComponent<animationSliderScript>().animIsPlay)
            {
                AnimStop();
            }
            else
            {
                AnimStart();
            }
        });
    }
	void Start () {
        //startBtn.onClick.AddListener(delegate
        //{
        //    if (model.GetComponent<animationSliderScript>().animIsPlay)
        //    {
        //        AnimStop();
        //    }
        //    else
        //    {
        //        AnimStart();
        //    }
        //});
	}
    /// <summary>
    /// 设置当前模型方法
    /// </summary>
    /// <param name="m"></param>
    public void SetModel(GameObject m)
    {
        model = m;
        
    }
	public void AnimStop()
    {
        model.GetComponent<animationSliderScript>().AnimationStop();
    }
    public void AnimStart()
    {
        model.GetComponent<animationSliderScript>().AnimationStart(); 
    }

    public void AnimReset()
    {
        model.GetComponent<animationSliderScript>().AnimtionReset();
    }
	
}
