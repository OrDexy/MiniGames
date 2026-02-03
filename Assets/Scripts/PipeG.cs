using UnityEngine;
using System.Collections.Generic;
public class PipeG : MonoBehaviour
{
	 public PipeScenarioScriptableObject[] scenes;
	 
	 public float maxX;
	 public float maxY;
	 
	 public GameObject line;
	 public GameObject turn;
	 public GameObject tShape;
	 public GameObject inP;
	 public GameObject outP;
     void Start()
     {
         int rnd = Random.Range(0, scenes.Length);
         inP.transform.Translate(new Vector3(0, scenes[rnd].yInput, 0));
         outP.transform.Translate(new Vector3(0, scenes[rnd].yOutput, 0));
         for(int i = 0; i < scenes[rnd].countOfLine; i++)
         	   Instantiate(line, new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY)),  Quaternion.identity);
         for(int i = 0; i < scenes[rnd].countOfTurn; i++)
        	   Instantiate(turn, new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY)), Quaternion.identity);
         for(int i = 0; i < scenes[rnd].countOfTShape; i++)
         	   Instantiate(tShape, new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY)), Quaternion.identity);
     }
}
