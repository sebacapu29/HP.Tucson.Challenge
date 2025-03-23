﻿using HP.Tucsone.Domain.Entities;
using static HP.Tucsone.Domain.Reserva;

namespace HP.Tucsone.Domain
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public Categoria Categoria { get; private set; }

        private Cliente() { }
        public Cliente(int id, string nombre, Categoria categoria)
        {
            this.Nombre = Nombre;
            this.Categoria = categoria;
            Id = id;
        }
    }
}
