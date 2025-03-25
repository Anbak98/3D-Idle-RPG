using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private List<UIView> Views;

        public void ShowView<T>() where T : UIView
        {
            if (_activeView)
                _activeView.Hide();

            _activeView = _viewLookUp[typeof(T)];
            _activeView.Show();
        }

        public void HideViews()
        {
            foreach (var view in Views)
            {
                view.Hide();
            }
        }

        #region PROTECTED
        protected void Awake()
        {
            _viewLookUp = new();

            foreach (var view in Views)
            {
                view.OwnThisView(this);
                _viewLookUp.Add(view.GetType(), view);
            }

            if(Views.Count > 0)
                _activeView = Views[0];
        }
        #endregion

        #region PRIVATE
        private Dictionary<Type, UIView> _viewLookUp;
        private UIView _activeView;
        #endregion
    }
}