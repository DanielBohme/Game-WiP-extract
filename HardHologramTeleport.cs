using UnityEngine;
using System.Collections;

public class HardHologramTeleport : MonoBehaviour
{
    private Transform teleportTarget;
    private Transform target;
    [SerializeField] private float teleportTime = 0f;
    private float distanceToTarget = Mathf.Infinity;
    private float targetRadius = 15f;

    private bool collisionDetected = false;
    private bool teleporting = false;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    private void TeleportRandomTime()
    {
        teleportTime = Random.Range(4f, 7f);
    }

    private void Update()
    {
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);
        }
        if (!teleporting) StartCoroutine(TeleportRoutine());
    }

    private IEnumerator TeleportRoutine()
    {
        teleporting = true;
        TeleportRandomTime();
        yield return new WaitForSeconds(teleportTime);
        Teleport();
        teleporting = false;
    }

    private void Teleport()
    {
        if (distanceToTarget <= targetRadius)
        {
            transform.position = new Vector3(Random.Range(-targetRadius + distanceToTarget, targetRadius - distanceToTarget), 1.91f, 
                Random.Range(-targetRadius + distanceToTarget, targetRadius - distanceToTarget));

            if (collisionDetected)
            {
                transform.position = new Vector3(Random.Range(-targetRadius, targetRadius), 1.91f, Random.Range(-targetRadius, targetRadius));
            }
        }

        collisionDetected = false;
    }

    private void OnCollisionEnter(Collision otherObjects)
    {
        if (otherObjects.gameObject)
        {
            collisionDetected = true;
        }
    }
}
