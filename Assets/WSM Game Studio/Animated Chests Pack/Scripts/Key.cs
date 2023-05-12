using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace WSMGameStudio
{
    public class Key : MonoBehaviour
    {
        
        public AudioSource _unlockSFX;
        public AudioSource _lockSFX;
        private bool _isPlayerInRange;
        public GameManager gameManager; 

        // private TextMeshPro PickupText;
        [SerializeField] TextMeshProUGUI PickupText;
        // [SerializeField] private Text PickupText;
        


        private void Start()
        {
            PickupText.gameObject.SetActive(false);
           //gameManager.KeyAcquired = true;
            
        }

        private void Update()
        {
            if (_isPlayerInRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Pickup();
                }
            }

        }

        private void OnTriggerEnter(Collider other)
        {
                _isPlayerInRange = true;
                PickupText.gameObject.SetActive(true);
                gameManager.KeyAcquired = true;

        }

         private void OnTriggerStay(Collider other)
        {
  
                _isPlayerInRange = true;
                PickupText.gameObject.SetActive(true);

        }


        private void OnTriggerExit(Collider other)
        {
                  _isPlayerInRange = false;
                PickupText.gameObject.SetActive(false);
                gameManager.KeyAcquired = true;
        }
        
        private void Pickup()
        {
            // gameManager.KeyAcquired = true;
            PickupText.gameObject.SetActive(false);
            Destroy(gameObject);
            gameManager.KeyAcquired = true;
            
        }

        private Animator _animatorController;

        // Use this for initialization
        void Awake()
        {
            _animatorController = GetComponent<Animator>();
        }

        /// <summary>
        /// Play key unlocking animation
        /// </summary>
        public void PlayUnlockAnimation()
        {
            _unlockSFX.Play();
            GetComponent<Animator>().SetBool(AnimationParameters.KeyUnlocked, true);
        }

        /// <summary>
        /// Play key unlocking animation and disable key after half second
        /// </summary>
        public void PlayLockAnimation()
        {
            _lockSFX.Play();
            GetComponent<Animator>().SetBool(AnimationParameters.KeyUnlocked, false);
            Invoke("DisableKey", 0.5f);
        }

        /// <summary>
        /// Disable key invoked by PlayLockAniamtion() method
        /// </summary>
        private void DisableKey()
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}