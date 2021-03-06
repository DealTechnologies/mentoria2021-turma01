﻿using Flunt.Notifications;
using System;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Voto.Inputs
{
    public class VotarCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdFilme { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (IdUsuario <= 0)
                    AddNotification("IdUsuario", Avisos.Campo_obrigatorio);
                
                if (IdFilme <= 0)
                    AddNotification("IdFilme", Avisos.Campo_obrigatorio);

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
