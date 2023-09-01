using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState {
    Available,
    Current,
    Completed,
}

public class MazeNode : MonoBehaviour {
    [SerializeField] GameObject[] walls;
    [SerializeField] MeshRenderer floor;

    public void RemoveWall(int wallPosition) {
        walls[wallPosition].gameObject.SetActive(false);
    }

    public void SetState(NodeState state) {
        floor.material.color = state switch {
            NodeState.Available => Color.white,
            NodeState.Current => Color.yellow,
            NodeState.Completed => Color.blue,
        };
    }
}
