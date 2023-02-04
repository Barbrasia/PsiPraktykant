using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class WC : MonoBehaviour
{ 
     public Transform[] bots;
    public Transform destination;
    
    private Vector3[] originalPositions;
    private NavMeshAgent[] navAgents;

    private void Awake()
    {
        originalPositions = new Vector3[bots.Length];
        navAgents = new NavMeshAgent[bots.Length];
        for (int i = 0; i < bots.Length; i++)
        {
            originalPositions[i] = bots[i].position;
            navAgents[i] = bots[i].GetComponent<NavMeshAgent>();
        }
        StartCoroutine(MoveBots());
    }

   

    private IEnumerator MoveBots()
    {
        while (true)
        {
            for (int i = 0; i < bots.Length; i++)
            {
                yield return new WaitForSeconds(Random.Range(5f, 10f));
                yield return new WaitForSeconds(2f);
                navAgents[i].destination = destination.position;

                while (navAgents[i].pathPending || navAgents[i].remainingDistance > 0.05f)
                {
                    yield return null;
                }

                yield return new WaitForSeconds(5f);
                navAgents[i].destination = originalPositions[i];

                while (navAgents[i].pathPending || navAgents[i].remainingDistance > 0.05f)
                {
                    yield return null;
                }

            }
        }
    }
  
}
