using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour {

    public static SFXCtrl instance;
    public SFX sfx;

    void Awake(){
        if(instance==null)
        {
            instance=this;
        }
    }


    public void gem(Vector3 pos){
        Instantiate(sfx.gem,pos,Quaternion.identity);
    }
	public void MagicBottle(Vector3 pos){
		Instantiate (sfx.magicBottle,pos,Quaternion.identity);
	}
	public void purpleWizard(Vector3 pos){
		Instantiate (sfx.purpleWizard,pos,Quaternion.identity);
	}
	public void KeySparkle(Vector3 pos){
		Instantiate (sfx.keySparkle,pos,Quaternion.identity);
	}
	public void enemyDied(Vector3 pos){
		Instantiate (sfx.enemyDied,pos,Quaternion.identity);
	}
	public void Fire(Vector3 pos){
		Instantiate (sfx.fire,pos,Quaternion.identity);
	}
	public void Servicer(Vector3 pos){
		Instantiate (sfx.servitor,pos,Quaternion.identity);
	}
	public void PrisetEnemy(Vector3 pos){
		Instantiate (sfx.prisetEnemy,pos,Quaternion.identity);
	}
	public void Blood(Vector3 pos){
		Instantiate (sfx.blood,pos,Quaternion.identity);
	}
	public void PlayerLand(Vector3 pos){
		Instantiate (sfx.playerLand,pos,Quaternion.identity);
	}
	public void SavePoint(Vector3 pos){
		Instantiate (sfx.star,pos,Quaternion.identity);
	}
	public void BossEffect(Vector3 pos){
		Instantiate (sfx.bossEffect,pos,Quaternion.identity);
	}
	public void DoorEffect(Vector3 pos){
		Instantiate (sfx.doorEffect,pos,Quaternion.identity);
	}
}
