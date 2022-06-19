using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using API_SCHOOL.Models.School;

namespace API_SCHOOL.Domain.School
{
    public class SchoolDomain : ISchoolDomain
    {
        public IConfiguration _config;

        public SchoolDomain(IConfiguration config)
        {
            _config = config;
        }

        #region Public methods

        //Metodo para busca de todas as escolas
        public string GetAllSchools()
        {
            var con = ConnectionMysql(_config.GetSection("MySQLConn").Value);

            //Query a ser executada no banco de dados
            var query = $"Select * from school";
            var result = SelectQueryMySQL(con, query);

            //Exemplo de conversão de DataTable par Json
            var tableToJson = JsonConvert.SerializeObject(result);

            //Exemplo de conversão de Json para Modelo
            var JsonToObject = JsonConvert.DeserializeObject<List<SchoolModel>>(tableToJson);
            
            return tableToJson;
        }

        //Metodo para busca de uma escola por ID
        public SchoolModel GetSchoolById(int Id)
        {
            var con = ConnectionMysql(_config.GetSection("MySQLConn").Value);

            //Query a ser executada no banco de dados
            var query = $"Select * from school where id = {Id}";
            var result = SelectQueryMySQL(con, query);

            //Exemplo de conversão de DataTable par Json
            var tableToJson = JsonConvert.SerializeObject(result);

            //Exemplo de conversão de Json para Modelo
            var JsonToObject = JsonConvert.DeserializeObject<SchoolModel>(tableToJson);

            return JsonToObject;
        }

        //Metodo para inserir uma nova escola
        public bool CreateSchool(SchoolModel school)
        {
            var con = ConnectionMysql(_config.GetSection("MySQLConn").Value);

            //Query a ser executada no banco de dados
            var query = $"INSERT INTO `school` VALUES ({school.Id},{school.IsActive},'{school.Name}','{school.Description}','{school.CreatAt.ToString("yyyy-MM-dd  HH:mm:ss")}','{school.UpdateAt.ToString("yyyy-MM-dd  HH:mm:ss")}','{school.Capacity}','{school.Capacity}');";

            return InsertDeleteUpdateMySQL(con, query);

        }

        public bool DeleteSchool(int Id)
        {
            var con = ConnectionMysql(_config.GetSection("MySQLConn").Value);

            //Query a ser executada no banco de dados
            var query = $"DELETE FROM `school`WHERE id = {Id};";

            return InsertDeleteUpdateMySQL(con, query);

        }

        public bool EditSchool(SchoolModel school)
        {
            var con = ConnectionMysql(_config.GetSection("MySQLConn").Value);

            var query = $"UPDATE `school` SET `IsActive` = {school.IsActive},`name`= '{school.Name}', `description`= '{school.Description}', `updateAt`= '{DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")}', `capacity` = '{school.Capacity}', `grade`= '{school.Grade}'  WHERE `id`= {school.Id};";

            return InsertDeleteUpdateMySQL(con, query);

        }

        #endregion

        #region Private methods

        //Metodo para criar conexao MySQL
        private MySqlConnection ConnectionMysql(string stringConnection)
        {
            return new MySqlConnection(stringConnection);
        }

        //Metodo para executar selects
        private DataTable SelectQueryMySQL(MySqlConnection con, string query)
        {
            //Abertura de conexão com MySQL
            con.Open();
            var table = new DataTable();

            //Executando query e alimentando DataTable
            var comand = new MySqlCommand(query, con);
            MySqlDataReader reader = comand.ExecuteReader();
            table.Load(reader);
            reader.Close();

            //Fechando Conexão com banco de dados
            con.Close();

            return table;
        }

        //Metodo para executar inserts
        private bool InsertDeleteUpdateMySQL(MySqlConnection con, string query)
        {
            //Abertura de conexão com MySQL
            con.Open();

            //Executando query e alimentando DataTable
            var comand = new MySqlCommand(query, con);
            var response = comand.ExecuteNonQuery();

            //Fechando Conexão com banco de dados
            con.Close();

            if (response == 1)
                return true;

            return false;
        }

        #endregion

    }
}
