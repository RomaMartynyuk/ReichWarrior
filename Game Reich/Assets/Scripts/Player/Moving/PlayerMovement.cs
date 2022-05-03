using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField] GameObject deadFab;
    [SerializeField] AudioClip deadSound;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    public void TakeDamage(int damage)
    {
        GetComponent<AudioSource>().PlayOneShot(deadSound);

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    void Die()
    {
        Instantiate(deadFab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
