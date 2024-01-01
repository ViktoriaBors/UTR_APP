using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    enum FunctionResultType
    {
        ok,
        error,
        fatal
    }
    internal class FunctionResult
    {
        string message;
        bool result;
        FunctionResultType fresult;

        public FunctionResult()
        {
            Message = string.Empty;
            Result = true;
            Fresult = FunctionResultType.ok;
        }

        public string Message { get => message; set => message = value; }
        public bool Result { get => result; set => result = value; }
        internal FunctionResultType Fresult { get => fresult; set => fresult = value; }
    }
}
