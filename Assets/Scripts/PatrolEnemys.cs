using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class PatrolEnemys : MonoBehaviour
{
	#region Vars
    public Transform[] points;
    int destPoint;
    int goPoint;
    NavMeshAgent agent;
	#endregion
	#region Start and Update
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
		goPoint = Random.Range(0, 3);
		destPoint = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(Stage1());
        }
    }
	#endregion
	#region NextPoint
    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        this.agent.destination = points[destPoint].position;
    }
	#endregion
	#region Stages
    IEnumerator Stage1()
    {
        switch (goPoint)
        {
            // 2 // 1 // 3
            // 5 // 4 // 6
            // 8 // 7 // 9
            // 11 // 10 // 12
            // 14 // 13 // 15
            case 0:
                this.agent.destination = points[2].position;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    Stage2();
					//agent.speed = 20f;
                }
                break;
            case 1:
                this.agent.destination = points[1].position;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    Stage2();
                }
                break;
            case 2:
                this.agent.destination = points[3].position;
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    Stage2();
                }
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1f);
    }
    void Stage2()
    {
        switch (goPoint)
        {
            // 5 // 4 // 6
            // 8 // 7 // 9
            // 11 // 10 // 12
            // 14 // 13 // 15
            case 0:
                this.agent.destination = points[5].position;
                Stage3();
                break;
            case 1:
                this.agent.destination = points[4].position;
                Stage3();
                break;
            case 2:
                this.agent.destination = points[6].position;
                Stage3();
                break;
            default:
                break;
        }
    }
    void Stage3()
    {
        switch (goPoint)
        {
            // 8 // 7 // 9
            // 11 // 10 // 12
            // 14 // 13 // 15
            case 0:
                this.agent.destination = points[8].position;
                Stage4();
                break;
            case 1:
                this.agent.destination = points[7].position;
                Stage4();
                break;
            case 2:
                this.agent.destination = points[9].position;
                Stage4();
                break;
            default:
                break;
        }
    }
    void Stage4()
    {
        switch (goPoint)
        {
            // 11 // 10 // 12
            // 14 // 13 // 15
            case 0:
                this.agent.destination = points[11].position;
                Stage5();
                break;
            case 1:
                this.agent.destination = points[10].position;
                Stage5();
                break;
            case 2:
                this.agent.destination = points[12].position;
                Stage5();
                break;
            default:
                break;
        }
    }
    void Stage5()
    {
        switch (goPoint)
        {
            // 14 // 13 // 15
            case 0:
                this.agent.destination = points[14].position;
                break;
            case 1:
                this.agent.destination = points[13].position;
                break;
            case 2:
                this.agent.destination = points[15].position;
                break;
            default:
                break;
        }
    }
	#endregion
}