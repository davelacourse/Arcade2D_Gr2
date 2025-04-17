using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] float _vitesseEnnemi = 4f;
    [SerializeField] int _pointsEnnemi = 100;
    [SerializeField] GameObject _explosion = default(GameObject);
    
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
            Player _player = FindAnyObjectByType<Player>();
            _player.DommageJoueur();
            UIManager.Instance.UpdateViesJoueur(_player.ViesJoueur);
        }
        else   if (collision.tag == "Laser")
        {
            GameManager.Instance.AugmenterPointage(_pointsEnnemi);
            Destroy(collision.gameObject);
        }

        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
