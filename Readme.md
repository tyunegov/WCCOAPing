#Работа менеджера
1. Менеджер должен находиться в папке bin проекта
2. Наличие DPType "_ConnectionDevices" с точками данных, у которые есть элементы 
-ip - типа string
-isConnected - типа bool 

#Работа менеджера в резервированной системе
1. В config делается запись 
	>\[ping]
	>ReduNumId=2, где 2 - номер системы
2. Для каждой точки данных должен быть добавлен элемент isConnected_2 для того, чтобы менеджер с номером системы 2 писал значение в этот элемент.