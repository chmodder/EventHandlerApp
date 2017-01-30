using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUX.Validation.Rules;
using WinUX.Validation.Rules.Common;

namespace EventHandlerApp.Validation
{
    public class CustomValidationRules : IntValidationRule
    {
        #region Overrides of IntValidationRule

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

        #endregion
    }
}
