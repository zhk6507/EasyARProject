using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class touchControl1 : MonoBehaviour {

    public Camera 模型相机;

    float x, y;
    float speed = 5;

    void Update()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            x = 0; y = 0;
        }

        #region 旋转
        if (Input.GetMouseButton(0) && transform.localScale.x > 0)
        {
            旋转();
        }
        #endregion

        #region 双指缩放
        if (Input.touchCount == 2 && transform.localScale.x > 0)
        {
            双指缩放();
        }
        else
        {
            Distance_now = 0; Distance_last = 0;//若不是双指触屏，则重置双指距离
        }
        #endregion

        //影子.position = transform.position - new Vector3(0, 0.3f, 0);
    }

    private bool Moving;
    Vector3 vec, 偏移量;
    //int LongPress;
    void OnMouseDrag()
    {
        #region 长按触发
        //if (vec == 模型相机.WorldToScreenPoint(transform.position))
        //{
        //    LongPress++;
        //    if (LongPress > 60)
        //    {
        //        Debug.Log("长按~~~~~~");
        //        Eve_长按();
        //        LongPress = 0;
        //    }
        //}
        //else
        //{
        //    LongPress = 0;
        //}
        #endregion

        #region 拖拽移动

        if (transform.localScale.x > 0)
        {
            Moving = true;
            vec = 模型相机.WorldToScreenPoint(transform.position);
            if (偏移量 == Vector3.zero)
            {
                偏移量 = vec - Input.mousePosition;
            }
            transform.position = 模型相机.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 偏移量.x, Input.mousePosition.y + 偏移量.y, vec.z));
        }

        #endregion
    }
    void OnMouseUp()
    {
        Moving = false;
        偏移量 = Vector3.zero;
    }
    void 旋转()
    {
        if (!Moving)
        {
            transform.Rotate(0, -x * speed, 0, Space.World);
            transform.Rotate(0, 0, y * speed, Space.World);
        }
    }

    float dis;
    float Distance_now, Distance_last;

    void 双指缩放()
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

                if (transform.localScale.x > 3.5f)
                {
                    transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
                }
                else if (transform.localScale.x < 1f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
        }
    }
}
