using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DemoController : ApiController
    {
        EmployeeEntities db = new EmployeeEntities();
        public string Post(Datum datum)
        {
            db.Data.Add(datum);
            db.SaveChanges();
            return "Save the details";
        }
        //Get details
        public IEnumerable<Datum> Get()
        {
            return db.Data.ToList();
        }
        //get details using id
        public Datum Get(int id)
        {
            Datum datums = db.Data.Find(id);
            return datums;
        }
    //Updating details
    public string Put(int id, Datum datum)
        {
            var datum_ = db.Data.Find(id);
            datum_.EmployeeName = datum.EmployeeName;
            datum_.Qualification = datum.Qualification;
            datum_.EmployeeDomain = datum.EmployeeDomain;
            db.Entry(datum_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Modified the data";
        }
        //delete records
        public string Delete(int id)
        {
            Datum datum = db.Data.Find(id);
            db.Data.Remove(datum);
            db.SaveChanges();
            return "Deleted";
        }
    }
}
