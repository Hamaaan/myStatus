using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightTrigger : MonoBehaviour
{
    [SerializeField] BalanceManager balanceManager;

    // Start is called before the first frame update
    void Start()
    {
        balanceManager = balanceManager.GetComponent<BalanceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rd = collision.GetComponent<Rigidbody2D>();
        balanceManager.measureWeight += (int)rd.mass;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D rd = collision.GetComponent<Rigidbody2D>();
        balanceManager.measureWeight -= (int)rd.mass;
    }
}
