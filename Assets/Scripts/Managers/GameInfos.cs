using UnityEngine;
using System.Collections;

public static class GameInfos {

	public static int playerClass;
	public static int gamemode;

	public static string GetPlayerClassName()
	{
		string className = "";
		switch(playerClass) {
		case 0:
			className = "Tank";
			break;
		case 1:
			className = "Soldier";
			break;
		case 2:
			className = "Ninja";
			break;
		case 3:
			className = "Bomber";
			break;
		case 4:
			className = "Wizard";
			break;
		default:
			throw new UnityException("No class matches.");
		}

		return className;
	}

	public static string GetPlayerTeamName() {
		if(PhotonNetwork.player.GetTeam () == PunTeams.Team.red){
			return "Rebel";
		} else {
			return "Scientist";
		}
	}

	public static Gamemode GetNewGameModeInstance() {
		Gamemode gm = null;
		switch(gamemode) {
		case 0:
			gm = new Deathmatch();
			break;
		case 1:
			gm = new TeamDeathmatch();
			break;
		case 2:
			gm = new CTF();
			break;
		case 3:
			gm = new Domination();
			break;
		case 4:
			gm = new KickEmAll();
			break;
		}

		return gm;
	}
}
