using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public int buttonID;            // ID de ce bouton
    public int[] correctSequence = { 1, 2, 3 };
    private int currentIndex = 0;

    public GameManager gameManager;
    public int clueIndex;           // Indice à activer quand fini

    private void OnMouseDown()
    {
        if (buttonID == correctSequence[currentIndex])
        {
            currentIndex++;
            if (currentIndex >= correctSequence.Length)
            {
                Debug.Log("Énigme 1 résolue !");
                gameManager.ActivateClue(clueIndex);
            }
        }
        else
        {
            currentIndex = 0;
            Debug.Log("Mauvais ordre, recommence !");
        }
    }
}
