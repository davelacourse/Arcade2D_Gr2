using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float _vitesseLaser = 20f;
    
    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _vitesseLaser);
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
}
