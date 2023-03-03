/*using UnityEngine;
using UnityEngine.UI;

public class ZoneChecker : MonoBehaviour
{
    public Text successText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            successText.text = "SUCCESS!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            successText.text = "";
        }
    }
}
*/