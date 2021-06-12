using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private string inventoryStringName;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private AudioClip collectionSound;
    [SerializeField] private float collectionSoundVolume = 1;

private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the Player1 is touching me, print "Collect" in the console
        if (collision.gameObject == Player1.Instance.gameObject)
        {
            // if(collectionSound) NewPlayer1.Instance.sfxAudioSource.PlayOneShot(collectionSound, collectionSoundVolume*Random.Range(.8f, 1.4f));

            // if (particlesCollectableGlitter)
            // {
            //     particlesCollectableGlitter.transform.parent = null;
            //     particlesCollectableGlitter.gameObject.SetActive(true);
            //     Destroy(particlesCollectableGlitter.gameObject, particlesCollectableGlitter.main.duration);
            // }

            Player1.Instance.coinsCollected += 1;

            Player1.Instance.UpdateUI();
            Destroy(gameObject);
        }
                //If the Player2 is touching me, print "Collect" in the console
        if (collision.gameObject == Player2.Instance.gameObject)
        {
            // if(collectionSound) NewPlayer2.Instance.sfxAudioSource.PlayOneShot(collectionSound, collectionSoundVolume*Random.Range(.8f, 1.4f));

            // if (particlesCollectableGlitter)
            // {
            //     particlesCollectableGlitter.transform.parent = null;
            //     particlesCollectableGlitter.gameObject.SetActive(true);
            //     Destroy(particlesCollectableGlitter.gameObject, particlesCollectableGlitter.main.duration);
            // }

            Player2.Instance.coinsCollected += 1;

            Player2.Instance.UpdateUI();
            Destroy(gameObject);
        }
    }
}
