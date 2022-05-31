using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefabs;

    public float minX;
    public float maxX;
    public float posY;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        Vector3 randamPosition = new Vector3(Random.Range(minX, maxX), posY, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefabs.name, randamPosition, Quaternion.identity);
    }
}
