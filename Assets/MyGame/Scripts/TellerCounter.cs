using UnityEngine;
using Valve.VR.InteractionSystem;
using TMPro;

public class TellerCounter : MonoBehaviour
{
    public int tellerCount;
    public int winAmountTeller = 3;
    public TMP_Text winningText;

    void Start()
    {
        // Deaktiviere den Winning Text am Anfang
        winningText.enabled = false;
    } 

    void OnTriggerEnter(Collider other)
    {
        // Überprüfen ob objekt der Teller ist
        if (other.CompareTag("Teller"))
        {
            // Den Teller zum Counter dazu zählen
            tellerCount++; print(tellerCount);

            // Überprüfe ob Telleranzahl erreicht
            if (tellerCount >= winAmountTeller)
            {
                // Wenn die Anzahl erreicht ist dann rufe die Gewinn Methode auf
                GameWon();               
            }

            // Deaktivieren der Teller Komponenten. Das man sie nicht mehr herausnehmen kann.
            Destroy(other.GetComponent<Throwable>());
            Destroy(other.GetComponent<Interactable>());

            // Das Teller Tag entfernen damit er die Methode nicht öfters aufrufen kann.
            other.tag = "Untagged";
        }
    }

    void GameWon()
    {
        // Aktiviere den Winning Text
        winningText.enabled = true;
    }
}
