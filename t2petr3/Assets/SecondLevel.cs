using UnityEngine;

public class SecondLevel : MonoBehaviour
{
    
    public void OnButtonClicl()
    {
        PlayerPrefs.SetInt("lvl", 1);
    }
}
