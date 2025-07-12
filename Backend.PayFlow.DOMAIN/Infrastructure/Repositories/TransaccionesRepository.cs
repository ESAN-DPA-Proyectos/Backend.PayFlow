using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Repositories
{
    public class TransaccionesRepository : ITransaccionesRepository
    {
        private readonly PayFlowDbContext _context;

        public TransaccionesRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        // Get all transactions
        public async Task<IEnumerable<Transacciones>> GetAllTransactions()
        {
            return await _context.Transacciones.ToListAsync();
        }

        // Get transacción by IdTransaccion
        public async Task<Transacciones?> GetTransaccionesById(int id)
        {
            return await _context.Transacciones
                .Where(t => t.IdTransaccion == id)
                .FirstOrDefaultAsync();
        }

        // Add category
        
        public async Task<int> AddTransacciones(Transacciones transacciones)
        {
            await _context.Transacciones.AddAsync(transacciones);
            await _context.SaveChangesAsync();
            return transacciones.IdTransaccion;

        }

        // Update transacción
        public async Task<bool> UpdateTransacciones(Transacciones transacciones)
        {
            var existingTransacciones = await GetTransaccionesById(transacciones.IdTransaccion);
            //var existingTransacciones = await _context.Transacciones.FindAsync(transacciones.IdTransaccion);
            if (existingTransacciones == null)
            {
                return false;
            }
            existingTransacciones.Tipo = transacciones.Tipo;
            existingTransacciones.Monto = transacciones.Monto;
            //existingTransacciones.FechaRegistro = transacciones.FechaRegistro; //No debe ser cambiado
            existingTransacciones.Estado = transacciones.Estado;
            existingTransacciones.MetodoPago = transacciones.MetodoPago;

            existingTransacciones.BeneficiarioNombre = transacciones.BeneficiarioNombre; //Añadido para incluir el nombre del beneficiario
            existingTransacciones.CuentaBeneficiario = transacciones.CuentaBeneficiario; //Añadido para incluir la cuenta del beneficiario
            existingTransacciones.Concepto = transacciones.Concepto; //Añadido para incluir el concepto de la transacción
            //existingTransacciones.Referencia = transacciones.Referencia; //Añadido para incluir la referencia de la transacción
            existingTransacciones.Comprobante = transacciones.Comprobante; //Añadido para incluir el comprobante de la transacción

            //_context.Transacciones.Update(existingTransacciones);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete transacción - Por regla de negocio, no se elimina una transacción.


        // Get transacción by IdUsuario
        public async Task<IEnumerable<TransaccionesDTO>> GetTransaccionesByUsu(int id)
        {
            // Se corrige el tipo de retorno del método para que coincida con la proyección a TransaccionesDTO.
            // Se asume que la entidad Transacciones tiene una propiedad IdUsuario para el filtro.
            return await _context.Transacciones
                // CORRECCIÓN: Usar el operador de igualdad (==) para comparar IDs enteros.
                // Si IdUsuario es nullable (int?), la comparación directa '== id' funciona correctamente.
                .Where(tr => tr.IdUsuario == id)
                .Select(tr => new TransaccionesDTO // Proyecta las propiedades necesarias al DTO
                {
                    IdTransaccion = tr.IdTransaccion,
                    Tipo = tr.Tipo,
                    Monto = tr.Monto,
                    FechaRegistro = tr.FechaRegistro,
                    Estado = tr.Estado,
                    MetodoPago = tr.MetodoPago,
                    BeneficiarioNombre = tr.BeneficiarioNombre,
                    CuentaBeneficiario = tr.CuentaBeneficiario,
                    Concepto = tr.Concepto,
                    Referencia = tr.Referencia,
                    Comprobante = tr.Comprobante,
                    OrigenRol = tr.OrigenRol,
                    IdUsuario = tr.IdUsuario // Asegúrate de incluir IdUsuario en el DTO si lo usas para filtrar o mostrar
                })
                .ToListAsync(); // Materializa la consulta a una lista de DTOs
        }


    }

}


