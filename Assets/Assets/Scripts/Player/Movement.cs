using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Camera camera;
    public Animator agentAnimator;
    private RaycastHit hit;
    private NavMeshAgent agent;
    private string groundTag = "Ground";
    private string catTag = "Cat";
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);   
                }
                if (hit.collider.CompareTag(catTag))
                {
                    agent.SetDestination(hit.point);
                    Debug.Log("cat click");
                }
            }

        }
        if (agent.velocity != Vector3.zero)
        {
            agentAnimator.SetBool("isWalking", true);
        }
        else if (agent.velocity == Vector3.zero)
        {
            agentAnimator.SetBool("isWalking", false);
        }
    }
}
