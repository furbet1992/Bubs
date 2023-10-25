using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragImage : MonoBehaviour
{
    //List that contains all the images to be selected
    //public List<GameObject> luckyCharms= new List<GameObject>(); 
    private bool isDragActive = false;

    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private Draggable lastDragged;


     void Awake()
    {
        DragImage[] controller = FindObjectsOfType<DragImage>(); 
        if(controller.Length > 1)
        {
            Destroy(gameObject);  
        }
    }
    void Update()
    {
        if(isDragActive && (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return; 
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position; 
        }
        else
        {
            return; 
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isDragActive)
        {
            Drag(); 
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    lastDragged = draggable;
                    InitialDrag(); 
                }
            }
        }
    }

    void InitialDrag()
    {
        isDragActive = true;
    }

    void Drag()
    {
        lastDragged.transform.position = new Vector3(worldPosition.x, worldPosition.y);
    }

    void Drop()
    {
        isDragActive = false; 
    }
}
