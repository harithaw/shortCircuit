using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class DrawLineScript : MonoBehaviour
{
    public Color LineColor;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.SetColors(LineColor, LineColor);
    }

    // Start is called before the first frame update
    void Start()
    {
        //lineRen.SetPosition(lineRen.positionCount++, new Vector3(0, 0, 0));
        //lineRen.SetPosition(lineRen.positionCount++, new Vector3(1, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            lineRenderer.SetPosition(lineRenderer.positionCount++, worldPosition);
        }
    }
}
