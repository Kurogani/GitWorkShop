using InventarioTiWS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using InventarioTiWS.Data.Models;

namespace InventarioTiWS.Services
{
    public class ItemService : IItem
    {


        private readonly InventarioWebContext _context;

        public ItemService(InventarioWebContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByID(string parametro)
        {
            return await _context.Items.Where(x=>x.CodigoItem == parametro).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetItemByTipo(int parametro)
        {
            return await _context.Items.Where(x => x.ItemTipo == parametro).ToListAsync();
        }

        public async Task<Item> GetItemByNoSerie(string parametro)
        {
            return await _context.Items.Where(x => x.NoSerie == parametro).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetItemByMarca(int parametro)
        {
            return await _context.Items.Where(x => x.Marca == parametro).ToListAsync();
        }

        public async Task<List<Item>> GetItemByProveedor(int parametro)
        {
            return await _context.Items.Where(x => x.Proveedor == parametro).ToListAsync();
        }

        public async Task<List<Item>> GetItemByUsuario(string parametro)
        {
            return await _context.Items.Where(x => x.Usuario == parametro).ToListAsync();
        }

        public async Task<Item> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                //return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                /*string desc = e.ToString();
                string dss = desc.Substring(0, 300);
                ExceptionManager logErrore = new ExceptionManager();
                await logErrore.PostException(_context, dss);*/
                throw e;
            }


            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> PostItem(Item item)
        {
            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                /* string desc = e.ToString();
                 string dss = desc.Substring(0, 300);
                 ExceptionManager logErrore = new ExceptionManager();
                 await logErrore.PostException(_context, dss);*/
                throw e;
            }

            return item;
        }

    }
}
