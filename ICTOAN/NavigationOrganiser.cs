using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ICTOAN
{
    public class NavigationOrganiser
    {
        #region PROPERTIES

        private Stack<Type> _navigationStack = new();

        public event PageUpdateEventHandler? Navigating;

        #endregion

        /// <summary>
        /// Adds the item `t` to the stack and navigates to it.
        /// </summary>
        /// <param name="t"></param>
        public void NavigateTo(Type t)
        {
            _navigationStack.Push(t);
            Navigate(t, $"Going to page of type: {t}");
        }

        /// <summary>
        /// Removes the highest item in the stack and navigates to the new highest.
        /// </summary>
        public void NavigateBack()
        {
            if (_navigationStack.Count > 1)
            {
                _navigationStack.Pop();
                var previousPageType = _navigationStack.Peek();
                Navigate(previousPageType, $"Going back to: {previousPageType}");
            }
        }

        /// <summary>
        /// Clears the stack and and opens the item of type 't'.
        /// </summary>
        /// <param name="t"></param>
        public void NavigateToMenu(Type t)
        {
            _navigationStack.Clear();
            NavigateTo(t);
        }

        /// <summary>
        /// Clears the stack but keeps the highest item in the stack.
        /// </summary>
        public void ClearHistory()
        {
            if (_navigationStack.Count > 0)
            {
                var currentPageType = _navigationStack.Peek();
                _navigationStack.Clear();
                _navigationStack.Push(currentPageType);
            }
        }


        /// <summary>
        /// Fires the event to alert the Host Window. Message provides some information about the navigation, PageType the Type to navigate to.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="message"></param>
        private void Navigate(Type t, string message)
        {
            Navigating?.Invoke(this, new() { PageType = t, Message = message });
        }
    }

    /// <summary>
    /// Used to notify the Host Window of the ongoing navigation.
    /// </summary>
    public delegate void PageUpdateEventHandler(object sender, NavigationEventArgs args);

    /// <summary>
    /// Arguments to transmit to the Host Window.
    /// </summary>
    public class NavigationEventArgs : EventArgs
    {
        public string Message { get; set; } = "";
        public Type PageType { get; set; } = null!;
    }
}
