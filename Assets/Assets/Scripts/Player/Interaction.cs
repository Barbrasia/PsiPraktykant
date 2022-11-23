using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out CatInteractable catInteractable))
                {
                    catInteractable.Interact();
                }
                if (collider.TryGetComponent(out MilkTableInteractable milkTableInteractable))
                {
                    milkTableInteractable.Interact();
                }
            }
        }
    }



}
