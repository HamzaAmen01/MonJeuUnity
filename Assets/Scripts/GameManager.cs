using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject key;         // Clé finale
    public GameObject[] clues;     // Indices des énigmes

    public void ActivateClue(int index)
    {
        if (index < 0 || index >= clues.Length) return;

        clues[index].SetActive(true);

        // Vérifier si toutes les énigmes sont résolues
        bool allSolved = true;
        foreach (var clue in clues)
        {
            if (!clue.activeSelf) allSolved = false;
        }

        // Si toutes résolues → activer la clé
        if (allSolved && key != null)
        {
            key.SetActive(true);
            Debug.Log("Bravoo : toutes les énigmes résolues, la clé est là !");
        }
    }
}
