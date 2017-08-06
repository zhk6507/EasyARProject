using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class RobotManager : MonoBehaviour {
    [SerializeField]
    RectTransform menuPanel, arrows;
    [SerializeField]
    Vector2 showPosition;
    [SerializeField]
    Vector2 hidePosition;
    private Toggle robot;
	// Use this for initialization
	void Start () {
        showPosition = menuPanel.transform.localPosition;
        menuPanel.DOLocalMoveX(hidePosition.x, 0f, false);
        robot = GetComponent<Toggle>();
        robot.onValueChanged.AddListener(delegate(bool isOn)
        {
            if (isOn)
            {
                ShowMenu();
                //arrows.DOLocalRotate(new Vector3(0f, 0f, 180f), 1f, RotateMode.Fast);
            }
            else
            {
                HideMenu();
                //arrows.DOLocalRotate(new Vector3(0f, 0f, 0f), 1f, RotateMode.Fast);

            }
        });
	}

    public void ShowMenu()
    {
        Tweener tween=menuPanel.DOLocalMoveX(showPosition.x, 1.5f, false);
        tween.SetEase(Ease.InOutBack);
        arrows.DOLocalRotate(new Vector3(0f, 0f, 180f), 1f, RotateMode.Fast);
    }

    public void HideMenu()
    {
        Tweener tween = menuPanel.DOLocalMoveX(hidePosition.x, 1.5f, false);
        tween.SetEase(Ease.InOutBack);
        arrows.DOLocalRotate(new Vector3(0f, 0f, 0f), 1f, RotateMode.Fast);
    }
	
}
