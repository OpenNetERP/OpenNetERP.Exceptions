using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenNetERP.Exceptions
{

    /// <summary>
    /// The PropertyException is thrown when a property value does not meet
    /// the contract of the property.  Ideally it should give a meaningful error 
    /// message describing what was wrong and which property is incorrect. 
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class PropertyException : SystemException, ISerializable
    {

        #region Variables

        private String m_propertyName;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the error message and the property name, or only the error message if no property name is set.(Overrides <see cref="Exception.Message">Exception.Message</see>.)
        /// </summary>
        public override String Message
        {
            get
            {
                String s = base.Message;
                if (!String.IsNullOrEmpty(m_propertyName))
                {
                    String resourceString = string.Format(Localization.Resource.ResourceManager.GetString("Prop_PropertyName_Name"), m_propertyName);
                    return s + Environment.NewLine + resourceString;
                }
                else
                    return s;
            }
        }

        /// <summary>
        /// Gets the name of the property that causes this exception.
        /// </summary>
        public virtual String ProperyName
        {
            get { return m_propertyName; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the <see cref="SerializationInfo">SerializationInfo</see> object with the property name and additional exception information.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        [System.Security.SecurityCritical]  // auto-generated_required 
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            Contract.EndContractBlock();
            base.GetObjectData(info, context);
            info.AddValue("PropertyName", m_propertyName, typeof(String));
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PropertyException class.
        /// </summary>
        public PropertyException() : base(Localization.Resource.ResourceManager.GetString("Prop_PropertyException"))
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public PropertyException(String message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.</param>
        public PropertyException(String message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyException class with a specified error message, the property name, and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="propertyName">The name of the property that caused the current exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.</param>
        public PropertyException(String message, String propertyName, Exception innerException) : base(message, innerException)
        {
            m_propertyName = propertyName;
        }

        /// <summary>
        /// Initializes a new instance of the PropertyException class with a specified error message and the name of the property that causes this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="propertyName">The name of the property that caused the current exception.</param>
        public PropertyException(String message, String propertyName) : base (message)
        {
            m_propertyName = propertyName;
        }

        /// <summary>
        /// Initializes a new instance of the PropertyException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        [System.Security.SecuritySafeCritical]
        protected PropertyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            m_propertyName = info.GetString("PropertyName");
        }

        #endregion
    }
}
