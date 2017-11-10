using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

	public List<Card> cardComparision; 
	[Header("卡牌種類清單")]
	public List<CardPattern>cardsToBePutIn;
	public Transform[] positions;
	void Start () {
		GenerateRandomCards();
		//SetupCardsToBePutIn ();
		//AddNewCard (CardPattern.蘋果);
		
	}
	void SetupCardsToBePutIn()//enum List
	{
		Array array = Enum.GetValues(typeof(CardPattern));
		foreach (var item in array) 
			{
				cardsToBePutIn.Add((CardPattern)item);
			}	
		cardsToBePutIn.RemoveAt(0);
	}
	//發牌
	void GenerateRandomCards(){
		int positionIndex = 0;
		for (int i = 0; i < 2; i++) {
			
		
		SetupCardsToBePutIn();
		int maxRandomNumber = cardsToBePutIn.Count;

		for (int j = 0; j < maxRandomNumber; maxRandomNumber--) {
			int randomNumber = UnityEngine.Random.Range (0, maxRandomNumber);
						//抽牌
			AddNewCard(cardsToBePutIn[randomNumber],positionIndex);
			cardsToBePutIn.RemoveAt (randomNumber);
			positionIndex++;
		 }
		}


	}

	void AddNewCard(CardPattern cardPattern,int positionIndex){
		GameObject card = Instantiate (Resources.Load<GameObject> ("Prefabs/牌"));
		card.GetComponent<Card> ().cardPattern = cardPattern;
		card.name = "牌_" + cardPattern.ToString ();
		card.transform.position = positions [positionIndex].position;

		GameObject graphic = Instantiate (Resources.Load<GameObject> ("Prefabs/圖"));
		graphic.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("mypic/" + cardPattern.ToString ());
		graphic.transform.SetParent (card.transform);
		graphic.transform.localPosition = new Vector3 (0, 0, 0.1f);
		graphic.transform.eulerAngles = new Vector3 (0, 180, 0);



	}
	public void AddCardInCardComparision(Card card){
		cardComparision.Add (card); 
	}
	public bool ReadyToCompareCards{
		get{
				if (cardComparision.Count == 2) {		
					return true;				
				} 
				else {
					return false;
				}
			
			}

	}
	public void CompareCardsInList(){
	
		if (ReadyToCompareCards) 
		{
			//Debug.Log ("Can compare cards");
			if (cardComparision [0].cardPattern == cardComparision [1].cardPattern) 
			{
				Debug.Log ("Succese");
				foreach (var card in cardComparision) {
					card.cardState = CardState.配對成功;
				}
				ClearCardComparision();
			} 
			else 
			{
				Debug.Log("Fail");
				StartCoroutine (MissMatchCards ());
				//TurnBackCards ();
				//ClearCardComparision();
			}
							
		}
	}
	void ClearCardComparision(){
		cardComparision.Clear();	
	}
	void TurnBackCards(){
		foreach (var card in cardComparision) {
			card.gameObject.transform.eulerAngles = Vector3.zero;
			card.cardState = CardState.未翻牌;
		}
	}

	IEnumerator MissMatchCards(){
		yield return new WaitForSeconds (1.5f);
		TurnBackCards ();
		ClearCardComparision();
	}
}
