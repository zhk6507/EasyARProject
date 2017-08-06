using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ShoeORHideSlider : MonoBehaviour{
    [SerializeField]
    RectTransform panel;

    [SerializeField]
    Vector2 showPosition,hidePosition;

    private bool isShow = false;


    void Start()
    {
        showPosition = panel.transform.localPosition;
        hidePosition = new Vector2(panel.localPosition.x, panel.localPosition.y - panel.rect.height);
        HidePanel();
    }


    void Update()
    {
        if(Input.GetTouch(0).phase==TouchPhase.Began)
        //if (Input.GetMouseButtonDown(0))
        {
            isShow = !isShow;
            if (isShow)
             {
               ShowPanel();
             }
            else
            {
               HidePanel();
            }
        }
    }


    void ShowPanel()
    {
        Tweener tween = panel.DOLocalMoveY(showPosition.y, 1.5f, false);
        tween.SetEase(Ease.InOutBack);
    }


    void HidePanel()
    {
        Tweener tween = panel.DOLocalMoveY(hidePosition.y, 1.5f, false);
        tween.SetEase(Ease.InOutBack);
    }
}
