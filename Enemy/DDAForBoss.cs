using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDAForBoss : DDAForMonsterGroup {

    public AudioClip bossMusic;
    public GeneralSoundCon gSoundCon;

    public override void ForBossStart()
    {
        gSoundCon.aSourceEnemy.clip = bossMusic;
        gSoundCon.aSourceEnemy.Play();
        
    }

    
}
