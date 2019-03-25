using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image bgImg;
    private Image fgImg;
    private Vector3 inputPoint;


    void Start() {
        bgImg = this.GetComponent<Image>();
        fgImg = transform.GetChild(0).GetComponent<Image>();
    }

    
    public void OnDrag(PointerEventData eventData) {

        Vector2 localPoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
            , eventData.position
            , eventData.pressEventCamera
            , out localPoint
            )) {

            // 计算坐标点
            localPoint.x /= bgImg.rectTransform.sizeDelta.x;
            localPoint.y /= bgImg.rectTransform.sizeDelta.y;

            inputPoint = new Vector3(localPoint.x * 2, 0, localPoint.y * 2);
            inputPoint = inputPoint.magnitude > 1.0f
                ? inputPoint.normalized
                : inputPoint;
            // 移动JoyStick按钮
            fgImg.rectTransform.localPosition =
                new Vector3(
                    inputPoint.x * bgImg.rectTransform.sizeDelta.x / 2,
                    inputPoint.z * bgImg.rectTransform.sizeDelta.y / 2,
                    0);

        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Reset();
    }

    public float Horizontal() {
        if (inputPoint.x != 0f)
            return inputPoint.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical() {
        if (inputPoint.z != 0f)
            return inputPoint.z;
        else
            return Input.GetAxis("Vertical");
    }

    public void Reset() {
        inputPoint.x = 0;
        inputPoint.z = 0;
        fgImg.rectTransform.localPosition = inputPoint;
    }

}
