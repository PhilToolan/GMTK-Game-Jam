using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : PhysicsObject
{
    [Header("Attributes")]
    [SerializeField] private float attackDuration; //How long is the attackBox active when attacking?
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float fallForgiveness = 1; //This is the amount of seconds the Player1 has after falling from a ledge to be able to jump
    [SerializeField] private float fallForgivenessCounter; //This is the simple counter that will begin the moment the Player1 falls from a ledge
    [SerializeField] private AudioClip deathSound;
    private bool frozen;
    private float launch;
    [SerializeField] private float launchRecovery;
    [SerializeField] private Vector2 launchPower;

    [Header("Inventory")]
    public int ammo;
    public int coinsCollected;
    private int maxHealth = 100;
    public int health = 100;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorFunctions animatorFunctions;
    [SerializeField] private GameObject attackBox;
    //public CameraEffects cameraEffects;
    private Vector2 healthBarOrigSize;
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>(); //Dictionary storing all inventory item strings and values
    public Sprite inventoryItemBlank; //The default inventory item slot sprite
    public Sprite keySprite; //The key inventory item
    public Sprite keyGemSprite; //The gem key inventory item

    public AudioSource sfxAudioSource;
    public AudioSource musicAudioSource;
    public AudioSource ambienceAudioSource;
    
    public GameObject barrier1;

    //Singleton instantation
    private static Player1 instance;
    public static Player1 Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player1>();
            return instance;
        }
    }

    private void Awake()
    {
        if (GameObject.Find("New Player1")) Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = "Player1";
        UpdateUI();
        SetSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            //Lerp (ease) the launch value back to zero at all times
            launch += (0 - launch) * Time.deltaTime * launchRecovery;

            targetVelocity = new Vector2(Input.GetAxis("Horizontal2") * maxSpeed + launch, 0);

            //If the Player1 is no longer grounded, begin counting the fallForgivenessCounter
            if (!grounded)
            {
                fallForgivenessCounter += Time.deltaTime;
            }
            else
            {
                fallForgivenessCounter = 0;
            }

            //If the Player1 presses "Jump" and we're grounded, set the velocity to a jump power value
            if (Input.GetButtonDown("Jump2") && fallForgivenessCounter < fallForgiveness)
            {
                //animatorFunctions.EmitParticles1();
                velocity.y = jumpPower;
                grounded = false;
                fallForgivenessCounter = fallForgiveness;
            }


            //Flip the Player1's localScale.x if the move speed is greater than .01 or less than -.01
            if (targetVelocity.x < -.01)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else if (targetVelocity.x > .01)
            {
                transform.localScale = new Vector2(1, 1);
            }

            //If we press "Fire1", then set the attackBox to active. Otherwise, set active to false
            // if (Input.GetButtonDown("Fire1"))
            // {
            //     animator.SetTrigger("attack");
            //     //StartCoroutine(ActivateAttack());
            // }

            //Check if Player1 health is smaller than or equal to 0.
            if (health <= 0)
            {
                //StartCoroutine(Die());
            }
        }

        if (coinsCollected == 1)
        {
            barrier1.SetActive(false);
        }

        //Set each animator float, bool, and trigger so it knows which animation to fire
        // animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        // animator.SetFloat("velocityY", velocity.y);
        // animator.SetBool("grounded", grounded);
        // animator.SetFloat("attackDirectionY", Input.GetAxis("Vertical"));

    }

    //Update UI elements
    public void UpdateUI()
    {
        //If the healthBarOrigSize has not been set yet, match it to the healthBar rectTransform size!
        // if (healthBarOrigSize == Vector2.zero) healthBarOrigSize = GameManager.Instance.healthBar.rectTransform.sizeDelta;
        // GameManager.Instance.coinsText.text = coinsCollected.ToString();
        // GameManager.Instance.healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), GameManager.Instance.healthBar.rectTransform.sizeDelta.y);
    }

    public void SetSpawnPosition()
    {
        //transform.position = GameObject.Find("Spawn Location").transform.position;
    }

    public IEnumerator Die()
    {
        frozen = true;
        // sfxAudioSource.PlayOneShot(deathSound);
        // animator.SetBool("dead", true);
        // animatorFunctions.EmitParticles5();
        //pause (yield) this function for 2 seconds
        yield return new WaitForSeconds(2);
        LoadLevel("Level1");
    }

    public IEnumerator FreezeEffect(float length, float timeScale)
    {
        Time.timeScale = timeScale;
        yield return new WaitForSeconds(length);
        Time.timeScale = 1;

    }

    public void LoadLevel(string loadSceneString)
    {
        // animator.SetBool("dead", false);
        // health = 100;
        // coinsCollected = 0;
        // RemoveInventoryItem("none", true);
        // frozen = false;
        // SceneManager.LoadScene(loadSceneString);
        // SetSpawnPosition();
        // UpdateUI();
    }

    public void AddInventoryItem(string inventoryName, Sprite image = null)
    {
        // inventory.Add(inventoryName, image);
        // //The blank sprite should now swap with key sprite
        // GameManager.Instance.inventoryItemImage.sprite = inventory[inventoryName];
    }

    public void RemoveInventoryItem(string inventoryName, bool removeAll = false)
    {
        // if(!removeAll)
        // {
        //     inventory.Remove(inventoryName);
        // }
        // else
        // {
        //     inventory.Clear();
        // }

        // inventory.Remove(inventoryName);
        // //The blank sprite should now swap with key sprite
        // GameManager.Instance.inventoryItemImage.sprite = inventoryItemBlank;
    }

    public void Hurt(int attackPower, int targetSide)
    {
        // StartCoroutine(FreezeEffect(.5f, .6f));
        // animator.SetTrigger("hurt");
        // Debug.Log("I'm getting hurt on my side:" + targetSide);
        // launch = -targetSide * launchPower.x;
        // velocity.y = launchPower.y;
        // //cameraEffects.Shake(5, .5f);
        // Player1.Instance.health -= attackPower;
        // Player1.Instance.UpdateUI();
    }
}
