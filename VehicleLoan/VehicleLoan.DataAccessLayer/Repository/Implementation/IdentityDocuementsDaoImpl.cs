using System;
using System.Collections.Generic;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;
using VehicleLoan.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq;
using VehicleLoan.BusinessModels;

namespace VehicleLoanDataAccessLayer.Repository.Implimantation
{
    class IdentityDocumentDaoImpl : IIdentityDocumentDao
    {
        public int AddIdentityDocument(IdentityDocumentsModel identityDocumentsModel)
        {
            IdentityDocuments identityDocuementobj = null;
            try 
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<IdentityDocuments> identityDocumentList = db.IdentityDocuments;
                    identityDocuementobj = new IdentityDocuments()
                    {
                        Adharcard = identityDocumentsModel.Adharcard,
                        Pancard = identityDocumentsModel.Pancard,
                        Photo = identityDocumentsModel.Photo,
                        Salaryslip = identityDocumentsModel?.Salaryslip, 


                    };
                    identityDocumentList.Add(identityDocuementobj);
                    int rowAffected = db.SaveChanges();
                    return rowAffected;

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteIdentityDocuements(int id)
        {
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<IdentityDocuments> identityDocuementList = db.IdentityDocuments;
                    IdentityDocuments identityDocuement = identityDocuementList.Where(i => i.IdentityId == id).First();
                    identityDocuementList.Remove(identityDocuement);
                    int rowAffected = db.SaveChanges();
                    return rowAffected;
                        
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<IdentityDocumentsModel> GetAllIdentityDocuement()
        {
            List<IdentityDocumentsModel> identityDocuementList = null;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<IdentityDocuments> allIdentityDocuements = db.IdentityDocuments;
                    identityDocuementList= allIdentityDocuements.Select(
                        Set => new IdentityDocumentsModel
                        {
                            Adharcard = Set.Adharcard,
                            Pancard= Set.Pancard,
                            Photo = Set.Photo,
                            Salaryslip= Set.Salaryslip,
                        }).ToList<IdentityDocumentsModel>();
                    db.SaveChanges();
                    return identityDocuementList;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
