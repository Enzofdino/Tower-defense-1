using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemymask;
    [Header("Attribute")]
    [SerializeField] private float targetingrange = 5f;
    [SerializeField] private float rotationspeed = 10f;

    private Transform target;
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingrange);
    }
    private void Update()
    {
        Findtarget();  

        if (target != null)
        {
            RotateTowardsTarget();  
            checktargetisrange();  
        }
    }
    private void Findtarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingrange, (Vector2)
            transform.position, 0f, enemymask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool checktargetisrange()
    {
        
        if (target == null)
        {
            Debug.LogWarning("Nenhum alvo detectado no alcance.");
            return false; 
        }

    
        return Vector2.Distance(target.position, transform.position) <= targetingrange;
    }
    private void RotateTowardsTarget()
    {
       
        if (target == null)
        {
            Debug.LogWarning("Nenhum alvo detectado para rotacionar.");
            return;
        }

       
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - turretRotationPoint.position.x) * Mathf.Rad2Deg - 90;

        // Criar a rotação do alvo e aplicá-la ao objeto
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationspeed);
    }


}