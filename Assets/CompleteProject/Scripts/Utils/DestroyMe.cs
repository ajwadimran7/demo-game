using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    
    public float lifetime = 5f;

    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }
}
