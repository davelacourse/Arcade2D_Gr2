using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listeEnnemiPrefab = new List<GameObject>();
    [SerializeField] private float _tempsMin = 4f;
    [SerializeField] private float _tempsMax = 10f;

    [SerializeField] private GameObject _conteneurEnnemi = default(GameObject);

    private bool _stopSpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnEnnemi());
        
        
    }

    // Définition de la coroutine
    IEnumerator SpawnEnnemi()
    {
        
        yield return new WaitForSeconds(3f);
        while (!_stopSpawn)
        {
            Vector2 positionInitiale = new Vector2(Random.Range(-8.3f, 8.3f), 6f);
            
            int randomIndex = Random.Range(0, _listeEnnemiPrefab.Count);
            GameObject newEnemy = Instantiate(_listeEnnemiPrefab[randomIndex], positionInitiale, Quaternion.identity);
            newEnemy.transform.parent = _conteneurEnnemi.transform; // Déplacer l'objet instancié dans un nouveau parent
            
            yield return new WaitForSeconds(Random.Range(_tempsMin, _tempsMax));
        }
    }

    public void Mortjoueur()
    {
        _stopSpawn = true;
    }
}
