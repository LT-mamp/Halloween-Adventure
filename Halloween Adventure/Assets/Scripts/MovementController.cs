using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    //variables públicas
    public float moveSpeed = 3; 
    public GameObject world;

    //Input
    PlayerInput playerInput;
    CharacterController characterController;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    float direction = 0;

    //Gravity
    float groundedGravity = -0.05f;
    float gravity = -9.8f;

    //m1 rotar espacio
    bool isRotatingPressed = false;
    bool isRotating = false;
    public bool isLookingToZ = true;
    [SerializeField] float rotationSpeed = 25f;
    Quaternion maxRotation = new Quaternion (0, 0, 0, 1);
    Quaternion minRotation = new Quaternion (0, 0, 0, 1);

    //variables para jump
    bool isJumpPressed = false;
    [SerializeField] float initialJumpVelocity;
    [SerializeField] float maxJumpHeight = 0.5f;
    [SerializeField] float maxJumpTime = .5f;
    bool isJumping = false;

    //witch and other
    bool isCreatePlatformPressed = false;
    [SerializeField] Transform originOfObject;
    [SerializeField] GameObject objectPrefab;
    bool creationActivated = false;
    GameObject createdObject = null;

    bool isInvertGravityPressed = false;
    bool isInverted = false;

    bool isSwingPressed = false;
    bool swingActive = false;
    Transform swingPosition;
    bool isSwinging = false;

    bool isPushPressed = false;
    bool pushEnabled = false;
    [SerializeField]
    Pusheable[] pusheable;
    float count = 10f;

    private void Awake() {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();

        //Input callbacks
        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;

        playerInput.CharacterControls.Jump.started += onJump;
        playerInput.CharacterControls.Jump.canceled += onJump;

        playerInput.CharacterControls.RotateWorld.started += onRotateWorld;
        playerInput.CharacterControls.RotateWorld.canceled += onRotateWorld;

        playerInput.CharacterControls.CreatePlatform.started += onCreatePlatform;
        playerInput.CharacterControls.CreatePlatform.canceled += onCreatePlatform;

        playerInput.CharacterControls.InvertGravity.started += onInvertGravity;
        playerInput.CharacterControls.InvertGravity.canceled += onInvertGravity;

        playerInput.CharacterControls.Swing.started += onSwing;
        playerInput.CharacterControls.Swing.canceled += onSwing;

        playerInput.CharacterControls.Push.started += onPush;
        playerInput.CharacterControls.Push.canceled += onPush;

        setUpJumpVariables();
    }

    void onMovementInput(InputAction.CallbackContext context){
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovement.x != 0 || currentMovement.y != 0;
    }

    void onJump(InputAction.CallbackContext context){
        isJumpPressed = context.ReadValueAsButton();
        //Debug.Log("JUMP= " + isJumpPressed);
    }
    
    void onRotateWorld(InputAction.CallbackContext context){
        isRotatingPressed = context.ReadValueAsButton(); 
        //Debug.Log("ROTAR = " + isRotatingPressed);
    }

    void onCreatePlatform(InputAction.CallbackContext context){
        isCreatePlatformPressed = context.ReadValueAsButton();
        //Debug.Log("MAGIC = " + isCreatePlatformPressed);
        if(isCreatePlatformPressed){
            createPlatform();
        }
    }

    void onInvertGravity(InputAction.CallbackContext context){
        isInvertGravityPressed = context.ReadValueAsButton();
        if(isInvertGravityPressed){
            invertGravity();
        }
    }

    void onSwing(InputAction.CallbackContext context){
        isSwingPressed = context.ReadValueAsButton();
        //Debug.Log("SWING = " + isSwingPressed);
    }

    void onPush(InputAction.CallbackContext context){
        isPushPressed = context.ReadValueAsButton();
        //Debug.Log("PUSHING = " + isPushPressed);
    }

    void setUpJumpVariables(){
        float timeToApex = maxJumpTime / 2 ;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxRotation *= Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentMovement);

        if(isRotatingPressed){
            isRotating = true;
            rotateWorld();
        }else if(isRotating){
            rotateWorld();
        }
        else if(isSwingPressed && swingActive){
            isSwinging = true;
            swing();
        }else if(isSwinging){
            swing();
        }else if(isPushPressed){
            pushEnabled = true;
            pushUpdateEnabled();
        }else if(count > 0 && pushEnabled){
            count -= Time.deltaTime;
        }else if(pushEnabled){
            count = 10f;
            pushEnabled = false;
            pushUpdateEnabled();
        }

        moveCharacter();
        applyGravity();
        jump();
    }

    void applyGravity(){
        bool isFalling = currentMovement.y <= 0.0f || !isJumpPressed;
        float fallMultiplier = 2.5f;
        if(characterController.isGrounded){
            currentMovement.y = groundedGravity;
        }else if(isFalling){
            float previousYVelocity = currentMovement.y;
            float newYVelocity = previousYVelocity + (gravity * fallMultiplier * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            currentMovement.y = nextYVelocity;
        }else {
            float previousYVelocity = currentMovement.y;
            float newYVelocity = previousYVelocity + (gravity * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            currentMovement.y = nextYVelocity;
            //Debug.Log("prev=" + previousYVelocity + " new=" + newYVelocity + " next=" + nextYVelocity + " result=" + currentMovement.y);
        }
    }

    void moveCharacter(){
        Vector3 newMovement = new Vector3(0, 0, 0);
        
        if(isRotating){
            newMovement.y = 0;
        }else{
            newMovement.y = currentMovement.y;
        }

        if(isLookingToZ){
            newMovement.x = currentMovement.x * moveSpeed;
            if(newMovement.x > currentMovement.x){
                direction = 1;
            }
            else{
                direction = -1;
            }
        }else{
            newMovement.z =  currentMovement.x * moveSpeed;
            if(newMovement.z > currentMovement.z){
                direction = 1;
            }
            else{
                direction = -1;
            }
        }
        
        characterController.Move(newMovement * Time.deltaTime);
    }

    void jump(){
        bool grounded = true;
        float jumpVel = 0f;
        if(!isInverted){
            grounded = characterController.isGrounded;
            jumpVel = initialJumpVelocity;
        }
        else{
            grounded = true;
            jumpVel = -initialJumpVelocity;
        }
        if(!isJumping && grounded && isJumpPressed){
            isJumping = true;
            //Debug.Log("initial=" + initialJumpVelocity + " current=" + currentMovement.y);
            currentMovement.y = jumpVel; //* Time.deltaTime;
            //Debug.Log("result = " + currentMovement.y);
        }else if(!isJumpPressed && isJumping && grounded){
            isJumping = false;
        }
    }

    void rotateWorld(){
        Quaternion actualRotation = world.transform.rotation;
        if(isLookingToZ){
            if(world.transform.rotation.y <= maxRotation.y){
                actualRotation *= Quaternion.Euler(0, rotationSpeed * 10 * Time.deltaTime, 0);
            }
            else{
                isRotating = false;
                actualRotation = maxRotation;
                isLookingToZ = false;
            }
        }else{
            if(world.transform.rotation.y >= minRotation.y){
                actualRotation *= Quaternion.Euler(0, -1 * rotationSpeed * 10 * Time.deltaTime, 0);
            }
            else{
                isRotating = false;
                actualRotation = minRotation;
                isLookingToZ = true;
            }
        }
        characterController.enabled = false;
        world.transform.rotation = actualRotation;
        characterController.enabled = true;
        
    }

    void createPlatform(){
        if(!creationActivated){
            createdObject = Instantiate(objectPrefab, originOfObject.position, objectPrefab.transform.rotation);
            creationActivated = true;
        }else{
            Destroy(createdObject, .5f);
            createdObject = Instantiate(objectPrefab, originOfObject.position, objectPrefab.transform.rotation);
            creationActivated = true;
        }
    }

    void invertGravity(){
        isInverted = !isInverted;
        if(!isInverted){
            Physics.gravity = new Vector3(0f, -1f, 0f);

        }else{
            Physics.gravity = new Vector3(0f, 1f, 0f);
        }

        gravity = -gravity;
        groundedGravity = -groundedGravity;

        /*Quaternion actualRotation = allPlatforms.transform.rotation;
    
        if(allPlatforms.transform.rotation.z <= maxRotation.y){
            actualRotation *= Quaternion.Euler(0, rotationSpeed * inversionVelocity * Time.deltaTime, 0);
        }
        else{
            isInvertingGravity = false;
            actualRotation.z = maxRotation.y;
        }
        
        allPlatforms.transform.rotation = actualRotation;*/
    }
    
    public void ActivateSwing(Transform swingObjective){
        //mostrar algo que indigue que desde ahí puedes hacer swing o poner algún elemento en la plataforma que lo indique o algo
        Debug.Log("Swing active");
        swingActive = true;
        swingPosition = swingObjective;
    }
    public void DeactivateSwing(){
        swingActive = false;
        swingPosition = null;
    }

    void swing(){
        Debug.Log("from: " + this.gameObject.transform.position + "  to: " + swingPosition.position);
        //characterController.Move(swingPosition.position);
        characterController.enabled = false;
        this.transform.position = swingPosition.position;
        characterController.enabled = true;
        isSwinging = false;
    }
    
    void pushUpdateEnabled(){
        foreach(Pusheable box in pusheable){
            box.UpdatePusheable(pushEnabled);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "push"){
            other.gameObject.GetComponent<Pusheable>().UpdateDirection(direction);
        }
    }

    private void OnEnable() {
        playerInput.CharacterControls.Enable();
    }
    private void OnDisable() {
        playerInput.CharacterControls.Disable();
    }
}


/*
para invertir gravedad es difícil hacer que funcione saltar sin poner código feo´
entonces había pensado ponerlo tipo no invierte la gravedad sino que se agarra al techo porque es super 
fuerte o algo así
entonces si salta se cae al suelo y ya, no vuelve a subir.

Tener en cuenta que hay que chekear que no esté el dialogo abierto para que el pj se pueda mover
i mean
segun si estas en visual novel o no tienes que poder moverte o no
u know

para hacer el sistema de diálogos con múltiples opciones tengo que currármelo o buscar otros vídeos

empujar cosas sin usar rigidbody chungo es
tiene que funcionar de alguna forma, queda investigar pero lo dejo para el segundo asalto de programación
*/
