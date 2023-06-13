// <copyright file="DoublyLinkedListNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Tasks
{
    /// <summary>
    /// Represents an item of a DoublyLinkedList.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public class DoublyLinkedListNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedListNode{T}"/> class.
        /// </summary>
        /// <param name="data">Value of the ccurrent instance.</param>
        public DoublyLinkedListNode(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets value of the current node.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Gets or sets the item that comes after the current one in the DoublyLinkedList.
        /// </summary>
        public DoublyLinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Gets or sets the item that comes before the current one in the DoublyLinkedList.
        /// </summary>
        public DoublyLinkedListNode<T> Previous { get; set; }
    }
}
