
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    GameObject waypointsGO;
     
    private List<Transform> waypointsTrans;

    int index;
    float speed, agentSpeed;
    Transform player;
    NavMeshAgent agenEnemy;
    bool isWalking = true;
    void Awake()
    {
        agenEnemy = GetComponent<NavMeshAgent>();
        if (agenEnemy != null)
        {
            agentSpeed = agenEnemy.speed;
        }
        waypointsTrans = new List<Transform>();
       
        for(int i=1;i< waypointsGO.GetComponentsInChildren<Transform>().Length;i++)
        {
            Transform g = waypointsGO.GetComponentsInChildren<Transform>()[i];
          
            Debug.Log(g.name + " " + g.position);
            waypointsTrans.Add(g);

        }
        index = Random.Range(0, waypointsTrans.Count);
        agenEnemy.destination = waypointsTrans[index].position;
    }

    void Update()
    {
   
            agenEnemy.destination = waypointsTrans[index].position;
            if (Vector3.Distance(agenEnemy.destination, transform.position) < 1.5f)
            {
                index = Random.Range(0, waypointsTrans.Count);
                agenEnemy.destination = waypointsTrans[index].position;
            }
 }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 9f);
    } 
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;


    int index;
    float speed, agentSpeed;
    Transform player;

    Animator anim;
    NavMeshAgent agenEnemy;
    GameObject blood;
    bool isWalking = true;
    bool attack = false;  
    void Awake()
    {
        blood = GameObject.Find("blood");
        anim = GetComponent<Animator>();
        agenEnemy = GetComponent<NavMeshAgent>();
        if (agenEnemy != null)
        {
            agentSpeed = agenEnemy.speed;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;

        index = Random.Range(0, waypoints.Length);
        agenEnemy.destination = waypoints[index].position;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, player.position) < 9f && Mathf.Abs(transform.position.y - player.position.y) < 1.5f)
        {
            agenEnemy.destination = player.position;
           if (Vector3.Distance(transform.position, player.position) < 1.5f)
            {
                attack = true;
                Attack();
            }
            else
            {
                attack = false;
                Attack();
            }
        }
        else
        {
            agenEnemy.destination = waypoints[index].position;
            if (Vector3.Distance(agenEnemy.destination, transform.position) < 1.5f)
            {
                index = Random.Range(0, waypoints.Length);
                agenEnemy.destination = waypoints[index].position;
            }
        }


    }
 
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 9f);
    }
   IEnumerator HideBlood()
    {
        yield return new WaitForSeconds(.2f); blood.GetComponent<Image>().enabled = false;

    }
  
   void Attack()
    {

        anim.SetBool("New Bool 0", attack);

    }
    void makeDamage()
    {
        if (Vector3.Distance(transform.position, player.position) < 2.5f)
        {
            Debug.Log("DAÑADO");
            blood.GetComponent<Image>().enabled = true;
            StartCoroutine("HideBlood");
        }
    }
}
*/