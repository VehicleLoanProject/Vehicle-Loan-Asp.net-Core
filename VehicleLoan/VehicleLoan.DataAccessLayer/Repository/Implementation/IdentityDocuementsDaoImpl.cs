using System;
using System.Collections.Generic;
using System.Text;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;
using System;
using VehicleLoan.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace VehicleLoanDataAccessLayer.Repository.Implimantation
{
    class IdentityDocumentDaoImpl : IIdentityDocuementDao
    {
        public int UploadIdentityDocument(IdentityDocuementModel identityDocumentsModel)
        {
            IdentityDocuement identityDocuementobj = null;
            try 
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<IdentityDocuement> identityDocuementList = db.IdentityDocuments;
                    identityDocuementobj = new IdentityDocuement()
                    {
                        Adharcard = identityDocumentsModel.Adharcard,
                        Pancard = identityDocumentsModel.Pancard,
                        Photo = identityDocumentsModel.Photo,
                        Salaryslip = identityDocumentsModel?.Salaryslip, 


                    };
                    identityDocuementobj.Upload(identityDocuementobj);
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
                    DbSet<IdentityDocuement> identityDocuementList = db.IdentityDocuments;
                    IdentityDocuement identityDocuement = identityDocuementList.Where(i => i.IdentityId == id).First();
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

        public List<IdentityDocuementModel> GetAllIdentityDocuement()
        {
            List<IdentityDocuementModel> identityDocuementList = null;
            try
            {
                using (var db = new VehicleloanContext())
                {
                    DbSet<IdentityDocuement> allIdentityDocuements = db.IdentityDocuments;
                    identityDocuementList= allIdentityDocuements.Select(
                        Set => new IdentityDocuementModel 
                        {
                            Adharcard = Set.Adharcard,
                            Pancard= Set.Pancard,
                            Photo= Set.Photo,
                            Salaryslip= Set.Salaryslip,
                        }).ToList<IdentityDocuementModel>();
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
