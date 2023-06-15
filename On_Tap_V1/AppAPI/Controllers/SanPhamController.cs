using AppData.Data;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        Context _context;
        public SanPhamController()
        {
            _context  = new Context();
        }
        // GET: api/<SanPhamController>
        [HttpGet]
        public IEnumerable<SanPham> Get()
        {
            return _context.sanPhams.ToList();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("{MaSp}")]
        public IEnumerable<SanPham> Get(string maSp)
        {
            return _context.sanPhams.ToList().Where(c=>c.MaSp == maSp);
        }

        // POST api/<SanPhamController>
        [HttpPost]
        public bool Post(string maSp, string tenSp, int Gia, int SlTon, string nhaSX,string thuonHieu)
        {
            SanPham sp = new SanPham()
            {
                Id = Guid.NewGuid(),
                MaSp = maSp,
                TenSp = tenSp,
                Gia = Gia,
                SlTon = SlTon,
                NhaSx = nhaSX,
                ThuongHieu = thuonHieu
            };
            try
            {
                _context.Add(sp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string maSp, string tenSp, int Gia, int SlTon, string nhaSX, string thuonHieu)
        {
            var sp = _context.sanPhams.ToList().FirstOrDefault(c => c.Id == id);
            sp.MaSp = maSp;
            sp.TenSp = tenSp;
            sp.Gia = Gia;
            sp.SlTon = SlTon;
            sp.NhaSx = nhaSX;
            sp.ThuongHieu = thuonHieu;
            try
            {
                _context.Update(sp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sp = _context.sanPhams.ToList().FirstOrDefault(c => c.Id == id);
            try
            {
                _context.sanPhams.Remove(sp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpGet("TinhGiaTien")]
        public float TinhGiaTien(float price, float voucher, float coupon)
        {
            return price * (1 - coupon / 100) - voucher;
        }
    }
}
