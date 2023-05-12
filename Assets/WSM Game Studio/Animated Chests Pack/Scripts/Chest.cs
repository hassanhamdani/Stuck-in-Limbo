using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


namespace WSMGameStudio
{
    public class Chest : MonoBehaviour
    {
        public Enums.OpeningDegrees _openingDegrees;
        public bool _showKeyAnimation;
        public GameObject _keyPrefab;
        public Transform _keyPlaceHolder;
        public AudioSource _openSFX;
        public AudioSource _closeSFX;

        private Animator _animatorController;
        private GameObject _keyClone;
        private Key _keyScript;
        private bool _isOpen = false;
        public GameManager gameManager; 
         private bool _isPlayerInRange; 
         private bool _isSceneLoading = false;

        // private TextMeshPro PickUpTextChest;
        [SerializeField] TextMeshProUGUI PickUpTextChest;

        /// <summary>
        /// initialization
        /// </summary>

        float time;
        float timedelay;

        private void Start()
        {
            PickUpTextChest.gameObject.SetActive(false);
            Debug.Log("starty");
            time = 0f;
            //timedelay = 5f;
            
        }

        private void Update()
        {
            time = time + 1f * Time.deltaTime;
            if (_isPlayerInRange)
            {
                if (Input.GetKeyDown(KeyCode.E) && gameManager.KeyAcquired == true)
                {
                    Open();
                    Debug.Log("Opening chets");
                    // // gameManager.KeyAcquired = false;
                    // if (time > timedelay)
                    // {
                    //     SceneManager.LoadScene("End");
                    // }
                }
            }
           // Debug.Log(time);
        }


        // private void end()
        // {
        //     // Destroy(GameObject.Find("Ellen"),2f);
        //     SceneManager.LoadScene("End");
            
        // }

        private void OnTriggerEnter(Collider other)
        {
                _isPlayerInRange = true;
                PickUpTextChest.gameObject.SetActive(true);
                gameManager.EllenonChest = true;
        }

         private void OnTriggerStay(Collider other)
        {
  
                _isPlayerInRange = true;
                PickUpTextChest.gameObject.SetActive(true);
                gameManager.EllenonChest = true;
        }


        void Awake()
        {
            _animatorController = GetComponent<Animator>();

            UpdateKey();
        }

        /// <summary>
        /// Updates the key model for the opening animation
        /// </summary>
        public void UpdateKey()
        {
            if (_keyPrefab != null)
            {
                _keyClone = Instantiate(_keyPrefab, _keyPlaceHolder);
                _keyClone.transform.parent = _keyPlaceHolder;
                _keyClone.SetActive(false);
                _keyScript = _keyClone.GetComponentInChildren<Key>(true);
            }
        }

        /// <summary>
        /// Play key unlocking and chest opening animations
        /// </summary>
        public void Open()
        {
            if (!_isOpen)
            {
                if (_showKeyAnimation)
                {
                    _keyClone.SetActive(true);
                    _keyScript.PlayUnlockAnimation();

                    //Wait key unlock animation
                    Invoke("OpenChest", 0.5f);
                }
                else
                    OpenChest();
                    Destroy(gameObject,3f);
                    // Destroy(GameObject.Find("Ellen"),5f);

            }
        }

        /// <summary>
        /// Play opening animation
        /// </summary>
        private void OpenChest()
        {
            _openSFX.Play();

            switch (_openingDegrees)
            {
                case Enums.OpeningDegrees.TenDegrees:
                    _animatorController.SetBool(AnimationParameters.Open10Degrees, true);
                    break;
                case Enums.OpeningDegrees.ThirtyDegrees:
                    _animatorController.SetBool(AnimationParameters.Open30Degrees, true);
                    break;
                case Enums.OpeningDegrees.FourtyFiveDegrees:
                    _animatorController.SetBool(AnimationParameters.Open45Degrees, true);
                    break;
                case Enums.OpeningDegrees.SixtyDegrees:
                    _animatorController.SetBool(AnimationParameters.Open60Degrees, true);
                    break;
                case Enums.OpeningDegrees.NinetyDegrees:
                    _animatorController.SetBool(AnimationParameters.Open90Degrees, true);
                    break;
                default:
                    break;
            }

            _isOpen = true;
        }

        /// <summary>
        /// Play chest closing animation
        /// </summary>
        public void Close()
        {
            if (_isOpen)
            {
                _closeSFX.Play();

                _animatorController.SetBool(AnimationParameters.Open10Degrees, false);
                _animatorController.SetBool(AnimationParameters.Open30Degrees, false);
                _animatorController.SetBool(AnimationParameters.Open45Degrees, false);
                _animatorController.SetBool(AnimationParameters.Open60Degrees, false);
                _animatorController.SetBool(AnimationParameters.Open90Degrees, false);

                _isOpen = false;
                //destroy chest
                //sleep for 3 seconds, then slowly fade out the chest
               
                
            }
        }

        /// <summary>
        /// Play key locking animation
        /// </summary>
        public void KeyLockAnimation()
        {
            if (_showKeyAnimation)
            {
                _keyScript.PlayLockAnimation();
            }
        }
    }
}
