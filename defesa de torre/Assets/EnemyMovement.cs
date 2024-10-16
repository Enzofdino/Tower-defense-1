using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [Header("Attibutes")]
    [SerializeField] private float movespeed = 2f;

    private Transform target;
    private int pathindex = 0;
    private void Start()
    {
        target = LevelManager.main.Caminho[0];
    }
    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathindex++;
            if(pathindex == LevelManager.main.Caminho.Length)
            {
                Destroy(gameObject);
                return;
            }
        }

    }
}
