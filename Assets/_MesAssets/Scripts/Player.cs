using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesseJoueur = 10f;
    [SerializeField] private float _maxY = 0f;
    [SerializeField] private GameObject _laserPrefab = default(GameObject);
    [SerializeField] private float _cadenceTir = 0.2f;

    private float _tempsTir = -1f;

    private InputSystem_Actions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new InputSystem_Actions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Attack.performed += Attack_performed;
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Attack.performed -= Attack_performed;
        _playerInputActions.Player.Disable();
 
    }

    private void Update()
    {
        MouvementJoueur();
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.time > _tempsTir)
        {
            //Tirer un laser  / Instancier
            Instantiate(_laserPrefab, transform.position + new Vector3(0f, 0.9f, 0f), Quaternion.identity);
            _tempsTir = Time.time + _cadenceTir;
        }
        
    }

    //Gère les déplacements du joueur
    private void MouvementJoueur()
    {
        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();

        direction2D.Normalize();

        transform.Translate(direction2D * Time.deltaTime * _vitesseJoueur);

        // Clamp le joueur entre 2 valeurs en Y
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, _maxY));

        //Effet sortie gauche/droite
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector2(-9.5f, transform.position.y);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector2(9.5f, transform.position.y);
        }
    }
}
