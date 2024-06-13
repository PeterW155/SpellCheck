using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{

    public GameObject[] spells;

    private void Awake()
    {
        Debug.Log("SpellHolder");
        spells = Resources.LoadAll<GameObject>("SpellPrefabs");
    }


}
