using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] Vector2Int mazeSize; 

    private void Start() {
        GenerateMazeInstant(mazeSize);
        // StartCoroutine(GenerateMaze(mazeSize));
    }

    void GenerateMazeInstant(Vector2Int size) {
        List<MazeNode> nodes = new List<MazeNode>();

        // Create Nodes.
        for (int x = 0; x < size.x; x++) {
            for (int y = 0; y < size.y; y++) {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);

                nodes.Add(newNode);
            }
        }
        // Stack of nodes that have been visited along a certain path.
        List<MazeNode> currentPath = new List<MazeNode>();
        // Nodes that have already been visited.
        List<MazeNode> completedNodes = new List<MazeNode>();
        // Select starting node.
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);

        while (completedNodes.Count < nodes.Count) {
            // Check nodes next to the current node.
            List<int> possibleNeighbours = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1) {
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y])) {
                        
                    possibleDirections.Add(1);
                    possibleNeighbours.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0) {
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y])) {
                        
                    possibleDirections.Add(2);
                    possibleNeighbours.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1) {
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1])) {
                        
                    possibleDirections.Add(3);
                    possibleNeighbours.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0) {
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1])) {
                        
                    possibleDirections.Add(4);
                    possibleNeighbours.Add(currentNodeIndex - 1);
                }
            }
            // Choose next node.
            if (possibleDirections.Count > 0) {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosen = nodes[possibleNeighbours[chosenDirection]];

                switch (possibleDirections[chosenDirection]) {
                case 1:
                    chosen.RemoveWall(1);
                    currentPath[currentPath.Count - 1].RemoveWall(0);
                    break;
                case 2:
                    chosen.RemoveWall(0);
                    currentPath[currentPath.Count - 1].RemoveWall(1);
                    break;
                case 3:
                    chosen.RemoveWall(3);
                    currentPath[currentPath.Count - 1].RemoveWall(2);
                    break;
                case 4:
                    chosen.RemoveWall(2);
                    currentPath[currentPath.Count - 1].RemoveWall(3);
                    break;
                }
                currentPath.Add(chosen);

            } else {
                completedNodes.Add(currentPath[currentPath.Count - 1]);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

    IEnumerator GenerateMaze(Vector2Int size) {
        List<MazeNode> nodes = new List<MazeNode>();

        // Create Nodes.
        for (int x = 0; x < size.x; x++) {
            for (int y = 0; y < size.y; y++) {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);

                yield return null;
            }
        }
        // Stack of nodes that have been visited along a certain path.
        List<MazeNode> currentPath = new List<MazeNode>();
        // Nodes that have already been visited.
        List<MazeNode> completedNodes = new List<MazeNode>();
        // Select starting node.
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count) {
            // Check nodes next to the current node.
            List<int> possibleNeighbours = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1) {
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y])) {
                        
                    possibleDirections.Add(1);
                    possibleNeighbours.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0) {
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y])) {
                        
                    possibleDirections.Add(2);
                    possibleNeighbours.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1) {
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1])) {
                        
                    possibleDirections.Add(3);
                    possibleNeighbours.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0) {
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1])) {
                        
                    possibleDirections.Add(4);
                    possibleNeighbours.Add(currentNodeIndex - 1);
                }
            }
            // Choose next node.
            if (possibleDirections.Count > 0) {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosen = nodes[possibleNeighbours[chosenDirection]];

                switch (possibleDirections[chosenDirection]) {
                case 1:
                    chosen.RemoveWall(1);
                    currentPath[currentPath.Count - 1].RemoveWall(0);
                    break;
                case 2:
                    chosen.RemoveWall(0);
                    currentPath[currentPath.Count - 1].RemoveWall(1);
                    break;
                case 3:
                    chosen.RemoveWall(3);
                    currentPath[currentPath.Count - 1].RemoveWall(2);
                    break;
                case 4:
                    chosen.RemoveWall(2);
                    currentPath[currentPath.Count - 1].RemoveWall(3);
                    break;
                }

                currentPath.Add(chosen);
                chosen.SetState(NodeState.Current); 
            } else {
                completedNodes.Add(currentPath[currentPath.Count - 1]);

                currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            yield return new WaitForSeconds(0.005f);
        }
    }
}
