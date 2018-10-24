using UnityEngine;

public class Game4Camera : MonoBehaviour {
    float positionCam = 80f;
    float cameraSpeed = -30;
	void Update () {
        positionCam += cameraSpeed * Time.deltaTime;
        this.gameObject.transform.position = new Vector3(0, 140f, positionCam);
	}
}
