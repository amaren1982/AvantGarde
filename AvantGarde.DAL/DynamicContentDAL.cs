using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvantGarde.DataContracts;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace AvantGarde.DAL
{
    public class DynamicContentDAL
    {
        public List<News> GetNewsforHomePage()
        {
            List<News> listNews = new List<News>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetNewsforHomePage", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdDate = objReader.GetOrdinal("Date");
                            int rdDescription = objReader.GetOrdinal("NewsDescription");


                            while (objReader.Read())
                            {
                                News news = new News();
                                if (objReader[rdId] != System.DBNull.Value)
                                    news.NewsId = objReader.GetInt32(rdId);
                                if (objReader[rdDate] != System.DBNull.Value)
                                    news.Date = objReader.GetDateTime(rdDate);
                                if (objReader[rdDescription] != System.DBNull.Value)
                                    news.Content = objReader.GetString(rdDescription);

                                listNews.Add(news);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listNews;
        }
        
        public List<News> GetAllNews()
        {
            List<News> listNews = new List<News>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetAllNews", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdDate = objReader.GetOrdinal("Date");
                            int rdDescription = objReader.GetOrdinal("NewsDescription");


                            while (objReader.Read())
                            {
                                News news = new News();
                                if (objReader[rdId] != System.DBNull.Value)
                                    news.NewsId = objReader.GetInt32(rdId);
                                if (objReader[rdDate] != System.DBNull.Value)
                                    news.Date = objReader.GetDateTime(rdDate);
                                if (objReader[rdDescription] != System.DBNull.Value)
                                    news.Content = objReader.GetString(rdDescription);

                                listNews.Add(news);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listNews;
        }

        public int SaveVendorDetails(VendorDetails vendor)
        {
            int iResult = 0;
            try
            {
                using (SQLHelper sqlHelp = new SQLHelper())
                {
                    sqlHelp.OpenConnection();
                    DbParameter[] sqlParameter = sqlHelp.GetParameters(10);

                    sqlParameter[0].ParameterName = "@SubCategoryId";
                    sqlParameter[0].DbType = System.Data.DbType.Int32;
                    sqlParameter[0].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[0].Value = vendor.SubCategoryId;

                    sqlParameter[1].ParameterName = "@OrgName";
                    sqlParameter[1].DbType = System.Data.DbType.String;
                    sqlParameter[1].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[1].Value = vendor.OrganizationName;

                    sqlParameter[2].ParameterName = "@EstYear";
                    sqlParameter[2].DbType = System.Data.DbType.Int32;
                    sqlParameter[2].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[2].Value = vendor.EstYear;

                    sqlParameter[3].ParameterName = "@Address";
                    sqlParameter[3].DbType = System.Data.DbType.String;
                    sqlParameter[3].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[3].Value = vendor.Address;

                    sqlParameter[4].ParameterName = "@Email";
                    sqlParameter[4].DbType = System.Data.DbType.String;
                    sqlParameter[4].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[4].Value = vendor.Email;

                    sqlParameter[5].ParameterName = "@Phone";
                    sqlParameter[5].DbType = System.Data.DbType.String;
                    sqlParameter[5].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[5].Value = vendor.Phone;

                    sqlParameter[6].ParameterName = "@ContactPerson";
                    sqlParameter[6].DbType = System.Data.DbType.String;
                    sqlParameter[6].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[6].Value = vendor.ContactPerson;

                    sqlParameter[7].ParameterName = "@Mobile";
                    sqlParameter[7].DbType = System.Data.DbType.String;
                    sqlParameter[7].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[7].Value = vendor.Mobile;

                    sqlParameter[8].ParameterName = "@VendorType";
                    sqlParameter[8].DbType = System.Data.DbType.Int32;
                    sqlParameter[8].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[8].Value = vendor.VendorType;

                    sqlParameter[9].ParameterName = "@BusinessDescription";
                    sqlParameter[9].DbType = System.Data.DbType.String;
                    sqlParameter[9].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[9].Value = vendor.Description;

                    iResult = sqlHelp.ExecuteNonQuery("usp_AddVendorDetails", sqlParameter, DBCommandType.StoredProcedure);
                    return iResult;

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<MainCategory> GetAllMainCategories()
        {
            List<MainCategory> listMainCategory = new List<MainCategory>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetMainCategories", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdName = objReader.GetOrdinal("Name");

                            while (objReader.Read())
                            {
                                MainCategory mainCategory = new MainCategory();
                                if (objReader[rdId] != System.DBNull.Value)
                                    mainCategory.Id = objReader.GetInt32(rdId);
                                if (objReader[rdName] != System.DBNull.Value)
                                    mainCategory.Name = objReader.GetString(rdName);
                                listMainCategory.Add(mainCategory);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listMainCategory;
        }

        public List<Category> GetAllCategoriesData()
        {
            List<Category> listCategory = new List<Category>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetCategoriesforMainCategory", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdCode = objReader.GetOrdinal("Code");
                            int rdName = objReader.GetOrdinal("Name");
                            int rdMainCategoryId = objReader.GetOrdinal("MainCategoryId");

                            while (objReader.Read())
                            {
                                Category category = new Category();
                                if (objReader[rdId] != System.DBNull.Value)
                                    category.Id = objReader.GetInt32(rdId);
                                if (objReader[rdName] != System.DBNull.Value)
                                    category.Name = objReader.GetString(rdName);
                                if (objReader[rdCode] != System.DBNull.Value)
                                    category.Code = objReader.GetString(rdCode);
                                if (objReader[rdName] != System.DBNull.Value)
                                    category.MainCategoryId = objReader.GetInt32(rdMainCategoryId);
                                listCategory.Add(category);

                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listCategory;
        }

        public List<SubCategory> GetAllSubCategoriesData()
        {
            List<SubCategory> listSubCategory = new List<SubCategory>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetSubCategoriesforCategory", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdCode = objReader.GetOrdinal("Code");
                            int rdName = objReader.GetOrdinal("Name");
                            int rdCategoryId = objReader.GetOrdinal("CategoryId");

                            while (objReader.Read())
                            {
                                SubCategory subCategory = new SubCategory();
                                if (objReader[rdId] != System.DBNull.Value)
                                    subCategory.Id = objReader.GetInt32(rdId);
                                if (objReader[rdName] != System.DBNull.Value)
                                    subCategory.Name = objReader.GetString(rdName);
                                if (objReader[rdCode] != System.DBNull.Value)
                                    subCategory.Code = objReader.GetString(rdCode);
                                if (objReader[rdName] != System.DBNull.Value)
                                    subCategory.CategoryId = objReader.GetInt32(rdCategoryId);
                                listSubCategory.Add(subCategory);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listSubCategory;
        }

        public List<SelectionCriteria> GetAllSelectionCriteria()
        {
            List<SelectionCriteria> listSelectionCriteria = new List<SelectionCriteria>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetSelectionCriteria", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdDescription = objReader.GetOrdinal("Description");
                            int rdSubCategoryId = objReader.GetOrdinal("SubCategoryId");

                            while (objReader.Read())
                            {
                                SelectionCriteria selectionCriteria = new SelectionCriteria();
                                if (objReader[rdId] != System.DBNull.Value)
                                    selectionCriteria.Id = objReader.GetInt32(rdId);
                                if (objReader[rdDescription] != System.DBNull.Value)
                                    selectionCriteria.Description = objReader.GetString(rdDescription);
                                if (objReader[rdSubCategoryId] != System.DBNull.Value)
                                    selectionCriteria.SubCategoryId = objReader.GetInt32(rdSubCategoryId);
                                listSelectionCriteria.Add(selectionCriteria);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listSelectionCriteria;
        }

        public List<VendorType> GetVendorTypes()
        {
            List<VendorType> listVendorTypes = new List<VendorType>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetVendorTypes", null, DBCommandType.StoredProcedure))
                    {
                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdName = objReader.GetOrdinal("Name");

                            while (objReader.Read())
                            {
                                VendorType vendorType = new VendorType();
                                if (objReader[rdId] != System.DBNull.Value)
                                    vendorType.Id = objReader.GetInt32(rdId);
                                if (objReader[rdName] != System.DBNull.Value)
                                    vendorType.Name = objReader.GetString(rdName);
                                listVendorTypes.Add(vendorType);
                            }
                        }
                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listVendorTypes;
        }

        public int SaveOnlineApplications(OnlineApplication application)
        {
            int iResult = 0;
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {

                    sqlHelp.OpenConnection();
                    DbParameter[] sqlParameter = sqlHelp.GetParameters(16);

                    sqlParameter[0].ParameterName = "@FirstName";
                    sqlParameter[0].DbType = System.Data.DbType.String;
                    sqlParameter[0].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[0].Value = application.FirstName;

                    sqlParameter[1].ParameterName = "@MiddleName";
                    sqlParameter[1].DbType = System.Data.DbType.String;
                    sqlParameter[1].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[1].Value = application.MiddleName;

                    sqlParameter[2].ParameterName = "@LastName";
                    sqlParameter[2].DbType = System.Data.DbType.String;
                    sqlParameter[2].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[2].Value = application.LastName;

                    sqlParameter[3].ParameterName = "@Address";
                    sqlParameter[3].DbType = System.Data.DbType.String;
                    sqlParameter[3].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[3].Value = application.Address;

                    sqlParameter[4].ParameterName = "@Email";
                    sqlParameter[4].DbType = System.Data.DbType.String;
                    sqlParameter[4].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[4].Value = application.Email;

                    sqlParameter[5].ParameterName = "@Landline";
                    sqlParameter[5].DbType = System.Data.DbType.String;
                    sqlParameter[5].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[5].Value = application.LandlineNumber;

                    sqlParameter[6].ParameterName = "@Mobile";
                    sqlParameter[6].DbType = System.Data.DbType.String;
                    sqlParameter[6].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[6].Value = application.Mobile;

                    sqlParameter[7].ParameterName = "@DOB";
                    sqlParameter[7].DbType = System.Data.DbType.DateTime;
                    sqlParameter[7].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[7].Value = application.DateOfBirth;

                    sqlParameter[8].ParameterName = "@Qualification";
                    sqlParameter[8].DbType = System.Data.DbType.String;
                    sqlParameter[8].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[8].Value = application.Qualification;

                    sqlParameter[9].ParameterName = "@Discipline";
                    sqlParameter[9].DbType = System.Data.DbType.String;
                    sqlParameter[9].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[9].Value = application.Discipline;

                    sqlParameter[10].ParameterName = "@CurrentEmployer";
                    sqlParameter[10].DbType = System.Data.DbType.String;
                    sqlParameter[10].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[10].Value = application.CurrentEmployer;

                    sqlParameter[11].ParameterName = "@Experience";
                    sqlParameter[11].DbType = System.Data.DbType.String;
                    sqlParameter[11].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[11].Value = application.Experience;

                    sqlParameter[12].ParameterName = "@CurrentCTC";
                    sqlParameter[12].DbType = System.Data.DbType.String;
                    sqlParameter[12].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[12].Value = application.CurrentCTC;

                    sqlParameter[13].ParameterName = "@ExpectedCTC";
                    sqlParameter[13].DbType = System.Data.DbType.String;
                    sqlParameter[13].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[13].Value = application.ExpectedCTC;

                    sqlParameter[14].ParameterName = "@Resume";
                    sqlParameter[14].DbType = System.Data.DbType.String;
                    sqlParameter[14].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[14].Value = application.Resume;

                    sqlParameter[15].ParameterName = "@Description";
                    sqlParameter[15].DbType = System.Data.DbType.String;
                    sqlParameter[15].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[15].Value = application.Description;

                    iResult = sqlHelp.ExecuteNonQuery("usp_AddOnlineApplication", sqlParameter, DBCommandType.StoredProcedure);
                    return iResult;

                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }


        }

        public int SaveCustomerFeedback(CustomerConnect feedback)
        {
            int iResult = 0;
            try
            {
                using (SQLHelper sqlHelp = new SQLHelper())
                {
                    sqlHelp.OpenConnection();
                    DbParameter[] sqlParameter = sqlHelp.GetParameters(8);

                    sqlParameter[0].ParameterName = "@Type";
                    sqlParameter[0].DbType = System.Data.DbType.Int32;
                    sqlParameter[0].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[0].Value = feedback.Type;

                    sqlParameter[1].ParameterName = "@OrgName";
                    sqlParameter[1].DbType = System.Data.DbType.String;
                    sqlParameter[1].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[1].Value = feedback.OrgName;

                    sqlParameter[2].ParameterName = "@Address";
                    sqlParameter[2].DbType = System.Data.DbType.String;
                    sqlParameter[2].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[2].Value = feedback.Address;

                    sqlParameter[3].ParameterName = "@Email";
                    sqlParameter[3].DbType = System.Data.DbType.String;
                    sqlParameter[3].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[3].Value = feedback.EmailId;

                    sqlParameter[4].ParameterName = "@Mobile";
                    sqlParameter[4].DbType = System.Data.DbType.String;
                    sqlParameter[4].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[4].Value = feedback.Mobile;

                    sqlParameter[5].ParameterName = "@ProposalNo";
                    sqlParameter[5].DbType = System.Data.DbType.String;
                    sqlParameter[5].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[5].Value = feedback.ProposalNo;

                    sqlParameter[6].ParameterName = "@Subject";
                    sqlParameter[6].DbType = System.Data.DbType.String;
                    sqlParameter[6].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[6].Value = feedback.Subject;

                    sqlParameter[7].ParameterName = "@Description";
                    sqlParameter[7].DbType = System.Data.DbType.String;
                    sqlParameter[7].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[7].Value = feedback.Description;

                    iResult = sqlHelp.ExecuteNonQuery("usp_AddCustomerConnect", sqlParameter, DBCommandType.StoredProcedure);
                    return iResult;

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<EmailTemplate> GetEmailTemplates()
        {
            List<EmailTemplate> listEmailTemplate = new List<EmailTemplate>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetEmailTemplates", null, DBCommandType.StoredProcedure))
                    {
                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("TemplateId");
                            int rdName = objReader.GetOrdinal("TemplateName");
                            int rdContent = objReader.GetOrdinal("TemplateContent");
                            int rdSubject = objReader.GetOrdinal("EmailSubject");
                            int rdEmailTo = objReader.GetOrdinal("SendEmailTo");

                            while (objReader.Read())
                            {
                                EmailTemplate objEmailTemplate = new EmailTemplate();
                                if (objReader[rdId] != System.DBNull.Value)
                                    objEmailTemplate.TemplateId = objReader.GetInt32(rdId);
                                if (objReader[rdName] != System.DBNull.Value)
                                    objEmailTemplate.TemplateName = objReader.GetString(rdName);
                                if (objReader[rdContent] != System.DBNull.Value)
                                    objEmailTemplate.TemplateContent = objReader.GetString(rdContent);
                                if (objReader[rdSubject] != System.DBNull.Value)
                                    objEmailTemplate.EmailSubject = objReader.GetString(rdSubject);
                                if (objReader[rdEmailTo] != System.DBNull.Value)
                                    objEmailTemplate.SendEmailTo = objReader.GetString(rdEmailTo);
                                listEmailTemplate.Add(objEmailTemplate);
                            }
                        }
                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listEmailTemplate;
        }

        public List<Downloads> GetDownloadsList()
        {
            List<Downloads> listDownloads = new List<Downloads>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetDownloadsList", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdDownloadId = objReader.GetOrdinal("DownloadId");
                            int rdAttachmentId = objReader.GetOrdinal("AttachmentId");
                            int rdSectionId = objReader.GetOrdinal("SectionId");
                            int rdDisplayName = objReader.GetOrdinal("DisplayName");
                            int rdDownloadPath = objReader.GetOrdinal("DownloadPath");
                            int rdCreatedDate = objReader.GetOrdinal("CreatedDate");
                            int rdModifiedDate = objReader.GetOrdinal("ModifiedDate");
                            int rdSectionName = objReader.GetOrdinal("SectionName");
                            
                            while (objReader.Read())
                            {
                                Downloads downloads = new Downloads();
                                if (objReader[rdDownloadId] != System.DBNull.Value)
                                    downloads.Id = objReader.GetInt32(rdDownloadId);
                                if (objReader[rdAttachmentId] != System.DBNull.Value)
                                    downloads.AttachmentId = objReader.GetInt32(rdAttachmentId);
                                if (objReader[rdSectionId] != System.DBNull.Value)
                                    downloads.SectionId = objReader.GetInt32(rdSectionId);
                                if (objReader[rdDisplayName] != System.DBNull.Value)
                                    downloads.DisplayName = objReader.GetString(rdDisplayName);
                                if (objReader[rdCreatedDate] != System.DBNull.Value)
                                    downloads.CreatedDate = Convert.ToDateTime(objReader[rdCreatedDate]);
                                if (objReader[rdModifiedDate] != System.DBNull.Value)
                                    downloads.ModifiedDate = Convert.ToDateTime(objReader[rdModifiedDate]);
                                if (objReader[rdDownloadPath] != System.DBNull.Value)
                                    downloads.DownloadPath = objReader.GetString(rdDownloadPath);
                                if (objReader[rdSectionName] != System.DBNull.Value)
                                    downloads.SectionName = objReader.GetString(rdSectionName);
                                listDownloads.Add(downloads);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listDownloads;
        }

        public List<PhotoGallery> GetGalleryList()
        {
            List<PhotoGallery> listGallery = new List<PhotoGallery>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetPhotoGalleryList", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdPhotoGalleryId = objReader.GetOrdinal("PhotoGalleryId");
                            int rdAttachmentId = objReader.GetOrdinal("AttachmentId");
                            int rdSectionId = objReader.GetOrdinal("SectionId");
                            int rdDisplayName = objReader.GetOrdinal("DisplayName");
                            int rdDownloadPath = objReader.GetOrdinal("DownloadPath");
                            int rdCreatedDate = objReader.GetOrdinal("CreatedDate");
                            int rdModifiedDate = objReader.GetOrdinal("ModifiedDate");
                            int rdSectionName = objReader.GetOrdinal("SectionName");

                            while (objReader.Read())
                            {
                                PhotoGallery downloads = new PhotoGallery();
                                if (objReader[rdPhotoGalleryId] != System.DBNull.Value)
                                    downloads.Id = objReader.GetInt32(rdPhotoGalleryId);
                                if (objReader[rdAttachmentId] != System.DBNull.Value)
                                    downloads.AttachmentId = objReader.GetInt32(rdAttachmentId);
                                if (objReader[rdSectionId] != System.DBNull.Value)
                                    downloads.SectionId = objReader.GetInt32(rdSectionId);
                                if (objReader[rdDisplayName] != System.DBNull.Value)
                                    downloads.DisplayName = objReader.GetString(rdDisplayName);
                                if (objReader[rdCreatedDate] != System.DBNull.Value)
                                    downloads.CreatedDate = Convert.ToDateTime(objReader[rdCreatedDate]);
                                if (objReader[rdModifiedDate] != System.DBNull.Value)
                                    downloads.ModifiedDate = Convert.ToDateTime(objReader[rdModifiedDate]);
                                if (objReader[rdDownloadPath] != System.DBNull.Value)
                                    downloads.DownloadPath = objReader.GetString(rdDownloadPath);
                                if (objReader[rdSectionName] != System.DBNull.Value)
                                    downloads.SectionName = objReader.GetString(rdSectionName);
                                listGallery.Add(downloads);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listGallery;
        }

        public List<Testimonial> GetAllTestimonials()
        {
            List<Testimonial> listTestimonials = new List<Testimonial>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetAllTestimonials", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdTestimonialId = objReader.GetOrdinal("TestimonialId");
                            int rdSectionId = objReader.GetOrdinal("SectionId");
                            int rdDisplayName = objReader.GetOrdinal("DisplayName");
                            int rdDownloadPath = objReader.GetOrdinal("DownloadPath");
                            int rdCreatedDate = objReader.GetOrdinal("CreatedDate");
                            int rdModifiedDate = objReader.GetOrdinal("ModifiedDate");
                            int rdSectionName = objReader.GetOrdinal("SectionName");

                            while (objReader.Read())
                            {
                                Testimonial downloads = new Testimonial();
                                if (objReader[rdTestimonialId] != System.DBNull.Value)
                                    downloads.Id = objReader.GetInt32(rdTestimonialId);
                                if (objReader[rdSectionId] != System.DBNull.Value)
                                    downloads.SectionId = objReader.GetInt32(rdSectionId);
                                if (objReader[rdDisplayName] != System.DBNull.Value)
                                    downloads.DisplayName = objReader.GetString(rdDisplayName);
                                if (objReader[rdCreatedDate] != System.DBNull.Value)
                                    downloads.CreatedDate = Convert.ToDateTime(objReader[rdCreatedDate]);
                                if (objReader[rdModifiedDate] != System.DBNull.Value)
                                    downloads.ModifiedDate = Convert.ToDateTime(objReader[rdModifiedDate]);
                                if (objReader[rdDownloadPath] != System.DBNull.Value)
                                    downloads.DownloadPath = objReader.GetString(rdDownloadPath);
                                if (objReader[rdSectionName] != System.DBNull.Value)
                                    downloads.SectionName = objReader.GetString(rdSectionName);
                                listTestimonials.Add(downloads);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listTestimonials;
        }

        public List<CurrentOpenings> GetAllActiveOpenings()
        {
            List<CurrentOpenings> listOpenings = new List<CurrentOpenings>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("usp_GetAllActiveOpenings", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("Id");
                            int rdCompany = objReader.GetOrdinal("Company");
                            int rdPosition = objReader.GetOrdinal("Position");
                            int rdQualification = objReader.GetOrdinal("Qualification");
                            int rdSkillset = objReader.GetOrdinal("Skillset");
                            int rdEmail = objReader.GetOrdinal("Email");
                            int rdOpenTillDate = objReader.GetOrdinal("OpenTillDate");
                            int rdCreatedDate = objReader.GetOrdinal("CreatedDate");
                            int rdModifiedDate = objReader.GetOrdinal("ModifiedDate");
                            
                            while (objReader.Read())
                            {
                                CurrentOpenings openings = new CurrentOpenings();
                                if (objReader[rdId] != System.DBNull.Value)
                                    openings.Id = objReader.GetInt32(rdId);
                                if (objReader[rdCompany] != System.DBNull.Value)
                                    openings.Company = objReader.GetString(rdCompany);
                                if (objReader[rdPosition] != System.DBNull.Value)
                                    openings.Position = objReader.GetString(rdPosition);
                                if (objReader[rdQualification] != System.DBNull.Value)
                                    openings.Qualification = objReader.GetString(rdQualification);
                                if (objReader[rdSkillset] != System.DBNull.Value)
                                    openings.Skillset = objReader.GetString(rdSkillset);
                                if (objReader[rdEmail] != System.DBNull.Value)
                                    openings.Email = objReader.GetString(rdEmail);
                                if (objReader[rdOpenTillDate] != System.DBNull.Value)
                                    openings.OpenTillDate = objReader.GetString(rdOpenTillDate);
                                if (objReader[rdCreatedDate] != System.DBNull.Value)
                                    openings.CreatedDate = Convert.ToDateTime(objReader[rdCreatedDate]);
                                if (objReader[rdModifiedDate] != System.DBNull.Value)
                                    openings.ModifiedDate = Convert.ToDateTime(objReader[rdModifiedDate]);
                                
                                listOpenings.Add(openings);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listOpenings;
        }

        public List<ParentSectors> GetParentSectors()
        {
            List<ParentSectors> listParentSectors = new List<ParentSectors>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("GetParentSector", null, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("ID");
                            int rdSectorName = objReader.GetOrdinal("SectorName");
                           
                            while (objReader.Read())
                            {
                                ParentSectors sector = new ParentSectors();
                                if (objReader[rdId] != System.DBNull.Value)
                                    sector.ID = objReader.GetInt32(rdId);
                                if (objReader[rdSectorName] != System.DBNull.Value)
                                    sector.ParentSectorName = objReader.GetString(rdSectorName);                               

                                listParentSectors.Add(sector);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listParentSectors;
        }


        public List<SectorsData> GetSectors(int ParentId)
        {
            List<SectorsData> listSectors = new List<SectorsData>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();
                    DbParameter[] sqlParameter = sqlHelp.GetParameters(1);

                    sqlParameter[0].ParameterName = "@parentid";
                    sqlParameter[0].DbType = System.Data.DbType.Int32;
                    sqlParameter[0].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[0].Value = ParentId;

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("GetSectorbyParentid", sqlParameter, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("ID");
                            int rdSectorName = objReader.GetOrdinal("SectorName");
                            int rdParentId = objReader.GetOrdinal("ParentSectorId");

                            while (objReader.Read())
                            {
                                SectorsData sector = new SectorsData();
                                if (objReader[rdId] != System.DBNull.Value)
                                    sector.ID = objReader.GetInt32(rdId);
                                if (objReader[rdSectorName] != System.DBNull.Value)
                                    sector.SectorName = objReader.GetString(rdSectorName);
                                if (objReader[rdParentId] != System.DBNull.Value)
                                    sector.ParentSectorID = objReader.GetInt32(rdParentId);

                                listSectors.Add(sector);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listSectors;
        }


        public List<SectorAttachments> GeSectorAttachment(int Sectorid)
        {
            List<SectorAttachments> listSectorAttachments = new List<SectorAttachments>();
            using (SQLHelper sqlHelp = new SQLHelper())
            {
                try
                {
                    sqlHelp.OpenConnection();
                    DbParameter[] sqlParameter = sqlHelp.GetParameters(1);

                    sqlParameter[0].ParameterName = "@Sectorid";
                    sqlParameter[0].DbType = System.Data.DbType.Int32;
                    sqlParameter[0].Direction = System.Data.ParameterDirection.Input;
                    sqlParameter[0].Value = Sectorid;

                    using (DbDataReader objReader = sqlHelp.GetDbDataReader("GetSectorAttachmentbySectorid", sqlParameter, DBCommandType.StoredProcedure))
                    {

                        if (objReader.HasRows)
                        {
                            int rdId = objReader.GetOrdinal("ID");
                            int rdCaption = objReader.GetOrdinal("caption");
                            int rdParentId = objReader.GetOrdinal("SectorID");
                            int rdDownloadPath = objReader.GetOrdinal("DownloadPath");
                            while (objReader.Read())
                            {
                                SectorAttachments sectorSectorAttachments = new SectorAttachments();
                                if (objReader[rdId] != System.DBNull.Value)
                                    sectorSectorAttachments.ID = objReader.GetInt32(rdId);
                                if (objReader[rdCaption] != System.DBNull.Value)
                                    sectorSectorAttachments.Caption = objReader.GetString(rdCaption);
                                if (objReader[rdParentId] != System.DBNull.Value)
                                    sectorSectorAttachments.SectorAttachment = objReader.GetString(rdDownloadPath);

                                listSectorAttachments.Add(sectorSectorAttachments);
                            }

                        }


                    }
                }
                finally
                {
                    sqlHelp.CloseConnection();
                }
            }
            return listSectorAttachments;
        }
    }
}
