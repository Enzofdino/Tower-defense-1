using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretrotation;
    [Header("Attribute")]
    [SerializeField] private float targetingrange = 5f;

    private Transform target;

    private void Update()
    {
        if(target != null)
        {
            Findtarget();
        }
    }
    private void Findtarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingrange, (Vector2)transform.position, 0f, enemyMask);
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position,transform.forward, targetingrange);
    }

}

