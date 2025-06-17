using UnityEngine;
using TMPro; 

public class WallController : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    public MeshRenderer wallRenderer;
    public Material positiveMaterial;
    public Material negativeMaterial;

    // Array of possible operation symbols
    private string[] positiveSymbols = { "+", "x" };
    private string[] negativeSymbols = { "-", "/" };

    public void SetupWall(bool isPositive)
    {
        int randomNumber = Random.Range(1, 6); // Generates a number from 1 to 5

        if (isPositive)
        {
            wallRenderer.material = positiveMaterial;
            // Randomly pick a positive symbol
            string symbol = positiveSymbols[Random.Range(0, positiveSymbols.Length)];
            textElement.text = symbol + randomNumber.ToString();
        }
        else
        {
            wallRenderer.material = negativeMaterial;
            // Randomly pick a negative symbol
            string symbol = negativeSymbols[Random.Range(0, negativeSymbols.Length)];

            // Ensure division doesn't use a number that causes issues (like /1 or /0 if we had 0)
            // For now, with numbers 1-5, division is simple.
            if (symbol == "/" && randomNumber == 0) // Just in case you change the range later
            {
                randomNumber = 1; // Avoid division by zero
            }
            textElement.text = symbol + randomNumber.ToString();
        }
    }
}