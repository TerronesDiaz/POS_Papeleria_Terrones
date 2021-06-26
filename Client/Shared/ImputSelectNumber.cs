using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Papeleria_Terrones.Client.Shared
{
   public class ImputSelectNumber<T> : InputSelect<T>
   {

      protected override bool TryParseValueFromString(string value,
                                                      out T result,
                                                      out string validationErrorMessege)
      {
         if (typeof(T) == typeof(int)) 
         {
         if(int.TryParse(value, out var resultInt)) 
            {
               result = (T)(object)resultInt;
               validationErrorMessege = null;
               return true;
            }
            else 
            {
               result = default;
               validationErrorMessege = "The choosen value is not a valid number.";
               return false;
            }
         }
         else 
         {
            return base.TryParseValueFromString(value, out result, out validationErrorMessege);
         }
      }

   }
}
