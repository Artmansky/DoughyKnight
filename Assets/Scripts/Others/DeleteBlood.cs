using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

[Docs("Deletes blood particles instantly after 1 second.")]
public class DeleteBlood : MonoBehaviour
{
    [Docs("Deletes blood particles instantly after 1 second.")]
    void Update()
    {
        Destroy(gameObject, 1f);
    }
}
