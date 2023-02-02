using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatInteractable : MonoBehaviour
{
    public NavMeshAgent agent;
    internal Vector3 startPosition;

    public void Interact()
    {
        Debug.Log("Give milk to cat");
    }

}
