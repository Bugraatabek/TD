using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;
    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>(); // try to remove the part after the = sign and see what initializing means
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();



    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down }; // this is a vector2int array that holds the values of right,, left, up, down because we are building BreadthFirstSearch
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
       
    }
    void Start()
    {
        startNode = gridManager.Grid[startCoordinates]; // to have control over
        destinationNode = gridManager.Grid[destinationCoordinates]; // to have control over
        BreadthFirstSearch();
        
        
        
    }
    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions) // for every direction in the Vector2Int directions array
        {
            Vector2Int neighborCoordinates = currentSearchNode.coordinates + direction; // New Vector2Int named neighborCoordinates = currentsearchnodes coordinates + directions coordinates
            if(grid.ContainsKey(neighborCoordinates)) // if the grid contains the key "neighborcoordinates"
            {
                neighbors.Add(grid[neighborCoordinates]); // at the Node named grid with the key [neighborCoordinates] to the neighbors list 

                
            }
        }
        foreach(Node neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode; //to create the connections on our map and build the BreadthFirstSearch tree // connected to is the public node from the node script
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }

    }
    void BreadthFirstSearch()
    {
        bool isRunning = true; // to use to break the loop

        frontier.Enqueue(startNode);     // adding startNode to the queue
        reached.Add(startCoordinates, startNode); //means we've reached the startNode
    
        while(frontier.Count > 0 && isRunning) // while we have a node in the frontier queue and isRunning = true
        {
            currentSearchNode = frontier.Dequeue(); //this will dequeue the first one in and make it the currentSearchNode
            ExploreNeighbors(); //this method will search the neighbors of the currentSearchNode
            if (currentSearchNode.coordinates == destinationCoordinates) // when the currentSearchNode's coordinates = destinationCoordinates this means we reached our
            {
                isRunning = false; // loop will break
            }
        }
    }
    List<Node> BuildPath() // We have searched through all the nodes and created a pool of nodes, so now we will go backwards from the destinationNode to startingNode for creating a path
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode; // created a new node called currentNode because, search algorithms last node is our destination node and it is the only one in queue so that makes it the currentNode 

        path.Add(destinationNode); // added the currentNode to the path list of nodes
        destinationNode.isPath = true; // this will color the path
        

        while(currentNode != null) // while we have a current node
        {
            currentNode.connectedTo = currentNode; // neighbor that our currentNode is connectedTo is our currentNode and so on
            path.Add(currentNode); // we are adding all the currentNodes to our path because we are tracking bacwards
            currentNode.isPath = true;
            
        }
        path.Reverse(); // because the path is from the destinationCoordinates to startingCoordinates we are reversing it
        return path; // this will make the method return the path list when used
    }
}
