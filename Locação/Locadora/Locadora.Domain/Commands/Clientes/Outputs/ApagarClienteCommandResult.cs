﻿using Locadora.Domain.Interfaces.Commands;

namespace Locadora.Domain.Commands.Clientes.Outputs
{
    public class ApagarClienteCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ApagarClienteCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
