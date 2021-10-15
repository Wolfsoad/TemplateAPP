using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Common
{
    public struct Messages
    {
        public const string PasswordLengthOutsideRequiredValues = "The {0} must be at least {2} and at max {1} characters long.";

        public const string PasswordConfirmationDontMatchPassword = "The password and confirmation password do not match.";

        public const string NoItemsFoundException = "The list {0} does not contain any element.";
    }
}
