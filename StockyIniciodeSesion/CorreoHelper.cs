using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.Mail;

namespace StockyIniciodeSesion
{
    class CorreoHelper
    {
        public static void EnviarCodigo(string destino, string codigo)
        {
            string remitente = "soportedetechzone@gmail.com";
            string contraseñaApp = "qagmqhwalotjzqal"; // sin espacios

            string asunto = "Código de recuperación";
            string cuerpo = $"Tu código de verificación es: {codigo}";

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(remitente, contraseñaApp),
                EnableSsl = true
            };

            var mensaje = new MailMessage(remitente, destino, asunto, cuerpo);
            smtp.Send(mensaje);
        }
    }
}