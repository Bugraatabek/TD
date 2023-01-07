using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways] // This means it will be executed even when we are not in play mode
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color pathColor = Color.green;
    //[SerializeField] Color exploredColor = new Color(1f,0.5f,0f);
    
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
        
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
        
    }
    void SetLabelColor()
    {
        if(gridManager == null) { return; } // safe guard in case GridManager doesn't exists
        Node node = gridManager.GetNode(coordinates);
        if(node == null) { return; } // safeguard in case node isn't there
        
        if       (!node.isWalkable)   {label.color = blockedColor;}
        // else if  (node.isExplored)    {label.color = exploredColor;}
        else if  (node.isPath)        {label.color = pathColor;}
        else                          {label.color = defaultColor;}
        // this code finds the node and looks at its values
        // then if it isn't walkable then the road is blocked
        // if node is walkable and its a path then the road is pathcolor
        // if node is walkable, a path and explored the the road is exploredcolor
        // else it is just defaulcolor

    }
    
    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x} , {coordinates.y}";
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}

