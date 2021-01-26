﻿using Flunt.Notifications;
using System;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Usuario.Inputs
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", Avisos.Campo_obrigatorio);
                else if (Nome.Length > 50)
                    AddNotification("Nome", Avisos.Campo_maior_que_o_esperado);

                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", Avisos.Campo_obrigatorio);
                else if (Login.Length > 50)
                    AddNotification("Login", Avisos.Campo_maior_que_o_esperado);

                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", Avisos.Campo_obrigatorio);
                else if (!(Senha.Length >= 3 && Senha.Length <= 6))
                    AddNotification("Senha", Avisos.Campo_maior_que_o_esperado);

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
