using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	public CardState cardState;
	public CardPattern cardPattern;
	public GameManager gameManager;
	void Start () {
		cardState = CardState.未翻牌;
	}
	private void OnMouseUp(){
		if (cardState.Equals (CardState.已翻牌)) {
			return;
		}
		if(gameManager.ReadyToCompareCards){
			return;
		}

		OpenCard ();
		gameManager.AddCardInCardComparision (this);
		gameManager.CompareCardsInList ();
	}
	void OpenCard(){
		transform.eulerAngles = new Vector3 (0, 180, 0);
		cardState = CardState.已翻牌;
	}
}

public enum CardState
{
	未翻牌,已翻牌,配對成功
}
public enum CardPattern
{
	無/*預設*/,白花,木桶,玩偶,橘偶,梯子,旗子,繩子,花
}