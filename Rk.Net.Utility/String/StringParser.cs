using System;
using System.Collections;

namespace Rk.Net.Utility
{
    /// <summary>
    /// An object of StringParser is used to parse text delimeted by a specific character or string.
    /// </summary>
    public sealed class StringParser : IEnumerable
    {
        #region Fields
        private string[] _tokens;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="StringParser"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="splitOptions">The split options.</param>
        public StringParser(string value, char separator, StringSplitOptions splitOptions)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _tokens = value.Split(new char[] { separator }, splitOptions);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringParser"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="splitOptions">The split options.</param>
        public StringParser(string value, string separator, StringSplitOptions splitOptions)
        {
            if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(separator))
            {
                _tokens = value.Split(new string[] { separator }, splitOptions);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the token<see cref="System.String"/> at the specified index.
        /// </summary>
        public string this[int index]
        {
            get
            {
                if (index < 0 || _tokens == null || index > _tokens.Length - 1)
                {
                    return string.Empty;
                }
                else
                {
                    return _tokens[index];
                }
            }
        }

        /// <summary>
        /// Returns the count of tokens.
        /// </summary>
        /// <value>The count of tokens.</value>
        public int Count
        {
            get { return (_tokens == null) ? 0 : _tokens.Length; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            if (_tokens == null) _tokens = new String[0];
            return _tokens.GetEnumerator();
        }
        #endregion
    }
}