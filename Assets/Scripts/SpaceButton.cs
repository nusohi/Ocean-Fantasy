using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public KeyCode keyCode = KeyCode.Space;
    private bool pressed = false;


    public void OnPointerDown(PointerEventData eventData) {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        pressed = false;
    }

    public bool BtnPressed() {
        if (pressed)
            return true;
        else
            return Input.GetKey(keyCode);
    }
}
