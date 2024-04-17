using UnityEngine;

namespace Destructible2D.Examples
{
    public class bomb : MonoBehaviour
    {
        public float Intercept;
        public LayerMask Layers = -1;
        public D2dDestructible.PaintType Paint;
        public Texture2D Shape;
        public Color Color = Color.white;
        public Vector2 Size = Vector2.one;
        public float Angle;
        public LayerMask layerToHit;
        public GameObject Explosion; 
        public int price;
        public Camera Camera; // Optionally specify the camera. If null, will use main camera.
        public GameObject ExplosionEffect;

        private StructureManager daddyStructure;

        void Start()
        {
            daddyStructure = GetComponentInParent<StructureManager>();
        }

        void Update()
        {
            if (daddyStructure.shouldExplode)
            {
                explode();
            }
        }

        void explode()
        {
            GameObject explosionEffectIns = Instantiate(ExplosionEffect,transform.position,Quaternion.identity); 
            SpawnExplosion();
            Destroy(explosionEffectIns,10);
            Destroy(gameObject);
        }

        private void SpawnExplosion()
        {
            // Ensure there's an effect to spawn
            if (Explosion != null)
            {
                // Use the specified camera or default to main camera
                var camera = Camera ? Camera : UnityEngine.Camera.main;

                if (camera != null)
                {
                    // Convert bomb's position to a spawn point for the explosion effect
                    var position = transform.position; // For 3D, or adapt if it's a 2D position
                    var rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)); // Random rotation, adjust as necessary

                    // Instantiate the explosion effect at the bomb's position with a random rotation
                    var explosionInstance = Instantiate(Explosion, position, rotation);
                    explosionInstance.SetActive(true);
                }
            }
        }
    }
}


