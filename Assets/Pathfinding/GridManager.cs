using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // [SerializeField] Node node; // This serialiazes our Node script "Node" is the type and "node" is the name
    [SerializeField] Vector2Int gridSize; // Serializing a Vector2Int will give us the ability to pass in the data of x and y because that's what a Vector2 is//
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>(); // Created a Dictionary with it's Key = Vector2Int and its Value = Node (Node objects) // Then we set it to a new one to initialize it //
    // So nodes have coordinates in them because that's how we set them to be. That's why our Key is Vector2Int when we want to find the "Node" at 2,1 we will tell the Dictionary to look at 2,1 Key and tell us the Value of the Node.
    public Dictionary<Vector2Int, Node> Grid {get {return grid;}} // don't want the dictionary grid to be writeable from outside of this script just want it readable so this Grid returns the value of grid
    void Awake() 
    {
        CreateGrid();
    }
    public Node GetNode(Vector2Int coordinates) // public Node means this method returns a value "Node" and is "public" so it is called GetNode method and the best way to return a node to dictionary is pass the key inside the method which is coordinates for this dictionary//
    {
        if(grid.ContainsKey(coordinates)) // this is a safeguard to not get an error in case a coordinate is passed in which is not included in the grid[] so the grid must have the key for if to work
        {
        return grid[coordinates]; // we want to return the value from the grid[] with the key "coordinates" 
        }
        return null; // if the if statement doesn't return(grid doesn't contain the key) the method will return null | void?
        // when we want to get a Node we can simply use this method

    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++) // for every x int that is less then the grid size's x coordinate add 1 to our x value
        {
            for (int y=0; y < gridSize.y; y++)  // Because this is a nested for loop (meaning for loop inside a for loop) every time loop increases x value it will increase the y value until it is greater than the gridsize's y coordinate
            {
                Vector2Int coordinates = new Vector2Int(x,y); // Vector2Int named coordinate initiated by "new" and is equel to x,y coordinates
                grid.Add(coordinates, new Node(coordinates, true)); //for every coordinate we looped this will add a Node that bool isWalkable = True
                Debug.Log(grid[coordinates].coordinates + "=" + grid[coordinates].isWalkable);
                // Because we are starting from 0 setting x or y < will give us the total grid number of x * y, if we set it to <= then we would have (x+1) * (y+1) numbers of grid 
            }
        }
    }
}
