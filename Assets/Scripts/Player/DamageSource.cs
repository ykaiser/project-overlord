using UnityEngine;
using System.Collections;


public class DamageSource {

	public enum DamageSourceType {
		SUICIDE, /* Player suicide */
		PLAYER, /* Damage from a player */
		/* More to come... */
	}

	public delegate byte[] SerializeMethod(object customObject);
	public delegate object DeserializeMethod(byte[] serializedCustomObject);

	public int damagerID;
	public DamageSourceType type;

	private DamageSource(DamageSourceType type, int damagerID) {
		this.type = type;
		this.damagerID = damagerID;

	}

	public static DamageSource SourceAsPlayer(int damagerID){
		return new DamageSource(DamageSourceType.PLAYER, damagerID);
	}

	public static DamageSource SourceAsSuicide() {
		return new DamageSource(DamageSourceType.SUICIDE, -1);
	}
}
