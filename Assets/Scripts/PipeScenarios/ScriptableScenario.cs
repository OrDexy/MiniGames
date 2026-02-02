using UnityEngine;
[CreateAssetMenu(fileName = "Scenario", menuName = "ScriptableObjects/PipeScenarioScriptableObject", order = 1)]
public class PipeScenarioScriptableObject : ScriptableObject
{
	 public int countOfLine;
	 public int countOfTurn;
	 public int countOfTShape;
	 //0 out of 10
    public int yInput;
    public int yOutput;	
}