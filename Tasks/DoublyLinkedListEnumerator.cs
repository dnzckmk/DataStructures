using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    /// <summary>
    /// Support iteration through generic DoublyLinkedList collection.
    /// </summary>
    /// <typeparam name="T">Generic T.</typeparam>
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> current;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedListEnumerator{T}"/> class.
        /// </summary>
        /// <param name="head">Head of the linked list.</param>
        public DoublyLinkedListEnumerator(DoublyLinkedListNode<T> head)
        {
            this.head = head;
            this.current = null;
        }

        /// <inheritdoc/>
        public T Current => this.current.Data;

        /// <inheritdoc/>
        object IEnumerator.Current => this.Current;

        /// <inheritdoc/>
        public void Dispose()
        {
            this.head = null;
            this.current = null;
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            if (this.current == null)
            {
                this.current = this.head;
            }
            else
            {
                this.current = this.current.Next;
            }

            return this.current != null;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            this.current = null;
        }
    }
}
