using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseManager : MonoBehaviour
{
    RaycastHit hitInfo;

    public event Action<Vector3> OnMouseClick;

    public static MouseManager Instance;

    public Texture2D point, atk, arrow;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        Instance = this;
    }

    void Update()
    {
        SetCursorTexture();
        MouseControl();
    }

    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hitInfo))
        {
            //切换鼠标指针
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(arrow, new Vector2(0, 0), CursorMode.Auto);
                    break;
                case "Enemy":
                    Cursor.SetCursor(atk, new Vector2(0, 0), CursorMode.Auto);
                    break;
            }
        }

    }

    void MouseControl()
    {
        if(Input.GetMouseButtonDown(1) && hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
                OnMouseClick?.Invoke(hitInfo.point);
        }
    }
}
