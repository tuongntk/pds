using System;
using FirstNews.Core.Runtime.Validation;

namespace FirstNews.Core.UI.Inputs
{
    [Serializable]
    [InputType("CHECKBOX")]
    public class CheckboxInputType : InputTypeBase
    {
        public CheckboxInputType()
            : this(new BooleanValueValidator())
        {

        }

        public CheckboxInputType(IValueValidator validator)
            : base(validator)
        {
            
        }
    }
}