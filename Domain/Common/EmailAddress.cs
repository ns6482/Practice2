using System;
using System.Text.RegularExpressions;

namespace TheTicketSellers.Domain.Common
{
    /// <summary>
    ///     Email address value type, they can be quite complex wtr to validations, so as an object could be beneficial
    ///     Also they are kind of used everywhere
    /// </summary>
    public class EmailAddress
    {
        /// <summary>
        ///     The _email address
        /// </summary>
        private string _emailAddress;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddress" /> class.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public EmailAddress(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddress" /> class.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        public EmailAddress(EmailAddress emailAddress)
        {
            _emailAddress = emailAddress._emailAddress;
        }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>
        ///     The address.
        /// </value>
        /// <exception cref="Exception">
        ///     Email address cannot be null
        ///     or
        ///     Email Address is not in correct format
        /// </exception>
        public string Address
        {
            get { return _emailAddress; }
            set
            {
                //bit crap, should have some sort of generic assertion class, e.g. AssertUtil.CheckNotnull(...), etc.
                if (value == null)
                    throw new Exception("Email address cannot be null");

                if (!Regex.IsMatch(value, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
                    throw new Exception("Email Address is not in correct format");


                //probably have a lot more, e.g. mininmum length etc.

                _emailAddress = value;
            }
        }
    }
}