using UnityEngine;

public class P4 : Movement
{
    bool stopMoves;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        IsActive = true;
    }
    void Update()
    {
        if (IsActive && stopMoves == false)
        {
            float xx = Input.GetAxis("Horizontal4") * vel * Time.deltaTime;
            float zz = Input.GetAxis("Vertical4") * vel * Time.deltaTime;
            Vector3 direction = new Vector3(xx, 0, zz);

            FreeMovement(direction);
            SmothRotate(direction);

            if (xx != 0)
            {
                animSpeed = 1f;
            }
            else if (zz != 0)
            {
                animSpeed = 1f;
            }
            else
            {
                animSpeed = 0f;
            }
            anim.SetFloat("speed", animSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Joystick4Button0))
        {
            anim.SetTrigger("jumping");
            Invoke("Jump", 0.8f);
        }
        if (Input.GetKeyDown(KeyCode.Joystick4Button1))
        {
            Punch();
            anim.SetTrigger("punching");
            Attack();
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * -1, out hit, 20f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                stopMoves = true;
                anim.SetBool("die", true);
                Debug.Log("Houve Colisão");
            }
        }
        if (Physics.Raycast(transform.position, transform.forward * 1, out hit, 20f))
        {
            if (hit.collider.CompareTag("WinCondiction"))
            {
                FinalRoom.endGame = true;
                anim.SetBool("winning", true);
            }
        }
    }
}
