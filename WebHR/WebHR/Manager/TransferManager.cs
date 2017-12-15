using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebHR.Gateway;
using WebHR.Models;

namespace WebHR.Manager
{
    public class TransferManager : ITransfer
    {
        TransferGateway transferGateway = new TransferGateway();

        public int Save(Transfer transfer)
        {
            return transferGateway.Save(transfer);
        }
        public List<Transfer> GetAll()
        {
            return transferGateway.GetAll();
        }

        // Implementing ITransfer
        public void PermanentTransfer()
        {
            
        }

        public void ReplacementTransfer()
        {
            
        }

        public void ShiftTransfer()
        {
            
        }
    }
}