using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DataAccessLayer
{
    public class CorseDetailsRepository
    {
        string connectionString = "server=DESKTOP-8VD1A1F\\SQLEXPRESS;database=Course;user Id =sa;password=Anaiyaan@123;";
        SqlConnection con = null;
        public CorseDetailsRepository()
        {
            con = new SqlConnection(connectionString);
        }

        public List<CourseDetails> SelectALLStudent()
        {
            try
            {
                var selectQuery = $"exec_SelectAllStudents";
                con.Open();
                List<CourseDetails> result = con.Query<CourseDetails>(selectQuery).ToList();
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CourseDetails SelectUserByName(string username)
        {
            try
            {
                var selectQuery = $"exec_SelectByName_'{username}'";
                con.Open();
                CourseDetails result = con.QueryFirstOrDefault<CourseDetails>(selectQuery);
                con.Close();

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RegisterUser(CourseDetails reg)
        {
            try
            {
                var insertQuery = $"exec_InsertUser_'{reg.Name}','{reg.InstitutionName}',{reg.EnquiryNumber},'{reg.Startdate}','{reg.Enddate}',{reg.Fees}";
                con.Open();
                con.Execute(insertQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateUser(CourseDetails reg)
        {
            try
            {
                var updateQuery = $"exec_UpdateUser_{reg.CourseDetailsID},'{reg.Name}','{reg.InstitutionName}',{reg.EnquiryNumber},'{reg.Startdate}','{reg.Enddate}',{reg.Fees}";
                //var connectionString = "server=DESKTOP-8VD1A1F\\SQLEXPRESS;database=batch9;user Id =sa;password=Anaiyaan@123;";

                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void DeleteUser(long regId)
        {
            try
            {
                var updateQuery = $"exec_DeleteUser_{regId}";
                con.Open();
                con.Execute(updateQuery);
                con.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
