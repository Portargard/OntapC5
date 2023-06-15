using AppData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        ThiDbContext db;
        public SanPhamController()
        {
            db = new ThiDbContext();
        }
        // GET: api/<SanPhamController>
        [HttpGet]
        public IEnumerable<SanPham> Get()
        {
            return db.sanPhams.ToList();
        }

        // GET api/<SanPhamController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SanPhamController>
        [HttpPost("Post")]
        public bool Post(SanPham sp)
        {
            try
            {
                db.sanPhams.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("Put")]
        public bool Put(SanPham sp)
        {
            try
            {
                db.sanPhams.Update(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{maSp}")]
        public bool Delete(string maSp)
        {
            try
            {
                var sp = db.sanPhams.ToList().FirstOrDefault(c => c.MaSP == maSp);
                db.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpGet("TinhTien")]
        public float TinhTien(float price,float voucher,float coupon)
        {
            return price*(1-coupon/100)-voucher;
        }
    }
}
