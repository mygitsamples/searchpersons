using SearchPersons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SearchPersons.Controllers
{
    public class PersonInfoController : Controller
    {
        // GET: PersonInfo
        public ActionResult Index(string personname="")
        {
           
            List<PersonInfo> lstPersons = new List<PersonInfo>();
            DataAccess da = new DataAccess();
            lstPersons=  da.getAllPersons(personname);
            List<StateInfo> lststates = new List<StateInfo>();
            lststates = da.getStates();
           


            return View(lstPersons);
        }
        [HttpPost]
        public ActionResult Index(int personid,string firstname,string lastname,char gender,DateTime dob,int stateid) {        
            DataAccess da = new DataAccess();
            da.updatePerson(personid,firstname,lastname,gender,dob,stateid);
            return View();
        }
    }
}