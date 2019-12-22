//-----------------------------------------------------------------------
// <copyright file="InputHandler.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Christian Giessrigl</author>
// <summary>
// This file contains the InputHandler class.
// It handles the users input.
// </summary>
//-----------------------------------------------------------------------
namespace TurtleGraphics
{
    using System;
    using System.Collections.Generic;
    using TurtleGraphics.Interfaces;

    /// <summary>
    /// This class ensures that the key, the user presses will be executed correctly.
    /// </summary>
    public class InputHandler : IEditorVisitable
    {
        /// <summary>
        /// The current written line of the user.
        /// </summary>
        private string text;

        /// <summary>
        /// The current page of the current valid command list.
        /// </summary>
        private int pageNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputHandler"/> class.
        /// </summary>
        public InputHandler()
        {
            this.PageNumber = 1;
            this.EditorReadOut = new List<EditorLine>();
            this.Text = string.Empty;
        }

        /// <summary>
        /// Gets or sets the number of the current page of the current valid commands.
        /// </summary>
        /// <value>
        /// The current page of the current valid command list.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If value is less than zero.
        /// </exception>
        public int PageNumber
        {
            get
            {
                return this.pageNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.pageNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of the valid commands the user has written for the current turtle.
        /// </summary>
        /// <value>
        /// The list of the current valid commands of the current turtle.
        /// </value>
        public List<EditorLine> EditorReadOut
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text of the line the user writes at the moment.
        /// </summary>
        /// <value>
        /// The current written line of the user.
        /// </value>
        /// <exception cref="ArgumentNullException">
        /// If value is null.
        /// </exception>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.text = value;
            }
        }

        /// <summary>
        /// This method ensures that the user's pressed key does the right things.
        /// </summary>
        /// <param name="cki">The user's pressed key.</param>
        public void Start(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.Backspace:
                    string newText = string.Empty;
                    for (int i = 0; i < this.Text.Length - 1; i++)
                    {
                        newText += this.Text[i];
                    }

                    this.Text = newText;
                    
                    break;

                case ConsoleKey.LeftArrow:
                    if (this.PageNumber > 1)
                    {
                        this.PageNumber--;
                    }

                    break;

                case ConsoleKey.RightArrow:
                    if (this.PageNumber < (this.EditorReadOut.Count + 9) / 10)
                    {
                        this.PageNumber++;
                    }

                    break;

                default:
                    if (!char.IsControl(cki.KeyChar))
                    {
                        this.Text += cki.KeyChar;
                    }

                    break;
            }
        }

        /// <summary>
        /// Invites the specified visitor in.
        /// </summary>
        /// <param name="visitor">The visiting object.</param>
        /// <exception cref="ArgumentNullException">
        /// If visitor is null.
        /// </exception>
        public void Accept(IEditorVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException();
            }

            visitor.Visit(this);
        }
    }
}
