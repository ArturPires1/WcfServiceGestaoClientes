using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceGestaoClientes
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string InsertUserRegDetails(RegDetails regdet);

        [OperationContract]
        DataSet GetUserRegDetails();

        [OperationContract]
        DataSet FetchUpdatedRecords(RegDetails regdet);

        [OperationContract]
        string UpdateUserRegDetails(RegDetails regdet);

        [OperationContract]
        bool DeleteUserRegDetails(RegDetails regdet);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class RegDetails
    {
       
        string p_CPF = string.Empty;
        string p_Nome = string.Empty;
        string p_Tipo = string.Empty;
        string p_Sexo = string.Empty;
        string p_Situacao = string.Empty;

     
        [DataMember]
        public string CPF
        {
            get { return p_CPF; }
            set { p_CPF = value; }
        }
        [DataMember]
        public string Nome
        {
            get { return p_Nome; }
            set { p_Nome = value; }
        }
        [DataMember]
        public string Tipo
        {
            get { return p_Tipo; }
            set { p_Tipo = value; }
        }
        [DataMember]
        public string Sexo
        {
            get { return p_Sexo; }
            set { p_Sexo = value; }
        }
        [DataMember]
        public string Situacao
        {
            get { return p_Situacao; }
            set { p_Situacao = value; }
        }
    }
}