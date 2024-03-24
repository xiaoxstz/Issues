using NModbusTest;

byte slaveId = 1;
Controller dM2C = new Controller();
dM2C.Connect(serialNo: 11, BaudRate: 38400);

Console.WriteLine("Step1...");
bool bSucceed = dM2C.SendPosNo(slaveId, 0);
Console.WriteLine($"Completed. Succeed:{bSucceed}");

Console.WriteLine("Step2...");
bSucceed = dM2C.SendPosNo(slaveId, 1);
Console.WriteLine($"Completed. Succeed:{bSucceed}");

Console.WriteLine("Step3...");
bSucceed = dM2C.SendPosNo(slaveId, 0);
Console.WriteLine($"Completed. Succeed:{bSucceed}");

Console.WriteLine("Step4...");
bSucceed = dM2C.SendPosNo(slaveId, 1);
Console.WriteLine($"Completed. Succeed:{bSucceed}");

Console.WriteLine("Step5...");
bSucceed = dM2C.SendPosNo(slaveId, 0);
Console.WriteLine($"Completed. Succeed:{bSucceed}");