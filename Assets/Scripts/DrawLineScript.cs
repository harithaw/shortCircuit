using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class DrawLineScript : MonoBehaviour
{
    public Color LineColor;
    private LineRenderer lineRenderer;

    bool isClicked = false;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.positionCount++;
    }

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && lineRenderer.positionCount > 1)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPosition);
            lineRenderer.positionCount++;

            lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPosition);

            isClicked = false;

        }
        
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;

            if (lineRenderer.positionCount == 1)
            {
                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPosition);
                lineRenderer.positionCount++;

                lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPosition);
            }
        }

        if (isClicked)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);


            lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPosition);
        }
    }
}
