using UnityEngine;
using TMPro; // ou UnityEngine.UI selon ton UI

public class CodePuzzle : MonoBehaviour
{
    public string code = "1234";
    public TMP_InputField inputField;
    public GameManager gameManager;
    public int clueIndex;
    public PlayerController playerController; // référence au script de déplacement

    void Start()
    {
        // Quand on clique sur le champ, bloquer les mouvements
        inputField.onSelect.AddListener(delegate { playerController.enabled = false; });
        // Quand on quitte le champ, redonner le contrôle
        inputField.onDeselect.AddListener(delegate { playerController.enabled = true; });
    }

    public void CheckCode()
    {
        if (inputField.text == code)
        {
            Debug.Log("Énigme 2 résolue !");
            gameManager.ActivateClue(clueIndex);
        }
        else
        {
            Debug.Log("Code incorrect !");
        }
    }
}
