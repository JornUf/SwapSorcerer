using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public Material highlightMaterial;
        public Material selectionMaterial;
        
        private Material originalMaterialHighlight;
        private Material originalMaterialSelection;
        private Transform highlight;
        private Transform selection;
        private RaycastHit raycastHit;

        [SerializeField] private bool lvl0 = false;

        [SerializeField] private SwapStatsPlayer _statsPlayer;

        [SerializeField]
        private GameObject futureHUD;

        CharacterController characterController;
        Vector3 moveDirection = Vector3.zero;

        private bool swapMode = false;

        [HideInInspector] public bool canMove = false;

        private bool started = false;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (started)
            {
                // We are grounded, so recalculate move direction based on axes
                Vector3 forward = (Vector3.forward + Vector3.left).normalized;
                Vector3 right = (Vector3.right + Vector3.forward).normalized;
                // Press Left Shift to run
                bool isRunning = Input.GetKey(KeyCode.LeftShift);
                float curSpeedX = canMove
                    ? (isRunning ? _statsPlayer.RunSpeed.Value : _statsPlayer.WalkSpeed.Value) *
                      Input.GetAxis("Vertical")
                    : 0;
                float curSpeedY = canMove
                    ? (isRunning ? _statsPlayer.RunSpeed.Value : _statsPlayer.WalkSpeed.Value) *
                      Input.GetAxis("Horizontal")
                    : 0;
                float movementDirectionY = moveDirection.y;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
                {
                    moveDirection.y = _statsPlayer.JumpSpeed.Value;
                }
                else
                {
                    moveDirection.y = movementDirectionY;
                }

                // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
                // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
                // as an acceleration (ms^-2)
                if (!characterController.isGrounded && canMove)
                {
                    moveDirection.y -= _statsPlayer.GravitySpeed.Value * 2 * Time.deltaTime;
                }

                // Player and Camera rotation
                if (canMove)
                {
                    // Move the controller
                    characterController.Move(moveDirection * Time.deltaTime);
                    if (Mathf.Abs(curSpeedX) > 0 || Mathf.Abs(curSpeedY) > 0)
                    {
                        transform.forward = new Vector3(moveDirection.x, -90, moveDirection.z);
                    }
                }

                if (Input.GetKeyUp(KeyCode.Q) && !lvl0)
                {
                    swapMode = true;
                    canMove = false;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    futureHUD.SetActive(true);
                }

                if (!canMove && Input.GetKeyUp(KeyCode.E))
                {
                    backtogame();
                }

                if (swapMode)
                {
                    DoSwapStuff();
                }
            }
        }

        public void startgame()
        {
            started = true;
            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void backtogame()
        {
            swapMode = false;
            canMove = true;
            highLightReset();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            futureHUD.SetActive(false);
        }

        void highLightReset()
        {
            if (highlight)
            {
                highlight.GetComponent<MeshRenderer>().material = originalMaterialHighlight;
                highlight = null;
            }

            if (selection)
            {
                selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
                selection.GetComponent<SwapStats>().unselected();
                selection = null;
            }

        }

        void DoSwapStuff()
        {
            // Highlight
            if (highlight != null)
            {
                highlight.GetComponent<MeshRenderer>().sharedMaterial = originalMaterialHighlight;
                highlight = null;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!EventSystem.current.IsPointerOverGameObject() &&
                Physics.Raycast(ray,
                    out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
            {
                highlight = raycastHit.transform;
                if (highlight.gameObject.GetComponent<SwapStats>())
                {
                    if (highlight.gameObject.GetComponent<SwapStats>().SwapStat && highlight != selection)
                    {
                        if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                        {
                            originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
                            highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                        }
                    }
                    else
                    {
                        highlight = null;
                    }
                }
                else
                {
                    highlight = null;
                }
            }

            // Selection
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (highlight)
                {
                    if (selection != null)
                    {
                        selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
                        selection.GetComponent<SwapStats>().unselected();
                    }

                    selection = raycastHit.transform;
                    if (selection.GetComponent<MeshRenderer>().material != selectionMaterial)
                    {
                        originalMaterialSelection = originalMaterialHighlight;
                        selection.GetComponent<MeshRenderer>().material = selectionMaterial;
                    }

                    highlight = null;
                    selection.GetComponent<SwapStats>().gotSelected();
                }
                else
                {
                    if (selection)
                    {
                        selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
                        selection.GetComponent<SwapStats>().unselected();
                        selection = null;
                    }
                }
            }
        }
    }