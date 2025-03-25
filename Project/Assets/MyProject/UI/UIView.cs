using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.UI
{
    public class UIView : MonoBehaviour
    {
        private static readonly int ShowAnimHash = Animator.StringToHash("Show");
        private static readonly int HideAnimHash = Animator.StringToHash("Hide");

        [SerializeField]
        private List<UIViewPlugin> _plugins;

        public void OwnThisView(UIController owner)
        {
            _ownerController = owner;
        }

        public virtual void Show()
        {
            if (_hideCoroutine != null)
            {
                StopCoroutine(_hideCoroutine);
                if (_animator.gameObject.activeInHierarchy && _animator.HasState(0, ShowAnimHash))
                    _animator.Play(ShowAnimHash, 0, 0);
            }

            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            if (_animator)
            {
                if (_hideCoroutine != null)
                    StopCoroutine(_hideCoroutine);

                _hideCoroutine = StartCoroutine(HideAnimCoroutine());
                return;
            }

            gameObject.SetActive(false);
        }

        #region PROTECTED
        protected UIController _ownerController;

        protected void Start()
        {
            TryGetComponent(out _animator);
        }
        #endregion

        #region PRIVATE
        private Animator _animator;
        private Coroutine _hideCoroutine;

        private IEnumerator HideAnimCoroutine()
        {
            _animator.Play(HideAnimHash);
            yield return null;
            while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
                yield return null;
            gameObject.SetActive(false);
        }
        #endregion
    }
}