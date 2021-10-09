using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject ropeAttatchment;
    public float maxDistance = 0.3f;

    public bool maxPull = false;

    private Vector3 offset;
    private float zCoord;

    [Header("MaxMovement")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = zCoord;
        mousePoint.y = 0;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        var newPos = GetMouseWorldPos() + offset;
        
        if (newPos.x <= minX || newPos.x >= maxX)
        {
            float xPos = Mathf.Clamp(newPos.x, minX + 0.1f, maxX);
            newPos = new Vector3(xPos, newPos.y, newPos.z);
        }

        transform.position = newPos;


    }

   
}
