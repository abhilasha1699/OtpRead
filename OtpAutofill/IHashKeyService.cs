using System;
using System.Collections.Generic;
using System.Text;

namespace OtpAutofill
{
    public interface IHashKeyService
    {
        string GenerateHashKey();
        void StartSmsRetRec();
    }
}
