using UnityEngine;

public class CollectPuzzle : MonoBehaviour
{
    public GameManager gameManager;  // Glisse ici ton GameManager
    public int clueIndex;            // L'indice à activer pour cette énigme

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))   // Vérifie que c’est le joueur
        {
            gameObject.SetActive(false);  // L’objet disparaît
            gameManager.ActivateClue(clueIndex); // Active l’indice correspondant
            Debug.Log("Objet collecté, indice activé !");
        }
    }
}
