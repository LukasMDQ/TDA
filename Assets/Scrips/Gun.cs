using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range=100;
    public Camera FPScam;
    

    //Efectos
    public GameObject inpactEffect;
    public GameObject inpactEffect2;
    public ParticleSystem FlashEffect;
    public AudioSource _audSource;
    public AudioClip _Clip_Disparo;
    public AudioClip _Clip_Impact;
    public AudioClip _Clip_ObjectInpact;

    void Start()
    {
        
    }

    
    void Update()
    {
        InputDisparo();
    }
    void InputDisparo()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
           
            Disparo();
            FlashEffect.Play();
        }
    } 
    void Disparo()
    {
        

        RaycastHit hit;
        AudioDisparo( _Clip_Disparo );
        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemi")
            {
                hit.transform.gameObject.GetComponent<VidaEnemigo>().vida -= 10;
                AudioDisparo (_Clip_Impact );
                Debug.Log ("EN EL BLANCO !!!");
                GameObject InpactoGO = Instantiate(inpactEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(InpactoGO,2f);
            }
            if (hit.transform.tag == "piso")
            {
                AudioDisparo(_Clip_ObjectInpact);
                
                GameObject InpactoGO = Instantiate(inpactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(InpactoGO, 2f);
            }
            if (hit.transform.tag == "objeto")
            {
                AudioDisparo(_Clip_Disparo);

                GameObject InpactoGO = Instantiate(inpactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(InpactoGO, 2f);
            }

        }
        
    }
    void AudioDisparo (AudioClip _Clip_Test)
    {
        _audSource.clip= _Clip_Test;
        _audSource.Play();
    }
    
}
