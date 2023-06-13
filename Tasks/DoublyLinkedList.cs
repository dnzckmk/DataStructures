// <copyright file="DoublyLinkedList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    /// <summary>
    /// Doubly linked list class.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        /// <summary>
        /// Head of the linked list.
        /// </summary>
        private DoublyLinkedListNode<T> head;

        /// <summary>
        /// Tail of the linked list.
        /// </summary>
        private DoublyLinkedListNode<T> tail;

        /// <summary>
        /// Gets length of the linked list.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Add item at the end of the list.
        /// </summary>
        /// <param name="e">Item to add.</param>
        public void Add(T e)
        {
            var newNode = new DoublyLinkedListNode<T>(e);

            // if the e is the first item
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }

            // if the list has items already
            else
            {
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;
            }

            this.Length++;
        }

        /// <summary>
        /// Add item (e) in the list at the specified index.
        /// </summary>
        /// <param name="index">Index the item will add.</param>
        /// <param name="e">Item to add the list.</param>
        /// <exception cref="IndexOutOfRangeException">If the index is smaller than zero or bigger than the length throw ArgumentOutOfRangeException.</exception>
        public void AddAt(int index, T e)
        {
            if (index < 0 || index > this.Length)
            {
                throw new IndexOutOfRangeException();
            }

            // If index equals to length, add the item at the end of the list.
            if (index == this.Length)
            {
                this.Add(e);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(e);

            // Add item at the beginning of the list.
            if (index == 0)
            {
                newNode.Next = this.head;
                this.head.Previous = newNode;
                this.head = newNode;
            }

            // Add item to the given index
            else
            {
                // Get value at the given index
                var current = this.GetNodeAtIndex(index);
                var previous = current.Previous;

                // Add new node's next and previous info
                newNode.Next = current.Next;
                newNode.Previous = current.Previous;

                // Fix current and previous properties of the next and previous items.
                previous.Next = newNode;
                current.Previous = newNode;
            }

            this.Length++;
        }

        /// <summary>
        /// Get item at the given index.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>Returns value of the item at the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws IndexOutOfRangeException if the index is not valid.</exception>
        public T ElementAt(int index)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException();
            }

            var node = this.GetNodeAtIndex(index);
            return node.Data;
        }

        /// <summary>
        /// Remove item from the list.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        public void Remove(T item)
        {
            var current = this.head;

            // current can be null when it is the tail.
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    this.RemoveNode(current);
                    return;
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Remove item at the given index.
        /// </summary>
        /// <param name="index">Index of the item to be removed.</param>
        /// <returns>Returns removed item's value.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws IndexOutOfRangeException when the given index is not valid.</exception>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException();
            }

            var node = this.GetNodeAtIndex(index);
            this.RemoveNode(node);
            return node.Data;
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(this.head);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Get node at the given index.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>Item at the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">If not found throws exception.</exception>
        private DoublyLinkedListNode<T> GetNodeAtIndex(int index)
        {
            var current = this.head;
            var currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current;
                }

                current = current.Next;
                currentIndex++;
            }

            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Remove item from the list.
        /// </summary>
        /// <param name="node">Item to remove.</param>
        private void RemoveNode(DoublyLinkedListNode<T> node)
        {
            if (node == this.head)
            {
                this.head = node.Next;
                this.head.Previous = null;
            }
            else if (node == this.tail)
            {
                this.tail = node.Previous;
                this.tail.Next = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }

            this.Length--;
        }
    }
}
