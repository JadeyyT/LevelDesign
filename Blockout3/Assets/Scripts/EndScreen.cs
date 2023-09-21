using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EndScreen : MonoBehaviour
{
    public TMP_Text starDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        starDisplay.text = $"{PlayerInfo.stars} stars collected";
    }
    
}
