using System;

namespace Hayman.Client.Infrastructure.Core
{
    /// <summary>
    /// Used by the ViewModel to set the state of all
    /// the data of a particular views data to the correct state
    /// </summary>
    [Serializable]
    public enum ViewMode
    {
        /// <summary>
        /// Adding new
        /// </summary>
        AddMode,
        /// <summary>
        /// Edit mode
        /// </summary>
        EditMode,
        /// <summary>
        /// View only mode
        /// </summary>
        ViewOnlyMode,
        /// <summary>
        /// Busy mode
        /// </summary>
        BusyMode
    }
}
