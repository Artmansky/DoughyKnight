using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

public class DeleteBlood : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 1f);
    }
}
