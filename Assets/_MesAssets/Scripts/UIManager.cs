using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text _txtPointage = default(TMP_Text);
    [SerializeField] private TMP_Text _txtViesJoueur = default(TMP_Text);

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdatePointage()
    {
        _txtPointage.text = "Pointage : " + GameManager.Instance.Pointage.ToString();
    }

    public void UpdateViesJoueur(int p_vies)
    {
        _txtViesJoueur.text = "Vies : " + p_vies.ToString();
    }
}
