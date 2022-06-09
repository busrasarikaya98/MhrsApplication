using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationBusinessLayer.EMailService
{
    public interface IEmailSenderService
    {
        Task SendAsync(EMailMessage message); //email gönderimleri asenkron olsun projeyi tıkamasın diye task yaptık
    }
}
