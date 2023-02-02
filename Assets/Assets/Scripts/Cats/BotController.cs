using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    public CatInteractable[] bots;
    public Vector3 destination;
    internal Vector3 startPosition;
    public float waitTime = 5f;
    public float randomWaitMin = 10f;
    public float randomWaitMax = 60f;
    private bool moving = false;
    private int currentBotIndex = 0;

    void Start()
    {
        //StartCoroutine(MoveBots());
        foreach (CatInteractable bot in bots)
        {
            StartCoroutine(MoveBot(bot));
        }
    }

    IEnumerator MoveBot(CatInteractable bot)
    {
        while (true)
        {
            CatInteractable currentBot = bots[currentBotIndex];
            if (!moving)
            {
                bot.startPosition = bot.transform.position;
                bool allBotsBack = true;
                for (int i = 0; i < bots.Length; i++)
                {
                    if (bots[i].agent.hasPath)
                    {
                        allBotsBack = false;
                        break;
                    }
                }
                if (allBotsBack)
                {
                    moving = true;
                    bot.agent.destination = destination;
                    while (bot.agent.remainingDistance >= bot.agent.stoppingDistance)
                    {
                        yield return null;
                    }
                    yield return new WaitForSeconds(waitTime);
                    bot.agent.destination = bot.startPosition;
                    while (bot.agent.pathPending)
                    {
                        yield return null;
                    }
                    float randomWaitTime = Random.Range(randomWaitMin, randomWaitMax);
                    yield return new WaitForSeconds(randomWaitTime);
                    moving = false;
                    currentBotIndex = (currentBotIndex + 1) % bots.Length;
                }
                else
                {
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }
    }

}