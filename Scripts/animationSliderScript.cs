using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class animationSliderScript : MonoBehaviour
{



    public GameObject targetGameobject;

    public Slider sliderTest;

    private string animationName = "Take 001";

    private float animationlength = 0;

    private int animationFrame = 0;

    private float tempValue = 0;

    public bool animIsPlay = false;

    void Start()
    {
        //targetGameobject.GetComponent<Animation>().Play();
        targetGameobject.GetComponent<Animation>().wrapMode = WrapMode.ClampForever;
        targetGameobject.GetComponent<Animation>().Stop();
        //animationlength = targetGameobject.GetComponent<Animation>()[animationName].length;
        sliderTest.onValueChanged.AddListener(delegate
        {
            sliderChange();
        });

    }

    void Update()
    {
        if (animIsPlay)
        {

            if (sliderTest.value < 1)
            {
                sliderTest.value += Time.deltaTime*0.5f;
                targetGameobject.GetComponent<Animation>()[animationName].normalizedTime = sliderTest.value ;
            }
        }
    }
    void OnDisable()
    {
        AnimtionReset();
    }

    public void sliderChange()
    {
        float valueTemp = sliderTest.value;

        targetGameobject.GetComponent<Animation>()[animationName].normalizedTime = valueTemp ;
        //Debug.Log(valueTemp);
        //targetGameobject.GetComponent<Animation>()[animationName].speed = 0;
    }
    public void AnimationStop()
    {
        targetGameobject.GetComponent<Animation>()[animationName].normalizedTime = sliderTest.value ;
        targetGameobject.GetComponent<Animation>()[animationName].speed = 0;
        animIsPlay = false;
        Debug.Log("停止");
    }
    
    public void AnimationStart()
    {
        targetGameobject.GetComponent<Animation>().Play();
        targetGameobject.GetComponent<Animation>()[animationName].speed = 1;
        animIsPlay = true;
        Debug.Log("开始");
    }

    public void AnimtionReset()
    {
        sliderTest.value = 0;
        targetGameobject.GetComponent<Animation>()[animationName].normalizedTime = 0;
        targetGameobject.GetComponent<Animation>()[animationName].speed = 0;
        animIsPlay = false;
    }
}