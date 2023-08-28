using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioTiWS.Data.Models;
using InventarioTiWS.Interfaces;
//using InventarioTiWS.Data.Dtos;


namespace InventarioTiWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItem _item;
        public ItemController(IItem item) => _item = item;

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            var items = await _item.GetAllItems();
            return items;
        }

        // GET: api/Estados/5
        [HttpGet("{parametro}")]
        public async Task<ActionResult<Item>> GetItemByID(string parametro)
        {
            var items = await _item.GetItemByID(parametro);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("GetItemByTipo/{parametro}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemByTipo(int parametro)
        {
            var items = await _item.GetItemByTipo(parametro);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("GetItemByNoSerie/{parametro}")]
        public async Task<ActionResult<Item>> GetItemByNoSerie(string parametro)
        {
            var items = await _item.GetItemByNoSerie(parametro);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("GetItemByMarca/{parametro}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemByMarca(int parametro)
        {
            var items = await _item.GetItemByMarca(parametro);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("GetItemByProveedor/{parametro}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemByProveedor(int parametro)
        {
            var items = await _item.GetItemByProveedor(parametro);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("GetItemByUsuario/{parametro}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemByUsuario(string parametro)
        {
            var items = await _item.GetItemByUsuario(parametro);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem([FromRoute] int id, [FromBody] Item item)
        {

            var items = await _item.PutItem(id, item);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _item.PostItem(item);
            return Ok(item);
        }
    }
}