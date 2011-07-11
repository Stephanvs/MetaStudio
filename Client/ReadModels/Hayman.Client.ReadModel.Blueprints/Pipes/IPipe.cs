namespace Hayman.MetaStudio.Core.Pipes
{
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// The generic interface for any Pipe implementation
    /// A pipe takes/consumes objects of type <typeparamref name="TStart"/> and returns/emits objects of type <typeparamref name="TEnd"/>
    /// </summary>
    /// <typeparam name="TStart">Refers to elements</typeparam>
    /// <typeparam name="TEnd">Refers to ends</typeparam>
    public interface IPipe<in TStart, out TEnd> : IPipe,
        IEnumerable<TEnd>,
        IEnumerator<TEnd>
    {
        /// <summary>
        /// Set an enumerator of TStart objects to the head (start) of the pipe.
        /// </summary>
        /// <param name="starts">elements the enumerator of incoming objects</param>
        void Starts(IEnumerator<TStart> starts);

        /// <summary>
        /// Set an enumerable of TStart objects to the head (start) of the pipe.
        /// </summary>
        /// <param name="elements">elements the enumerable of incoming objects</param>
        void Starts(IEnumerable<TStart> elements);
    }

    public interface IPipe
    {
        /// <summary>
        /// Returns the transformation path to arrive at the current object of the pipe.
        /// </summary>
        /// <returns>a List of all of the objects traversed for the current iterator position of the pipe.</returns>
        ArrayList GetPath();
    }
}
