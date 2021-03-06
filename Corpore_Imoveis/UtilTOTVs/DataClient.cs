using System;
using System.Data;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;


namespace Corpore_Imoveis.UtilTOTVs

{
    /// <summary>
    /// Classe que encapsula os métodos de acesso aos DataServers
    /// </summary>
    public class DataClient
    {
        public readonly string ServerAddress;
        public readonly string Context;
        public readonly string UserName;
        public readonly string Password;

        public DataClient(string serverAddress, string context, string userName, string password)
        {
            this.ServerAddress = serverAddress;
                this.Context = context;
            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        /// Faz a leitura do Schema do DataServer
        /// </summary>
        /// <returns>Dados do Schema</returns>
        public string ReadSchema(string DataServerName)
        {
            try
            {
                using (DataServer.IwsDataServerClient client = this.CreateClient(this.ServerAddress, this.UserName, this.Password))
                    return client.GetSchema(DataServerName, this.Context);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar Schema.\r\n\r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Faz a leitura dos dados da visão do DataServer
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="viewData">Dados da visão</param>
        /// <returns>DataSet da visão</returns>
        public DataSet ReadView(string DataServerName, string filter, out string viewData)
        {
            try
            {
                // lê os dados da visão...
                using (DataServer.IwsDataServerClient client = this.CreateClient(this.ServerAddress, this.UserName, this.Password))
                    viewData = client.ReadView(DataServerName, filter, this.Context);

                // carrega o DataSet...
                DataSet dataSet = null;
                if (!string.IsNullOrEmpty(viewData))
                    dataSet = Utils.LoadDataSet(viewData);

                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na leitura da visão.\r\n\r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Faz a leitura dos dados do registro do DataServer
        /// </summary>
        /// <param name="pk">Valor da chave primária</param>
        /// <param name="recordData">Dados do registro</param>
        /// <returns>DataSet do registro</returns>
        public DataSet ReadRecord(string DataServerName, object[] pk, out string recordData)
        {
            try
            {
                // monta o string da pk...
                StringBuilder pkString = new StringBuilder();
                if (pk != null)
                {
                    for (int i = 0; i < pk.Length; i++)
                    {
                        if (i > 0)
                            pkString.Append(";");
                        pkString.Append(pk[i]);
                    }
                }

                return ReadRecord(DataServerName, pkString.ToString(), out recordData);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na leitura do registro.\r\n\r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Faz a leitura dos dados do registro do DataServer
        /// </summary>
        /// <param name="pk">Valor da chave primária</param>
        /// <param name="recordData">Dados do registro</param>
        /// <returns>DataSet do registro</returns>
        public DataSet ReadRecord(string DataServerName, string pkString, out string recordData)
        {
            try
            {
                // faz a chamada...
                using (DataServer.IwsDataServerClient client = this.CreateClient(this.ServerAddress, this.UserName, this.Password))
                    recordData = client.ReadRecord(DataServerName, pkString, this.Context);

                // retorna o DataSet...
                DataSet dataSet = Utils.LoadDataSet(recordData);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na leitura do registro.\r\n\r\n" + ex.Message);
            }
        }


        /// <summary>
        /// Salva os dados do registro do DataServer
        /// </summary>
        /// <param name="dataSet">Dados do registro</param>
        /// <returns>Chave primária do registro salvo</returns>
        public string[] SaveRecord(string DataServerName, DataSet dataSet, bool includeSchema,
          bool ignoreExtendedProps)
        {
            try
            {
                // carrega o XML...
                string xml = Utils.GetDataSetXML(dataSet, includeSchema, ignoreExtendedProps, false);

                // salva...
                return this.SaveRecord(DataServerName, xml);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o registro.\r\n\r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Salva os dados do registro do DataServer
        /// </summary>
        /// <param name="dataSetXML">Dados do registro</param>
        /// <returns>Chave primária do registro salvo</returns>
        public string[] SaveRecord(string DataServerName, string dataSetXML)
        {
            string result;
            try
            {
                // faz a chamada...
                using (DataServer.IwsDataServerClient client = this.CreateClient(this.ServerAddress, this.UserName, this.Password))
                    result = client.SaveRecord(DataServerName, dataSetXML, this.Context);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o registro.\r\n\r\n" + ex.Message);
            }
                        // verifica se retornou algum resultado...
            if (string.IsNullOrEmpty(result))
                return null;
            else
            {
                string[] resultKey = result.Split('\r');
                // retorna a chave primária...
                if (result.Length >= 1)
                    return result.Split(';');
                else
                    throw new Exception(result);
            }
        }

        private HttpRequestMessageProperty CreateBasicAuthorizationMessageProperty(string username, string password)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string credential = String.Format("{0}:{1}", username, password);

            var httpRequestProperty = new HttpRequestMessageProperty();
            httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] =
              "Basic " + Convert.ToBase64String(encoding.GetBytes(credential));

            return httpRequestProperty;
        }


        private DataServer.IwsDataServerClient CreateClient(string serverAddress, string userName, string password)
        {
            // cria o cliente...
            string url = string.Format("{0}/wsDataServer/IwsDataServer", this.ServerAddress);
            DataServer.IwsDataServerClient client = new DataServer.IwsDataServerClient(
              Utils.CreateBinding(),
              new System.ServiceModel.EndpointAddress(url));
            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            OperationContextScope scope = new OperationContextScope(client.InnerChannel);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                  CreateBasicAuthorizationMessageProperty(this.UserName, this.Password);
            

                return client;
        }
    }
}
