using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSoundCon : MonoBehaviour {

    public AudioSource aSourceNormal, aSourceEnemy;
    public float normalVolTarget, normalVolFadeSpeed, enemyVolTarget, enemyVolFadeSpeed;

    private GameObject[] enemies;
    private bool autoMusic;
    private bool enemyMusicOn;

    //targetVol between 0~1;

    public void NormalSoundFade(float speed, float targetVol)
    {
        StartCoroutine(SoundFade(speed, targetVol, aSourceNormal));
        
    }

    public void EnemySoundFade(float speed, float targetVol)
    {
        StartCoroutine(SoundFade(speed, targetVol, aSourceEnemy));
    }


    IEnumerator SoundFade(float sp, float tV, AudioSource AS) 
    {
        

        while (Mathf.Abs(AS.volume - tV)>0.01)
        {

            AS.volume = Mathf.Lerp(AS.volume, tV, sp * Time.deltaTime);
            yield return new WaitForSeconds(0.033f);
        }
        AS.volume = tV;
    }

    

    public void NormalMusicFadeIn()
    {
        CheckIsPlaying();
        NormalSoundFade(normalVolFadeSpeed, normalVolTarget);
        EnemySoundFade(enemyVolFadeSpeed, 0f);
    }

    public void EnemyMusicFadeIn()
    {
        CheckIsPlaying();
        NormalSoundFade(normalVolFadeSpeed, 0f);
        EnemySoundFade(enemyVolFadeSpeed, enemyVolTarget);

    }

    void CheckIsPlaying()
    {
        if (!aSourceEnemy.isPlaying) aSourceEnemy.Play();
        if (!aSourceNormal.isPlaying) aSourceNormal.Play();
    }



    public void AutoMusic(bool onOff)
    {
        autoMusic = onOff;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        if (enemies.Length >1)
        {
            enemyMusicOn = false;
        }
        else
        {
            enemyMusicOn = true;
        }
    }

    void LateUpdate() // after decided the enemyMusicOn
    {
        if (autoMusic)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //Debug.Log(enemies.Length);
            if (enemies.Length > 1)
            {
                if(!enemyMusicOn)
                {
                    
                    StopAllCoroutines();
                    CheckIsPlaying();
                    EnemyMusicFadeIn();
                    enemyMusicOn = true;
                }
                
            }
            else
            {
                if (enemyMusicOn)
                {
                    
                    StopAllCoroutines();
                    CheckIsPlaying();
                    NormalMusicFadeIn();
                    enemyMusicOn = false;
                }
                
            }
        }
        
        

    }

    public void MuteMusic()
    {
        aSourceEnemy.Stop();
        aSourceNormal.Stop();
    }

    public void SetEnemyMusicClip(AudioClip clip)
    {
        aSourceEnemy.clip = clip;
    }

    public void SetNormalMusicClip(AudioClip clip)
    {
        aSourceNormal.clip = clip;
    }

}
