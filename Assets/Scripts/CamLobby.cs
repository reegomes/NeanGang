using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLobby : MonoBehaviour {

    [SerializeField]
    GameObject player;
    // Use this for initialization

    void LateUpdate()
    {
        transform.LookAt(Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z), 1f));
    }
}
