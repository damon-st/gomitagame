using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveJosctick : MonoBehaviour
{

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private float runSpeedMove = 2.5f;

    public Joystick joystick;

    public Rigidbody2D rigidBody2D; // su rigid para aplicarle fuerza tanto para moverlo
    public Animator animator;
    public float speed = 3.1f; // velociada de movimiento
    public Vector2 _movement; // movimeinto del persoanje

    public SpriteRenderer spriteRender;// utilizar el sprite para aser girar izquierda o derecha

    public float jumpForce = 7f; // fuerza de slato

    private bool _isGrounded;  // si esta en el suelo o no para poder saltar

    public LayerMask groundLayer; // aqui utilizamos esto para saver si esta en el suelo o no colisionado por su layer

    public Transform groundChecker; //aqui almacenarros un objeto para instanciar rayitos en ese punto

    public Transform rigthFoot;

    private bool _isGroundRigth;

    public float groundChecekRadius; //aqui sera el radio para la deteccion

    private float longIdle; //variable para almacenar el tiempo que pasa si moverse le usuario
    private float longIdleTime = 5f; // tiempo para inicar la animacion


    public float doubleJumpSpeed = 3.9f; // creamos una varible para la nueva fuerza  o no saltar doble salto

    private bool canDoubleJump; // varible para comprobar si podmeos saltar o no

    private bool _faceRight = true;

    public RectTransform retryMenu;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

       
        if (horizontalMove < 0f && _faceRight == true)
        {
            //aqui si la direccion es en -x seria mirando ala izquierda por lo cual damos un flix a la izquierda
            //spriteRender.flipX = true;
            FLip();

        }

        if (horizontalMove > 0f && _faceRight == false)
        {
            //aqui si la direccion es en +x seria mirando ala derecha por lo cual damos un flix a la izquierda
            //spriteRender.flipX = false;
            FLip();
        }

        //aqui vemos si estamos o no el suelo
        _isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundChecekRadius, groundLayer);

        _isGroundRigth = Physics2D.OverlapCircle(rigthFoot.position, groundChecekRadius, groundLayer);


    }

    private void FixedUpdate()
    {
        //aqui primero multiplicmaos el movieminto por la velocidad que establecimos y  recuperamos el moviemnito y lo guardamos
        //float horizontalVelocity = _movement.normalized.x * speed;

        //aqui pasamos el primer parametro la velocidad horizntal y el segundo la misma velocidad vertical y ai  movemos al personaje por su rigidBody
       // rigidBody2D.velocity = new Vector2(horizontalVelocity, rigidBody2D.velocity.y);
    
        horizontalMove = joystick.Horizontal * speed;

        rigidBody2D.velocity = new Vector2(horizontalMove, rigidBody2D.velocity.y);
        // transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * speed;

    }

    private void LateUpdate()
    {
        //aqui asemos la animacion del movimento de correr

        animator.SetBool("Run", horizontalMove != 0 && _isGrounded && rigthFoot);

        animator.SetBool("IsGround", _isGrounded);

        //comparamos si el personaje esta moviendo o no
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            //aqui aumentamos el contador;
            longIdle += Time.deltaTime;
            //aqui hacemos la comprovacion si es mayor que el tiempo estableicdo
            if (longIdle > longIdleTime)
            {
                animator.SetTrigger("LongIdle");
            }
        }
        else
        {
            longIdle = 0f;
        }

    }

    public void DamageEnemy()
    {
        AudioManager.StopTemporizadorAudio();

        StartCoroutine("VisualFeedBack");
    }

    private IEnumerator VisualFeedBack()
    {
        spriteRender.color = Color.red;


        AudioManager.PlayCollisionEnemyAudio();

        yield return new WaitForSeconds(0.1f);

        spriteRender.color = Color.white;

        //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        Time.timeScale = 0;
        retryMenu.gameObject.SetActive(true);

    }


    void FLip()
    {
        //aqui ago que se voltee el valor
        _faceRight = !_faceRight;

        //para voltear a un persoanje lo asemos en su transfor x que sea siempre a -1
        float localScale = transform.localScale.x;
        localScale = localScale * -1;

        // aqui le ago que se de la vuelta el personaje
        //primer vlaor el nuevo localscalex lo siguientes son  scale su actual escala en y y z 

        transform.localScale = new Vector3(localScale, transform.localScale.y, transform.localScale.z);
    }


    public void Jump()
    {
        if (_isGrounded)
        {
            PlayJumpAudio();
            canDoubleJump = true;
            //  rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
        }
        else
        {

            if (canDoubleJump)
            {
                // rigidBody2D.AddForce(Vector2.up * doubleJumpSpeed, ForceMode2D.Impulse);
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }

        }
    }

    public void PlayWalkAudio()
    {
        AudioManager.PlayWalkStepAudio();
    }

    public void PlayWalkIzquierdoAudio()
    {
        AudioManager.PlayWlakIzquierdoAudio();
    }

    public void PlayJumpAudio()
    {
        AudioManager.PlaySaltarAudio();
    }

    public void PlayPuertaNivelAudio()
    {
        AudioManager.PlayPuertaNivel();
    }
}
