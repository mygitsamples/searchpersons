using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SearchPersons.Models
{
    public class DataAccess
    {
        string connstring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public List<PersonInfo> getAllPersons(string personname="") {
            List<PersonInfo> lstPersons = new List<PersonInfo>();         
            try {
                SqlConnection conn = new SqlConnection(connstring);
                SqlCommand cmd = new SqlCommand("uspPersonSearch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@person_name",personname);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PersonInfo persons = new PersonInfo();
                    persons.PersonId = Convert.ToInt32(rdr["person_id"]);
                    persons.FirstName = rdr["first_name"].ToString();
                    persons.LastName = rdr["last_name"].ToString();
                    persons.Gender = Convert.ToChar(rdr["gender"]);
                    persons.StateCode = rdr["state_code"].ToString();
                    persons.DOB = Convert.ToDateTime(rdr["DOB"]);
                    lstPersons.Add(persons);
                }
                conn.Close();
                
            }
            catch (Exception ex) { throw ex; }
            return lstPersons;
        }

        public bool updatePerson(int personid, string firstname, string lastname, char gender, DateTime dob, int stateid) {
            bool result = false;
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                SqlCommand cmd = new SqlCommand("uspPersonSearch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@person_id", personid);
                cmd.Parameters.AddWithValue("@first_name", firstname);
                cmd.Parameters.AddWithValue("@last_name", lastname);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@state_id", stateid);
                cmd.Parameters.AddWithValue("@dob", dob);
                conn.Open();
               int rows= cmd.ExecuteNonQuery();
                if (rows > 0) { result=true; }
                conn.Close();
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        public List<StateInfo> getStates() {
            

               List<StateInfo> lstStates = new List<StateInfo>();
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                SqlCommand cmd = new SqlCommand("uspStatesList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StateInfo states = new StateInfo();
                    states.StateId = Convert.ToInt32(rdr["state_id"]);
                    states.StateCode = rdr["state_code"].ToString();                
                    lstStates.Add(states);
                }
                conn.Close();

            }
            catch (Exception ex) { throw ex; }
            return lstStates;



        }
    }
}