using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Nemesis : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;
    public Rigidbody rb;
    public GameObject target;
    public NavMeshAgent Agente;
    public float Speed;

    private void Start()
    {
        
        target = GameObject.Find("Player");
    }
    void Update()
    {
        Comportamiento_Enemigo();
    }
    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position,target.transform.position)>10)
        {
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                  
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                   
                    break;
            }
        }
        else
        {
            Debug.Log("CARNEEE ! ");
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation, 2 ) ;
            transform.Translate(Vector3.forward * Speed * 2 * Time.deltaTime);
        }
        
    }
      
   

}
