﻿using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Dtos;
using System.Net;
using System.Net.Mail;

namespace EReconciliation.DataAccess.Concrete
{
    public class EfMailDal : IMailDal
    {
        public void SendMail(SendMailDto sendMailDto)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(sendMailDto.MailParameter.Email);
                mail.To.Add(sendMailDto.Email);
                mail.Subject = sendMailDto.Subject;
                mail.Body = sendMailDto.Body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(sendMailDto.MailParameter.SMTP))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(sendMailDto.MailParameter.Email, sendMailDto.MailParameter.Password);
                    smtp.EnableSsl = sendMailDto.MailParameter.SSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
