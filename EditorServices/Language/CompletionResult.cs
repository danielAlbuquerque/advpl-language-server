﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advpl_language_server.EditorServices
{

    using System;

    /// <summary>
    /// Possible types of CompletionResults
    /// </summary>
    public enum CompletionResultType
    {
        /// <summary> An unknown result type, kept as text only</summary>
        Text = 0,

        /// <summary>A history result type like the items out of get-history</summary>
        History = 1,

        /// <summary>A command result type like the items out of get-command</summary>
        Command = 2,

        /// <summary>A provider item</summary>
        ProviderItem = 3,

        /// <summary>A provider container</summary>
        ProviderContainer = 4,

        /// <summary>A property result type like the property items out of get-member</summary>
        Property = 5,

        /// <summary>A method result type like the method items out of get-member</summary>
        Method = 6,

        /// <summary>A parameter name result type like the Parameters property out of get-command items</summary>
        ParameterName = 7,

        /// <summary>A parameter value result type</summary>
        ParameterValue = 8,

        /// <summary>A variable result type like the items out of get-childitem variable:</summary>
        Variable = 9,

        /// <summary>A namespace</summary>
        Namespace = 10,

        /// <summary>A type name</summary>
        Type = 11,

        /// <summary>A keyword</summary>
        Keyword = 12,

        /// <summary>A dynamic keyword</summary>
        DynamicKeyword = 13,

        // If a new enum is added, there is a range test that uses DynamicKeyword for parameter validation
        // that needs to be updated to use the new enum.
        // We can't use a "MaxValue" enum because it's value would preclude ever adding a new enum.
    }

    /// <summary>
    /// Class used to store a tab completion or Intellisense result
    /// </summary>
    public class CompletionResult
    {
        /// <summary>
        /// ID in DB
        /// </summary>
        public string _id;
        /// <summary>
        /// Text to be used as the auto completion result
        /// </summary>
        private string _completionText;

        /// <summary>
        /// Text to be displayed in a list
        /// </summary>
        private string _listItemText;

        /// <summary>
        /// The text for the tooltip with details to be displayed about the object
        /// </summary>
        private string _toolTip;

        /// <summary>
        /// Type of completion result
        /// </summary>
        private CompletionResultType _resultType;

        /// <summary>
        /// Private member for null instance
        /// </summary>
        private static readonly CompletionResult s_nullInstance = new CompletionResult();

        /// <summary>
        /// Detail
        /// </summary>
        private string _detail;

        public string Detail
        {
            get
            {
                return _detail;
            }
        }
        /// <summary>
        /// Gets the text to be used as the auto completion result
        /// </summary>
        public string CompletionText
        {
            get
            {
                if (this == s_nullInstance)
                {
                    throw new Exception("CompletionText");
                }
                return _completionText;
            }
        }

        /// <summary>
        /// Gets the text to be displayed in a list
        /// </summary>
        public string ListItemText
        {
            get
            {
                if (this == s_nullInstance)
                {
                    throw new Exception("CompletionText");
                }
                return _listItemText;
            }
        }

        /// <summary>
        /// Gets the type of completion result
        /// </summary>
        public CompletionResultType ResultType
        {
            get
            {
                if (this == s_nullInstance)
                {
                    throw new Exception("CompletionText");
                }
                return _resultType;
            }
        }

        /// <summary>
        /// Gets the text for the tooltip with details to be displayed about the object
        /// </summary>
        public string ToolTip
        {
            get
            {
                if (this == s_nullInstance)
                {
                    throw new Exception("CompletionText");
                }
                return _toolTip;
            }
            
        }

        /// <summary>
        /// Gets the null instance of type CompletionResult
        /// </summary>
        internal static CompletionResult Null
        {
            get { return s_nullInstance; }
        }

        /// <summary>
        /// Initializes a new instance of the CompletionResult class
        /// </summary>
        /// <param name="completionText">the text to be used as the auto completion result</param>
        /// <param name="listItemText">he text to be displayed in a list</param>
        /// <param name="resultType">the type of completion result</param>
        /// <param name="toolTip">the text for the tooltip with details to be displayed about the object</param>
        public CompletionResult(string completionText, string listItemText, CompletionResultType resultType, string toolTip, string detail)
        {
            if (String.IsNullOrEmpty(completionText))
            {
                throw new Exception("CompletionText");
            }

            if (String.IsNullOrEmpty(listItemText))
            {
                throw new Exception("CompletionText");
            }

            if (resultType < CompletionResultType.Text || resultType > CompletionResultType.DynamicKeyword)
            {
                throw new Exception("CompletionText");
            }

            if (String.IsNullOrEmpty(toolTip))
            {
                throw new Exception("CompletionText");
            }

            _completionText = completionText;
            _listItemText = listItemText;
            _toolTip = toolTip;
            _resultType = resultType;
            _detail = detail;
        }


        /// <summary>
        /// Initializes a new instance of this class internally if the result out of TabExpansion is a string
        /// </summary>
        /// <param name="completionText">completion text</param>
        public CompletionResult(string completionText)
            : this(completionText, completionText, CompletionResultType.Text, completionText, null)
        {
        }

        /// <summary>
        /// An null instance of CompletionResult.
        /// </summary>
        ///
        /// <remarks>
        /// This can be used in argument completion, to indicate that the completion attempt has gone through the
        /// native command argument completion methods.
        /// </remarks>
        private CompletionResult() { }
    }
}