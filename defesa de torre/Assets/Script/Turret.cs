using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretrotation;
    [Header("Attribute")]
    [SerializeField] private float targetingrange = 5f;
    [SerializeField] private LayerMask enemymask;

    private Transform target;

    private void Update()
    {
        if(target != null)
        {
            Findtarget();
            return;
        }
        RotateTowardsTarget();
        checktargetisrange();
    }
    private void Findtarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingrange, (Vector2)
            transform.position, 0f, enemymask);

        if(hits.Length > 0 )
        {
            target = hits[0].transform;
        }
    }
    private bool checktargetisrange()
    {
        return Vector2.Distance(target.position,transform.position) <= targetingrange;
    }
    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x 
            - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        turretrotation.rotation = targetRotation;
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position,transform.forward, targetingrange);
    }

}

