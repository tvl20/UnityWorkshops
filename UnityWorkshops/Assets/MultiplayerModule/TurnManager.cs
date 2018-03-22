using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour 
{
	public List<Player> AllPlayers;
	public int CurrentPlayerIndex = -1;

	void Start()
	{
		foreach(Player player in AllPlayers)
		{
			player.gameObject.SetActive(false);
		}

		StartTurn();
	}
	
	public void StartTurn()
	{
		changeActivePlayer();

	}

	public void EndTurn()
	{
		StartTurn();
	}

	private void changeActivePlayer()
	{
		if(CurrentPlayerIndex >= 0)
		{
			AllPlayers[CurrentPlayerIndex].gameObject.SetActive(false);
		}

		CurrentPlayerIndex++;
		if (CurrentPlayerIndex >= AllPlayers.Count)
		{
			CurrentPlayerIndex = 0;
		}
		AllPlayers[CurrentPlayerIndex].gameObject.SetActive(true);
	}
}