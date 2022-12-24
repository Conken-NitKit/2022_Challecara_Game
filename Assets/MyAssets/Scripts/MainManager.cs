using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private BeholderManager beholderManager;
    [SerializeField] 
    private BlackKnightManager blackKnightManager;
    [SerializeField] 
    private FylingDemonManager fylingDemonManager;
    [SerializeField] 
    private LizardWarriorManager lizardWarriorManager;
    [SerializeField] 
    private RatAssassinManager ratAssassinManager;
    [SerializeField] 
    private SpecterManager specterManager;
    [SerializeField]
    private Timer timer;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.5f);
        beholderManager.Init();
        blackKnightManager.Init();
        fylingDemonManager.Init();
        lizardWarriorManager.Init();
        ratAssassinManager.Init();
        specterManager.Init();
        timer.StartCountUp();
    }
}
