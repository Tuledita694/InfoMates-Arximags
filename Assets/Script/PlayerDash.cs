using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Configuración del dash
    public float dashSpeed = 12f; // Velocidad ajustada para recorrer ~4 bloques
    public float dashDuration = 0.2f; // Duración ajustada para alcanzar la distancia
    public float dashCooldown = 5f; // Cooldown de 5 segundos

    private Rigidbody2D rb; // Referencia al Rigidbody2D del jugador
    private Vector2 dashDirection; // Dirección del dash
    private bool isDashing = false; // Indicador de si el jugador está dashing
    private float dashTime; // Temporizador del dash
    private float lastDashTime = -Mathf.Infinity; // Último tiempo en el que se hizo un dash

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detectar dirección de movimiento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        dashDirection = new Vector2(moveX, moveY).normalized;

        // Iniciar el dash cuando se presiona J y no está en cooldown
        if (Input.GetKeyDown(KeyCode.J) && !isDashing && Time.time >= lastDashTime + dashCooldown && dashDirection != Vector2.zero)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed; // Movimiento en la dirección del dash
            dashTime -= Time.fixedDeltaTime;

            if (dashTime <= 0)
            {
                EndDash();
            }
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        lastDashTime = Time.time; // Registrar el momento del dash
    }

    void EndDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero; // Detener el movimiento después del dash
    }
}
