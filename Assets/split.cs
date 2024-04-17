using UnityEngine;

public class SpriteFragmentation : MonoBehaviour
{
    public int fragmentCount = 100;
    public float fragmentSize = 0.5f;
    public float explosionForce = 10f;
    public float fragmentLifetime = 2f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Fragmentize(mousePos, explosionForce);
        }
    }

    private void Fragmentize(Vector3 explosionPoint, float explosionForce)
    {
        // Get the sprite renderer component
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Generate a mesh based on the sprite's texture
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[fragmentCount * 3];
        int[] triangles = new int[fragmentCount * 3];
        Vector2[] uv = new Vector2[fragmentCount * 3];

        for (int i = 0; i < fragmentCount; i++)
        {
            // Generate random positions for the fragments
            Vector3 randomPos = Random.insideUnitSphere * fragmentSize;
            vertices[i * 3] = randomPos;
            vertices[i * 3 + 1] = randomPos + Vector3.up * fragmentSize;
            vertices[i * 3 + 2] = randomPos + Vector3.right * fragmentSize;

            // Set the triangle indices
            triangles[i * 3] = i * 3;
            triangles[i * 3 + 1] = i * 3 + 1;
            triangles[i * 3 + 2] = i * 3 + 2;

            // Set the UV coordinates for texture mapping
            uv[i * 3] = new Vector2(0, 0);
            uv[i * 3 + 1] = new Vector2(0, 1);
            uv[i * 3 + 2] = new Vector2(1, 1);
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        // Create a new game object for each fragment
        for (int i = 0; i < fragmentCount; i++)
        {
            GameObject fragment = new GameObject("Fragment");
            fragment.transform.position = transform.position;
            fragment.transform.rotation = transform.rotation;

            // Add a sprite renderer and set the sprite and material
            SpriteRenderer fragmentRenderer = fragment.AddComponent<SpriteRenderer>();
            fragmentRenderer.sprite = spriteRenderer.sprite;
            fragmentRenderer.material = spriteRenderer.material;

            // Add a mesh filter and set the mesh
            MeshFilter meshFilter = fragment.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;

            // Add a rigidbody and apply explosion force
            Rigidbody2D rb = fragment.AddComponent<Rigidbody2D>();
            Vector3 explosionDir = (fragment.transform.position - explosionPoint).normalized;
            rb.AddForce(explosionDir * explosionForce, ForceMode2D.Impulse);

            // Add a polygon collider for collision detection
            PolygonCollider2D collider = fragment.AddComponent<PolygonCollider2D>();
            Vector2[] colliderPoints = new Vector2[3];
            colliderPoints[0] = vertices[i * 3];
            colliderPoints[1] = vertices[i * 3 + 1];
            colliderPoints[2] = vertices[i * 3 + 2];
            collider.points = colliderPoints;

            // Destroy the fragment after a specified lifetime
            Destroy(fragment, fragmentLifetime);
        }

        // Destroy the original sprite object
        Destroy(gameObject);
    }
}