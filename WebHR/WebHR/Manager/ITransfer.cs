using System.Security.Cryptography.X509Certificates;

namespace WebHR.Manager
{
    public interface ITransfer
    {
        void PermanentTransfer();
        void ReplacementTransfer();
        void ShiftTransfer();
    }
}