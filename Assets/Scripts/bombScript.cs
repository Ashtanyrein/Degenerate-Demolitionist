using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using EZCameraShake;

public class bombScript : MonoBehaviour
{
    public float fieldOfImpact;
    public float force;
    public LayerMask layerToHit;
    public GameObject ExplosionEffect;
    public int price;
    
    private StructureManager daddyStructure;

    void Start () {
        daddyStructure = GetComponentInParent<StructureManager>();    
    }
    
    void Update(){
        if(daddyStructure.shouldExplode)
            explode();
    }

    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact,layerToHit);
        
        foreach(Collider2D obj in objects) 
        {
            Vector2 direction = obj.transform.position - transform.position;
            
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        //CameraShaker.Instance.ShakeOnce(4,4,0.1f,1f);

        GameObject explosionEffectIns = Instantiate(ExplosionEffect,transform.position,Quaternion.identity); 
        Destroy(explosionEffectIns,10);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}
