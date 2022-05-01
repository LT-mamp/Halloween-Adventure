using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
    //variables públicas
=======
    //saving data test
    [Header("Stuff")]
    [SerializeField] LayerMask ground;
    public GameManager gm;

    [Header("Player")]
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
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
    float Igravity = 9.8f;
    float gravity = -9.8f;

<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
    //m1 rotar espacio
    bool isRotatingPressed = false;
    bool isRotating = false;
=======
    //variables para jump
    [Header("Jump")]
    [SerializeField] float initialJumpVelocity;
    [SerializeField] float maxJumpHeight = 0.5f;
    [SerializeField] float maxJumpTime = .5f;
    bool isJumpPressed = false;
    bool isJumping = false;

    //m1 rotar espacio
    [Header("Rotate")]
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
    public bool isLookingToZ = true;
    [SerializeField] float rotationSpeed = 25f;
    bool isRotatingPressed = false;
    bool isRotating = false;
    Quaternion maxRotation = new Quaternion (0, 0, 0, 1);
    Quaternion minRotation = new Quaternion (0, 0, 0, 1);

<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
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

=======
    [Header("Creation")]
    [SerializeField] Transform originOfCreation;
    //[SerializeField] Vector2 creationPoint;
    [SerializeField] GameObject objectPrefab;
    bool creationActivated = false;
    bool isCreatePlatformPressed = false;
    int directionOfMovement = 1;
    GameObject createdObject = null;

    [Header("Invert")]
    public Transform temporalGroundPoint;
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
    bool isInvertGravityPressed = false;
    bool isInverted = false;

    bool isSwingPressed = false;
    bool swingActive = false;
    Transform swingPosition;
    bool isSwinging = false;

<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
    bool isPushPressed = false;
    bool pushEnabled = false;
    [SerializeField]
    Pusheable[] pusheable;
=======
    [Header("Push")]
    [SerializeField] Pusheable[] pusheable;
    bool isPushPressed = false;
    bool pushEnabled = false;
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
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

<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
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
=======
    public void onMovementInput(InputAction.CallbackContext context){
        if(context.started || context.canceled){
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
        }
        
        isMovementPressed = currentMovement.x != 0 || currentMovement.y != 0;

        if(currentMovement.x > 0){
            directionOfMovement = 1;
        }else if(currentMovement.x < 0){
            directionOfMovement = -1;
        }
    }

    public void onJump(InputAction.CallbackContext context){
        if(context.started || context.canceled){
            isJumpPressed = context.ReadValueAsButton();
        }
    }
    
    public void onRotateWorld(InputAction.CallbackContext context){
        if(gm.isMechanicActive[0] && (context.started || context.canceled)){
            isRotatingPressed = context.ReadValueAsButton(); 
            Debug.Log("ROTANDO " + isRotatingPressed);
        }
    }

    public void onCreatePlatform(InputAction.CallbackContext context){
        if(gm.isMechanicActive[1] && (context.started || context.canceled)){
            isCreatePlatformPressed = context.ReadValueAsButton();
            //Debug.Log("MAGIC = " + isCreatePlatformPressed);
            if(isCreatePlatformPressed){
                //set active esta chuche en la UI
                gm.SetCandyOnUse(Candy.Mars, true);

                createPlatform();
            }
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
        }
    }

<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
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
=======
    public void onInvertGravity(InputAction.CallbackContext context){
        if(gm.isMechanicActive[2] && (context.started || context.canceled)){
            isInvertGravityPressed = context.ReadValueAsButton();
            //Debug.Log("I= " + isInvertGravityPressed);
            if(isInvertGravityPressed){
                invertGravity();
            }
        }
    }

    public void onSwing(InputAction.CallbackContext context){
        if(gm.isMechanicActive[3] && (context.started || context.canceled)){
            isSwingPressed = context.ReadValueAsButton();
            //Debug.Log("SWING = " + isSwingPressed);
        }
    }

    public void onPush(InputAction.CallbackContext context){
        if(gm.isMechanicActive[4] && (context.started || context.canceled)){
            isPushPressed = context.ReadValueAsButton();
            //Debug.Log("PUSHING = " + isPushPressed);

        }
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
    }

    void setUpJumpVariables(){
        float timeToApex = maxJumpTime / 2 ;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        Igravity = (-2 * -maxJumpHeight) / Mathf.Pow(timeToApex, 2);
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
        /*if(rb.velocity.y < -10 || rb.velocity.y > 10){
            Debug.Log(rb.velocity.y);
        }*/

        if(isRotatingPressed){
            isRotating = true;
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
=======
            //set active esta chuche en la UI
            gm.SetCandyOnUse(Candy.Soul, true);
            //gm.activeCandyPrototipo[(int)Candy.Soul].text += "X";
            if(isLookingToZ){
                gm.ActivarElementosEnPlano(2, true);
            }else{
                gm.ActivarElementosEnPlano(1, true);
            }
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
            rotateWorld();
        }else if(isRotating){
            rotateWorld();
        }
        else if(isSwingPressed && swingActive){
            isSwinging = true;
            //set active esta chuche en la UI
            gm.SetCandyOnUse(Candy.Lima, true);
            swing();
        }else if(isSwinging){
            swing();
        }else if(isPushPressed){
            pushEnabled = true;
            //set active esta chuche en la UI
            gm.SetCandyOnUse(Candy.Tibo, true);
            pushUpdateEnabled();
        }else if(count > 0 && pushEnabled){
            count -= Time.deltaTime;
        }else if(pushEnabled){
            count = 10f;
            pushEnabled = false;
            //set active esta chuche en la UI
            gm.SetCandyOnUse(Candy.Tibo, false);
            pushUpdateEnabled();
        }

        moveCharacter();
        if(isInverted) applyGravity(-1, Igravity, temporalGroundPoint);
        else applyGravity(1, gravity, groundPoint);
        jump();
    }

    void applyGravity(int invert, float g, Transform gp){
        /*if(isInverted && !Physics2D.OverlapCircle(groundPoint.position, .1f, ground)){
            Debug.Log("Not grounded");
        }*/
        bool isFalling = (currentMovement.y * invert) <= 0.0f || !isJumpPressed;
        float fallMultiplier = 2.5f;
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
        if(characterController.isGrounded){
            currentMovement.y = groundedGravity;
=======
        if(Physics2D.OverlapCircle(gp.position, .1f, ground) && (rb.velocity.y * invert) <= 0){
            currentMovement.y = groundedGravity * invert;
            //Debug.Log("isGrounded");
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
        }else if(isFalling){
            float previousYVelocity = currentMovement.y;
            float newYVelocity = previousYVelocity + (g * fallMultiplier * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            currentMovement.y = nextYVelocity;
        }else {
            float previousYVelocity = currentMovement.y;
            float newYVelocity = previousYVelocity + (g * Time.deltaTime);
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
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
        bool grounded = true;
        float jumpVel = 0f;
        if(!isInverted){
            grounded = characterController.isGrounded;
            jumpVel = initialJumpVelocity;
        }
        else{
            grounded = true;
            jumpVel = -initialJumpVelocity;
=======
        bool grounded;
        float jumpVel = 0f;
        if(isInverted){ 
            grounded = Physics2D.OverlapCircle(temporalGroundPoint.position, .1f, ground);
            jumpVel = -initialJumpVelocity;
        }
        else{
            grounded = Physics2D.OverlapCircle(groundPoint.position, .1f, ground);
            jumpVel = initialJumpVelocity;
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
        }

        if(!isJumping && grounded && isJumpPressed){
            isJumping = true;
            //Debug.Log("initial=" + initialJumpVelocity + " current=" + currentMovement.y);
            currentMovement.y = jumpVel; //* Time.deltaTime;
            //Debug.Log("result = " + currentMovement.y);
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
=======

            //saving data test
            //gm.Apoints += 1;

>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
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
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
=======
                gm.ActivarElementosEnPlano(1, false);

                //set active esta chuche en la UI
                gm.SetCandyOnUse(Candy.Soul, false);
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
            }
        }else{
            if(world.transform.rotation.y >= minRotation.y){
                actualRotation *= Quaternion.Euler(0, -1 * rotationSpeed * 10 * Time.deltaTime, 0);
            }
            else{
                isRotating = false;
                actualRotation = minRotation;
                isLookingToZ = true;
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
=======
                gm.ActivarElementosEnPlano(2, false);

                //set active esta chuche en la UI
                gm.SetCandyOnUse(Candy.Soul, false);
>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
            }
        }
        characterController.enabled = false;
        world.transform.rotation = actualRotation;
        characterController.enabled = true;
        
    }

    void createPlatform(){
<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
=======
        //Vector2 origin = new Vector2(originOfCreation.position.x, originOfCreation.position.y);
        Vector2 origin = originOfCreation.position;
        if(directionOfMovement == -1){
            origin.x -= 5;
        }
        //Vector2 origin = new Vector2(directionOfMovement*creationPoint.x, creationPoint.y);
        //Debug.Log("Crear plataforma en: " + origin);

>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
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
        if(isInverted){
            Physics2D.gravity = new Vector3(0f, -1f, 0f);
            
            //set active esta chuche en la UI
            gm.SetCandyOnUse(Candy.Leo, true);

        }else{
            Physics2D.gravity = new Vector3(0f, 1f, 0f);

            //set active esta chuche en la UI
            gm.SetCandyOnUse(Candy.Leo, false);
        }

        //gravity = -gravity;
        //groundedGravity = -groundedGravity;

        Debug.Log("Invertido = " + isInverted);

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
        //set active esta chuche en la UI
        gm.SetCandyOnUse(Candy.Lima, false);
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

<<<<<<< Updated upstream:Halloween Adventure/Assets/Scripts/MovementController.cs
    private void OnEnable() {
        playerInput.CharacterControls.Enable();
    }
    private void OnDisable() {
        playerInput.CharacterControls.Disable();
    }
=======
    private void OnCollisionEnter2D(Collision2D other) {
        if(pushEnabled && other.gameObject.tag == "push"){
            Pusheable box = other.gameObject.GetComponent<Pusheable>();
            box.UpdateDirection(directionOfMovement);
        }
        //Debug.Log("pushing");
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(pushEnabled && other.gameObject.tag == "push"){
            Pusheable box = other.gameObject.GetComponent<Pusheable>();
            box.UpdateDirection(0);
        }
    }

    public void LoadData(GameData data){
        gm.Apoints = data.Apoints;
        gm.Bpoints = data.Bpoints;
        gm.Cpoints = data.Cpoints;
    }

    public void SaveData(ref GameData data){
        data.Apoints = gm.Apoints;
        data.Bpoints = gm.Bpoints;
        data.Cpoints = gm.Cpoints;
    }


>>>>>>> Stashed changes:Halloween Adventure/Assets/Scripts/Player/MovementController.cs
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
