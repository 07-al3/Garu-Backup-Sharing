using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image currentHealth;
    [SerializeField] private Image currentShield;
    [SerializeField] private GameObject deadCanvas;

    public bool dead;
    private Animator anim;
    private Rigidbody2D body;
    private BehavioursSetter behaviourReference;
    private Transform playerPosition;
    public Transform lastCheckpoint {get; private set;}

    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        behaviourReference = GetComponent<BehavioursSetter>();
        playerPosition = GetComponent<Transform>();
    }

    private void Update()
    {
        if(dead)
            die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("enemy"))
            takeDamage((float)other.GetComponent<Variables>().declarations.Get("damageValue"));
        if(other.tag.Equals("CheckPoint"))
        {
            lastCheckpoint = other.transform;
            other.GetComponent<Animator>().SetTrigger("Activate");
        }
        if(other.tag.Equals("Health"))
        {
            currentHealth.fillAmount = Mathf.Clamp(currentHealth.fillAmount + (float)other.GetComponent<Variables>().declarations.Get("Value"), 0, 1f);
            other.gameObject.SetActive(false);
        }
        if(other.tag.Equals("Shield"))
        {
            currentShield.fillAmount = Mathf.Clamp(currentShield.fillAmount + (float)other.GetComponent<Variables>().declarations.Get("Value"), 0, 1f);
            other.gameObject.SetActive(false);
        }
    }

    private void takeDamage(float damage)
    {
        anim.SetTrigger("Hurt");

        if(currentShield.fillAmount < damage)
        {
            float temp = currentShield.fillAmount;
            currentShield.fillAmount = 0f;

            damage -= temp;

            currentHealth.fillAmount -= damage;
            currentHealth.fillAmount = currentHealth.fillAmount < 0.01f ? 0f : currentHealth.fillAmount;
        } 
        else
        {
            currentShield.fillAmount -= damage;   
            currentShield.fillAmount = currentShield.fillAmount < 0.01f ? 0f : currentShield.fillAmount;
        }      

        checkIfDie();
    }

    private void checkIfDie()
    {
        dead = currentHealth.fillAmount == 0;
    }

    private void die()
    {
        anim.SetTrigger("Die");
        behaviourReference.setActive(false);

        body.gravityScale = 0;
        body.linearVelocity = Vector2.zero;

        playerPosition.position = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 0.02f);

        currentHealth.fillAmount = 0;
        currentShield.fillAmount = 0;

        deadCanvas.SetActive(true);
    }
}
