using UnityEngine;
using Unity.VisualScripting;

public class MobHealth : MonoBehaviour
{
    [SerializeField] private float health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Projectile"))
        {
            health -= (float)other.GetComponent<Variables>().declarations.Get("DamageValue");
            try
            {
                GetComponent<Animator>().SetTrigger("Hurt");
            }
            catch(System.Exception)
            {}
        }
        if(health < 0.1f)
            gameObject.SetActive(false);
    }

    public float getHealth()
    {
        return health;
    }
}
