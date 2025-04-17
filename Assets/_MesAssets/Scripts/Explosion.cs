using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        
        Destroy(gameObject, 2.5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 2f);
    }
}
