using System;
using Tasks.DoNotChange;

namespace Tasks
{
    /// <summary>
    ///  Combination of Queue and Stack structures.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="HybridFlowProcessor{T}"/> class.
        /// </summary>
        public HybridFlowProcessor()
        {
            this.storage = new DoublyLinkedList<T>();
        }

        /// <summary>
        /// Remove item from the beginning of the list.
        /// Queue structure.
        /// FIFO - First in first out.
        /// </summary>
        /// <returns>Returns dequeued item.</returns>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException if the queue is empty.</exception>
        public T Dequeue()
        {
            if (this.storage.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return this.storage.RemoveAt(0);
        }

        /// <summary>
        /// Add item to the end of the list.
        /// Queue structure.
        /// FIFO - First in first out.
        /// </summary>
        /// <param name="item">Item to be added to the queue.</param>
        public void Enqueue(T item)
        {
            this.storage.Add(item);
        }

        /// <summary>
        /// Remove item from the end of the list.
        /// Stack structure.
        /// FILO - First in last out.
        /// </summary>
        /// <returns>Returns poped item.</returns>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException if the stack is empty.</exception>
        public T Pop()
        {
            if (this.storage.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var lastIndex = this.storage.Length - 1;
            return this.storage.RemoveAt(lastIndex);
        }

        /// <summary>
        /// Add item to the end of the list.
        /// Stack structure.
        /// FILO - First in last out.
        /// </summary>
        /// <param name="item">Item to be added to the stack.</param>
        public void Push(T item)
        {
            this.storage.Add(item);
        }
    }
}
