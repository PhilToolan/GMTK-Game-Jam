using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private string inventoryStringName;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private AudioClip collectionSound;
    [SerializeField] private float collectionSoundVolume = 1;

private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is touching me, print "Collect" in the console
        if (collision.gameObject == Player.Instance.gameObject)
        {
            // if(collectionSound) NewPlayer.Instance.sfxAudioSource.PlayOneShot(collectionSound, collectionSoundVolume*Random.Range(.8f, 1.4f));

            // if (particlesCollectableGlitter)
            // {
            //     particlesCollectableGlitter.transform.parent = null;
            //     particlesCollectableGlitter.gameObject.SetActive(true);
            //     Destroy(particlesCollectableGlitter.gameObject, particlesCollectableGlitter.main.duration);
            // }

            Player.Instance.coinsCollected += 1;

            Player.Instance.UpdateUI();
            Destroy(gameObject);
        }
    }
}
