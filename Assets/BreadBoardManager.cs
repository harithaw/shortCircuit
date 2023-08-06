using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBoardManager : MonoBehaviour
{
    public GameObject gridCell;

    public int rows;
    public int cols;

    private float X;
    private float Y;

    public float cellSize = 1.5f;

    public LineRenderer lineRenderPrefab;
    private LineRenderer currentLine;

    private LineRenderer selectedLine = null;

    public Material lineMaterial;

    private List<LineRenderer> lines = new List<LineRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        InstantiateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)//Input.GetMouseButtonDown(0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2Int clickedCell = new Vector2Int(Mathf.FloorToInt(mousePos.x / cellSize),
                Mathf.FloorToInt(mousePos.y / cellSize));

            if(touch.phase==TouchPhase.Began)
            {
                if (isValidCell(clickedCell))
                {
                    startNewLine(clickedCell);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endLine(clickedCell);
                currentLine = null;
            }
            
        }

        if(Input.touchCount > 0 && currentLine != null)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2Int currentCell = new Vector2Int(Mathf.FloorToInt(mousePos.x / cellSize),
                Mathf.FloorToInt(mousePos.y / cellSize));

            updateLinePosition(currentCell);
        }

        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

            if(hit.collider != null)
            {
                LineRenderer selectedLineRenderer = hit.collider.GetComponent<LineRenderer>();

                if(selectedLineRenderer != null)
                {
                    selectLine(selectedLineRenderer);
                }
            }
        }
    }

    void InstantiateGrid()
    {
        X = transform.position.x + rows;
        Y = transform.position.y + cols;
        for (int i= (int)transform.position.x; i < X; i++)
        {
            for (int y = (int)transform.position.y; y < Y; y++)
            {
                Vector3 cellPosition = new Vector3(i * cellSize, y * cellSize, 0);
                GameObject cell = Instantiate(gridCell, cellPosition, Quaternion.identity);
                cell.transform.SetParent(transform);
            }
        }
    }

    private bool isValidCell(Vector2Int cell)
    {
        X = transform.position.x + rows;
        Y = transform.position.y + cols;
        return cell.x >= (int)transform.position.x && cell.x < X && cell.y >= (int)transform.position.y && cell.y < Y;
    }

    private void startNewLine(Vector2Int startCell)
    {
        currentLine = Instantiate(lineRenderPrefab);
        currentLine.positionCount = 2;

        Vector3 startPos = new Vector3(startCell.x * cellSize, startCell.y * cellSize, -1f);
        currentLine.SetPosition(0, startPos);
        currentLine.SetPosition(1, startPos);

        currentLine.material = lineMaterial;

        lines.Add(currentLine);
    }

    private void updateLinePosition(Vector2Int endCell)
    {
        Vector3 endPos = new Vector3(endCell.x * cellSize, endCell.y * cellSize, -1f);
        currentLine.SetPosition(1, endPos);
    }

    private void endLine(Vector2Int endCell)
    {
        Vector3 endPos = new Vector3(endCell.x * cellSize, endCell.y * cellSize, -1f);
        currentLine.SetPosition(1, endPos);
    }

    public void clearAllLines()
    {
        LineRenderer[] lines = FindObjectsOfType<LineRenderer>();
        foreach(LineRenderer line in lines)
        {
            Destroy(line.gameObject);
        }
    }

    public void selectLine(LineRenderer line)
    {
        selectedLine = line;
    }

    public void deleteSelectedLine()
    {
        if(selectedLine != null)
        {
            Destroy(selectedLine.gameObject);
            lines.Remove(selectedLine);
            selectedLine = null;
        }
    }
}
