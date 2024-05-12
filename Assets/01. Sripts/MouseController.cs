using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    private bool isDrag = false;

    [SerializeField]
    private RectTransform selectBox;

    private Vector3 beginPos;
    private Vector3 endPos;

    private void Update()
    {
        if (isDrag)
            DrawBox();
    }

    private void OnLeftButton(InputValue value)
    {
        if(value.isPressed)
        {
            beginPos = Input.mousePosition;
            isDrag = true;
        }
        else
        {
            if(selectBox.gameObject.activeSelf)
                selectBox.gameObject.SetActive(false);

            isDrag = false;
        }
    }

    private void OnRightButton(InputValue value)
    {

    }

    private void DrawBox()
    {
        endPos = Input.mousePosition;

        if ((endPos - beginPos).sqrMagnitude < 1) return;

        selectBox.gameObject.SetActive(true);

        float width = Mathf.Abs(endPos.x - beginPos.x);
        float height = Mathf.Abs(endPos.y - beginPos.y);

        selectBox.sizeDelta = new Vector2(width, height);
        selectBox.anchoredPosition = (beginPos + endPos) / 2;
    }

    private void SelectUnit()
    {

    }
}
