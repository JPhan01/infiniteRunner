using System.Collections.Generic;
using UnityEngine;

public class Spawner_Script : MonoBehaviour
{
    public Transform chunkContainer;
    public List<GameObject> chunksList;
    private int lastIndex = -1;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Chunks")
        {
            Transform lastChunkEnd = other.gameObject.transform.Find("Chunk_End");
            Instantiate(PickRandomChunk(), lastChunkEnd.position, Quaternion.identity, chunkContainer);
        }
    }
    private GameObject PickRandomChunk()
    {

        int randIndex = Random.Range(0, chunksList.Count);
        while (randIndex == lastIndex)
        {
            randIndex = Random.Range(0, chunksList.Count);
        }
        lastIndex = randIndex;
        return chunksList[randIndex];
    }
}