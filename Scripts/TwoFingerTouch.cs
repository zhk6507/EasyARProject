using UnityEngine;
using System.Collections;

public class TwoFingerTouch : MonoBehaviour
{
    Vector3 initLoacalScale;
	// Use this for initialization
	void Start () {
        initLoacalScale = transform.localScale;
	}
	void OnDisable()
    {
        transform.localScale = initLoacalScale;
    }
	// Update is called once per frame
	void Update () {
        #region 双指缩放
        if (Input.touchCount == 2 && transform.localScale.x > 0)
        {
            TwoFingerScale();
        }
        else
        {
            Distance_now = 0; Distance_last = 0;//若不是双指触屏，则重置双指距离
        }
        #endregion
	
	}
    float dis;
    float Distance_now, Distance_last;

    void TwoFingerScale()
    {
        if (transform.localScale.x > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Distance_now = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                dis = Distance_now - Distance_last;

                if (Distance_last != 0)
                {
                    transform.localScale *= (1 + dis / 300);
                }

                Distance_last = Distance_now;

                if (transform.localScale.x > initLoacalScale.x*3.5f)
                {

                    transform.localScale = new Vector3(initLoacalScale.x * 3.5f, initLoacalScale.y * 3.5f, initLoacalScale.z * 3.5f);
                }
                else if (transform.localScale.x < initLoacalScale.x)
                {
                    transform.localScale = initLoacalScale;
                    //transform.localScale = new Vector3(initLoacalScale.x, initLoacalScale.y, initLoacalScale.z);
                }
            }
        }
    }
    
}
