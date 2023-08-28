using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioTiWS.Data.Models;

namespace InventarioTiWS.Interfaces
{
    public interface IItem
    {

        public Task<List<Item>> GetAllItems();
        public Task<Item> GetItemByID(string parametro);
        public Task<List<Item>> GetItemByTipo(int parametro);
        public Task<Item> GetItemByNoSerie(string parametro);
        public Task<List<Item>> GetItemByMarca(int parametro);
        public Task<List<Item>> GetItemByProveedor(int parametro);
        public Task<List<Item>> GetItemByUsuario(string parametro);
        public Task<Item> PutItem(int id, Item item);
        Task<Item> PostItem(Item item);

    }
}

