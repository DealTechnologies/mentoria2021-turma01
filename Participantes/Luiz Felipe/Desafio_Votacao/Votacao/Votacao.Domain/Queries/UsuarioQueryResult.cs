﻿namespace Votacao.Domain.Queries
{
    public class UsuarioQueryResult
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }
    }
}
