using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlood : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1f);
    }
}
