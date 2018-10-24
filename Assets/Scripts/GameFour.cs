using UnityEngine;

public class GameFour : MonoBehaviour
{
    #region variáveis
    public GameObject[] rooms;
    int index, range, rand, leng;
    public GameObject[] players;
    #endregion
    void Start()
    {
        range = rooms.Length;
    }
    void Update()
    {
        foreach (GameObject i in rooms)
        {
            switch (index)
        {
            case 0:
            leng = 120;
            break;
            case 1:
            leng = 360;
            break;
            case 2:
            leng = 600;
            break;
            case 3:
            leng = 840;
            break;
            case 4:
            leng = 1080;
            break;
            default:
            break;
        }
            index++;
			rand = Random.Range(0, range);
            if (index <= range)
            {	
				Instantiate(rooms[rand].gameObject, new Vector3(0, 0, (transform.position.z - leng)), Quaternion.identity);
                print("Contador> " + index);
            }
        }
        //if()
    }
}
