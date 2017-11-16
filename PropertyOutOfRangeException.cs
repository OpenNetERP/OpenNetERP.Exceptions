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
    /// The exception that is thrown when the value of a property is outside the allowable range of values as defined by the invoked property.
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class PropertyOutOfRangeException : PropertyException, ISerializable
    {

        #region Variables

        private static volatile String _rangeMessage;

        private Object m_actualValue;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the argument value that causes this exception.
        /// </summary>
        public virtual Object ActualValue
        {
            get { return m_actualValue; }
        }

        /// <summary>
        /// Gets the error message and the property name, or only the error message if no property name is set.(Overrides <see cref="Exception.Message">Exception.Message</see>.)
        /// </summary>
        public override string Message
        {
            get
            {
                String s = base.Message;
                if (m_actualValue != null)
                {
                    String valueMessage = string.Format(Localization.Resource.ResourceManager.GetString("PropertyOutOfRange_ActualValue"), m_actualValue.ToString());
                    if (s == null)
                        return valueMessage;
                    return s + Environment.NewLine + valueMessage;
                }
                return s;
            }
        }

        private static String RangeMessage
        {
            get
            {
                if (_rangeMessage == null)
                    _rangeMessage = Localization.Resource.ResourceManager.GetString("Prop_PropertyOutOfRangeException");
                return _rangeMessage;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///  Sets the <see cref="SerializationInfo">SerializationInfo</see> object with the property name and additional exception information.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">An object that describes the source or destination of the serialized data.</param>
        [System.Security.SecurityCritical]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            Contract.EndContractBlock();
            base.GetObjectData(info, context);
            info.AddValue("ActualValue", m_actualValue, typeof(Object));
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PropertyOutOfRangeException class.
        /// </summary>
        public PropertyOutOfRangeException() : base(RangeMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyOutOfRangeException class with the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="propertyName">The name of the property that caused the exception.</param>
        public PropertyOutOfRangeException(String propertyName) : base(RangeMessage, propertyName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyOutOfRangeException class with the name of the property that causes this exception and a specified error message.
        /// </summary>
        /// <param name="propertyName">The name of the property that caused the exception.</param>
        /// <param name="message">The message that describes the error.</param>
        public PropertyOutOfRangeException(String propertyName, String message) : base(message, propertyName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PropertyOutOfRangeException class with a specified error message and the exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<b>Nothing</b> in Visual Basic) if no inner exception is specified.</param>
        public PropertyOutOfRangeException(String message, Exception innerException) : base(message, innerException)
        {
        }


        /// <summary>
        /// Initializes a new instance of the PropertyOutOfRangeException class with the property name, the value of the property, and a specified error message.

        /// </summary>
        /// <param name="propertyName">The name of the property that caused the exception.</param>
        /// <param name="actualValue">The value of the property that causes this exception.</param>
        /// <param name="message">The message that describes the error.</param>
        public PropertyOutOfRangeException(String propertyName, Object actualValue, String message) : base(message, propertyName)
        {
            m_actualValue = actualValue;
        }

        /// <summary>
        /// Initializes a new instance of the PropertyOutOfRangeException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">An object that describes the source or destination of the serialized data.</param>
        protected PropertyOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context) {
            m_actualValue = info.GetValue("ActualValue", typeof(Object));
        }

        #endregion
    }
}
