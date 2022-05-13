using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int questprogress;
    public int questgoal;
    public TextMeshProUGUI questText;
    // Start is called before the first frame update
    void Start()
    {
        questgoal = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        



        questText.text = $"the town needs you to eliminate {questprogress}/{questgoal} SLOGs !!!";


    }
}
