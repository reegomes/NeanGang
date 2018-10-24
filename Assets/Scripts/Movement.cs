using UnityEngine;

public class Movement : MonoBehaviour {
    protected Animator anim;
    protected Rigidbody rb;
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected LayerMask layer;

    protected bool IsActive;

    [Header("-- Player Settings --")]
    [SerializeField] protected float vel = 50;
    [SerializeField] protected float angleVel = 15;

    [Header("Anim Stats")]
    protected float animSpeed;
    protected Vector3 NormalizedDirection(Vector3 posToGo)
    {
        Vector3 targetDirection = new Vector3(posToGo.x, 0f, posToGo.z);
        targetDirection = mainCam.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        return targetDirection;
    }
    protected void FreeMovement(Vector3 posToGo)
    {
        transform.position += NormalizedDirection(posToGo);    
    }
    //Faz a rotação
    protected void SmothRotate(Vector3 posToFace)
    {
        float step = angleVel * Time.deltaTime;
        Vector3 targetDirection = NormalizedDirection(posToFace);
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    protected void Jump()
    {
        rb.AddForce(Vector3.up * 500f);
    }
    protected void Attack()
    {
        Ray raiozin = Punch();
        RaycastHit hit;
        if (Physics.Raycast(raiozin.origin, raiozin.direction, out hit, 10f))
        {
            hit.collider.GetComponent<Rigidbody>().AddForce(raiozin.direction * 15000f);
        }
    }
    protected Ray Punch()
    {
        Vector3 posInicial = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        Ray linha = new Ray(posInicial, transform.forward);
        Debug.DrawRay(linha.origin,linha.direction * 5f, Color.red,5f);
        return linha;
    }
}