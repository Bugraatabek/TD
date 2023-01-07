using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // We are making the Nodes visible | serializeable | so when we want to serialize "Node" in our MonoBehaviour scripts, we will be able to see them in the Inspector
public class Node // There wasn't anything called Node in the C# language we have created it and gave it a meaning

{
    public Vector2Int coordinates; // this is the coordinates we set for our Node, what goes for bool "isWalkable" goes for this one too
    public bool isWalkable; // this is the bool we set for our Node, The Constructors "isWalkable" is different then this one, so we set that one to this one inside the constructor.
    public bool isExplored;
    public bool isPath;
    
    public Node connectedTo; // we gave created a public Node so we can reach it from other Scripts

    public Node(Vector2Int coordinates, bool isWalkable) // This is a Constructor // When we want to use a Vector2 it wants us to pass in some parameters, so we are doing the same thing here, when we use this constructor, it will want us to pass in a Vector 2 which is coordinates and a bool which is connected to isWalkable
    {
      this.coordinates = coordinates;// we are setting the constructors coordinates to Node's coordinates
      this.isWalkable = isWalkable; // we are setting the constructors bool to Node's bool   
    }

}
