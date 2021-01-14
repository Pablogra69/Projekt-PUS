using System.ServiceModel;

namespace Host_IIS_WcfService
{

    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string[] GetData(string i_Id, int i_Operation);

        [OperationContract]
        System.Data.DataTable GetDataList(string s_IdLocal);

        [OperationContract]
        bool IsServerConnected();

        [OperationContract(IsOneWay = true)]
        void PutProduct(string id, string lokalizacja, bool idOrCatalog);


        [OperationContract(IsOneWay = true)]
        void AddEmptyProduct(string[] list, int Open_Create);

        [OperationContract(IsOneWay = true)]
        void AddPicture(string[] list, int Open_Create);

        [OperationContract]
        string[] GetListPicture();

        [OperationContract]
        string[] GetListProductEmpty();

        [OperationContract(IsOneWay = true)]
        void AddOrder(byte[] xml, string s_FileName);

        [OperationContract]
        string[] GetListOrders();

        [OperationContract]
        System.Data.DataTable GetOrder(string s_FileName);

        [OperationContract(IsOneWay = true)]
        void DeleteOrder(string s_FileName);
    }




}
