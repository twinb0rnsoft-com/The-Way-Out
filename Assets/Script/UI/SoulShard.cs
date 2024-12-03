using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulShard : MonoBehaviour
{

    //  Initialization
    public Text soulShard;
    private static int soulShardCount;
    private static int soulShardMax;
    private GameObject door;

    // Process
    void Start()
    {
        soulShardCount = 0;
        soulShardMax = GameObject.FindGameObjectsWithTag("SoulShard").Length;
        door = GameObject.FindGameObjectWithTag("door");
        door.SetActive(false);
        DisplayEarnedSoulShardText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SoulShard"))
        {
            other.gameObject.SetActive(false);
            soulShardCount += 1;
            EnableNextLevelDoor();
            DisplayEarnedSoulShardText();
        }
    }

    void DisplayEarnedSoulShardText()
    {
        soulShard.text = ": " + soulShardCount.ToString() + "/ " + soulShardMax.ToString();
    }

    void EnableNextLevelDoor()
    {
        if (soulShardCount == soulShardMax)
        {
            door.SetActive(true);
        }
    }
}
