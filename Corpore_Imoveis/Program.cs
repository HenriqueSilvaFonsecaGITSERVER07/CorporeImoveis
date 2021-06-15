using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corpore_Imoveis.DataServer;
using System.Web;
using Corpore_Imoveis.UtilTOTVs;
using System.Data;
using System.IO;

namespace Corpore_Imoveis
{
    class Program
    {
        static string url = "http://agamenon.emgea.ativos:8051";
       

        static string usuario = "x000417";
        static string senha = "Brasil07";
        static int counter = 0;
        static void Main(string[] args)
        {
            //AtualizarImovel();
            //InserirDespesasImoveis();
            SalvarUnidade();
            //VisualizarUnidade();
            //ReadView();
            //ReadRecord();
            //ReadRecordFinanceiro();
            //SaveRecordImovel();
            //SaveRecordFinanceiro();
            //ReadViewDespesa();
        }

        static public void InserirDespesasImoveis()
        {

            DespesasImoveisDataContext dbDespesas = new DespesasImoveisDataContext();

            ImoveisDataContext dbImoveis = new ImoveisDataContext();

            CORPORE_IMO_SOAPDataContext dbDespesasCorporeImoSoap = new CORPORE_IMO_SOAPDataContext();

            List<XDESPESA> listaDespesasCorporeImoSoap = dbDespesasCorporeImoSoap.XDESPESAs.ToList();

            List<tblCargaImoveisDadosCompletosDespesas20210531> listaDespesas = dbDespesas.tblCargaImoveisDadosCompletosDespesas20210531s.Take(3000).ToList();

            foreach (var item in listaDespesas)
            {
                var verificaCadastroDuplicado = listaDespesasCorporeImoSoap.Where(x => x.DESCDESPESA.Contains(item.EMGEA_NumContrato.ToString())).FirstOrDefault();

                if (verificaCadastroDuplicado != null)
                {
                    using (StreamWriter w = File.AppendText("Log.txt"))
                    {
                        Log("Já existe uma despesa cadastrada para o contrato " + item.EMGEA_NumContrato, w);
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    Console.WriteLine("Já existe uma despesa cadastrada para o contrato " + item.EMGEA_NumContrato);
                    Console.WriteLine("===============================================================");
                }
                else
                {
                    var listaImoveis = dbImoveis.XALGIMOVELs.Where(x => x.DESCIMOVEL.Equals(item.EMGEA_NumContrato)).ToList();

                    int tipoValorDespesa = 1;

                    if (listaImoveis.Count == 1)
                    {
                        var imovel = listaImoveis.FirstOrDefault();

                        if (item.N_DE_PARCELAS > 1 && item.VALOR_TOTAL_IPTU_2021 > 0)
                        {
                            tipoValorDespesa = 2;
                            SaveRecordDespesaImoveis(item, imovel, tipoValorDespesa);
                        }
                        else if (item.VALOR_TOTAL_C__DESCONTO >= 0 && item.N_DE_PARCELAS <= 1 && item.VALOR_TOTAL_IPTU_2021 > 0)
                        {
                            item.N_DE_PARCELAS = 1;

                            if (item.VALOR_TOTAL_C__DESCONTO == 0)
                            {
                                item.VALOR_TOTAL_C__DESCONTO = item.VALOR_TOTAL_IPTU_2021;
                            }

                            SaveRecordDespesaImoveis(item, imovel, tipoValorDespesa);
                        }
                        else
                        {
                            using (StreamWriter w = File.AppendText("Log _error ao cadastrar valores.txt"))
                            {
                                Log("Os valores do contrato contrato: " + item.EMGEA_NumContrato + " estão zerados!", w);
                            }

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                            Console.WriteLine("Os valores ou as parcelas do contrato contrato: " + item.EMGEA_NumContrato + " estão zerados!");
                            Console.WriteLine("===============================================================");
                        }
                    }
                    else if (listaImoveis.Count > 1)
                    {
                        using (StreamWriter w = File.AppendText("Log _error imóvel duplicado.txt"))
                        {
                            Log("Os valores do contrato contrato: " + item.EMGEA_NumContrato + " estão zerados!", w);
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                        Console.WriteLine("Existe mais de um imóvel para esse número de contrato: " + item.EMGEA_NumContrato);
                        Console.WriteLine("===============================================================");
                    }
                    else
                    {
                        using (StreamWriter w = File.AppendText("Log imóvel não localizado.txt"))
                        {
                            Log("Não existe um imóvel cadastrado com esse número de contrato: " + item.EMGEA_NumContrato, w);
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                        Console.WriteLine("Não existe um imóvel cadastrado com esse número de contrato: " + item.EMGEA_NumContrato);
                        Console.WriteLine("===============================================================");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            Console.WriteLine("Finalizado");
            Console.WriteLine("Foram inseridos " + counter + " novos registros!");
            Console.WriteLine("===============================================================");
            Console.Read();
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog importação de despesas do imóvel : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("===============================================================");
        }

        static public void ReadView()
        {
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            //o filtro pode ser qualquer campo da visão, por exemplo CODCOLIGADA=1 AND CODFILIAL = 1  
            string filtro = "1=1";

            string recordData;

            // Retorna as credenciais para acesso ao WS  
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);
            // lê os dados da visão respeitando o filtro passado  
            DataSet ds = dataclient.ReadView("FinLanDataBR", filtro, out recordData);
            // Pode utilizar o ds tipado para DataSet ou a variável recordData que possui o XML da solicitação   
            Console.WriteLine(recordData);
            Console.Read();
        }
        static public void ReadRecord()
        {
            //importante passar no contexto o mesmo código de usuário usado para logar no webservice  
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            string recordData;
            // Retorna as credenciais para acesso ao WS  
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);
            //O ReadRecord retorna o registro da edição do cadastro RM respeitando a chave primária  
            DataSet ds = dataclient.ReadRecord("ImbImovelContratoAdmData", "0;0;0;0;0", out recordData);
            // Pode utilizar o ds tipado para DataSet ou a variável recordData que possui o XML da solicitação   
            Console.WriteLine(recordData);
            Console.Read();
        }
        static public void ReadRecordFinanceiro()
        {
            //importante passar no contexto o mesmo código de usuário usado para logar no webservice  
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            string recordData;
            // Retorna as credenciais para acesso ao WS  
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);
            //O ReadRecord retorna o registro da edição do cadastro RM respeitando a chave primária  
            DataSet ds = dataclient.ReadRecord("FinLanDataBR", "0;0;0;0;0", out recordData);
            // Pode utilizar o ds tipado para DataSet ou a variável recordData que possui o XML da solicitação   
            Console.WriteLine(recordData);
            Console.Read();
        }
        static public void ReadViewDespesa()
        {
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            //o filtro pode ser qualquer campo da visão, por exemplo CODCOLIGADA=1 AND CODFILIAL = 1  
            string filtro = "1=1";


            string recordData;

            // Retorna as credenciais para acesso ao WS  
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);
            // lê os dados da visão respeitando o filtro passado  
            DataSet ds = dataclient.ReadView("ImbDespesaAluguelData", filtro, out recordData);
            // Pode utilizar o ds tipado para DataSet ou a variável recordData que possui o XML da solicitação   
            Console.WriteLine(recordData);
            Console.Read();
        }
        static public void SaveRecordDespesaImoveis(tblCargaImoveisDadosCompletosDespesas20210531 despesa, XALGIMOVEL imovel, int tipoValorDespesa)
        {
            string xml = @"<ImbDespesaAluguelData xmlns='http://tempuri.org/ImbDespesaAluguelData.xsd\'> " +
                             "<XDESPESA> " +
                                //Identificação
                                "<CODCOLIGADA>1</CODCOLIGADA> " +
                                "<CODDESPESA>0</CODDESPESA>" +
                                "<ORIGEM>1</ORIGEM> " +
                                //"<STATUS>0</STATUS>  " +
                                "<ANOEXERCICIO>2021</ANOEXERCICIO>  " +
                                "<COMPETENCIA>2021-05-01 00:00:00.0000000</COMPETENCIA>  " +
                                "<DESCDESPESA>" + despesa.EMGEA_NumContrato + "</DESCDESPESA>" +
                                "<NUMERODOCUMENTO>" + despesa.EMGEA_NumContrato + "</NUMERODOCUMENTO>  " +
                                "<CODTIPODESPESA>2</CODTIPODESPESA>  " +
                                "<CODPARAMMVTO>1</CODPARAMMVTO> " +
                                //Verificar de onde vem o cliente
                                "<CODCOLCFO>0</CODCOLCFO>  " +
                                "<CODCFO>F00786</CODCFO>  " +
                                "<CODIMOVEL>" + imovel.CODIMOVEL + "</CODIMOVEL>  " +
                                "<IDINSCRICAOMUNICIPAL></IDINSCRICAOMUNICIPAL>  " +


                                //Valor Despesa
                                "<TIPOVALORDESPESA>" + tipoValorDespesa + "</TIPOVALORDESPESA> " +
                                "<VALORAVISTA>" + despesa.VALOR_TOTAL_C__DESCONTO + "</VALORAVISTA>  " +
                                "<VALORAPRAZO>" + despesa.VALOR_TOTAL_IPTU_2021 + "</VALORAPRAZO> " +
                                "<PRIMEIROVENCIMENTO>" + despesa.VENCIMENTO_CONTA_ÚNICA + "</PRIMEIROVENCIMENTO>  " +
                                "<NUMPARCELA>" + despesa.N_DE_PARCELAS + "</NUMPARCELA>  " +
                                "<PERIODICIDADE>1</PERIODICIDADE> " +
                                "<INTERVALODIAS></INTERVALODIAS>  " +

                             //Reembolso
                             //"<PERMITEREEMBOLSO></PERMITEREEMBOLSO>  " +
                             //"<CODREGRAREEMBOLSO> </CODREGRAREEMBOLSO>  " +
                             //"<IDPARAMFIN></IDPARAMFIN>  " +
                             //"<TIPOVALORREEMBOLSO>1</TIPOVALORREEMBOLSO>  " +
                             //"<PRIMEIROVCTOREEMBOLSO>0001-01-01 00:00:00.0000000</PRIMEIROVCTOREEMBOLSO>  " +
                             //"<NUMPARCELAREEMBOLSO>0</NUMPARCELAREEMBOLSO>  " +
                             //"<PERIODICIDADEREEMBOLSO>1</PERIODICIDADEREEMBOLSO> " +
                             //"<INTERVALODIASREEMBOLSO></INTERVALODIASREEMBOLSO> " +

                             //Não está sendo utilizadas
                             //"<COD_PESS_EMPR></COD_PESS_EMPR>  " +
                             //"<NUM_UNID></NUM_UNID> " +
                             //"<NUM_SUB_UNID></NUM_SUB_UNID>  " +
                             //"<CODSEGURO></CODSEGURO>  " +
                             "</XDESPESA> " +
                          "</ImbDespesaAluguelData>";

            //importante passar no contexto o mesmo código de usuário usado para logar no webservice  
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            // Retorna as credenciais para acesso ao WS  
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);

            string[] retorno = dataclient.SaveRecord("ImbDespesaAluguelData", xml);

            counter++;

            using (StreamWriter w = File.AppendText("Log registros inseridos.txt"))
            {
                Log("Foi inserido 1 despesa para o imóvel : " + imovel.CODIMOVEL, w);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            Console.WriteLine("Foi inserido " + retorno[0].ToString() + " depesa para o imóvel " + imovel.CODIMOVEL);
            Console.WriteLine("===============================================================");
        }
        static public void SaveRecordFinanceiro()
        {
            string xml = @"
            <FinLAN>  
              <FLAN>  
                <CODCOLIGADA>1</CODCOLIGADA>  
                <IDLAN>0</IDLAN>  
                <NUMERODOCUMENTO>00006498</NUMERODOCUMENTO>  
                <CODIGOBARRA>27598427600000150003344233346730000000001355</CODIGOBARRA>  
                <IPTE>27593344243334673000600000013557842760000015000</IPTE>  
                <CNABNOSSONUMERO>0001355</CNABNOSSONUMERO>  
                <NFOUDUP>0</NFOUDUP>  
                <CLASSIFICACAO>0</CLASSIFICACAO>  
                <PAGREC>1</PAGREC>  
                <STATUSLAN>1</STATUSLAN>  
                <CODAPLICACAO>S</CODAPLICACAO>  
                <CODCOLXCX>1</CODCOLXCX>  
                <CODCCUSTO>03.00.00</CODCCUSTO>  
                <DATACRIACAO>2009-06-22T00:00:00</DATACRIACAO>  
                <DATAVENCIMENTO>2009-06-22T17:24:00</DATAVENCIMENTO>  
                <DATAEMISSAO>2009-06-22T13:18:26</DATAEMISSAO>  
                <DATABAIXA>2009-06-22T00:00:00</DATABAIXA>  
                <DATACONTABILIZBX>2009-06-22T00:00:00</DATACONTABILIZBX>  
                <DATAPAG>2009-06-22T00:00:00</DATAPAG>  
                <VALORORIGINAL>150.0000</VALORORIGINAL>  
                <VALORBAIXADO>150.0000</VALORBAIXADO>  
                <VALORCAP>0.0000</VALORCAP>  
                <VALORJUROS>0.0000</VALORJUROS>  
                <VALORDESCONTO>0.0000</VALORDESCONTO>  
                <VALORCHEQUE>0.0000</VALORCHEQUE>  
                <VALOROP1>0.0000</VALOROP1>  
                <VALOROP2>0.0000</VALOROP2>  
                <VALOROP3>0.0000</VALOROP3>  
                <VALOROP4>0.0000</VALOROP4>  
                <VALOROP5>0.0000</VALOROP5>  
                <VALOROP6>0.0000</VALOROP6>  
                <VALOROP7>0.0000</VALOROP7>  
                <VALOROP8>0.0000</VALOROP8>  
                <VALORMULTA>0.0000</VALORMULTA>  
                <VALORAUXILIAR>1.0000</VALORAUXILIAR>  
                <VALORBASEIRRF>100.0000</VALORBASEIRRF>  
                <VALORIRRF>0.0000</VALORIRRF>  
                <VALORREPASSE>0.0000</VALORREPASSE>  
                <VALORVENCIMENTOANTECIP>0.0000</VALORVENCIMENTOANTECIP>  
                <VALORNOTACREDITO>0.0000</VALORNOTACREDITO>  
                <VALORADIANTAMENTO>0.0000</VALORADIANTAMENTO>  
                <VALORDEVOLUCAO>0.0000</VALORDEVOLUCAO>  
                <JUROSDIA>0.0000</JUROSDIA>  
                <CAPMENSAL>0.0000</CAPMENSAL>  
                <TAXASVENDOR>0.0000</TAXASVENDOR>  
                <JUROSVENDOR>0.0000</JUROSVENDOR>  
                <CODCOLCFO>1</CODCOLCFO>  
                <CODCFO>C00003</CODCFO>  
                <CODCOLCXA>1</CODCOLCXA>  
                <CODCXA>106</CODCXA>  
                <IDPGTO>1</IDPGTO>  
                <CODTDO>01</CODTDO>  
                <CODFILIAL>1</CODFILIAL>  
                <SERIEDOCUMENTO>@@@</SERIEDOCUMENTO>  
                <TIPOCONTABILLAN>0</TIPOCONTABILLAN>  
                <CODMOEVALORORIGINAL>R$</CODMOEVALORORIGINAL>  
                <LIBAUTORIZADA>0</LIBAUTORIZADA>  
                <STATUSEXPORTACAO>0</STATUSEXPORTACAO>  
                <NUMLOTECONTABIL>0</NUMLOTECONTABIL>  
                <STATUSEXTRATO>0</STATUSEXTRATO>  
                <CNABCARTEIRA>21</CNABCARTEIRA>  
                <CNABACEITE>0</CNABACEITE>  
                <CNABSTATUS>0</CNABSTATUS>  
                <CNABBANCO>275</CNABBANCO>  
                <REEMBOLSAVEL>0</REEMBOLSAVEL>  
                <CODBAIXA>2</CODBAIXA>  
                <USUARIO>Kenya</USUARIO>  
                <BAIXAAUTORIZADA>1</BAIXAAUTORIZADA>  
                <TEMCHEQUEPARCIAL>0</TEMCHEQUEPARCIAL>  
                <JAIMPRIMIU>0</JAIMPRIMIU>  
                <NUMBLOQUEIOS>0</NUMBLOQUEIOS>  
                <NUMCONTABILBX>00006497</NUMCONTABILBX>  
                <COTACAOINCLUSAO>0.000000000</COTACAOINCLUSAO>  
                <COTACAOBAIXA>0.000000000</COTACAOBAIXA>  
                <CARENCIAJUROS>0</CARENCIAJUROS>  
                <TIPOJUROSDIA>0</TIPOJUROSDIA>  
                <USUARIOCRIACAO>UsrProcSel</USUARIOCRIACAO>  
                <DATAALTERACAO>2009-06-22T00:00:00</DATAALTERACAO>  
                <ALTERACAOBLOQUEADA>0</ALTERACAOBLOQUEADA>  
                <MULTADIA>0.0000</MULTADIA>  
                <DESCONTADO>0</DESCONTADO>  
                <VALORINSS>0.0000</VALORINSS>  
                <VALORDEDUCAO>0.0000</VALORDEDUCAO>  
                <APLICFORMULA>F</APLICFORMULA>  
                <INSSEMOUTRAEMPRESA>0.0000</INSSEMOUTRAEMPRESA>  
                <PERCENTBASEINSS>100.0000</PERCENTBASEINSS>  
                <PERCBASEINSSEMPREGADO>100.0000</PERCBASEINSSEMPREGADO>  
                <INSSEDITADO>0</INSSEDITADO>  
                <IRRFEDITADO>0</IRRFEDITADO>  
                <REUTILIZACAO>0</REUTILIZACAO>  
                <VALORSESTSENAT>0.0000</VALORSESTSENAT>  
                <CONVENIO>123321</CONVENIO>  
                <DIGCONVENIO>2</DIGCONVENIO>  
                <PERCJUROS>0</PERCJUROS>  
                <PERCDESCONTO>0</PERCDESCONTO>  
                <PERCMULTA>0</PERCMULTA>  
                <PERCCAP>0</PERCCAP>  
                <PERCOP1>0</PERCOP1>  
                <PERCOP2>0</PERCOP2>  
                <PERCOP3>0</PERCOP3>  
                <PERCOP4>0</PERCOP4>  
                <PERCOP5>0</PERCOP5>  
                <PERCOP6>0</PERCOP6>  
                <PERCOP7>0</PERCOP7>  
                <PERCOP8>0</PERCOP8>  
                <VALORINSSEMPREGADOR>0</VALORINSSEMPREGADOR>  
                <VALORBASEINSSEMPREGADOR>0</VALORBASEINSSEMPREGADOR>  
                <VRBASEINSS>0</VRBASEINSS>  
                <VRBASEIRRF>0</VRBASEIRRF>  
                <VALORSERVICO>150.0000</VALORSERVICO>  
                <VRBASEINSSOUTRAEMPRESA>0.0000</VRBASEINSSOUTRAEMPRESA>  
                <IDHISTORICO>2627</IDHISTORICO>  
                <PreencherRatCCusto>true</PreencherRatCCusto>  
                <PreencherRatDepto>true</PreencherRatDepto>  
                <VRPERDAFINANCEIRA>0.0000</VRPERDAFINANCEIRA>  
                <MODELOCONTABILIZACAO>1</MODELOCONTABILIZACAO>  
                <MODELOCONTABILIZACAOBAIXA>1</MODELOCONTABILIZACAOBAIXA>  
                <IDCONVENIO>8</IDCONVENIO>  
                <VALORORIGINALBX>0</VALORORIGINALBX>  
                <VALORDESCONTOBX>0</VALORDESCONTOBX>  
                <VALORJUROSBX>0</VALORJUROSBX>  
                <VALORMULTABX>0</VALORMULTABX>  
                <VALORCAPBX>0</VALORCAPBX>  
                <VALOROP1BX>0,0000</VALOROP1BX>  
                <VALOROP2BX>0,0000</VALOROP2BX>  
                <VALOROP3BX>0,0000</VALOROP3BX>  
                <VALOROP4BX>0,0000</VALOROP4BX>  
                <VALOROP5BX>0,0000</VALOROP5BX>  
                <VALOROP6BX>0,0000</VALOROP6BX>  
                <VALOROP7BX>0,0000</VALOROP7BX>  
                <VALOROP8BX>0,0000</VALOROP8BX>  
                <VALORINSSBX>0</VALORINSSBX>  
                <VALORIRRFBX>0</VALORIRRFBX>  
                <VALORSESTSENATBX>0</VALORSESTSENATBX>  
                <VALORDEVOLUCAOBX>0</VALORDEVOLUCAOBX>  
                <VALORNOTACREDITOBX>0</VALORNOTACREDITOBX>  
                <VALORADIANTAMENTOBX>0</VALORADIANTAMENTOBX>  
                <VALORJUROSVENDORBX>0</VALORJUROSVENDORBX>  
                <VALORRETENCOESBX>0</VALORRETENCOESBX>  
                <STATUSORCAMENTO>0</STATUSORCAMENTO>  
                <BAIXAPENDENTE>0</BAIXAPENDENTE>  
                <VALORDESCONTOACORDO>0.0000</VALORDESCONTOACORDO>  
                <VALORJUROSACORDO>0.0000</VALORJUROSACORDO>  
                <VALORACRESCIMOACORDO>0.0000</VALORACRESCIMOACORDO>  
                <VALORDEDUCAOVARIAVEL>0.0000</VALORDEDUCAOVARIAVEL>  
                <STATUSLIQDUVIDOSA>0</STATUSLIQDUVIDOSA>  
                <CODCOLPGTO>1</CODCOLPGTO>  
              </FLAN>  
              <FLANRATCCU>  
                <IDRATCCU>0</IDRATCCU>  
                <CODCOLIGADA>1</CODCOLIGADA>  
                <IDLAN>0</IDLAN>  
                <CODCCUSTO>03.00.00</CODCCUSTO>
                <CODCOLNATFINANCEIRA>1</CODCOLNATFINANCEIRA>
                <CODNATFINANCEIRA>1001</CODNATFINANCEIRA>
                <NOME>Administrativo</NOME>  
                <VALOR>150.0000</VALOR>  
                <PERCENTUAL>100.0000</PERCENTUAL>  
              </FLANRATCCU>  
              <FLANCOMPL>  
                <CODCOLIGADA>1</CODCOLIGADA>  
                <IDLAN>0</IDLAN>  
              </FLANCOMPL>   
            </FinLAN>
";

            //importante passar no contexto o mesmo código de usuário usado para logar no webservice  
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            // Retorna as credenciais para acesso ao WS  
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);

            string[] retorno = dataclient.SaveRecord("FinLanDataBR", xml);

            Console.WriteLine(retorno[0].ToString());
            Console.Read();
        }
        static public void VisualizarUnidade()
        {

            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO=x000417";

            string filtro = "1=1";

            string recordData;

            DataClient dataclient = new DataClient(url, contexto, usuario, senha);

            DataSet ds = dataclient.ReadView("ImbVendaEmpreendimentoUnidadeData", filtro, out recordData);

            Console.WriteLine(recordData);

            Console.ReadLine();


        }
        static public void SalvarUnidade()
        {
            string xml = @"<ImbVendaEmpreendimentoUnidade >  
                                <XUNIDADE>  
                                    <COD_PESS_EMPR>2001</COD_PESS_EMPR>  
                                    <NUM_UNID>1</NUM_UNID>  
                                    <DSC_LOCAL>Residencial Aquarius</DSC_LOCAL>  
                                    <QTD_SUB_UNID>1</QTD_SUB_UNID>  
                                    <AREA_TOTAL>0.0000</AREA_TOTAL>  
                                    <COD_SIT_OPRL>B</COD_SIT_OPRL>  
                                    <COD_PESS_ULT_MNT>Carlos</COD_PESS_ULT_MNT>  
                                    <DAT_ULT_MNT>2003-06-23T17:28:03.98</DAT_ULT_MNT>  
                                    <CODCOLIGADA>1</CODCOLIGADA>  
                                    <DATA_LANC>2001-09-25T00:00:00</DATA_LANC>  
                                </XUNIDADE>  
                                <XUNIDADECOMPL>  
                                    <COD_PESS_EMPR>2001</COD_PESS_EMPR> 
                                   <NUM_UNID>1</NUM_UNID>  
                                </XUNIDADECOMPL>  
                            </ImbVendaEmpreendimentoUnidade>";

             //<NOME_EMPREENDIMENTO>Residencial Aquarius</NOME_EMPREENDIMENTO>  

            //importante passar no contexto o mesmo código de usuário usado para logar no webservice
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            // Retorna as credenciais para acesso ao WS
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);

            string[] retorno = dataclient.SaveRecord("ImbVendaEmpreendimentoUnidadeData", xml);

            Console.WriteLine(retorno[0].ToString());
            Console.Read();
        }
        static public void AtualizarImovel()
        {
            string xml = @"<ImbImovel xmlns='http://tempuri.org/ImbImovel.xsd\'>  
                                <XALGIMOVEL>
                                    <CODCOLIMOVEL>1</CODCOLIMOVEL>
                                    <CODIMOVEL>3</CODIMOVEL>
                                </XALGIMOVEL>
                                <XSUBUNIDADE>
                                    <NUM_SUB_UNID>7</NUM_SUB_UNID>
                                </XSUBUNIDADE>
                            </ImbImovel>";

                                    //<NOME_EMPREENDIMENTO>Residencial Aquarius</NOME_EMPREENDIMENTO>  

            //importante passar no contexto o mesmo código de usuário usado para logar no webservice
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            // Retorna as credenciais para acesso ao WS
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);

            string[] retorno = dataclient.SaveRecord("ImbImovelData", xml);

            Console.WriteLine(retorno[0].ToString());
            Console.Read();
        }
        static public void SalvarImovel()
        {
            string xml = @"<ImbImovel xmlns='http://tempuri.org/ImbImovel.xsd\'>  
                       <XALGIMOVEL>
                            <CODCOLIMOVEL>1</CODCOLIMOVEL>
                            <CODIMOVEL>0</CODIMOVEL>
                            <SITUACAOIMOVEL>0</SITUACAOIMOVEL>
                            <IMOVELPROPRIO>0</IMOVELPROPRIO>
                            <TIPOAREA>1</TIPOAREA>
                            <VALORLOCACAOSUGERIDO>6.000,00</VALORLOCACAOSUGERIDO>
                            <ACEITANEGOCIACAO>0</ACEITANEGOCIACAO>
                            <DATACADASTRO>2021-05-25T00:00:00</DATACADASTRO>
                            <CEP>71692000</CEP>
                            <TIPOLOGRADOURO>1</TIPOLOGRADOURO>
                            <HISTORICO>CADASTRO DE HISTÓRICO</HISTORICO>
                            <DESCRUA>DESC TESTE</DESCRUA>
                            <LOGRADOURO>SAMAMBAIA SUL</LOGRADOURO>
                            <NUMERO>1</NUMERO>
                            <BAIRRO>SAMAMBAIA</BAIRRO>
                            <MUNICIPIO>00108</MUNICIPIO>
                            <NOMEMUNICIPIO>DF</NOMEMUNICIPIO>
                            <ESTADO>DF</ESTADO>
                            <NOMEETD>Teste Cadastro Atualizado</NOMEETD>
                            <PAIS>1</PAIS>
                            <DESCPAIS>Brasil</DESCPAIS>
                            <RECCREATEDBY>e000172</RECCREATEDBY>
                            <RECCREATEDON>2021-05-25T10:42:12</RECCREATEDON>
                            <RECMODIFIEDBY>e000172</RECMODIFIEDBY>
                            <RECMODIFIEDON>2021-05-25T10:42:22</RECMODIFIEDON>
                            <PERCENTPARTADM>100.0000</PERCENTPARTADM>
                            <TIPOLOCACAOAREA>0</TIPOLOCACAOAREA>
                            <CODCARTORIO>1</CODCARTORIO>
                            <INTEGRACAOPORTAIS>0</INTEGRACAOPORTAIS>
                            <METROQUADRADOLOCADO>0.0000</METROQUADRADOLOCADO>
                            <METROQUADRADODISPONIVEL>0.0000</METROQUADRADODISPONIVEL>
                            <METROQUADRADOLOCAVEL>0.0000</METROQUADRADOLOCAVEL>
                            <METROQUADRADORESERVADO>0.0000</METROQUADRADORESERVADO>
                            <REFLANCAMENTO>1</REFLANCAMENTO>
                            <LANCAMENTOFINANCEIRO>1</LANCAMENTOFINANCEIRO>
                          </XALGIMOVEL>
                    </ImbImovel>";

            //importante passar no contexto o mesmo código de usuário usado para logar no webservice
            string contexto = "CODSISTEMA=G;CODCOLIGADA=1;CODUSUARIO={usuario}";

            // Retorna as credenciais para acesso ao WS
            DataClient dataclient = new DataClient(url, contexto, usuario, senha);

            string[] retorno = dataclient.SaveRecord("ImbImovelData", xml);

            Console.WriteLine(retorno[0].ToString());
            Console.Read();
        }



    }
}
