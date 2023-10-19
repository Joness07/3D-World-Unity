using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainScript : MonoBehaviour
{
    public TerrainCollider tC;

    private void Awake()
    {
        tC = GetComponent<TerrainCollider>();

        tC.enabled = false;
        tC.enabled = true;
    }
}
