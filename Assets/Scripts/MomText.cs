using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomText : MonoBehaviour
{
    public GameObject MomTextPanel;

    void Start()
    {
        MomTextPanel.SetActive(false);

        // Invoke SpawnDelay after 10 seconds
        Invoke("SpawnDelay", 25f);
    }

    void SpawnDelay()
    {
        MomTextPanel.SetActive(true);
        // Invoke DespawnDelay after 6 seconds
        Invoke("DespawnDelay", 6f);
    }

    void DespawnDelay()
    {
        MomTextPanel.SetActive(false);
    }
}
