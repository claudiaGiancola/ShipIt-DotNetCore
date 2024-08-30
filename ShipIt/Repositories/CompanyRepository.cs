﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Npgsql;
using ShipIt.Exceptions;
using ShipIt.Models.ApiModels;
using ShipIt.Models.DataModels;

namespace ShipIt.Repositories
{
    public interface ICompanyRepository
    {
        int GetCount();
        CompanyDataModel GetCompany(string gcp);
        public IEnumerable<CompanyProductsStockDataModel> GetCompanyProductsStockByWarehouseId(int id);
        void AddCompanies(IEnumerable<Company> companies);
    }

    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public int GetCount()
        {
            string CompanyCountSQL = "SELECT COUNT(*) FROM gcp";
            return (int)QueryForLong(CompanyCountSQL);
        }

        public CompanyDataModel GetCompany(string gcp)
        {
            string sql =
                "SELECT gcp_cd, gln_nm, gln_addr_02, gln_addr_03, gln_addr_04, gln_addr_postalcode, gln_addr_city, contact_tel, contact_mail " +
                "FROM gcp " +
                "WHERE gcp_cd = @gcp_cd";
            var parameter = new NpgsqlParameter("@gcp_cd", gcp);
            string noProductWithIdErrorMessage = string.Format("No companies found with gcp: {0}", gcp);
            return base.RunSingleGetQuery(sql, reader => new CompanyDataModel(reader), noProductWithIdErrorMessage, parameter);
        }

        public IEnumerable<CompanyProductsStockDataModel> GetCompanyProductsStockByWarehouseId(int id)
        {
            
            string sql = "SELECT * FROM gcp as c JOIN gtin as p ON c.gcp_cd = p.gcp_cd JOIN stock as s ON p.p_id = s.p_id WHERE w_id = @w_id AND c.gcp_cd = p.gcp_cd AND s.hld < p.l_th AND p.ds != 1";

            var parameter = new NpgsqlParameter("@w_id", id);
            string noProductWithIdErrorMessage = string.Format("No stock found with w_id: {0}", id);
            
            try
            {
            return base.RunGetQuery(sql, reader => new CompanyProductsStockDataModel(reader), noProductWithIdErrorMessage, parameter).ToList();
            } catch (NoSuchEntityException)
            {
                return new List<CompanyProductsStockDataModel>();
            }

        }

        public void AddCompanies(IEnumerable<Company> companies)
        {
            string sql =
                "INSERT INTO gcp (gcp_cd, gln_nm, gln_addr_02, gln_addr_03, gln_addr_04, gln_addr_postalcode, gln_addr_city, contact_tel, contact_mail) " +
                "VALUES (@gcp_cd, @gln_nm, @gln_addr_02, @gln_addr_03, @gln_addr_04, @gln_addr_postalcode, @gln_addr_city, @contact_tel, @contact_mail)";

            var parametersList = new List<NpgsqlParameter[]>();
            foreach (var company in companies)
            {
                var companyDataModel = new CompanyDataModel(company);
                parametersList.Add(companyDataModel.GetNpgsqlParameters().ToArray());
            }

            base.RunTransaction(sql, parametersList);
        }
    }

}