using UnityEngine;

public class ElementCollect : MonoBehaviour
{
    // The logic for the permanent element power-ups.

    //                         air,   earth, fire
    public bool[] willGrant = {false, false, true}; // Determines which element will be granted to the player upon collection

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerLogic player = GameManager.gm.FindPlayerScript();
            for (int i = 0; i < player.unlocks.Length; i++) // Loops through the player's element booleans,
            {
                if (willGrant[i]) player.unlocks[i] = willGrant[i]; // and sets a boolean to true if willGrant[i] is true.
            }
            Destroy(this.gameObject);
        }
    }
}
