using System;
using System.Data;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Layered.Common.Contract
{
    [Serializable]
    public class BusinessValidationException : DataException
    {
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the validation key.
        /// </summary>
        public string ValidationKey { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        public BusinessValidationException() : base()
        {
            PropertyName = string.Empty;
            ValidationKey = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="validationKey">The validation key.</param>
        public BusinessValidationException(string propertyName, string validationKey)
            : this("The property: " + propertyName + " is not valid. Reason: " + validationKey)
        {
            PropertyName = propertyName;
            ValidationKey = validationKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException" /> class.
        /// </summary>
        /// <param name="message"> The message. </param>
        public BusinessValidationException(string message)
          : base(message)
        {
            PropertyName = string.Empty;
            ValidationKey = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="validationKey">The validation key.</param>
        /// <param name="innerException">The inner exception.</param>
        public BusinessValidationException(string propertyName, string validationKey, Exception innerException)
            : this("The property: " + propertyName + " is not valid. Reason: " + validationKey, innerException)
        {
            PropertyName = propertyName;
            ValidationKey = validationKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException" /> class.
        /// </summary>
        /// <param name="message"> The message. </param>
        /// <param name="innerException"> The inner exception. </param>
        public BusinessValidationException(string message, Exception innerException)
          : base(message, innerException)
        {
            PropertyName = string.Empty;
            ValidationKey = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        protected BusinessValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            PropertyName = (string)serializationInfo.GetValue(nameof(PropertyName), typeof(string));
            ValidationKey = (string)serializationInfo.GetValue(nameof(ValidationKey), typeof(string));
        }

        /// <inheritdoc />
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(PropertyName), PropertyName);
            info.AddValue(nameof(ValidationKey), ValidationKey);
            base.GetObjectData(info, context);
        }
    }
}
