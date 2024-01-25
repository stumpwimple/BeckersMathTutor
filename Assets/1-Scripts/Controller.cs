using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{
    public int firstNum;
    public int secondNum;
    public Text firstNumText;
    public Text secondNumText;
    public int signCount; // For each sign you are practicing with
    public string sign;
    public Text signText;
    public int answer;
    public GameObject firstSprite;
    public GameObject secondSprite;
    public GameObject firstSpawnPoint;
    public GameObject secondSpawnPoint;
    public Text Answer1;
    public Text Answer2;
    public Text Answer3;
    public Text Answer4;
    public Text finalAnswer;
    public Text congratsText;
    public GameObject winMessage;


    // Use this for initialization
    void Start ()
    {
        firstNum = Random.Range(0, 10);
        secondNum= Random.Range(0, 10);

        if (Random.Range(1, signCount+1) == 1)
        {
            PlusFunction();
        }
        else
        {
            MinusFunction();
        }

        firstSpawn(firstNum);
        secondSpawn(secondNum);

        shuffleAnswers();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void PlusFunction()
    {
        sign = "+";
        signText.text = sign;
        answer = firstNum + secondNum;
    }

    void MinusFunction()
    {
        sign = "-";
        signText.text = sign;
        if (secondNum > firstNum)
        {
            int temp = firstNum;
            firstNum = secondNum;
            secondNum = temp;
        }
        answer = firstNum - secondNum;
    }
    void firstSpawn(int numSpawns)
    {
        firstNumText.text = firstNum.ToString();
        for (int i = 0; i < numSpawns; i++)
        {
            //GameObject sprite = Instantiate(firstSprite, firstSpawnPoint.transform.position + Vector3.forward*i*1.5f, Quaternion.identity) as GameObject; //Linear Spawn
            GameObject sprite = Instantiate(firstSprite, new Vector3(Random.RandomRange(-13f,-1.5f),1f,Random.RandomRange(-8,8)), Quaternion.identity) as GameObject; //Random Spawn
            //sprite.transform.localScale *= Random.RandomRange(0.5f,1.5f); //Randomizes Ball size
        }
    }
    void secondSpawn(int numSpawns)
    {
        secondNumText.text = secondNum.ToString();
        for (int i = 0; i < numSpawns; i++)
        {
            
            //GameObject sprite = Instantiate(secondSprite, secondSpawnPoint.transform.position + Vector3.forward*i*1.5f, Quaternion.identity) as GameObject; //Linear Spawn
            GameObject sprite = Instantiate(secondSprite, new Vector3(Random.RandomRange(1.5f, 13f), 1f, Random.RandomRange(-8, 8)), Quaternion.identity) as GameObject; //Random Spawn
            //sprite.transform.localScale *= Random.RandomRange(0.5f,1.5f); //Randomizes Ball size
        }
    }
    
    public void CheckTheMath(Text text)
    {
        if (text.text == answer+"")
        {
            print("Correct");
            finalAnswer.text = "" + answer;
            winMessage.SetActive(true); // Activates Win Message
            Answer1.gameObject.SetActive(false);
            Answer2.gameObject.SetActive(false);
            Answer3.gameObject.SetActive(false);
            Answer4.gameObject.SetActive(false);
            finalAnswer.gameObject.SetActive(true);
            congratsText.gameObject.SetActive(true);

        }
        else
        {
            print("Incorrect");
            shuffleAnswers();

        }
    }
    void shuffleAnswers()
    {
        int randomizer = Random.RandomRange(-3, 1);
        Answer1.text = "" + (answer + randomizer);
        Answer2.text = "" + (answer + randomizer + 1);
        Answer3.text = "" + (answer + randomizer + 2);
        Answer4.text = "" + (answer + randomizer + 3);
    }

}
