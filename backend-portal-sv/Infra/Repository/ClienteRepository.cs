﻿using Domain.Entity;
using Domain.Entity.Chatbot;
using Infra.Conection;
using Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConnectionContext _context;
        public ClienteRepository(ConnectionContext context)
        {
            _context = context;
        }
        public async Task Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");

            await _context.Clientes.Where(c => c.Id == cliente.Id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não foi encontrado.");
            }
            return cliente;
        }

        public async Task<List<Cliente>> GetAll(int numero_pagina, int quantidade_p_pagina)
        {
            var listaClientes = await _context.Clientes.Skip(numero_pagina * quantidade_p_pagina).Take(quantidade_p_pagina).ToListAsync();
            return listaClientes;
        }

        public async Task Update(Cliente cliente)
        {
            _context.ChangeTracker.Clear(); 
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
