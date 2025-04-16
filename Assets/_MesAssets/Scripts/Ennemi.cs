using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] float _vitesseEnnemi = 4f;
    
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _vitesseEnnemi);

        if (transform.position.y < -6f)
        {
            float randomX = Random.Range(-8.3f, 8.3f);
            transform.position = new Vector2(randomX, 6f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Enlève une vie au joueur
            Destroy(gameObject);
        }
        else   if (collision.tag == "Laser")
        {
            // Donne des points au joueur
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
