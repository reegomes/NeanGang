using UnityEngine;
public class RaycastEnemy : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * -1, Color.cyan, 100f);
        if (Physics.Raycast(transform.position, transform.forward * -1, out hit, 200f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Perdeu por colisão com as tropas!");
                anim.SetBool("die", true);

            }
        }
        Debug.DrawRay(transform.position, transform.up * -1, Color.green, 100f);
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, 1000f))
        {
            if (hit.collider.CompareTag("WinCondiction"))
            {
                Debug.Log("Você venceu!");
                FinalRoom.endGame = true;
                anim.SetBool("winning", true);
            }
            Debug.Log("Não colidiu");
        }
    }
}