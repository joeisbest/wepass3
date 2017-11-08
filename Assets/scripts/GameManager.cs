using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<Card> cardComparision; 
	void Start () {
		
	}
	void AddNewCard(CardPattern cardPattern){
		GameObject card = Instantiate (Resources.Load<GameObject> ("Prefabs/牌"));
		card.GetComponent<Card> ().cardPattern = cardPattern;
		card.name = "牌_" + cardPattern.ToString ();
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
