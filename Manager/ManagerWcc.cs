using ETM.WCCOA;
using System;

namespace WCCOAPing
{
    class ManagerWcc
    {
        string[] args;
        public ManagerWcc(string[] args)
        {
            this.args = args;
            EstablishConection();
        }

        public OaManager MyManager { get; private set; }

        void EstablishConection()
        {
            // 1. Создание менеджера
            MyManager = OaSdk.CreateManager();
            //2. Инициализация конфигурации менеджера 
            MyManager.Init(ManagerSettings.DefaultApiSettings, args);
            //3. Запуск менеджера
            MyManager.StartAsync().Wait();
            //4. Информация о соединении. Информация пишется в консоль WinCC_OA
            Console.WriteLine("Connection to project established");
        }        
    }
}
